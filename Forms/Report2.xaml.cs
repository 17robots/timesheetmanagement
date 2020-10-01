using FivesBronxTimesheetManagement.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace FivesBronxTimesheetManagement.Forms
{
    public partial class Report2 : Window
    {
        private Queries2 queries = new Queries2();

        private Functions functions;

        private List<User> users;

        private List<User> selectedUsers;

        private List<string> availableTables;

        private List<string> selectedTables;

        private List<string> colNames;

        private ExportToExcel<Entry, List<Entry>> export;

        private User user;

        public Report2(User User)
        {
            InitializeComponent();
            user = User;
            queries = new Queries2();
            functions = new Functions();
            LoadConstantsFromDB();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_generate_Click(object sender, RoutedEventArgs e)
        {
            export = new ExportToExcel<Entry, List<Entry>>()
            {
                dataToPrint = GetEntries(SelectedUsers(), SelectedTables())
            };

            if(singleUserReport.IsChecked ?? false)
            {
                if (columns.SelectedItems.Count != 0)
                {
                    List<string> filteredCols = new List<string>();
                    foreach (string prop in columns.SelectedItems) filteredCols.Add(prop);
                    export.GenerateReport(SelectedUsers(), filteredCols);
                }
                else export.GenerateReport(SelectedUsers());
            }
            else if((singleUserReport.IsChecked ?? false) == false)
            {
                if (columns.SelectedItems.Count != 0)
                {
                    List<string> filteredCols = new List<string>();
                    foreach (string prop in columns.SelectedItems) filteredCols.Add(prop);
                    export.GenerateReport(filteredCols);
                }
                else export.GenerateReport();
            }
        }

        private List<string> CreateListQString(List<string> _tables, List<User> _users)
        {
            string[] tTimesheetCTimesheetCode;
            DateTime? selectedDate;
            bool hasValue;
            bool flag;
            bool hasValue1;
            List<string> strs = new List<string>();
            string str = "";
            string str1 = "";
            string str2 = "";
            string str4 = "";
            string listString;

            if (timesheet_code.SelectedItems.Count != 0)
            {
                listString = "";
                foreach(var item in timesheet_code.SelectedItems)
                {
                    listString += "'";
                    listString += (item as TimesheetCode).Code;
                    listString += "',";
                }

                listString = listString.Substring(0, listString.Length - 1);

                tTimesheetCTimesheetCode = new string[] { " AND ", queries.t_Timesheet_Codes_c_Timesheet_Code, " in (", listString, ")" };
                str = string.Concat(tTimesheetCTimesheetCode);
            }

            if (task_type.SelectedItems.Count != 0)
            {
                listString = "";
                foreach (var item in task_type.SelectedItems)
                {
                    listString += "'";
                    listString += item;
                    listString += "',";
                }

                listString = listString.Substring(0, listString.Length - 1);

                tTimesheetCTimesheetCode = new string[] { " AND ", queries.t_Timesheet_c_Task_Type, " in (", listString, ")" };
                str1 = string.Concat(tTimesheetCTimesheetCode);
            }

            if (projectSelect.SelectedItems.Count != 0)
            {
                listString = "";
                foreach (var item in projectSelect.SelectedItems)
                {
                    listString += "'";
                    listString += item;
                    listString += "',";
                }

                listString = listString.Substring(0, listString.Length - 1);

                tTimesheetCTimesheetCode = new string[] { " AND ", queries.t_Timesheet_c_Project_Serial, " in (", listString, ")" };
                str2 = string.Concat(tTimesheetCTimesheetCode);
            }

            if (from.SelectedDate.HasValue)
            {
                hasValue = false;
            }
            else
            {
                selectedDate = to.SelectedDate;
                hasValue = !selectedDate.HasValue;
            }
            if (!hasValue)
            {
                if (from.SelectedDate.HasValue)
                {
                    flag = true;
                }
                else
                {
                    selectedDate = to.SelectedDate;
                    flag = !selectedDate.HasValue;
                }
                if (flag)
                {
                    if (!from.SelectedDate.HasValue)
                    {
                        hasValue1 = true;
                    }
                    else
                    {
                        selectedDate = to.SelectedDate;
                        hasValue1 = to.SelectedDate.HasValue;
                    }
                    if (hasValue1)
                    {
                        tTimesheetCTimesheetCode = new string[] { " AND ", queries.t_Timesheet_c_Date, ">= '",
                            to.SelectedDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), "' AND ",
                            queries.t_Timesheet_c_Date, "<= '", from.SelectedDate.Value.ToString("yyyy-MM-dd",
                            CultureInfo.InvariantCulture), "'" };
                        str4 = string.Concat(tTimesheetCTimesheetCode);
                    }
                    else if (!from.SelectedDate.HasValue ? false : !to.SelectedDate.HasValue)
                    {
                        tTimesheetCTimesheetCode = new string[] { " AND ", queries.t_Timesheet_c_Date, "='", from.SelectedDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), "'" };
                        str4 = string.Concat(tTimesheetCTimesheetCode);
                    }
                }
                else
                {
                    tTimesheetCTimesheetCode = new string[] { " AND ", queries.t_Timesheet_c_Date, "='", to.SelectedDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), "'" };
                    str4 = string.Concat(tTimesheetCTimesheetCode);
                }
            }
            foreach (User _user in _users)
            {
                foreach (string _table in _tables)
                {
                    object[] userID = new object[] { "SELECT * FROM ", _table, " WHERE user_id = '", _user.UserID, "'", str, str1, str2, str4 };
                    strs.Add(string.Concat(userID));
                }
            }
            return strs;
        }

        private List<Entry> GetEntries(List<User> Users, List<string> Tables)
        {
            List<Entry> entries = new List<Entry>();
            foreach(string table in Tables)
            {
                List<string> strs = new List<string>()
                {
                    table
                };
                foreach (Entry entry in queries.Entries(CreateListQString(strs, Users)))
                {
                    entries.Add(entry);
                }
            }
            return entries;
        }

        private void LoadConstantsFromDB()
        {
            List<string> userDisplayOptions = new List<string>()
            {
                "Show Approvees",
                "Show Active Users",
                "Show All Users"
            };

            List<string> datePresetDisplayOptions = new List<string>()
            {
                "Use Custom Range",
                "Today",
                "Week To Date",
                "Month To Date",
                "Year To Date"
            };

            datePreset.ItemsSource = datePresetDisplayOptions;
            datePreset.SelectedIndex = 0;

            userSelect.ItemsSource = userDisplayOptions;
            userSelect.SelectedIndex = 0;

            LoadUsersRules();
            availableTables = new List<string>()
            {
                "Not Submitted",
                "Submitted, Not Approved",
                "Approved",
                "Archived"
            };

            table.ItemsSource = availableTables;
            foreach(TimesheetCode timesheetCode in queries.TimesheetCodeAll()) timesheet_code.Items.Add(timesheetCode);
            foreach (string str in queries.TaskTypes()) task_type.Items.Add(str);
            foreach (Project project in queries.ProjectAll()) if(functions.IntToBool(project.IsOpen)) projectSelect.Items.Add(project.Number_Serial);
            timesheet_code.DisplayMemberPath = "Code_Description";
            timesheet_code.SelectedValuePath = "Code";

            colNames = new List<string>();

            foreach(PropertyInfo prop in typeof(Entry).GetProperties())
            {
                colNames.Add(prop.Name);
            }

            columns.ItemsSource = colNames;
        }

        private void LoadUsersRules()
        {
            users = new List<User>();
            if (functions.IntToBool(user.IsValidator) ? true : functions.IntToBool(user.IsAdmin))
            {
                switch(userSelect.SelectedItem.ToString())
                {
                    case "Show Approvees":
                        user_name.ItemsSource = 
                        (
                            from X in queries.User_GetApprovees(user)
                            where functions.IntToBool(X.IsActive)
                            orderby X.UserName
                            select X
                        ).ToList();
                        break;
                    case "Show Active Users":
                        user_name.ItemsSource =
                        (
                            from X in queries.GetUser_All()
                            where functions.IntToBool(X.IsActive)
                            orderby X.UserName
                            select X
                        ).ToList();
                        break;
                    case "Show All Users":
                        user_name.ItemsSource =
                        (
                            from X in queries.GetUser_All()
                            orderby X.UserName
                            select X
                        ).ToList();
                        break;
                }
            }
            else
            {
                users.Add(user);
                userSelect.Visibility = Visibility.Hidden;
                user_name.SelectedItem = user;
                user_name.ItemsSource = users;
            }
            user_name.DisplayMemberPath = "UserName";
        }

        private List<string> SelectedTables()
        {
            selectedTables = new List<string>();
            if(table.SelectedItems.Count != 0)
            {
                if (table.SelectedItems.Contains("Not Submitted")) selectedTables.Add(queries.t_Timesheet_Prelim);
                if (table.SelectedItems.Contains("Submitted, Not Approved")) selectedTables.Add(queries.t_Timesheet_Limbo);
                if (table.SelectedItems.Contains("Approved")) selectedTables.Add(queries.t_Timesheet_Final);
                if (table.SelectedItems.Contains("Archived")) selectedTables.Add(queries.t_Timesheet_Archive);
            }
            else
            {
                selectedTables.Add(queries.t_Timesheet_Prelim);
                selectedTables.Add(queries.t_Timesheet_Limbo);
                selectedTables.Add(queries.t_Timesheet_Final);
                selectedTables.Add(queries.t_Timesheet_Archive);
            }
            return selectedTables;
        }

        private void table_ItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTables = SelectedTables();
        }

        private void userSelect_SelectionChanged(object sender, EventArgs e) //used 
        {
            LoadUsersRules();
        }

        private void datePreset_ItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(datePreset.SelectedItem.ToString())
            {
                case "Today":
                    to.SelectedDate = DateTime.Today;
                    from.SelectedDate = DateTime.Today;
                    to.IsEnabled = false;
                    from.IsEnabled = false;
                    break;
                case "Week To Date":
                    to.SelectedDate = DateTime.Today.AddDays(-7);
                    from.SelectedDate = DateTime.Today;
                    to.IsEnabled = false;
                    from.IsEnabled = false;
                    break;
                case "Month To Date":
                    to.SelectedDate = DateTime.Today.AddMonths(-1);
                    from.SelectedDate = DateTime.Today;
                    to.IsEnabled = false;
                    from.IsEnabled = false;
                    break;
                case "Year To Date":
                    to.SelectedDate = DateTime.Parse("01/01");
                    from.SelectedDate = DateTime.Today;
                    to.IsEnabled = false;
                    from.IsEnabled = false;
                    break;
                default:
                    to.SelectedDate = null ;
                    from.SelectedDate = null;
                    to.IsEnabled = true;
                    from.IsEnabled = true;
                    break;
            }
        }

        private void generalReport_CheckedChanged(object sender, EventArgs e)
        {
            if(generalReport.IsChecked ?? false)
            {
                columns.SelectedItems.Add(columns.Items[columns.Items.IndexOf("user_id")].ToString());
                columns.SelectedItems.Add(columns.Items[columns.Items.IndexOf("user_name")].ToString());
                columns.SelectedItems.Add(columns.Items[columns.Items.IndexOf("project_sap")].ToString());
                columns.SelectedItems.Add(columns.Items[columns.Items.IndexOf("number_network")].ToString());
                columns.SelectedItems.Add(columns.Items[columns.Items.IndexOf("number_activity")].ToString());
                columns.SelectedItems.Add(columns.Items[columns.Items.IndexOf("date")].ToString());
                columns.SelectedItems.Add(columns.Items[columns.Items.IndexOf("hours")].ToString());
                columns.SelectedItems.Add(columns.Items[columns.Items.IndexOf("description")].ToString());
            }
            else
            {
                columns.SelectedItems.Clear();
            }
        }

        private List<User> SelectedUsers()
        {
            selectedUsers = new List<User>();
            if(user_name.SelectedItems.Count != 0)
            {
                foreach(User user in user_name.SelectedItems)
                {
                    selectedUsers.Add((User)user);
                }
            }
            else
            {
                foreach(User user in user_name.Items)
                {
                    selectedUsers.Add(user);
                }
            }
            return selectedUsers;
        }

        private void user_name_ItemSelectionChanged(object sender, SelectionChangedEventArgs e) // used 
        {
            selectedUsers = SelectedUsers();
        }

        private void userSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadUsersRules();
        }
    }
}
