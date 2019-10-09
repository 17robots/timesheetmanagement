using FivesBronxTimesheetManagement.Classes;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class Report : Window
	{
		private Queries queries;

		private Functions functions;

		private List<User> users;

		private List<User> selectedUsers;

		private List<string> selectedTables;

		private List<string> availableTables;

		private ExportToExcel<Entry, List<Entry>> export;

		private User user;

		public Report(FivesBronxTimesheetManagement.Classes.User User)
		{
			this.InitializeComponent();
			this.user = User;
			this.queries = new Queries();
			this.functions = new Functions();
			this.LoadConstantsFromDb();
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			this.export = new ExportToExcel<Entry, List<Entry>>()
			{
				dataToPrint = this.GetEntries(this.SelectedUsers(), this.SelectedTables())
			};
			this.export.GenerateReport();
		}

		private void cbxProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.cbxProject.SelectedItem != null)
			{
				this.chbxProjectSelectAll.IsChecked = new bool?(false);
				this.UpdateSections();
			}
		}

		private void cbxSection_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.cbxSection.SelectedItem != null)
			{
				this.chbxSectionSelectAll.IsChecked = new bool?(false);
			}
		}

		private void cbxTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.cbxTable.SelectedItem != null)
			{
				this.chbxTableSelectAll.IsChecked = new bool?(false);
			}
		}

		private void cbxTaskType_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.cbxTaskType.SelectedItem != null)
			{
				this.chbxTaskTypeSelectAll.IsChecked = new bool?(false);
			}
		}

		private void cbxTimesheetCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.cbxTimesheetCode.SelectedItem != null)
			{
				this.chbxTimesheetCodeSelectAll.IsChecked = new bool?(false);
			}
		}

		private void cbxUserName_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.cbxUserName.SelectedItem != null)
			{
				this.chbxUserNameSelectAll.IsChecked = new bool?(false);
			}
		}

		private void chbxProjectSelectAll_CheckedChanged(object sender, RoutedEventArgs e)
		{
			bool? isChecked = this.chbxProjectSelectAll.IsChecked;
			if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) == 0)
			{
				isChecked = this.chbxProjectSelectAll.IsChecked;
				if (((isChecked.GetValueOrDefault() ? true : !isChecked.HasValue) ? false : this.cbxProject.SelectedItem == null))
				{
					this.chbxProjectSelectAll.IsChecked = new bool?(true);
				}
			}
			else
			{
				this.cbxProject.SelectedItem = null;
			}
		}

		private void chbxSectionSelectAll_CheckedChanged(object sender, RoutedEventArgs e)
		{
			bool? isChecked = this.chbxSectionSelectAll.IsChecked;
			if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) == 0)
			{
				isChecked = this.chbxSectionSelectAll.IsChecked;
				if (((isChecked.GetValueOrDefault() ? true : !isChecked.HasValue) ? false : this.cbxSection.SelectedItem == null))
				{
					this.chbxSectionSelectAll.IsChecked = new bool?(true);
				}
			}
			else
			{
				this.cbxSection.SelectedItem = null;
			}
		}

		private void chbxTableSelectAll_CheckedChanged(object sender, RoutedEventArgs e)
		{
			bool? isChecked = this.chbxTableSelectAll.IsChecked;
			if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) == 0)
			{
				isChecked = this.chbxTableSelectAll.IsChecked;
				if (((isChecked.GetValueOrDefault() ? true : !isChecked.HasValue) ? false : this.cbxTable.SelectedItem == null))
				{
					this.chbxTableSelectAll.IsChecked = new bool?(true);
				}
			}
			else
			{
				this.cbxTable.SelectedItem = null;
			}
		}

		private void chbxTaskTypeSelectAll_CheckedChanged(object sender, RoutedEventArgs e)
		{
			bool? isChecked = this.chbxTaskTypeSelectAll.IsChecked;
			if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) == 0)
			{
				isChecked = this.chbxTaskTypeSelectAll.IsChecked;
				if (((isChecked.GetValueOrDefault() ? true : !isChecked.HasValue) ? false : this.cbxTaskType.SelectedItem == null))
				{
					this.chbxTaskTypeSelectAll.IsChecked = new bool?(true);
				}
			}
			else
			{
				this.cbxTaskType.SelectedItem = null;
			}
		}

		private void chbxTimesheetCodeSelectAll_CheckedChanged(object sender, RoutedEventArgs e)
		{
			bool? isChecked = this.chbxTimesheetCodeSelectAll.IsChecked;
			if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) == 0)
			{
				isChecked = this.chbxTimesheetCodeSelectAll.IsChecked;
				if (((isChecked.GetValueOrDefault() ? true : !isChecked.HasValue) ? false : this.cbxTimesheetCode.SelectedItem == null))
				{
					this.chbxTimesheetCodeSelectAll.IsChecked = new bool?(true);
				}
			}
			else
			{
				this.cbxTimesheetCode.SelectedItem = null;
			}
		}

		private void chbxUserNameSelectAll_CheckedChanged(object sender, RoutedEventArgs e)
		{
			bool? isChecked = this.chbxUserNameSelectAll.IsChecked;
			if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) == 0)
			{
				isChecked = this.chbxUserNameSelectAll.IsChecked;
				if (((isChecked.GetValueOrDefault() ? true : !isChecked.HasValue) ? false : this.cbxUserName.SelectedItem == null))
				{
					this.chbxUserNameSelectAll.IsChecked = new bool?(true);
				}
			}
			else
			{
				this.cbxUserName.SelectedItem = null;
			}
		}

		private List<string> CreateListQString(List<string> _tables, List<User> _users)
		{
			string[] tTimesheetCTimesheetCode;
			DateTime? selectedDate;
			DateTime value;
			bool hasValue;
			bool flag;
			bool hasValue1;
			List<string> strs = new List<string>();
			string str = "";
			string str1 = "";
			string str2 = "";
			string str3 = "";
			string str4 = "";
			if (this.cbxTimesheetCode.SelectedItem != null)
			{
				tTimesheetCTimesheetCode = new string[] { " AND ", this.queries.t_Timesheet_c_Timesheet_Code, "= '", this.cbxTimesheetCode.SelectedValue.ToString(), "'" };
				str = string.Concat(tTimesheetCTimesheetCode);
			}
			if (this.cbxTaskType.SelectedItem != null)
			{
				tTimesheetCTimesheetCode = new string[] { " AND ", this.queries.t_Timesheet_c_Task_Type, "= '", this.cbxTaskType.SelectedItem.ToString(), "'" };
				str1 = string.Concat(tTimesheetCTimesheetCode);
			}
			if (this.cbxProject.SelectedItem != null)
			{
				tTimesheetCTimesheetCode = new string[] { " AND ", this.queries.t_Timesheet_c_Project_Serial, "= '", this.cbxProject.SelectedItem.ToString(), "'" };
				str2 = string.Concat(tTimesheetCTimesheetCode);
			}
			if (this.cbxSection.SelectedItem != null)
			{
				tTimesheetCTimesheetCode = new string[] { " AND ", this.queries.t_Timesheet_c_Number_Section, "= '", this.cbxSection.SelectedItem.ToString(), "'" };
				str3 = string.Concat(tTimesheetCTimesheetCode);
			}
			if (this.dtpFrom.SelectedDate.HasValue)
			{
				hasValue = false;
			}
			else
			{
				selectedDate = this.dtpTo.SelectedDate;
				hasValue = !selectedDate.HasValue;
			}
			if (!hasValue)
			{
				if (this.dtpFrom.SelectedDate.HasValue)
				{
					flag = true;
				}
				else
				{
					selectedDate = this.dtpTo.SelectedDate;
					flag = !selectedDate.HasValue;
				}
				if (flag)
				{
					if (!this.dtpFrom.SelectedDate.HasValue)
					{
						hasValue1 = true;
					}
					else
					{
						selectedDate = this.dtpTo.SelectedDate;
						hasValue1 = !selectedDate.HasValue;
					}
					if (!hasValue1)
					{
						tTimesheetCTimesheetCode = new string[] { " AND ", this.queries.t_Timesheet_c_Date, ">= '", null, null, null, null, null, null };
						value = this.dtpFrom.SelectedDate.Value;
						tTimesheetCTimesheetCode[3] = value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
						tTimesheetCTimesheetCode[4] = "' AND ";
						tTimesheetCTimesheetCode[5] = this.queries.t_Timesheet_c_Date;
						tTimesheetCTimesheetCode[6] = "<= '";
						value = this.dtpTo.SelectedDate.Value;
						tTimesheetCTimesheetCode[7] = value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
						tTimesheetCTimesheetCode[8] = "'";
						str4 = string.Concat(tTimesheetCTimesheetCode);
					}
					else if ((!this.dtpFrom.SelectedDate.HasValue ? false : !this.dtpTo.SelectedDate.HasValue))
					{
						tTimesheetCTimesheetCode = new string[] { " AND ", this.queries.t_Timesheet_c_Date, "='", null, null };
						value = this.dtpFrom.SelectedDate.Value;
						tTimesheetCTimesheetCode[3] = value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
						tTimesheetCTimesheetCode[4] = "'";
						str4 = string.Concat(tTimesheetCTimesheetCode);
					}
				}
				else
				{
					tTimesheetCTimesheetCode = new string[] { " AND ", this.queries.t_Timesheet_c_Date, "<= '", null, null };
					value = this.dtpTo.SelectedDate.Value;
					tTimesheetCTimesheetCode[3] = value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
					tTimesheetCTimesheetCode[4] = "'";
					str4 = string.Concat(tTimesheetCTimesheetCode);
				}
			}
			foreach (User _user in _users)
			{
				foreach (string _table in _tables)
				{
					object[] userID = new object[] { "SELECT * FROM ", _table, " WHERE user_id ='", _user.UserID, "'", str, str1, str2, str3, str4 };
					strs.Add(string.Concat(userID));
				}
			}
			return strs;
		}

		private List<Entry> GetEntries(List<User> Users, List<string> Tables)
		{
			List<Entry> entries = new List<Entry>();
			foreach (string table in Tables)
			{
				List<string> strs = new List<string>()
				{
					table
				};
				foreach (Entry entry in this.queries.Entries(table, this.queries.ReturnIntList(this.CreateListQString(strs, Users), this.queries.t_Timesheet_c_Entry_Id)))
				{
					entries.Add(entry);
				}
			}
			return entries;
		}

		private void LoadConstantsFromDb()
		{
			this.LoadUsersRules();
			this.availableTables = new List<string>()
			{
				"Not Submitted",
				"Submitted, Not Approved",
				"Approved",
				"Archived"
			};
			this.cbxTable.ItemsSource = this.availableTables;
			foreach (TimesheetCode timesheetCode in this.queries.TimesheetCodeAll())
			{
				this.cbxTimesheetCode.Items.Add(timesheetCode);
			}
			foreach (string str in this.queries.TaskTypes())
			{
				this.cbxTaskType.Items.Add(str);
			}
			foreach (Project project in this.queries.ProjectAll())
			{
				if (!this.functions.IntToBool(project.IsOpen))
				{
					continue;
				}
				this.cbxProject.Items.Add(project.Number_Serial);
			}
			this.cbxTimesheetCode.DisplayMemberPath = "Code_Description";
			this.cbxTimesheetCode.SelectedValuePath = "Code";
		}

		private void LoadUsersRules()
		{
			this.users = new List<User>();
			if ((this.functions.IntToBool(this.user.IsValidator) ? true : this.functions.IntToBool(this.user.IsAdmin)))
			{
				this.chbxUserNameSelectAll.IsChecked = new bool?(true);
				this.users = (
					from X in this.queries.GetUser_All()
					where this.functions.IntToBool(X.IsActive)
					orderby X.UserName
					select X).ToList<User>();
				this.cbxUserName.ItemsSource = this.users;
			}
			else
			{
				this.users.Add(this.user);
				this.chbxUserNameSelectAll.Visibility = System.Windows.Visibility.Hidden;
				this.cbxUserName.SelectedItem = this.user;
				this.cbxUserName.ItemsSource = this.users;
			}
			this.cbxUserName.DisplayMemberPath = "UserName";
		}

		private List<string> SelectedTables()
		{
			this.selectedTables = new List<string>();
			string str = "";
			if (this.cbxTable.SelectedValue != null)
			{
				str = this.cbxTable.SelectedValue.ToString();
			}
			bool? isChecked = this.chbxTableSelectAll.IsChecked;
			if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) != 0)
			{
				this.selectedTables.Add(this.queries.t_Timesheet_Prelim);
				this.selectedTables.Add(this.queries.t_Timesheet_Limbo);
				this.selectedTables.Add(this.queries.t_Timesheet_Final);
				this.selectedTables.Add(this.queries.t_Timesheet_Archive);
			}
			else if (this.cbxTable.SelectedItem.ToString() == "Not Submitted")
			{
				this.selectedTables.Add(this.queries.t_Timesheet_Prelim);
			}
			else if (this.cbxTable.SelectedItem.ToString() == "Submitted, Not Approved")
			{
				this.selectedTables.Add(this.queries.t_Timesheet_Limbo);
			}
			else if (this.cbxTable.SelectedItem.ToString() == "Approved")
			{
				this.selectedTables.Add(this.queries.t_Timesheet_Final);
			}
			else if (this.cbxTable.SelectedItem.ToString() == "Archived")
			{
				this.selectedTables.Add(this.queries.t_Timesheet_Archive);
			}
			return this.selectedTables;
		}

		private List<User> SelectedUsers()
		{
			this.selectedUsers = new List<User>();
			bool? isChecked = this.chbxUserNameSelectAll.IsChecked;
			if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) != 0)
			{
				this.selectedUsers = this.users;
			}
			else if (this.cbxUserName.SelectedItem != null)
			{
				this.selectedUsers.Add((User)this.cbxUserName.SelectedValue);
			}
			else
			{
				this.selectedUsers = this.users;
			}
			return this.selectedUsers;
		}

		private void UpdateSections()
		{
			// string str = null;
			this.cbxSection.Items.Clear();
			if ((this.cbxProject.SelectedItem == null ? false : this.cbxTaskType.SelectedItem != null))
			{
				if ((this.cbxProject.SelectedItem.ToString() == "" ? false : !(this.cbxTaskType.SelectedItem.ToString() == "")))
				{
					string str1 = this.cbxProject.SelectedItem.ToString();
					string str2 = this.cbxTaskType.SelectedItem.ToString();
					if (!this.queries.ProjectIsOpen(str1))
					{
						foreach (string str in this.queries.SectionNumbers(this.queries.ProjectNumber_WarrantyNetwork(str1), str2))
						{
							this.cbxSection.Items.Add(str);
						}
					}
					else
					{
						foreach (string str3 in this.queries.SectionNumbers(this.queries.ProjectNumber_Network(str1), str2))
						{
							this.cbxSection.Items.Add(str3);
						}
					}
				}
			}
		}
	}
}