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
			InitializeComponent();
			user = User;
			queries = new Queries();
			functions = new Functions();
			LoadConstantsFromDb();
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			export = new ExportToExcel<Entry, List<Entry>>()
			{
				dataToPrint = GetEntries(SelectedUsers(), SelectedTables())
			};
			export.GenerateReport();
		}

		private void cbxProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (cbxProject.SelectedItem != null)
			{
				chbxProjectSelectAll.IsChecked = new bool?(false);
				UpdateSections();
			}
		}

		private void cbxSection_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (cbxSection.SelectedItem != null)
			{
				chbxSectionSelectAll.IsChecked = new bool?(false);
			}
		}

		private void cbxTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (cbxTable.SelectedItem != null)
			{
				chbxTableSelectAll.IsChecked = new bool?(false);
			}
		}

		private void cbxTaskType_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (cbxTaskType.SelectedItem != null)
			{
				chbxTaskTypeSelectAll.IsChecked = new bool?(false);
			}
		}

		private void cbxTimesheetCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (cbxTimesheetCode.SelectedItem != null)
			{
				chbxTimesheetCodeSelectAll.IsChecked = new bool?(false);
			}
		}

		private void cbxUserName_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (cbxUserName.SelectedItem != null)
			{
				chbxUserNameSelectAll.IsChecked = new bool?(false);
			}
		}

		private void chbxProjectSelectAll_CheckedChanged(object sender, RoutedEventArgs e)
		{
			bool? isChecked = chbxProjectSelectAll.IsChecked;
			if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) == 0)
			{
				isChecked = chbxProjectSelectAll.IsChecked;
				if (((isChecked.GetValueOrDefault() ? true : !isChecked.HasValue) ? false : cbxProject.SelectedItem == null))
				{
					chbxProjectSelectAll.IsChecked = new bool?(true);
				}
			}
			else
			{
				cbxProject.SelectedItem = null;
			}
		}

		private void chbxSectionSelectAll_CheckedChanged(object sender, RoutedEventArgs e)
		{
			bool? isChecked = chbxSectionSelectAll.IsChecked;
			if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) == 0)
			{
				isChecked = chbxSectionSelectAll.IsChecked;
				if (((isChecked.GetValueOrDefault() ? true : !isChecked.HasValue) ? false : cbxSection.SelectedItem == null))
				{
					chbxSectionSelectAll.IsChecked = new bool?(true);
				}
			}
			else
			{
				cbxSection.SelectedItem = null;
			}
		}

		private void chbxTableSelectAll_CheckedChanged(object sender, RoutedEventArgs e)
		{
			bool? isChecked = chbxTableSelectAll.IsChecked;
			if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) == 0)
			{
				isChecked = chbxTableSelectAll.IsChecked;
				if (((isChecked.GetValueOrDefault() ? true : !isChecked.HasValue) ? false : cbxTable.SelectedItem == null))
				{
					chbxTableSelectAll.IsChecked = new bool?(true);
				}
			}
			else
			{
				cbxTable.SelectedItem = null;
			}
		}

		private void chbxTaskTypeSelectAll_CheckedChanged(object sender, RoutedEventArgs e)
		{
			bool? isChecked = chbxTaskTypeSelectAll.IsChecked;
			if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) == 0)
			{
				isChecked = chbxTaskTypeSelectAll.IsChecked;
				if (((isChecked.GetValueOrDefault() ? true : !isChecked.HasValue) ? false : cbxTaskType.SelectedItem == null))
				{
					chbxTaskTypeSelectAll.IsChecked = new bool?(true);
				}
			}
			else
			{
				cbxTaskType.SelectedItem = null;
			}
		}

		private void chbxTimesheetCodeSelectAll_CheckedChanged(object sender, RoutedEventArgs e)
		{
			bool? isChecked = chbxTimesheetCodeSelectAll.IsChecked;
			if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) == 0)
			{
				isChecked = chbxTimesheetCodeSelectAll.IsChecked;
				if (((isChecked.GetValueOrDefault() ? true : !isChecked.HasValue) ? false : cbxTimesheetCode.SelectedItem == null))
				{
					chbxTimesheetCodeSelectAll.IsChecked = new bool?(true);
				}
			}
			else
			{
				cbxTimesheetCode.SelectedItem = null;
			}
		}

		private void chbxUserNameSelectAll_CheckedChanged(object sender, RoutedEventArgs e)
		{
			bool? isChecked = chbxUserNameSelectAll.IsChecked;
			if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) == 0)
			{
				isChecked = chbxUserNameSelectAll.IsChecked;
				if (((isChecked.GetValueOrDefault() ? true : !isChecked.HasValue) ? false : cbxUserName.SelectedItem == null))
				{
					chbxUserNameSelectAll.IsChecked = new bool?(true);
				}
			}
			else
			{
				cbxUserName.SelectedItem = null;
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
			if (cbxTimesheetCode.SelectedItem != null)
			{
				tTimesheetCTimesheetCode = new string[] { " AND ", queries.t_Timesheet_c_Timesheet_Code, "= '", cbxTimesheetCode.SelectedValue.ToString(), "'" };
				str = string.Concat(tTimesheetCTimesheetCode);
			}
			if (cbxTaskType.SelectedItem != null)
			{
				tTimesheetCTimesheetCode = new string[] { " AND ", queries.t_Timesheet_c_Task_Type, "= '", cbxTaskType.SelectedItem.ToString(), "'" };
				str1 = string.Concat(tTimesheetCTimesheetCode);
			}
			if (cbxProject.SelectedItem != null)
			{
				tTimesheetCTimesheetCode = new string[] { " AND ", queries.t_Timesheet_c_Project_Serial, "= '", cbxProject.SelectedItem.ToString(), "'" };
				str2 = string.Concat(tTimesheetCTimesheetCode);
			}
			if (cbxSection.SelectedItem != null)
			{
				tTimesheetCTimesheetCode = new string[] { " AND ", queries.t_Timesheet_c_Number_Section, "= '", cbxSection.SelectedItem.ToString(), "'" };
				str3 = string.Concat(tTimesheetCTimesheetCode);
			}
			if (dtpFrom.SelectedDate.HasValue)
			{
				hasValue = false;
			}
			else
			{
				selectedDate = dtpTo.SelectedDate;
				hasValue = !selectedDate.HasValue;
			}
			if (!hasValue)
			{
				if (dtpFrom.SelectedDate.HasValue)
				{
					flag = true;
				}
				else
				{
					selectedDate = dtpTo.SelectedDate;
					flag = !selectedDate.HasValue;
				}
				if (flag)
				{
					if (!dtpFrom.SelectedDate.HasValue)
					{
						hasValue1 = true;
					}
					else
					{
						selectedDate = dtpTo.SelectedDate;
						hasValue1 = !selectedDate.HasValue;
					}
					if (!hasValue1)
					{
						tTimesheetCTimesheetCode = new string[] { " AND ", queries.t_Timesheet_c_Date, ">= '", null, null, null, null, null, null };
						value = dtpFrom.SelectedDate.Value;
						tTimesheetCTimesheetCode[3] = value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
						tTimesheetCTimesheetCode[4] = "' AND ";
						tTimesheetCTimesheetCode[5] = queries.t_Timesheet_c_Date;
						tTimesheetCTimesheetCode[6] = "<= '";
						value = dtpTo.SelectedDate.Value;
						tTimesheetCTimesheetCode[7] = value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
						tTimesheetCTimesheetCode[8] = "'";
						str4 = string.Concat(tTimesheetCTimesheetCode);
					}
					else if ((!dtpFrom.SelectedDate.HasValue ? false : !dtpTo.SelectedDate.HasValue))
					{
						tTimesheetCTimesheetCode = new string[] { " AND ", queries.t_Timesheet_c_Date, "='", null, null };
						value = dtpFrom.SelectedDate.Value;
						tTimesheetCTimesheetCode[3] = value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
						tTimesheetCTimesheetCode[4] = "'";
						str4 = string.Concat(tTimesheetCTimesheetCode);
					}
				}
				else
				{
					tTimesheetCTimesheetCode = new string[] { " AND ", queries.t_Timesheet_c_Date, "<= '", null, null };
					value = dtpTo.SelectedDate.Value;
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
				foreach (Entry entry in queries.Entries(table, queries.ReturnIntList(CreateListQString(strs, Users), queries.t_Timesheet_c_Entry_Id)))
				{
					entries.Add(entry);
				}
			}
			return entries;
		}

		private void LoadConstantsFromDb()
		{
			LoadUsersRules();
			availableTables = new List<string>()
			{
				"Not Submitted",
				"Submitted, Not Approved",
				"Approved",
				"Archived"
			};
			cbxTable.ItemsSource = availableTables;
			foreach (TimesheetCode timesheetCode in queries.TimesheetCodeAll())
			{
				cbxTimesheetCode.Items.Add(timesheetCode);
			}
			foreach (string str in queries.TaskTypes())
			{
				cbxTaskType.Items.Add(str);
			}
			foreach (Project project in queries.ProjectAll())
			{
				if (!functions.IntToBool(project.IsOpen))
				{
					continue;
				}
				cbxProject.Items.Add(project.Number_Serial);
			}
			cbxTimesheetCode.DisplayMemberPath = "Code_Description";
			cbxTimesheetCode.SelectedValuePath = "Code";
		}

		private void LoadUsersRules()
		{
			users = new List<User>();
			if ((functions.IntToBool(user.IsValidator) ? true : functions.IntToBool(user.IsAdmin)))
			{
				chbxUserNameSelectAll.IsChecked = new bool?(true);
				users = (
					from X in queries.GetUser_All()
					where functions.IntToBool(X.IsActive)
					orderby X.UserName
					select X).ToList<User>();
				cbxUserName.ItemsSource = users;
			}
			else
			{
				users.Add(user);
				chbxUserNameSelectAll.Visibility = System.Windows.Visibility.Hidden;
				cbxUserName.SelectedItem = user;
				cbxUserName.ItemsSource = users;
			}
			cbxUserName.DisplayMemberPath = "UserName";
		}

		private List<string> SelectedTables()
		{
			selectedTables = new List<string>();
			string str = "";
			if (cbxTable.SelectedValue != null)
			{
				str = cbxTable.SelectedValue.ToString();
			}
			bool? isChecked = chbxTableSelectAll.IsChecked;
			if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) != 0)
			{
				selectedTables.Add(queries.t_Timesheet_Prelim);
				selectedTables.Add(queries.t_Timesheet_Limbo);
				selectedTables.Add(queries.t_Timesheet_Final);
				selectedTables.Add(queries.t_Timesheet_Archive);
			}
			else if (cbxTable.SelectedItem.ToString() == "Not Submitted")
			{
				selectedTables.Add(queries.t_Timesheet_Prelim);
			}
			else if (cbxTable.SelectedItem.ToString() == "Submitted, Not Approved")
			{
				selectedTables.Add(queries.t_Timesheet_Limbo);
			}
			else if (cbxTable.SelectedItem.ToString() == "Approved")
			{
				selectedTables.Add(queries.t_Timesheet_Final);
			}
			else if (cbxTable.SelectedItem.ToString() == "Archived")
			{
				selectedTables.Add(queries.t_Timesheet_Archive);
			}
			return selectedTables;
		}

		private List<User> SelectedUsers()
		{
			selectedUsers = new List<User>();
			bool? isChecked = chbxUserNameSelectAll.IsChecked;
			if ((!isChecked.GetValueOrDefault() ? 0 : Convert.ToInt32(isChecked.HasValue)) != 0)
			{
				selectedUsers = users;
			}
			else if (cbxUserName.SelectedItem != null)
			{
				selectedUsers.Add((User)cbxUserName.SelectedValue);
			}
			else
			{
				selectedUsers = users;
			}
			return selectedUsers;
		}

		private void UpdateSections()
		{
			// string str = null;
			cbxSection.Items.Clear();
			if ((cbxProject.SelectedItem == null ? false : cbxTaskType.SelectedItem != null))
			{
				if ((cbxProject.SelectedItem.ToString() == "" ? false : !(cbxTaskType.SelectedItem.ToString() == "")))
				{
					string str1 = cbxProject.SelectedItem.ToString();
					string str2 = cbxTaskType.SelectedItem.ToString();
					if (!queries.ProjectIsOpen(str1))
					{
						foreach (string str in queries.SectionNumbers(queries.ProjectNumber_WarrantyNetwork(str1), str2))
						{
							cbxSection.Items.Add(str);
						}
					}
					else
					{
						foreach (string str3 in queries.SectionNumbers(queries.ProjectNumber_Network(str1), str2))
						{
							cbxSection.Items.Add(str3);
						}
					}
				}
			}
		}
	}
}