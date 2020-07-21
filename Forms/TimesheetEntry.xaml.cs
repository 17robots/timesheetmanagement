using FivesBronxTimesheetManagement.Classes;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class TimesheetEntry : Window
	{
		private Connection myConnection;

		private Queries queries;

		private User user;

		private double hoursMax;

		private double hoursMin;

		private double hoursIncrement;

		private Functions functions;

		private List<Entry> itemsSourceEntries;

		private List<Entry> itemsSourceEntriesUnapproved;

		private List<Entry> itemsSourceEntriesApproved;

		private List<Entry> itemsSourceEntriesFiltered;

		private List<Section> sectionsAll;

		private DateTime weekEnding;

		private DateTime currentWeekEnding;

		private User_Defaults user_Defaults;

		private bool isDayfiltered = false;

		private bool approvedQueryHasRun = false;

		private DateTime filteredDate = DateTime.Now;

		public TimesheetEntry(FivesBronxTimesheetManagement.Classes.User User)
		{
			this.InitializeComponent();
			this.user = User;
			this.myConnection = new Connection();
			this.queries = new Queries();
			this.functions = new Functions();
			this.user_Defaults = new User_Defaults(this.user);
			this.itemsSourceEntriesApproved = new List<Entry>();
			this.LoadConstantsFromDb();
			this.RefreshDGHoursFromClassList();
			this.BindDataGrid(this.dgHours);
			this.BindDataGrid(this.dgHoursUnapproved);
			this.BindDataGrid(this.dgHoursApproved);
			this.RefreshDefaultSelections(this.user_Defaults);
			this.hoursMax = 24;
			this.hoursMin = 0.5;
			this.hoursIncrement = 0.5;
			this.txtHours.Text = this.hoursMin.ToString();
			object[] userID = new object[] { "Time Entry for Employee #: ", this.user.UserID, " - ", this.user.UserName };
			base.Title = string.Concat(userID);
			this.lblSectionDescription.Content = "";
			this.dtpDate.SelectedDate = new DateTime?(DateTime.Now);
			this.weekEnding = this.functions.WeekEnding(DateTime.Now);
			this.RefreshDateList(this.weekEnding);
		}

		private void BindDataGrid(DataGrid dataGrid)
		{
			List<DataGridTextColumn> dataGridTextColumns = new List<DataGridTextColumn>();
			SetterBaseCollection setters = (new System.Windows.Style(typeof(DataGridCell))).Setters;
			Setter setter = new Setter()
			{
				Property = Control.HorizontalContentAlignmentProperty,
				Value = System.Windows.HorizontalAlignment.Right
			};
			setters.Add(setter);
			DataGridTextColumn dataGridTextColumn = new DataGridTextColumn()
			{
				Header = "Date"
			};
			Binding binding = new Binding("date")
			{
				Converter = new FivesBronxTimesheetManagement.Classes.DateTimeConverter()
			};
			dataGridTextColumn.Binding = binding;
			dataGridTextColumns.Add(dataGridTextColumn);
			DataGridTextColumn dataGridTextColumn1 = new DataGridTextColumn()
			{
				Header = "Timesheet Code",
				Binding = new Binding("timesheet_code")
			};
			dataGridTextColumns.Add(dataGridTextColumn1);
			DataGridTextColumn dataGridTextColumn2 = new DataGridTextColumn()
			{
				Header = "Task Type",
				Binding = new Binding("task_type")
			};
			dataGridTextColumns.Add(dataGridTextColumn2);
			DataGridTextColumn dataGridTextColumn3 = new DataGridTextColumn()
			{
				Header = "Project Serial",
				Binding = new Binding("project_serial")
			};
			dataGridTextColumns.Add(dataGridTextColumn3);
			DataGridTextColumn dataGridTextColumn4 = new DataGridTextColumn()
			{
				Header = "Section",
				Binding = new Binding("number_section")
			};
			dataGridTextColumns.Add(dataGridTextColumn4);
			DataGridTextColumn dataGridTextColumn5 = new DataGridTextColumn()
			{
				Header = "Hours"
			};
			Binding binding1 = new Binding("hours")
			{
				Converter = new HoursWorkedConverter()
			};
			dataGridTextColumn5.Binding = binding1;
			dataGridTextColumn5.CellStyle = (System.Windows.Style)base.FindResource("alignRight");
			dataGridTextColumns.Add(dataGridTextColumn5);
			DataGridTextColumn dataGridTextColumn6 = new DataGridTextColumn()
			{
				Header = "Description",
				Binding = new Binding("description")
			};
			dataGridTextColumns.Add(dataGridTextColumn6);
			DataGridTextColumn dataGridTextColumn7 = new DataGridTextColumn()
			{
				Header = "Submitted Status",
				Binding = new Binding("submitted_status")
			};
			dataGridTextColumns.Add(dataGridTextColumn7);
			DataGridTextColumn dataGridTextColumn8 = new DataGridTextColumn()
			{
				Header = "Approval Status",
				Binding = new Binding("approval_status")
			};
			dataGridTextColumns.Add(dataGridTextColumn8);
			DataGridTextColumn dataGridTextColumn9 = new DataGridTextColumn()
			{
				Header = "Rejection Reason",
				Binding = new Binding("rejection_reason")
			};
			dataGridTextColumns.Add(dataGridTextColumn9);
			foreach (DataGridTextColumn dataGridTextColumn10 in dataGridTextColumns)
			{
				dataGridTextColumn10.IsReadOnly = true;
				dataGrid.Columns.Add(dataGridTextColumn10);
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.myConnection.Close();
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
			if (this.IsValidEntry())
			{
				code = ((TimesheetCode)this.cbxTimeCode.SelectedItem).Code;
				if (!(this.cbxTaskType.SelectedItem.ToString() == "(N/A)"))
				{
					str = this.cbxTaskType.SelectedItem.ToString();
					Project selectedItem = (Project)this.cbxJob.SelectedItem;
					numberSerial = selectedItem.Number_Serial;
					numberSAP = selectedItem.Number_SAP;
					Section section = (Section)this.cbxSection.SelectedItem;
					numberSection = section.Number_Section;
					nullable = new int?(section.Id);
					nullable1 = new int?(int.Parse(section.Number_ProjectNetwork));
					numberActivity = section.Number_Activity;
				}
				else
				{
					str = this.cbxTaskType.SelectedItem.ToString();
					numberSerial = "";
					numberSAP = "";
					numberSection = "";
					nullable = null;
					nullable1 = null;
					numberActivity = "";
				}
				DateTime? selectedDate = this.dtpDate.SelectedDate;
				DateTime value = selectedDate.Value;
				int month = value.Month;
				int year = value.Year;
				text = this.txtDescription.Text;
				int? nullable2 = null;
				int? nullable3 = nullable2;
				int userID = this.user.UserID;
				string userName = this.user.UserName;
				string str1 = this.functions.approvalStatus(ApprovalStatus.Submitted);
				nullable2 = null;
				selectedDate = null;
				Entry entry = new Entry(nullable3, userID, userName, nullable, numberSerial, numberSAP, numberSection, nullable1, numberActivity, value, month, year, num, text, code, str, str1, ApprovalStatus.Submitted, "", nullable2, "", DateTime.Now, DateTime.Now, selectedDate);
				this.queries.SaveTimeEntry(this.queries.t_Timesheet_Prelim, entry, ApprovalStatus.NotSubmitted, ApprovalStatus.NotSubmitted);
				this.RefreshDGHoursFromClassList();
				this.RefreshDateList(this.functions.WeekEnding(entry.date));
				if (this.isDayfiltered)
				{
					this.Filter_Filter(this.filteredDate);
				}
			}
		}

		private void btnWeekDecrement_Click(object sender, RoutedEventArgs e)
		{
			this.currentWeekEnding = this.currentWeekEnding.AddDays(-7);
			this.RefreshDateList(this.currentWeekEnding);
		}

		private void btnWeekIncrement_Click(object sender, RoutedEventArgs e)
		{
			this.currentWeekEnding = this.currentWeekEnding.AddDays(7);
			this.RefreshDateList(this.currentWeekEnding);
		}

		private void cbxJob_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Project project = new Project();
			if ((this.cbxTaskType.SelectedItem == null ? false : !(this.cbxTaskType.SelectedItem.ToString() == "(N/A)")))
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
			string str1 = "";
			Project selectedItem = (Project)this.cbxJob.SelectedItem;
			try
			{
				str = this.cbxSection.SelectedItem.ToString();
				if (this.functions.IntToBool(selectedItem.IsOpen))
				{
					str1 = selectedItem.Number_Network.ToString();
				}
				else if (this.functions.IntToBool(selectedItem.IsWarrantyOpen))
				{
					str1 = selectedItem.Number_WarrantyNetwork.ToString();
				}
				this.lblSectionDescription.Content = string.Concat(((Section)this.cbxSection.SelectedItem).Number_ProjectNetwork.ToString(), " - ", ((Section)this.cbxSection.SelectedItem).Number_Activity.ToString());
			}
			catch
			{
				this.lblSectionDescription.Content = "";
			}
		}

		private void cbxTaskType_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if ((this.cbxTaskType.SelectedItem == null ? true : this.cbxTaskType.SelectedItem.ToString() == "(N/A)"))
			{
				this.cbxJob.SelectedItem = null;
			}
			this.UpdateSections((Project)this.cbxJob.SelectedItem);
		}

		private void cbxTimeCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		}

		public void ClearSelection()
		{
			this.cbxSection.SelectedItem = null;
			this.cbxJob.SelectedItem = null;
			this.cbxTaskType.SelectedItem = null;
			this.cbxTimeCode.SelectedItem = null;
			this.txtDescription.Text = "";
			this.txtHours.Text = this.hoursMin.ToString();
			this.dtpDate.SelectedDate = null;
		}

		private void DeleteEntry()
		{
			if (MessageBox.Show("Are you sure you want to delete this Entry?", "Delete Entry?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
				try
				{
					Queries query = this.queries;
					string tTimesheetPrelim = this.queries.t_Timesheet_Prelim;
					int? entryId = ((Entry)this.dgHours.SelectedItems[0]).entry_id;
					query.DeleteTimeEntry(tTimesheetPrelim, entryId.Value);
					this.RefreshDGHoursFromClassList();
				}
				catch
				{
				}
			}
		}

		private void dgContextMenu_Copy_Click(object sender, RoutedEventArgs e)
		{
			if ((this.dgHours.SelectedItems == null ? false : MessageBox.Show("Are you sure you want to copy?", "Copy?", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
			{
				DateTime now = DateTime.Now;
				double hours = hoursMin;
				CustomDateTimePicker customDateTimePicker = new CustomDateTimePicker();
				bool? nullable = customDateTimePicker.ShowDialog();
				if ((!nullable.GetValueOrDefault() ? 0 : Convert.ToInt32(nullable.HasValue)) != 0)
				{
					now = customDateTimePicker.date;
					hours = customDateTimePicker.hours;
					List<Entry> entries = new List<Entry>();
					foreach (Entry selectedItem in this.dgHours.SelectedItems)
					{
						entries.Add(new Entry(selectedItem, now, hours));
					}
					this.queries.SaveTimeEntry(this.queries.t_Timesheet_Prelim, entries, ApprovalStatus.NotSubmitted, ApprovalStatus.NotSubmitted);
					this.RefreshDGHoursFromClassList();
					this.RefreshSummaryByDate(this.functions.WeekEnding(now));
					if (this.isDayfiltered)
					{
						this.Filter_Filter(this.filteredDate);
					}
				}
			}
		}

		private void dgContextMenu_Delete_Click(object sender, RoutedEventArgs e)
		{
			this.DeleteEntry();
		}

		private void dgContextMenu_Edit_Click(object sender, RoutedEventArgs e)
		{
			this.LaunchEditor();
		}

		private void dgHours_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (VisualTreeHelper.GetParent((DependencyObject)e.OriginalSource).GetType() == typeof(ContentPresenter))
			{
				this.LaunchEditor();
			}
		}

		private void dtpDate_GotFocus(object sender, RoutedEventArgs e)
		{
			this.dtpDate.Focus();
		}

		private void dtpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.ValidateDate(this.dtpDate.SelectedDate.Value, this.lblDateError);
			}
			catch
			{
				this.lblDateError.Content = "Date must be selected";
			}
		}

		private void Filter_Check(Label label)
		{
			if (!this.isDayfiltered)
			{
				this.Filter_Filter(label);
			}
			else
			{
				this.Filter_Unfilter();
			}
		}

		private void Filter_Filter(Label label)
		{
			bool flag = false;
			Label lblWeekDay1 = new Label();
			Label lblSundayDay1 = new Label();
			Label lblWeekDay1Total = new Label();
			if (label.Name.Contains("Day1"))
			{
				lblWeekDay1 = this.lblWeek_Day1;
				lblSundayDay1 = this.lblSunday_Day1;
				lblWeekDay1Total = this.lblWeek_Day1_Total;
			}
			else if (label.Name.Contains("Day2"))
			{
				lblWeekDay1 = this.lblWeek_Day2;
				lblSundayDay1 = this.lblMonday_Day2;
				lblWeekDay1Total = this.lblWeek_Day2_Total;
			}
			else if (label.Name.Contains("Day3"))
			{
				lblWeekDay1 = this.lblWeek_Day3;
				lblSundayDay1 = this.lblTuesday_Day3;
				lblWeekDay1Total = this.lblWeek_Day3_Total;
			}
			else if (label.Name.Contains("Day4"))
			{
				lblWeekDay1 = this.lblWeek_Day4;
				lblSundayDay1 = this.lblWednesday_Day4;
				lblWeekDay1Total = this.lblWeek_Day4_Total;
			}
			else if (label.Name.Contains("Day5"))
			{
				lblWeekDay1 = this.lblWeek_Day5;
				lblSundayDay1 = this.lblThursday_Day5;
				lblWeekDay1Total = this.lblWeek_Day5_Total;
			}
			else if (label.Name.Contains("Day6"))
			{
				lblWeekDay1 = this.lblWeek_Day6;
				lblSundayDay1 = this.lblFriday_Day6;
				lblWeekDay1Total = this.lblWeek_Day6_Total;
			}
			else if (!label.Name.Contains("Day7"))
			{
				flag = true;
			}
			else
			{
				lblWeekDay1 = this.lblWeek_Day7;
				lblSundayDay1 = this.lblSaturday_Day7;
				lblWeekDay1Total = this.lblWeek_Day7_Total;
			}
			if (!flag)
			{
				lblWeekDay1.Background = Brushes.Green;
				lblSundayDay1.Background = Brushes.Green;
				lblWeekDay1Total.Background = Brushes.Green;
				DateTime dateTime = DateTime.Parse(lblWeekDay1.Content.ToString());
				lblWeekDay1.ToolTip = string.Concat("Filtered on ", dateTime.ToShortDateString());
				dateTime = DateTime.Parse(lblWeekDay1.Content.ToString());
				lblSundayDay1.ToolTip = string.Concat("Filtered on ", dateTime.ToShortDateString());
				dateTime = DateTime.Parse(lblWeekDay1.Content.ToString());
				lblWeekDay1Total.ToolTip = string.Concat("Filtered on ", dateTime.ToShortDateString());
				this.isDayfiltered = true;
				this.filteredDate = DateTime.Parse(lblWeekDay1.Content.ToString());
				this.Filter_Filter(this.filteredDate);
			}
		}

		private void Filter_Filter(DateTime date)
		{
			this.itemsSourceEntriesFiltered = (
				from x in this.itemsSourceEntries
				where x.date.ToShortDateString() == date.ToShortDateString()
				select x).ToList<Entry>();
			this.dgHours.ItemsSource = this.itemsSourceEntriesFiltered;
		}

		private void Filter_Unfilter()
		{
			//FrameworkElement child = null;
			foreach (FrameworkElement child in this.SummaryByDate_Date.Children)
			{
				if (child is Label)
				{
					(child as Label).Background = Brushes.Transparent;
					(child as Label).ToolTip = null;
				}
			}
			foreach (FrameworkElement transparent in this.SummaryByDate_DayOfWeek.Children)
			{
				if (transparent is Label)
				{
					(transparent as Label).Background = Brushes.Transparent;
					(transparent as Label).ToolTip = null;
				}
			}
			foreach (FrameworkElement frameworkElement in this.SummaryByDate_Amount.Children)
			{
				if (frameworkElement is Label)
				{
					(frameworkElement as Label).Background = Brushes.Transparent;
					(frameworkElement as Label).ToolTip = null;
				}
			}
			this.isDayfiltered = false;
			this.filteredDate = DateTime.Now;
			this.dgHours.ItemsSource = 
				from x in this.itemsSourceEntries
				orderby x.date
				select x;
		}

		private bool IsValidDate(DateTime date)
		{
			bool flag;
			try
			{
				flag = this.queries.Period_Open(date.Month, date.Year);
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		private bool IsValidEntry()
		{
			bool flag;
			if (this.cbxTimeCode.SelectedItem == null)
			{
				MessageBox.Show("You must select a timecode");
				flag = false;
			}
			else if (this.cbxTaskType.SelectedItem != null)
			{
				if (!(this.cbxTaskType.SelectedItem.ToString() == "(N/A)"))
				{
					if (this.cbxJob.SelectedItem == null)
					{
						MessageBox.Show("You must select a project");
						flag = false;
						return flag;
					}
					else if (this.cbxSection.SelectedItem == null)
					{
						MessageBox.Show("You must select a section");
						flag = false;
						return flag;
					}
				}
				if (!this.dtpDate.SelectedDate.HasValue)
				{
					MessageBox.Show("You must select a date");
					flag = false;
				}
				else if (!this.IsValidDate(this.dtpDate.SelectedDate.Value))
				{
					MessageBox.Show("The Date you have selected is in a closed period");
					flag = false;
				}
				else if (!string.IsNullOrEmpty(this.txtDescription.Text))
				{
					flag = true;
				}
				else
				{
					MessageBox.Show("You must enter a description");
					flag = false;
				}
			}
			else
			{
				MessageBox.Show("You must select a task type");
				flag = false;
			}
			return flag;
		}

		private void LaunchEditor()
		{
			try
			{
				if (this.dgHours.SelectedItem != null)
				{
					Entry item = this.dgHours.SelectedItems[0] as Entry;
					(new TimesheetEntry_Edit(item, this)).Show();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
			}
		}

		private void LoadConstantsFromDb()
		{
			this.cbxJob.DisplayMemberPath = "Serial_Customer_Machine";
			this.cbxJob.SelectedValuePath = "Serial_Customer_Machine";
			this.cbxTimeCode.DisplayMemberPath = "Code_Description";
			this.cbxTimeCode.SelectedValuePath = "Code_Description";
			this.cbxSection.DisplayMemberPath = "SectionNumber_SectionDescription";
			this.cbxSection.SelectedValuePath = "SectionNumber_SectionDescription";
			foreach (TimesheetCode timesheetCode in this.queries.TimesheetCodeAll())
			{
				this.cbxTimeCode.Items.Add(timesheetCode);
			}
			foreach (string str in this.queries.TaskTypes())
			{
				this.cbxTaskType.Items.Add(str);
			}
			foreach (Project project in this.queries.ProjectAll())
			{
				if ((this.functions.IntToBool(project.IsOpen) ? true : this.functions.IntToBool(project.IsWarrantyOpen)))
				{
					this.cbxJob.Items.Add(project);
				}
			}
			this.sectionsAll = this.queries.Sections();
			this.myConnection.Close();
		}

		private void menuEditDeleteEntry_Click(object sender, RoutedEventArgs e)
		{
			this.DeleteEntry();
		}

		private void menuEditEditEntry_Click(object sender, RoutedEventArgs e)
		{
			this.LaunchEditor();
		}

		private void menuEditSubmitForApproval_Click(object sender, RoutedEventArgs e)
		{
			this.SubmitForApproval();
		}

		private void menuFileChangePassword_Click(object sender, RoutedEventArgs e)
		{
			(new UserChangePassword(this.user)).Show();
		}

		private void menuFileClose_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		private void menuFileExport_Click(object sender, RoutedEventArgs e)
		{
			ExportToExcel<Entry, List<Entry>> exportToExcel = new ExportToExcel<Entry, List<Entry>>()
			{
				dataToPrint = this.queries.Entries(this.queries.t_Timesheet_Prelim, this.queries.User_AllEntries(this.user.UserID, this.queries.t_Timesheet_Prelim))
			};
			exportToExcel.GenerateReport();
		}

		private void menuFilePrint_Click(object sender, RoutedEventArgs e)
		{
			PrintDialog printDialog = new PrintDialog();
			bool? nullable = printDialog.ShowDialog();
			if ((!nullable.GetValueOrDefault() ? 0 : Convert.ToInt32(nullable.HasValue)) != 0)
			{
				printDialog.PrintVisual(this.dgHours, "Print Grid");
			}
		}

		private void menuOptionsUserPreferences_Click(object sender, RoutedEventArgs e)
		{
			bool? nullable = (new UserDefaults(this.user)).ShowDialog();
			if ((!nullable.GetValueOrDefault() ? 0 : Convert.ToInt32(nullable.HasValue)) != 0)
			{
				this.user_Defaults = new User_Defaults(this.user);
				this.ClearSelection();
				this.RefreshDefaultSelections(this.user_Defaults);
			}
		}

		private void menuViewAbout_Click(object sender, RoutedEventArgs e)
		{
			(new About()).Show();
		}

		private void menuViewProjectInformation_Click(object sender, RoutedEventArgs e)
		{
			(new ProjectInfoScreen()).Show();
		}

		private void menuViewReports_Click(object sender, RoutedEventArgs e)
		{
			this.RunReports();
		}

		private void menuViewUserRights_Click(object sender, RoutedEventArgs e)
		{
			(new UserRights(this.user)).Show();
		}

		public void RefreshDateList(DateTime WeekEnding)
		{
			this.currentWeekEnding = this.functions.WeekEnding(WeekEnding);
			this.lblWeek_Day7.Content = this.currentWeekEnding.ToShortDateString();
			Label lblWeekDay6 = this.lblWeek_Day6;
			DateTime dateTime = this.currentWeekEnding.AddDays(-1);
			lblWeekDay6.Content = dateTime.ToShortDateString();
			Label lblWeekDay5 = this.lblWeek_Day5;
			dateTime = this.currentWeekEnding.AddDays(-2);
			lblWeekDay5.Content = dateTime.ToShortDateString();
			Label lblWeekDay4 = this.lblWeek_Day4;
			dateTime = this.currentWeekEnding.AddDays(-3);
			lblWeekDay4.Content = dateTime.ToShortDateString();
			Label lblWeekDay3 = this.lblWeek_Day3;
			dateTime = this.currentWeekEnding.AddDays(-4);
			lblWeekDay3.Content = dateTime.ToShortDateString();
			Label lblWeekDay2 = this.lblWeek_Day2;
			dateTime = this.currentWeekEnding.AddDays(-5);
			lblWeekDay2.Content = dateTime.ToShortDateString();
			Label lblWeekDay1 = this.lblWeek_Day1;
			dateTime = this.currentWeekEnding.AddDays(-6);
			lblWeekDay1.Content = dateTime.ToShortDateString();
			this.RefreshSummaryByDate(this.currentWeekEnding);
		}

		public void RefreshDefaultSelections(User_Defaults defaults)
		{
			if (defaults.TimesheetCode != null)
			{
				this.cbxTimeCode.SelectedValue = defaults.TimesheetCode.Code_Description;
			}
			if (!string.IsNullOrEmpty(defaults.TaskType))
			{
				this.cbxTaskType.SelectedItem = defaults.TaskType;
			}
			if (defaults.Project != null)
			{
				this.cbxJob.SelectedValue = defaults.Project.Serial_Customer_Machine;
			}
		}

		public void RefreshDGHoursFromClassList()
		{
			WaitCursor waitCursor = new WaitCursor();
			try
			{
				this.dgHours.ItemsSource = null;
				try
				{
					this.itemsSourceEntries = this.queries.Entries(this.queries.t_Timesheet_Prelim, this.queries.User_AllEntries(this.user.UserID, this.queries.t_Timesheet_Prelim));
					this.dgHours.ItemsSource = 
						from E in this.itemsSourceEntries
						orderby E.date
						select E;
					this.itemsSourceEntriesUnapproved = this.queries.Entries(this.queries.t_Timesheet_Limbo, this.queries.User_AllEntries(this.user.UserID, this.queries.t_Timesheet_Limbo));
					this.dgHoursUnapproved.ItemsSource = 
						from E in this.itemsSourceEntriesUnapproved
						orderby E.date
						select E;
				}
				catch (Exception exception)
				{
					MessageBox.Show(exception.ToString());
				}
			}
			finally
			{
				if (waitCursor != null)
				{
					((IDisposable)waitCursor).Dispose();
				}
			}
		}

		public void RefreshSummaryByDate(DateTime weekEnding)
		{
			double num = (
				from E in this.itemsSourceEntries
				where E.date.Date == weekEnding.AddDays(-6).Date
				select E).Sum<Entry>((Entry E) => E.hours);
			double num1 = (
				from E in this.itemsSourceEntries
				where E.date.Date == weekEnding.AddDays(-5).Date
				select E).Sum<Entry>((Entry E) => E.hours);
			double num2 = (
				from E in this.itemsSourceEntries
				where E.date.Date == weekEnding.AddDays(-4).Date
				select E).Sum<Entry>((Entry E) => E.hours);
			double num3 = (
				from E in this.itemsSourceEntries
				where E.date.Date == weekEnding.AddDays(-3).Date
				select E).Sum<Entry>((Entry E) => E.hours);
			double num4 = (
				from E in this.itemsSourceEntries
				where E.date.Date == weekEnding.AddDays(-2).Date
				select E).Sum<Entry>((Entry E) => E.hours);
			double num5 = (
				from E in this.itemsSourceEntries
				where E.date.Date == weekEnding.AddDays(-1).Date
				select E).Sum<Entry>((Entry E) => E.hours);
			double num6 = (
				from E in this.itemsSourceEntries
				where E.date.Date == weekEnding.Date
				select E).Sum<Entry>((Entry E) => E.hours);
			List<double> nums = new List<double>()
			{
				num,
				num1,
				num2,
				num3,
				num4,
				num5,
				num6
			};
			List<double> nums1 = nums;
			double num7 = nums1.Sum();
			List<Label> labels = new List<Label>()
			{
				this.lblWeek_Day1_Total,
				this.lblWeek_Day2_Total,
				this.lblWeek_Day3_Total,
				this.lblWeek_Day4_Total,
				this.lblWeek_Day5_Total,
				this.lblWeek_Day6_Total,
				this.lblWeek_Day7_Total
			};
			List<Label> normal = labels;
			string str = "There are only 24 hours in a day!  Please Correct!";
			for (int i = 0; i < nums1.Count; i++)
			{
				string str1 = (nums1[i] != 0 ? nums1[i].ToString() : "-");
				if (nums1[i] <= 24)
				{
					normal[i].Content = str1;
					normal[i].FontWeight = FontWeights.Normal;
					normal[i].ToolTip = null;
					normal[i].Background = null;
				}
				else
				{
					normal[i].Content = str1;
					normal[i].FontWeight = FontWeights.ExtraBold;
					normal[i].ToolTip = str;
					normal[i].Background = Brushes.Red;
				}
			}
			this.lblWeek_Total.Content = num7.ToString();
		}

		private void RunReports()
		{
			(new Report(this.user)).Show();
		}

		private void SubmitForApproval()
		{
			(new TimesheetApproval_Submission(this.user, this)).Show();
		}

		private void SummaryByDate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.Filter_Check(sender as Label);
		}

		private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if ((((sender as TabControl).SelectedItem as TabItem).Header.ToString() != "Approved" ? false : !this.approvedQueryHasRun))
			{
				if (MessageBox.Show("Display All Approved Time Entries?  This may take a while.", "Display Approved?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
				{
					this.itemsSourceEntriesApproved = this.queries.Entries(this.queries.t_Timesheet_Final, this.queries.User_AllEntries(this.user.UserID, this.queries.t_Timesheet_Final));
					this.dgHoursApproved.ItemsSource = 
						from E in this.itemsSourceEntriesApproved
						orderby E.date
						select E;
					this.approvedQueryHasRun = true;
				}
			}
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

		private void TxtHoursSelectAll(object sender, RoutedEventArgs e)
		{
			this.txtHours.SelectAll();
		}

		private void UpdateSections(Project project)
		{
			// Section section = null;
			this.cbxSection.Items.Clear();
			this.lblSectionDescription.Content = "";
			if ((project == null || this.cbxTaskType.SelectedItem == null || project.Number_Serial == "" ? false : !(this.cbxTaskType.SelectedItem.ToString() == "")))
			{
				string str = this.cbxTaskType.SelectedItem.ToString();
				if (!this.functions.IntToBool(project.IsOpen))
				{
					foreach (Section section in 
						from n in this.sectionsAll
						where n.Number_ProjectNetwork == project.Number_Network.ToString()
						select n into t
						where t.TaskType == str
						select t)
					{
						this.cbxSection.Items.Add(section);
					}
				}
				else
				{
					foreach (Section section1 in 
						from n in this.sectionsAll
						where n.Number_ProjectNetwork == project.Number_Network.ToString()
						select n into t
						where t.TaskType == str
						select t)
					{
						this.cbxSection.Items.Add(section1);
					}
				}
			}
		}

		public void ValidateDate(DateTime date, Label label)
		{
			if (!this.IsValidDate(date))
			{
				label.Content = "Period closed.";
			}
			else
			{
				label.Content = "Period open.";
			}
		}
	}
}