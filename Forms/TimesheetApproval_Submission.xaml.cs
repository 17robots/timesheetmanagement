using FivesBronxTimesheetManagement.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class TimesheetApproval_Submission : Window
	{
		private User user;

		private Queries2 queries = new Queries2();

		private TimesheetEntry tsEntryScreen;

		private Functions functions;

		private DateTime weekEnding;

		private DateTime currentWeekEnding;

		private List<Entry> itemsSourceEntries;

		private List<Entry> items;

		private DateTime beforeDate;

		public TimesheetApproval_Submission(FivesBronxTimesheetManagement.Classes.User User, TimesheetEntry tsEntryScreen)
		{
			InitializeComponent();
			queries = new Queries2();
			functions = new Functions();
			user = User;
			this.tsEntryScreen = tsEntryScreen;
			beforeDate = DateTime.Now;
			RefreshDGHoursFromClassList();
			BindDataGrid();
			weekEnding = functions.WeekEnding(DateTime.Now);
			RefreshDateList(weekEnding);
		}

		private void BindDataGrid()
		{
			List<DataGridTextColumn> dataGridTextColumns = new List<DataGridTextColumn>();
			DataGridTextColumn dataGridTextColumn = new DataGridTextColumn()
			{
				Header = "Date"
			};
			Binding binding = new Binding("date")
			{
				Converter = new Classes.DateTimeConverter()
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
				Header = "Hours",
				Binding = new Binding("hours")
			};
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
				dgHours.Columns.Add(dataGridTextColumn10);
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			tsEntryScreen.RefreshDGHoursFromClassList();
			Close();
		}

		private void btnRefresh_Click(object sender, RoutedEventArgs e)
		{
			RefreshDGHoursFromClassList();
		}

		private void btnSendForApproval_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to submit?", "Submit?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
				List<Entry> entries = new List<Entry>();
				for (int i = 0; i < dgHours.SelectedItems.Count; i++)
				{
					entries.Add(dgHours.SelectedItems[i] as Entry);
				}
				queries.Approval_SubmitFor(entries);
				RefreshDGHoursFromClassList();
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

		private void ckbxSelectAll_Clicked(object sender, RoutedEventArgs e)
		{
			try
			{
				bool? isChecked = ckbxSelectAll.IsChecked;
				if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) == 0)
				{
					dgHours.SelectedItem = null;
					ckbxSelectAll.Content = "Select All";
					dgHours.Focus();
				}
				else
				{
					dgHours.SelectAll();
					ckbxSelectAll.Content = "DeSelect All";
					dgHours.Focus();
				}
			}
			catch
			{
			}
		}

		private void dgHours_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			double num = 0;
			foreach (Entry selectedItem in dgHours.SelectedItems)
			{
				num += selectedItem.hours;
			}
			if (num != 0)
			{
				lblHoursSelectedForApproval.Content = num.ToString();
			}
			else
			{
				lblHoursSelectedForApproval.Content = "-";
			}
		}

		private void dtpEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			if (dtpEndDate.SelectedDate.HasValue)
			{
				beforeDate = dtpEndDate.SelectedDate.Value;
			}
			else
			{
				dtpEndDate.SelectedDate = new DateTime?(beforeDate);
			}
		}

		private void RefreshDateList(DateTime WeekEnding)
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

		public void RefreshDGHoursFromClassList()
		{
			dgHours.ItemsSource = null;
			try
			{
				itemsSourceEntries = queries.Entries(queries.User_AllEntries(user.UserID, queries.t_Timesheet_Prelim));
				items = (
					from E in itemsSourceEntries
					where E.date <= beforeDate
					select E).ToList<Entry>();
				items.AddRange((
					from E in itemsSourceEntries
					where E.date > beforeDate
					where (E.timesheet_code.Equals("H") || E.timesheet_code.Equals("PA") || E.timesheet_code.Equals("UA") ? true : E.timesheet_code.Equals("V"))
					select E).ToList<Entry>());
				dgHours.ItemsSource = 
					from E in items
					orderby E.date
					select E;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
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
			lblWeek_Total.Content = num7.ToString();
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			tsEntryScreen.RefreshDGHoursFromClassList();
			tsEntryScreen.RefreshSummaryByDate(functions.WeekEnding(DateTime.Now));
		}
	}
}