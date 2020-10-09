using FivesBronxTimesheetManagement.Classes;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class TimesheetApproval : Window
	{
		private User user;

		private Queries2 queries = new Queries2();

		private Connection myConnection;

		private DateTime weekEnding;

		private DateTime currentWeekEnding;

		private DateTime beforeDate;

		private List<Entry> itemsSourceEntries;

		private List<User> users;

		private Functions myFunctions;

		public TimesheetApproval(FivesBronxTimesheetManagement.Classes.User User)
		{
			this.user = User;
			this.InitializeComponent();
			this.queries = new Queries2();
			this.myConnection = new Connection();
			this.myFunctions = new Functions();
			this.LoadConstantsFromDb();
			Label label = this.lblApproverName;
			int userID = this.user.UserID;
			label.Content = string.Concat(userID.ToString(), "-", this.user.UserName);
			this.beforeDate = DateTime.Now;
			this.dtpEndDate.SelectedDate = new DateTime?(this.beforeDate);
			this.RefreshDGHoursFromClassList();
			this.BindDataGrid();
			this.weekEnding = this.myFunctions.WeekEnding(DateTime.Now);
			this.RefreshDateList(this.weekEnding);
		}

		private void BindDataGrid()
		{
			List<DataGridTextColumn> dataGridTextColumns = new List<DataGridTextColumn>();
			DataGridTextColumn dataGridTextColumn = new DataGridTextColumn()
			{
				Header = "User ID",
				Binding = new Binding("user_id")
			};
			dataGridTextColumns.Add(dataGridTextColumn);
			DataGridTextColumn dataGridTextColumn1 = new DataGridTextColumn()
			{
				Header = "User Name",
				Binding = new Binding("user_name")
			};
			dataGridTextColumns.Add(dataGridTextColumn1);
			DataGridTextColumn dataGridTextColumn2 = new DataGridTextColumn()
			{
				Header = "Date"
			};
			Binding binding = new Binding("date")
			{
				Converter = new FivesBronxTimesheetManagement.Classes.DateTimeConverter()
			};
			dataGridTextColumn2.Binding = binding;
			dataGridTextColumns.Add(dataGridTextColumn2);
			DataGridTextColumn dataGridTextColumn3 = new DataGridTextColumn()
			{
				Header = "Timesheet Code",
				Binding = new Binding("timesheet_code")
			};
			dataGridTextColumns.Add(dataGridTextColumn3);
			DataGridTextColumn dataGridTextColumn4 = new DataGridTextColumn()
			{
				Header = "Task Type",
				Binding = new Binding("task_type")
			};
			dataGridTextColumns.Add(dataGridTextColumn4);
			DataGridTextColumn dataGridTextColumn5 = new DataGridTextColumn()
			{
				Header = "Project Serial",
				Binding = new Binding("project_serial")
			};
			dataGridTextColumns.Add(dataGridTextColumn5);
			DataGridTextColumn dataGridTextColumn6 = new DataGridTextColumn()
			{
				Header = "Section",
				Binding = new Binding("number_section")
			};
			dataGridTextColumns.Add(dataGridTextColumn6);
			DataGridTextColumn dataGridTextColumn7 = new DataGridTextColumn()
			{
				Header = "Hours",
				Binding = new Binding("hours")
			};
			dataGridTextColumns.Add(dataGridTextColumn7);
			DataGridTextColumn dataGridTextColumn8 = new DataGridTextColumn()
			{
				Header = "Description",
				Binding = new Binding("description")
			};
			dataGridTextColumns.Add(dataGridTextColumn8);
			DataGridTextColumn dataGridTextColumn9 = new DataGridTextColumn()
			{
				Header = "Submitted Status",
				Binding = new Binding("submitted_status")
			};
			dataGridTextColumns.Add(dataGridTextColumn9);
			DataGridTextColumn dataGridTextColumn10 = new DataGridTextColumn()
			{
				Header = "Approval Status",
				Binding = new Binding("approval_status")
			};
			dataGridTextColumns.Add(dataGridTextColumn10);
			DataGridTextColumn dataGridTextColumn11 = new DataGridTextColumn()
			{
				Header = "Rejection Reason",
				Binding = new Binding("rejection_reason")
			};
			dataGridTextColumns.Add(dataGridTextColumn11);
			foreach (DataGridTextColumn dataGridTextColumn12 in dataGridTextColumns)
			{
				dataGridTextColumn12.IsReadOnly = true;
				this.dgHours.Columns.Add(dataGridTextColumn12);
			}
		}

		private void btnApprove_Click(object sender, RoutedEventArgs e)
		{
			List<Entry> entries = new List<Entry>();
			for (int i = 0; i < this.dgHours.SelectedItems.Count; i++)
			{
				entries.Add((Entry)this.dgHours.SelectedItems[i]);
			}
			this.queries.Approval_Approve(entries, this.user);
			this.RefreshDGHoursFromClassList();
		}

		private void btnRefresh_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.RefreshDGHoursFromClassList();
				this.RefreshSummaryByDate(this.currentWeekEnding);
				this.ckbxSelectAll.IsChecked = new bool?(false);
			}
			catch
			{
			}
		}

		private void btnReject_Click(object sender, RoutedEventArgs e)
		{
			string str = Interaction.InputBox("Enter A Rejection Reason", "Rejection Reason", "", -1, -1);
			if (str == "") str = "No Reason Provided";
			List<Entry> entries = new List<Entry>();
			for (int i = 0; i < this.dgHours.SelectedItems.Count; i++)
			{
				entries.Add((Entry)this.dgHours.SelectedItems[i]);
			}
			this.queries.Approval_Reject(entries, str);
			this.RefreshDGHoursFromClassList();
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
			if ((this.dtpEndDate.SelectedDate.Value > DateTime.Now ? false : this.dtpEndDate.SelectedDate.HasValue))
			{
				this.beforeDate = this.dtpEndDate.SelectedDate.Value;
			}
			else
			{
				this.dtpEndDate.SelectedDate = new DateTime?(this.beforeDate);
			}
		}

		private void LoadConstantsFromDb()
		{
			this.users = (
				from E in this.queries.User_GetApprovees(this.user)
				orderby E.UserName
				select E).ToList<User>();
			this.cbxEmployee.ItemsSource = this.users;
			this.cbxEmployee.DisplayMemberPath = "UserName";
		}

		private void RefreshDateList(DateTime WeekEnding)
		{
			this.currentWeekEnding = this.myFunctions.WeekEnding(WeekEnding);
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
			string tTimesheetLimbo = this.queries.t_Timesheet_Limbo;
			if (this.cbxEmployee.SelectedItem != null)
			{
				int userID = ((User)this.cbxEmployee.SelectedItem).UserID;
				this.dgHours.ItemsSource = null;
				try
				{
					this.itemsSourceEntries = this.queries.Entries(this.queries.User_AllEntries(userID, tTimesheetLimbo));
					this.dgHours.ItemsSource = 
						from E in this.itemsSourceEntries
						orderby E.date
						where E.date <= this.beforeDate
						select E;
				}
				catch (Exception exception)
				{
					MessageBox.Show(exception.ToString());
				}
			}
		}

		public void RefreshSummaryByDate(DateTime weekEnding)
		{
			try
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
				string suspicion = "Employee had over 8.5 hours on this date. Please Review.";
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
					else if (nums1[i] >= 8.6 && nums1[i] < 24)
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
				this.lblWeek_Total.Content = num7.ToString();
			}
			catch
			{
			}
		}
	}
}