using FivesBronxTimesheetManagement.Classes;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Markup;
using MessageBox = System.Windows.Forms.MessageBox;
using TextBox = System.Windows.Controls.TextBox;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class TimesheetEntry_Edit : Window
	{
		private Connection myConnection;

		private Queries queries;

		private Functions functions;

		private TimesheetEntry tsEntry;

		private Entry entry;

		private Entry originalEntry;

		private int entryId;

		private double hoursMax = 24;

		private double hoursMin = 0.5;

		private double hoursIncrement = 0.5;

		public TimesheetEntry_Edit(Entry entry, TimesheetEntry tsEntry)
		{
			this.entryId = entry.entry_id.Value;
			this.entry = entry;
			this.originalEntry = entry;
			this.tsEntry = tsEntry;
			this.InitializeComponent();
			this.queries = new Queries();
			this.myConnection = new Connection();
			this.functions = new Functions();
			this.LoadConstantsFromDb();
			this.LoadSelectedEntry();
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		private void btnHoursDecrement_Click(object sender, RoutedEventArgs e)
		{
			double num = double.Parse(this.txtHours.Text);
			num -= this.hoursIncrement;
			TextBox str = this.txtHours;
			double num1 = this.functions.RoundedValueInRange(num, this.hoursMin, this.hoursMax);
			str.Text = num1.ToString();
		}

		private void btnHoursIncrement_Click(object sender, RoutedEventArgs e)
		{
			double num = double.Parse(this.txtHours.Text);
			num += this.hoursIncrement;
			TextBox str = this.txtHours;
			double num1 = this.functions.RoundedValueInRange(num, this.hoursMin, this.hoursMax);
			str.Text = num1.ToString();
		}

		private void btnSubmit_Click(object sender, RoutedEventArgs e)
		{
			int? nullable;
			string numberSerial;
			string numberSAP;
			string numberSection;
			int? nullable1;
			string numberActivity;
			double num = double.Parse(this.txtHours.Text);
			string text = "";
			string code = "";
			string str = "";
			if (this.cbxTimeCode.SelectedItem != null)
			{
				code = ((TimesheetCode)this.cbxTimeCode.SelectedItem).Code;
				if (this.cbxTaskType.SelectedItem != null)
				{
					if (!(this.cbxTaskType.SelectedValue.ToString() == "(N/A)"))
					{
						str = this.cbxTaskType.SelectedValue.ToString();
						if (this.cbxJob.SelectedValue != null)
						{
							Project selectedItem = (Project)this.cbxJob.SelectedItem;
							numberSerial = selectedItem.Number_Serial;
							numberSAP = selectedItem.Number_SAP;
							if (this.cbxSection.SelectedValue == null)
							{
								MessageBox.Show("You must select a section");
								return;
							}
							Section section = this.cbxSection.SelectedItem as Section;
							numberSection = section.Number_Section;
							nullable = new int?(section.Id);
							nullable1 = new int?(int.Parse(section.Number_ProjectNetwork));
							numberActivity = section.Number_Activity;
						}
						else
						{
							MessageBox.Show("You must select a project");
							return;
						}
					}
					else
					{
						str = this.cbxTaskType.SelectedValue.ToString();
						numberSerial = "";
						numberSAP = "";
						numberSection = "";
						nullable = null;
						nullable1 = null;
						numberActivity = "";
					}
					if (this.dtpDate.SelectedDate.HasValue)
					{
						DateTime value = this.dtpDate.SelectedDate.Value;
						int month = value.Month;
						int year = value.Year;
						if(!queries.Period_Open(month, year))
						{
							MessageBox.Show("Date Must Be Within The Period");
							return;
						}

						if (!string.IsNullOrEmpty(this.txtDescription.Text))
						{
							text = this.txtDescription.Text;
							this.entry.section_id = nullable;
							this.entry.project_serial = numberSerial;
							this.entry.project_sap = numberSAP;
							this.entry.number_section = numberSection;
							this.entry.number_network = nullable1;
							this.entry.number_activity = numberActivity;
							this.entry.date = value;
							this.entry.period = month;
							this.entry.year = year;
							this.entry.hours = num;
							this.entry.description = text;
							this.entry.timesheet_code = code;
							this.entry.task_type = str;
							this.queries.UpdateTimeEntry(this.entry);
							this.tsEntry.RefreshDGHoursFromClassList();
							this.tsEntry.RefreshSummaryByDate(this.functions.WeekEnding(this.entry.date));
							base.Close();
						}
						else
						{
							MessageBox.Show("You must enter a description");
						}
					}
					else
					{
						MessageBox.Show("You must select a date");
					}
				}
				else
				{
					MessageBox.Show("You must select a task type");
				}
			}
			else
			{
				MessageBox.Show("You must select a timecode");
			}
		}

		private void cbxJob_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Project project = new Project();
			if ((this.cbxTaskType.SelectedValue == null ? false : !(this.cbxTaskType.SelectedValue.ToString() == "(N/A)")))
			{
				project = (Project)this.cbxJob.SelectedItem;
			}
			else
			{
				this.cbxJob.SelectedItem = null;
			}
			this.UpdateSections(project);
		}

		private void cbxSection_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string str = "";
			Project selectedItem = (Project)this.cbxJob.SelectedItem;
			try
			{
				if (this.functions.IntToBool(selectedItem.IsOpen))
				{
					str = selectedItem.Number_Network.ToString();
				}
				else if (this.functions.IntToBool(selectedItem.IsWarrantyOpen))
				{
					str = selectedItem.Number_WarrantyNetwork.ToString();
				}
				this.lblSectionDescription.Content = string.Concat((this.cbxSection.SelectedItem as Section).Number_ProjectNetwork, " - ", (this.cbxSection.SelectedItem as Section).Number_Activity);
			}
			catch
			{
				this.lblSectionDescription.Content = "";
			}
		}

		private void cbxTaskType_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.cbxTaskType.SelectedItem.ToString();
			if ((this.cbxTaskType.SelectedItem == null ? true : this.cbxTaskType.SelectedItem.ToString() == "(N/A)"))
			{
				this.cbxJob.SelectedItem = null;
			}
			this.UpdateSections((Project)this.cbxJob.SelectedItem);
		}

		private void cbxTimeCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		}

		private void dtpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.tsEntry.ValidateDate(this.dtpDate.SelectedDate.Value, this.lblDateError);
			}
			catch
			{
				this.lblDateError.Content = "Date must be selected";
			}
		}

		private void LoadConstantsFromDb()
		{
			this.cbxJob.DisplayMemberPath = "Serial_Customer_Machine";
			this.cbxJob.SelectedValuePath = "Serial_Customer_Machine";
			this.cbxTaskType.DisplayMemberPath = "Id";
			this.cbxTaskType.SelectedValuePath = "Id";
			this.cbxTimeCode.DisplayMemberPath = "Code_Description";
			this.cbxTimeCode.SelectedValuePath = "Code_Description";
			this.cbxSection.DisplayMemberPath = "SectionNumber_SectionDescription";
			this.cbxSection.SelectedValuePath = "Number_Section";
			foreach (TimesheetCode timesheetCode in this.queries.TimesheetCodeAll())
			{
				this.cbxTimeCode.Items.Add(timesheetCode);
			}
			foreach (TaskType taskType in this.queries.TaskTypesAll())
			{
				this.cbxTaskType.Items.Add(taskType);
			}
			foreach (Project project in this.queries.ProjectAll())
			{
				if ((this.functions.IntToBool(project.IsOpen) ? true : this.functions.IntToBool(project.IsWarrantyOpen)))
				{
					this.cbxJob.Items.Add(project);
				}
			}
			this.myConnection.Close();
		}

		private void LoadSelectedEntry()
		{
			this.cbxTimeCode.SelectedValue = (new TimesheetCode(this.entry.timesheet_code)).Code_Description;
			this.cbxTaskType.SelectedValue = (new TaskType(this.entry.task_type)).Id;
			if (!string.IsNullOrEmpty(this.entry.project_serial))
			{
				this.cbxJob.SelectedValue = (new Project(this.entry.project_serial)).Serial_Customer_Machine;
			}
			this.cbxSection.SelectedValue = this.entry.number_section;
			this.dtpDate.SelectedDate = new DateTime?(this.entry.date);
			this.txtHours.Text = this.entry.hours.ToString();
			this.txtDescription.Text = this.entry.description;
		}

		private void txtHours_LostFocus(object sender, RoutedEventArgs e)
		{
			if (this.functions.IsNumeric(this.txtHours.Text))
			{
				TextBox str = this.txtHours;
				double num = this.functions.RoundedValueInRange(double.Parse(this.txtHours.Text), this.hoursMin, this.hoursMax);
				str.Text = num.ToString();
			}
			else
			{
				this.txtHours.Text = this.hoursMin.ToString();
			}
		}

		private void UpdateSections(Project project)
		{
			// Section section = null;
			this.cbxSection.Items.Clear();
			this.lblSectionDescription.Content = "";
			if ((project == null || this.cbxTaskType.SelectedItem == null || project.Number_Serial == "" ? false : !(this.cbxTaskType.SelectedItem.ToString() == "")))
			{
				TaskType selectedItem = this.cbxTaskType.SelectedItem as TaskType;
				if (!this.functions.IntToBool(project.IsOpen))
				{
					foreach (Section section in this.queries.Sections(project.Number_WarrantyNetwork, selectedItem.Id))
					{
						this.cbxSection.Items.Add(section);
					}
				}
				else
				{
					foreach (Section section1 in this.queries.Sections(project.Number_Network, selectedItem.Id))
					{
						this.cbxSection.Items.Add(section1);
					}
				}
			}
		}
	}
}