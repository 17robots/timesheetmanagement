using FivesBronxTimesheetManagement.Classes;
using System;
using System.Windows;
using System.Windows.Controls;
using MessageBox = System.Windows.Forms.MessageBox;
using TextBox = System.Windows.Controls.TextBox;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class TimesheetEntry_Duplicate : Window
	{
		private Connection myConnection;

		private Queries2 queries = new Queries2();

		private Functions functions;

		private TimesheetEntry tsEntry;

		public Entry entry;

		private double hoursMax = 24;

		private double hoursMin = 0.5;

		private double hoursIncrement = 0.5;

		public TimesheetEntry_Duplicate(Entry entry, TimesheetEntry tsEntry)
		{
			this.entry = entry;
			this.tsEntry = tsEntry;
			InitializeComponent();
			queries = new Queries2();
			myConnection = new Connection();
			functions = new Functions();
			LoadConstantsFromDb();
			LoadSelectedEntry();
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void btnHoursDecrement_Click(object sender, RoutedEventArgs e)
		{
			double num = double.Parse(txtHours.Text);
			num -= hoursIncrement;
			TextBox str = txtHours;
			double num1 = functions.RoundedValueInRange(num, hoursMin, hoursMax);
			str.Text = num1.ToString();
		}

		private void btnHoursIncrement_Click(object sender, RoutedEventArgs e)
		{
			double num = double.Parse(txtHours.Text);
			num += hoursIncrement;
			TextBox str = txtHours;
			double num1 = functions.RoundedValueInRange(num, hoursMin, hoursMax);
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
			double num = double.Parse(txtHours.Text);
			string text;
			string code;
			string str;
			if (cbxTimeCode.SelectedItem != null)
			{
				code = ((TimesheetCode)cbxTimeCode.SelectedItem).Code;
				if (cbxTaskType.SelectedItem != null)
				{
					if (!(cbxTaskType.SelectedValue.ToString() == "(N/A)"))
					{
						str = cbxTaskType.SelectedValue.ToString();
						if (cbxJob.SelectedValue != null)
						{
							Project selectedItem = (Project)cbxJob.SelectedItem;
							numberSerial = selectedItem.Number_Serial;
							numberSAP = selectedItem.Number_SAP;
							if (cbxSection.SelectedValue == null)
							{
								MessageBox.Show("You must select a section");
								return;
							}
							Section section = cbxSection.SelectedItem as Section;
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
						str = cbxTaskType.SelectedValue.ToString();
						numberSerial = "";
						numberSAP = "";
						numberSection = "";
						nullable = null;
						nullable1 = null;
						numberActivity = "";
					}
					if (dtpDate.SelectedDate.HasValue)
					{
						DateTime value = dtpDate.SelectedDate.Value;
						int month = value.Month;
						int year = value.Year;
						if(!queries.Period_Open(month, year))
						{
							MessageBox.Show("Date Must Be Within The Period");
							return;
						}

						if (!string.IsNullOrEmpty(txtDescription.Text))
						{
							text = txtDescription.Text;
							entry.section_id = nullable;
							entry.project_serial = numberSerial;
							entry.project_sap = numberSAP;
							entry.number_section = numberSection;
							entry.number_network = nullable1;
							entry.number_activity = numberActivity;
							entry.date = value;
							entry.period = month;
							entry.year = year;
							entry.hours = num;
							entry.description = text;
							entry.timesheet_code = code;
							entry.task_type = str;
							DialogResult = new bool?(true);
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
			if (cbxTaskType.SelectedValue == null ? false : !(cbxTaskType.SelectedValue.ToString() == "(N/A)"))
			{
				project = (Project)cbxJob.SelectedItem;
			}
			else
			{
				cbxJob.SelectedItem = null;
			}
			UpdateSections(project);
		}

		private void cbxSection_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string str;
			Project selectedItem = (Project)cbxJob.SelectedItem;
			try
			{
				if (functions.IntToBool(selectedItem.IsOpen))
				{
					str = selectedItem.Number_Network.ToString();
				}
				else if (functions.IntToBool(selectedItem.IsWarrantyOpen))
				{
					str = selectedItem.Number_WarrantyNetwork.ToString();
				}
				lblSectionDescription.Content = string.Concat((cbxSection.SelectedItem as Section).Number_ProjectNetwork, " - ", (cbxSection.SelectedItem as Section).Number_Activity);
			}
			catch
			{
				lblSectionDescription.Content = "";
			}
		}

		private void cbxTaskType_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			cbxTaskType.SelectedItem.ToString();
			if (cbxTaskType.SelectedItem == null ? true : cbxTaskType.SelectedItem.ToString() == "(N/A)")
			{
				cbxJob.SelectedItem = null;
			}
			UpdateSections((Project)cbxJob.SelectedItem);
		}

		private void cbxTimeCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		}

		private void dtpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				tsEntry.ValidateDate(dtpDate.SelectedDate.Value, lblDateError);
			}
			catch
			{
				lblDateError.Content = "Date must be selected";
			}
		}

		private void LoadConstantsFromDb()
		{
			cbxJob.DisplayMemberPath = "Serial_Customer_Machine";
			cbxJob.SelectedValuePath = "Serial_Customer_Machine";
			cbxTaskType.DisplayMemberPath = "Id";
			cbxTaskType.SelectedValuePath = "Id";
			cbxTimeCode.DisplayMemberPath = "Code_Description";
			cbxTimeCode.SelectedValuePath = "Code_Description";
			cbxSection.DisplayMemberPath = "SectionNumber_SectionDescription";
			cbxSection.SelectedValuePath = "Number_Section";
			foreach (TimesheetCode timesheetCode in queries.TimesheetCodeAll())
			{
				cbxTimeCode.Items.Add(timesheetCode);
			}
			foreach (TaskType taskType in queries.TaskTypesAll())
			{
				cbxTaskType.Items.Add(taskType);
			}
			foreach (Project project in queries.ProjectAll())
			{
				if (functions.IntToBool(project.IsOpen) ? true : functions.IntToBool(project.IsWarrantyOpen))
				{
					cbxJob.Items.Add(project);
				}
			}
			myConnection.Close();
		}

		private void LoadSelectedEntry()
		{
			cbxTimeCode.SelectedValue = new TimesheetCode(entry.timesheet_code).Code_Description;
			cbxTaskType.SelectedValue = (new TaskType(entry.task_type)).Id;
			if (!string.IsNullOrEmpty(entry.project_serial))
			{
				cbxJob.SelectedValue = queries.Project(entry.project_serial).Serial_Customer_Machine;
			}
			cbxSection.SelectedValue = entry.number_section;
			dtpDate.SelectedDate = new DateTime?(entry.date);
			txtHours.Text = entry.hours.ToString();
			txtDescription.Text = entry.description;
		}

		private void txtHours_LostFocus(object sender, RoutedEventArgs e)
		{
			if (functions.IsNumeric(txtHours.Text))
			{
				TextBox str = txtHours;
				double num = functions.RoundedValueInRange(double.Parse(txtHours.Text), hoursMin, hoursMax);
				str.Text = num.ToString();
			}
			else
			{
				txtHours.Text = hoursMin.ToString();
			}
		}

		private void UpdateSections(Project project)
		{
			cbxSection.Items.Clear();
			lblSectionDescription.Content = "";
			if (project == null || cbxTaskType.SelectedItem == null || project.Number_Serial == "" ? false : !(cbxTaskType.SelectedItem.ToString() == ""))
			{
				TaskType selectedItem = cbxTaskType.SelectedItem as TaskType;
				if (!functions.IntToBool(project.IsOpen))
				{
					foreach (Section section in queries.Sections(project.Number_WarrantyNetwork, selectedItem.Id))
					{
						cbxSection.Items.Add(section);
					}
				}
				else
				{
					foreach (Section section1 in queries.Sections(project.Number_Network, selectedItem.Id))
					{
						cbxSection.Items.Add(section1);
					}
				}
			}
		}
	}
}