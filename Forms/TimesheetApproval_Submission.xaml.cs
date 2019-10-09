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
using System.Windows.Markup;
using System.Windows.Media;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class TimesheetApproval_Submission : Window
	{
		private User user;

		private Queries queries;

		private Connection myConnection;

		private TimesheetEntry tsEntryScreen;

		private Functions functions;

		private DateTime weekEnding;

		private DateTime currentWeekEnding;

		private List<Entry> itemsSourceEntries;

		private List<Entry> items;

		private DateTime beforeDate;

		public TimesheetApproval_Submission(FivesBronxTimesheetManagement.Classes.User User, TimesheetEntry tsEntryScreen)
		{
			this.InitializeComponent();
			this.queries = new Queries();
			this.myConnection = new Connection();
			this.functions = new Functions();
			this.user = User;
			this.tsEntryScreen = tsEntryScreen;
			this.beforeDate = DateTime.Now;
			this.RefreshDGHoursFromClassList();
			this.BindDataGrid();
			this.weekEnding = this.functions.WeekEnding(DateTime.Now);
			this.RefreshDateList(this.weekEnding);
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
				this.dgHours.Columns.Add(dataGridTextColumn10);
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.tsEntryScreen.RefreshDGHoursFromClassList();
			base.Close();
		}

		private void btnRefresh_Click(object sender, RoutedEventArgs e)
		{
			this.RefreshDGHoursFromClassList();
		}

		private void btnSendForApproval_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to submit?", "Submit?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
				List<Entry> entries = new List<Entry>();
				for (int i = 0; i < this.dgHours.SelectedItems.Count; i++)
				{
					entries.Add(this.dgHours.SelectedItems[i] as Entry);
				}
				this.queries.Approval_SubmitFor(entries);
				this.RefreshDGHoursFromClassList();
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

		private void ckbxSelectAll_Clicked(object sender, RoutedEventArgs e)
		{
			try
			{
				bool? isChecked = this.ckbxSelectAll.IsChecked;
				if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) == 0)
				{
					this.dgHours.SelectedItem = null;
					this.ckbxSelectAll.Content = "Select All";
					this.dgHours.Focus();
				}
				else
				{
					this.dgHours.SelectAll();
					this.ckbxSelectAll.Content = "DeSelect All";
					this.dgHours.Focus();
				}
			}
			catch
			{
			}
		}

		private void dgHours_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			double num = 0;
			foreach (Entry selectedItem in this.dgHours.SelectedItems)
			{
				num += selectedItem.hours;
			}
			if (num != 0)
			{
				this.lblHoursSelectedForApproval.Content = num.ToString();
			}
			else
			{
				this.lblHoursSelectedForApproval.Content = "-";
			}
		}

		private void dtpEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.dtpEndDate.SelectedDate.HasValue)
			{
				this.beforeDate = this.dtpEndDate.SelectedDate.Value;
			}
			else
			{
				this.dtpEndDate.SelectedDate = new DateTime?(this.beforeDate);
			}
		}

		private void RefreshDateList(DateTime WeekEnding)
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

		public void RefreshDGHoursFromClassList()
		{
			this.dgHours.ItemsSource = null;
			try
			{
				this.itemsSourceEntries = this.queries.Entries(this.queries.t_Timesheet_Prelim, this.queries.User_AllEntries(this.user.UserID, this.queries.t_Timesheet_Prelim));
				this.items = (
					from E in this.itemsSourceEntries
					where E.date <= this.beforeDate
					select E).ToList<Entry>();
				this.items.AddRange((
					from E in this.itemsSourceEntries
					where E.date > this.beforeDate
					where (E.timesheet_code.Equals("H") || E.timesheet_code.Equals("PA") || E.timesheet_code.Equals("UA") ? true : E.timesheet_code.Equals("V"))
					select E).ToList<Entry>());
				this.dgHours.ItemsSource = 
					from E in this.items
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

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			this.tsEntryScreen.RefreshDGHoursFromClassList();
			this.tsEntryScreen.RefreshSummaryByDate(this.functions.WeekEnding(DateTime.Now));
		}
	}
}