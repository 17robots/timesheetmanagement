using FivesBronxTimesheetManagement.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Binding = System.Windows.Data.Binding;
using Label = System.Windows.Controls.Label;
using MessageBox = System.Windows.Forms.MessageBox;
using PrintDialog = System.Windows.Controls.PrintDialog;
using TabControl = System.Windows.Controls.TabControl;
using TextBox = System.Windows.Controls.TextBox;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class TimesheetEntry : Window
	{
		private Connection myConnection;

		private Queries2 queries = new Queries2();

		private User user;

		private double hoursMax;

		private double hoursMin;

		private double hoursIncrement;

		private Functions functions;

		private List<Entry> itemsSourceEntries;

		private List<Entry> itemsSourceEntriesUnapproved;

		private List<Entry> itemsSourceEntriesApproved;

		private List<Entry> itemSourceEntriesPrevWeek;

		private List<Entry> itemsSourceEntriesFiltered;

		private List<Section> sectionsAll;

		private DateTime weekEnding;

		private DateTime currentWeekEnding;

		private User_Defaults user_Defaults;

		private bool isDayfiltered = false;

		private bool approvedQueryHasRun = false;

		private bool preWeekQueryHasRun = false;

		private DateTime filteredDate = DateTime.Now;

		public TimesheetEntry(FivesBronxTimesheetManagement.Classes.User User)
		{
			InitializeComponent();
			user = User;
			myConnection = new Connection();
			queries = new Queries2();
			functions = new Functions();
			user_Defaults = new User_Defaults(user);
			itemsSourceEntriesApproved = new List<Entry>();
			LoadConstantsFromDb();
			RefreshDGHoursFromClassList();
			BindDataGrid(dgHours);
			BindDataGrid(dgHoursUnapproved);
			BindDataGrid(dgHoursApproved);
			BindDataGrid(dgHoursPrevWeek);
			RefreshDefaultSelections(user_Defaults);
			hoursMax = 24;
			hoursMin = 0.5;
			hoursIncrement = 0.5;
			txtHours.Text = hoursMin.ToString();
			object[] userID = new object[] { "Time Entry for Employee #: ", user.UserID, " - ", user.UserName };
			base.Title = string.Concat(userID);
			lblSectionDescription.Content = "";
			dtpDate.SelectedDate = new DateTime?(DateTime.Now);
			weekEnding = functions.WeekEnding(DateTime.Now);
			RefreshDateList(weekEnding);
		}

		private void BindDataGrid(System.Windows.Controls.DataGrid dataGrid)
		{
			List<DataGridTextColumn> dataGridTextColumns = new List<DataGridTextColumn>();
			SetterBaseCollection setters = (new System.Windows.Style(typeof(System.Windows.Controls.DataGridCell))).Setters;
			Setter setter = new Setter()
			{
				Property = System.Windows.Controls.Control.HorizontalContentAlignmentProperty,
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
			myConnection.Close();
			base.Close();
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
			string text = "";
			string code = "";
			string str = "";
			if (IsValidEntry())
			{
				code = ((TimesheetCode)cbxTimeCode.SelectedItem).Code;
				if (!(cbxTaskType.SelectedItem.ToString() == "(N/A)"))
				{
					str = cbxTaskType.SelectedItem.ToString();
					Project selectedItem = (Project)cbxJob.SelectedItem;
					numberSerial = selectedItem.Number_Serial;
					numberSAP = selectedItem.Number_SAP;
					Section section = (Section)cbxSection.SelectedItem;
					numberSection = section.Number_Section;
					nullable = new int?(section.Id);
					nullable1 = new int?(int.Parse(section.Number_ProjectNetwork));
					numberActivity = section.Number_Activity;
				}
				else
				{
					str = cbxTaskType.SelectedItem.ToString();
					numberSerial = "";
					numberSAP = "";
					numberSection = "";
					nullable = null;
					nullable1 = null;
					numberActivity = "";
				}
				DateTime? selectedDate = dtpDate.SelectedDate;
				DateTime value = selectedDate.Value;
				int month = value.Month;
				int year = value.Year;
				text = txtDescription.Text;
				int? nullable2 = null;
				int? nullable3 = nullable2;
				int userID = user.UserID;
				string userName = user.UserName;
				string str1 = functions.approvalStatus(ApprovalStatus.Submitted);
				nullable2 = null;
				selectedDate = null;
				Entry entry = new Entry(nullable3, userID, userName, nullable, numberSerial, numberSAP, numberSection, nullable1, numberActivity, value, month, year, num, text, code, str, str1, ApprovalStatus.Submitted, "", nullable2, "", DateTime.Now, DateTime.Now, selectedDate);
				queries.SaveTimeEntry(queries.t_Timesheet_Prelim, entry, ApprovalStatus.NotSubmitted, ApprovalStatus.NotSubmitted);
				RefreshDGHoursFromClassList();
				RefreshDateList(functions.WeekEnding(entry.date));
				if (isDayfiltered)
				{
					Filter_Filter(filteredDate);
				}
			}
		}

		private void btnWeekDecrement_Click(object sender, RoutedEventArgs e)
		{
			currentWeekEnding = currentWeekEnding.AddDays(-7);
			RefreshDateList(currentWeekEnding);
		}

		private void btnWeekIncrement_Click(object sender, RoutedEventArgs e)
		{
			currentWeekEnding = currentWeekEnding.AddDays(7);
			RefreshDateList(currentWeekEnding);
		}

		private void cbxJob_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Project project = new Project();
			if ((cbxTaskType.SelectedItem == null ? false : !(cbxTaskType.SelectedItem.ToString() == "(N/A)")))
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
			string str = "";
			string str1 = "";
			Project selectedItem = (Project)cbxJob.SelectedItem;
			try
			{
				str = cbxSection.SelectedItem.ToString();
				if (functions.IntToBool(selectedItem.IsOpen))
				{
					str1 = selectedItem.Number_Network.ToString();
				}
				else if (functions.IntToBool(selectedItem.IsWarrantyOpen))
				{
					str1 = selectedItem.Number_WarrantyNetwork.ToString();
				}
				lblSectionDescription.Content = string.Concat(((Section)cbxSection.SelectedItem).Number_ProjectNetwork.ToString(), " - ", ((Section)cbxSection.SelectedItem).Number_Activity.ToString());
			}
			catch
			{
				lblSectionDescription.Content = "";
			}
		}

		private void cbxTaskType_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if ((cbxTaskType.SelectedItem == null ? true : cbxTaskType.SelectedItem.ToString() == "(N/A)"))
			{
				cbxJob.SelectedItem = null;
			}
			UpdateSections((Project)cbxJob.SelectedItem);
		}

		private void cbxTimeCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		}

		public void ClearSelection()
		{
			cbxSection.SelectedItem = null;
			cbxJob.SelectedItem = null;
			cbxTaskType.SelectedItem = null;
			cbxTimeCode.SelectedItem = null;
			txtDescription.Text = "";
			txtHours.Text = hoursMin.ToString();
			dtpDate.SelectedDate = null;
		}

		private void DeleteEntry()
		{
			if (System.Windows.MessageBox.Show("Are you sure you want to delete this Entry?", "Delete Entry?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
				try
				{
					Queries2 query = queries;
					string tTimesheetPrelim = queries.t_Timesheet_Prelim;
					int? entryId = ((Entry)dgHours.SelectedItems[0]).entry_id;
					query.DeleteTimeEntry(tTimesheetPrelim, entryId.Value);
					RefreshDGHoursFromClassList();
				}
				catch
				{
				}
			}
		}

		private void dgContextMenu_Copy_Click(object sender, RoutedEventArgs e)
		{
			if (dgHours.SelectedItems == null ? false : true)
			{
				DateTime now = DateTime.Now;
				TimesheetEntry_Duplicate customDateTimePicker;
				
				// now = customDateTimePicker.date;
				// hours = customDateTimePicker.hours;
				List<Entry> entries = new List<Entry>();
				foreach (Entry selectedItem in dgHours.SelectedItems)
				{
					customDateTimePicker = new TimesheetEntry_Duplicate(selectedItem, this);
					bool? nullable = customDateTimePicker.ShowDialog();
					if ((!nullable.GetValueOrDefault() ? 0 : Convert.ToInt32(nullable.HasValue)) != 0)
						entries.Add(new Entry(customDateTimePicker.entry));
				}
				queries.SaveTimeEntry(queries.t_Timesheet_Prelim, entries, ApprovalStatus.NotSubmitted, ApprovalStatus.NotSubmitted);
				RefreshDGHoursFromClassList();
				RefreshSummaryByDate(functions.WeekEnding(now));
				if (isDayfiltered)
				{
					Filter_Filter(filteredDate);
				}
			}
		}

		private void dgContextMenu_Copy_Click_Prev(object sender, RoutedEventArgs e)
		{
			if (dgHoursPrevWeek.SelectedItems == null ? false : true)
			{
				DateTime now = DateTime.Now;
				TimesheetEntry_Duplicate customDateTimePicker;

				// now = customDateTimePicker.date;
				// hours = customDateTimePicker.hours;
				List<Entry> entries = new List<Entry>();
				foreach (Entry selectedItem in dgHoursPrevWeek.SelectedItems)
				{
					customDateTimePicker = new TimesheetEntry_Duplicate(selectedItem, this);
					bool? nullable = customDateTimePicker.ShowDialog();
					if ((!nullable.GetValueOrDefault() ? 0 : Convert.ToInt32(nullable.HasValue)) != 0)
						entries.Add(new Entry(customDateTimePicker.entry));
				}
				queries.SaveTimeEntry(queries.t_Timesheet_Prelim, entries, ApprovalStatus.NotSubmitted, ApprovalStatus.NotSubmitted);
				RefreshDGHoursFromClassList();
				RefreshSummaryByDate(functions.WeekEnding(now));
				if (isDayfiltered)
				{
					Filter_Filter(filteredDate);
				}
			}
		}

		private void dgContextMenu_Delete_Click(object sender, RoutedEventArgs e)
		{
			DeleteEntry();
		}

		private void dgContextMenu_Edit_Click(object sender, RoutedEventArgs e)
		{
			LaunchEditor();
		}

		private void dgHours_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (VisualTreeHelper.GetParent((DependencyObject)e.OriginalSource).GetType() == typeof(ContentPresenter))
			{
				LaunchEditor();
			}
		}

		private void dtpDate_GotFocus(object sender, RoutedEventArgs e)
		{
			dtpDate.Focus();
		}

		private void dtpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				ValidateDate(dtpDate.SelectedDate.Value, lblDateError);
			}
			catch
			{
				lblDateError.Content = "Date must be selected";
			}
		}

		private void Filter_Check(Label label)
		{
			if (!isDayfiltered)
			{
				Filter_Filter(label);
			}
			else
			{
				Filter_Unfilter();
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
				lblWeekDay1 = lblWeek_Day1;
				lblSundayDay1 = lblSunday_Day1;
				lblWeekDay1Total = lblWeek_Day1_Total;
			}
			else if (label.Name.Contains("Day2"))
			{
				lblWeekDay1 = lblWeek_Day2;
				lblSundayDay1 = lblMonday_Day2;
				lblWeekDay1Total = lblWeek_Day2_Total;
			}
			else if (label.Name.Contains("Day3"))
			{
				lblWeekDay1 = lblWeek_Day3;
				lblSundayDay1 = lblTuesday_Day3;
				lblWeekDay1Total = lblWeek_Day3_Total;
			}
			else if (label.Name.Contains("Day4"))
			{
				lblWeekDay1 = lblWeek_Day4;
				lblSundayDay1 = lblWednesday_Day4;
				lblWeekDay1Total = lblWeek_Day4_Total;
			}
			else if (label.Name.Contains("Day5"))
			{
				lblWeekDay1 = lblWeek_Day5;
				lblSundayDay1 = lblThursday_Day5;
				lblWeekDay1Total = lblWeek_Day5_Total;
			}
			else if (label.Name.Contains("Day6"))
			{
				lblWeekDay1 = lblWeek_Day6;
				lblSundayDay1 = lblFriday_Day6;
				lblWeekDay1Total = lblWeek_Day6_Total;
			}
			else if (!label.Name.Contains("Day7"))
			{
				flag = true;
			}
			else
			{
				lblWeekDay1 = lblWeek_Day7;
				lblSundayDay1 = lblSaturday_Day7;
				lblWeekDay1Total = lblWeek_Day7_Total;
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
				isDayfiltered = true;
				filteredDate = DateTime.Parse(lblWeekDay1.Content.ToString());
				Filter_Filter(filteredDate);
			}
		}

		private void Filter_Filter(DateTime date)
		{
			itemsSourceEntriesFiltered = (
				from x in itemsSourceEntries
				where x.date.ToShortDateString() == date.ToShortDateString()
				select x).ToList<Entry>();
			dgHours.ItemsSource = itemsSourceEntriesFiltered;
		}

		private void Filter_Unfilter()
		{
			foreach (FrameworkElement child in SummaryByDate_Date.Children)
			{
				if (child is Label)
				{
					(child as Label).Background = Brushes.Transparent;
					(child as Label).ToolTip = null;
				}
			}
			foreach (FrameworkElement transparent in SummaryByDate_DayOfWeek.Children)
			{
				if (transparent is Label)
				{
					(transparent as Label).Background = Brushes.Transparent;
					(transparent as Label).ToolTip = null;
				}
			}
			foreach (FrameworkElement frameworkElement in SummaryByDate_Amount.Children)
			{
				if (frameworkElement is Label)
				{
					(frameworkElement as Label).Background = Brushes.Transparent;
					(frameworkElement as Label).ToolTip = null;
				}
			}
			isDayfiltered = false;
			filteredDate = DateTime.Now;
			dgHours.ItemsSource = 
				from x in itemsSourceEntries
				orderby x.date
				select x;
		}

		private bool IsValidDate(DateTime date)
		{
			bool flag;
			try
			{
				flag = queries.Period_Open(date.Month, date.Year);
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
			if (cbxTimeCode.SelectedItem == null)
			{
				MessageBox.Show("You must select a timecode");
				flag = false;
			}
			else if (cbxTaskType.SelectedItem != null)
			{
				if (!(cbxTaskType.SelectedItem.ToString() == "(N/A)"))
				{
					if (cbxJob.SelectedItem == null)
					{
						MessageBox.Show("You must select a project");
						flag = false;
						return flag;
					}
					else if (cbxSection.SelectedItem == null)
					{
						MessageBox.Show("You must select a section");
						flag = false;
						return flag;
					}
				}
				if (!dtpDate.SelectedDate.HasValue)
				{
					MessageBox.Show("You must select a date");
					flag = false;
				}
				else if (!IsValidDate(dtpDate.SelectedDate.Value))
				{
					MessageBox.Show("The Date you have selected is in a closed period");
					flag = false;
				}
				else if (!string.IsNullOrEmpty(txtDescription.Text))
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
				if (dgHours.SelectedItem != null)
				{
					Entry item = dgHours.SelectedItems[0] as Entry;
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
			cbxJob.DisplayMemberPath = "Serial_Customer_Machine";
			cbxJob.SelectedValuePath = "Serial_Customer_Machine";
			cbxTimeCode.DisplayMemberPath = "Code_Description";
			cbxTimeCode.SelectedValuePath = "Code_Description";
			cbxSection.DisplayMemberPath = "SectionNumber_SectionDescription";
			cbxSection.SelectedValuePath = "SectionNumber_SectionDescription";
			foreach (TimesheetCode timesheetCode in queries.TimesheetCodeAll())
			{
				cbxTimeCode.Items.Add(timesheetCode);
			}
			foreach (string str in queries.TaskTypes())
			{
				cbxTaskType.Items.Add(str);
			}
			foreach (Project project in queries.ProjectAll())
			{
				if ((functions.IntToBool(project.IsOpen) ? true : functions.IntToBool(project.IsWarrantyOpen)))
				{
					cbxJob.Items.Add(project);
				}
			}
			sectionsAll = queries.Sections();
			myConnection.Close();
		}

		private void menuEditDeleteEntry_Click(object sender, RoutedEventArgs e)
		{
			DeleteEntry();
		}

		private void menuEditEditEntry_Click(object sender, RoutedEventArgs e)
		{
			LaunchEditor();
		}

		private void menuEditSubmitForApproval_Click(object sender, RoutedEventArgs e)
		{
			SubmitForApproval();
		}

		private void menuFileChangePassword_Click(object sender, RoutedEventArgs e)
		{
			(new UserChangePassword(user)).Show();
		}

		private void menuFileClose_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		private void menuFileExport_Click(object sender, RoutedEventArgs e)
		{
			ExportToExcel<Entry, List<Entry>> exportToExcel = new ExportToExcel<Entry, List<Entry>>()
			{
				dataToPrint = queries.Entries(queries.User_AllEntries(user.UserID, queries.t_Timesheet_Prelim))
			};
			exportToExcel.GenerateReport();
		}

		private void menuFilePrint_Click(object sender, RoutedEventArgs e)
		{
			PrintDialog printDialog = new PrintDialog();
			bool? nullable = printDialog.ShowDialog();
			if ((!nullable.GetValueOrDefault() ? 0 : Convert.ToInt32(nullable.HasValue)) != 0)
			{
				printDialog.PrintVisual(dgHours, "Print Grid");
			}
		}

		private void menuOptionsUserPreferences_Click(object sender, RoutedEventArgs e)
		{
			bool? nullable = (new UserDefaults(user)).ShowDialog();
			if ((!nullable.GetValueOrDefault() ? 0 : Convert.ToInt32(nullable.HasValue)) != 0)
			{
				user_Defaults = new User_Defaults(user);
				ClearSelection();
				RefreshDefaultSelections(user_Defaults);
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

		/*private void menuViewReports_Click(object sender, RoutedEventArgs e)
		{
			RunReports();
		}*/

		private void menuViewUserRights_Click(object sender, RoutedEventArgs e)
		{
			(new UserRights(user)).Show();
		}

		public void RefreshDateList(DateTime WeekEnding)
		{
			currentWeekEnding = functions.WeekEnding(WeekEnding);
			lblWeek_Day7.Content = currentWeekEnding.ToShortDateString();
			Label lblWeekDay6 = lblWeek_Day6;
			DateTime dateTime = currentWeekEnding.AddDays(-1);
			lblWeekDay6.Content = dateTime.ToShortDateString();
			Label lblWeekDay5 = lblWeek_Day5;
			dateTime = currentWeekEnding.AddDays(-2);
			lblWeekDay5.Content = dateTime.ToShortDateString();
			Label lblWeekDay4 = lblWeek_Day4;
			dateTime = currentWeekEnding.AddDays(-3);
			lblWeekDay4.Content = dateTime.ToShortDateString();
			Label lblWeekDay3 = lblWeek_Day3;
			dateTime = currentWeekEnding.AddDays(-4);
			lblWeekDay3.Content = dateTime.ToShortDateString();
			Label lblWeekDay2 = lblWeek_Day2;
			dateTime = currentWeekEnding.AddDays(-5);
			lblWeekDay2.Content = dateTime.ToShortDateString();
			Label lblWeekDay1 = lblWeek_Day1;
			dateTime = currentWeekEnding.AddDays(-6);
			lblWeekDay1.Content = dateTime.ToShortDateString();
			RefreshSummaryByDate(currentWeekEnding);
		}

		public void RefreshDefaultSelections(User_Defaults defaults)
		{
			if (defaults.TimesheetCode != null)
			{
				cbxTimeCode.SelectedValue = defaults.TimesheetCode.Code_Description;
			}
			if (!string.IsNullOrEmpty(defaults.TaskType))
			{
				cbxTaskType.SelectedItem = defaults.TaskType;
			}
			if (defaults.Project != null)
			{
				cbxJob.SelectedValue = defaults.Project.Serial_Customer_Machine;
			}
		}

		public void RefreshDGHoursFromClassList()
		{
			WaitCursor waitCursor = new WaitCursor();
			try
			{
				dgHours.ItemsSource = null;
				try
				{
					itemsSourceEntries = queries.Entries(queries.User_AllEntries(user.UserID, queries.t_Timesheet_Prelim));
					dgHours.ItemsSource = 
						from E in itemsSourceEntries
						orderby E.date
						select E;
					itemsSourceEntriesUnapproved = queries.Entries(queries.User_AllEntries(user.UserID, queries.t_Timesheet_Limbo));
					dgHoursUnapproved.ItemsSource = 
						from E in itemsSourceEntriesUnapproved
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
				from E in itemsSourceEntries
				where E.date.Date == weekEnding.AddDays(-6).Date
				select E).Sum<Entry>((Entry E) => E.hours);
			double num1 = (
				from E in itemsSourceEntries
				where E.date.Date == weekEnding.AddDays(-5).Date
				select E).Sum<Entry>((Entry E) => E.hours);
			double num2 = (
				from E in itemsSourceEntries
				where E.date.Date == weekEnding.AddDays(-4).Date
				select E).Sum<Entry>((Entry E) => E.hours);
			double num3 = (
				from E in itemsSourceEntries
				where E.date.Date == weekEnding.AddDays(-3).Date
				select E).Sum<Entry>((Entry E) => E.hours);
			double num4 = (
				from E in itemsSourceEntries
				where E.date.Date == weekEnding.AddDays(-2).Date
				select E).Sum<Entry>((Entry E) => E.hours);
			double num5 = (
				from E in itemsSourceEntries
				where E.date.Date == weekEnding.AddDays(-1).Date
				select E).Sum<Entry>((Entry E) => E.hours);
			double num6 = (
				from E in itemsSourceEntries
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
				lblWeek_Day1_Total,
				lblWeek_Day2_Total,
				lblWeek_Day3_Total,
				lblWeek_Day4_Total,
				lblWeek_Day5_Total,
				lblWeek_Day6_Total,
				lblWeek_Day7_Total
			};
			List<Label> normal = labels;
			string str = "There are only 24 hours in a day!  Please Correct!";
			string suspicion = "You worked more than 8 hours on this date, this will be reviewed.";
			for (int i = 0; i < nums1.Count; i++)
			{
				string str1 = (nums1[i] != 0 ? nums1[i].ToString() : "-");
				if (nums1[i] <= 8.5)
				{
					normal[i].Content = str1;
					normal[i].FontWeight = FontWeights.Normal;
					normal[i].ToolTip = null;
					normal[i].Background = null;
				}
				else if(nums1[i] >= 8.6 && nums1[i] < 24)
                {
					normal[i].Content = str1;
					normal[i].FontWeight = FontWeights.ExtraBold;
					normal[i].ToolTip = suspicion;
					normal[i].Background = Brushes.Orange;
                }
				else
				{
					normal[i].Content = str1;
					normal[i].FontWeight = FontWeights.ExtraBold;
					normal[i].ToolTip = str;
					normal[i].Background = Brushes.Red;
				}
			}
			lblWeek_Total.Content = num7.ToString();
		}

		/*private void RunReports()
		{
			(new Report(user)).Show();
		}*/

		private void SubmitForApproval()
		{
			(new TimesheetApproval_Submission(user, this)).Show();
		}

		private void SummaryByDate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			Filter_Check(sender as Label);
		}

		private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Console.WriteLine(((sender as TabControl).SelectedItem as TabItem).Header.ToString());
			if (((sender as TabControl).SelectedItem as TabItem).Header.ToString() != "Approved" ? false : !approvedQueryHasRun)
			{
				itemsSourceEntriesApproved = queries.Entries(queries.User_AllEntries(user.UserID, queries.t_Timesheet_Final));
				dgHoursApproved.ItemsSource =
					from E in itemsSourceEntriesApproved
					orderby E.date
					select E;
				approvedQueryHasRun = true;
			}
			else if (((sender as TabControl).SelectedItem as TabItem).Header.ToString() != "Last Week" ? false : !preWeekQueryHasRun)
			{
				itemSourceEntriesPrevWeek = queries.Entries(queries.User_AllEntries(user.UserID, queries.t_Timesheet_Final));
				List<Entry> filteredList = new List<Entry>();

				filteredList.AddRange(
					from E in itemSourceEntriesPrevWeek
					where E.date.Date == weekEnding.AddDays(-13).Date
					|| E.date.Date == weekEnding.AddDays(-12).Date
					|| E.date.Date == weekEnding.AddDays(-11).Date
					|| E.date.Date == weekEnding.AddDays(-10).Date
					|| E.date.Date == weekEnding.AddDays(-9).Date
					|| E.date.Date == weekEnding.AddDays(-8).Date
					|| E.date.Date == weekEnding.AddDays(-7).Date
					orderby E.date
					select E
				);

				dgHoursPrevWeek.ItemsSource =
					from E in filteredList
					orderby E.date
					select E;
				preWeekQueryHasRun = true;
			}
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

		private void TxtHoursSelectAll(object sender, RoutedEventArgs e)
		{
			txtHours.SelectAll();
		}

		private void UpdateSections(Project project)
		{
			cbxSection.Items.Clear();
			lblSectionDescription.Content = "";
			if ((project == null || cbxTaskType.SelectedItem == null || project.Number_Serial == "" ? false : !(cbxTaskType.SelectedItem.ToString() == "")))
			{
				string str = cbxTaskType.SelectedItem.ToString();
				if (!functions.IntToBool(project.IsOpen))
				{
					foreach (Section section in 
						from n in sectionsAll
						where n.Number_ProjectNetwork == project.Number_Network.ToString()
						select n into t
						where t.TaskType == str
						select t)
					{
						cbxSection.Items.Add(section);
					}
				}
				else
				{
					foreach (Section section1 in 
						from n in sectionsAll
						where n.Number_ProjectNetwork == project.Number_Network.ToString()
						select n into t
						where t.TaskType == str
						select t)
					{
						cbxSection.Items.Add(section1);
					}
				}
			}
		}

		public void ValidateDate(DateTime date, Label label)
		{
			if (!IsValidDate(date))
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