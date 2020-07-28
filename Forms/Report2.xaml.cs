using FivesBronxTimesheetManagement.Classes;
using Google.Protobuf.Collections;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FivesBronxTimesheetManagement.Forms
{
    public partial class Report2 : Window
    {
        private Queries queries;

        private Functions functions;

        private List<User> users;

        private List<User> selectedUsers;

        private List<string> availableTables;

        private List<string> selectedTables;

        private ExportToExcel<Entry, List<Entry>> export;

        private User user;

        public Report2(User User)
        {
            InitializeComponent();
            user = User;
            queries = new Queries();
            functions = new Functions();
            LoadConstantsFromDB();
            table.SelectedItem = table.Items[0]; // force at least one to be selected
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            base.Close();
        }

        private void btn_generate_Click(object sender, RoutedEventArgs e)
        {
            export = new ExportToExcel<Entry, List<Entry>>()
            {
                dataToPrint = GetEntries(SelectedUsers(), SelectedTables())
            };
            export.GenerateReport();
        }

        private void task_type_ItemSelectionChanged(object sender, SelectionChangedEventArgs e) // used
        {
            UpdateSections();
        }

        private void project_ItemSelectionChanged(object sender, SelectionChangedEventArgs e) // used
        {
            UpdateSections();
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
            string str3 = "";
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

            if (section.SelectedItems.Count != 0)
            {
                listString = "";
                foreach (var item in section.SelectedItems)
                {
                    listString += "'";
                    listString += item;
                    listString += "',";
                }

                listString = listString.Substring(0, listString.Length - 1);

                tTimesheetCTimesheetCode = new string[] { " AND ", queries.t_Timesheet_c_Number_Section, " in (", listString, ")" };
                str3 = string.Concat(tTimesheetCTimesheetCode);
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
                            from.SelectedDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), "' AND ",
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
                    object[] userID = new object[] { "SELECT * FROM ", _table, " WHERE user_id = '", _user.UserID, "'", str, str1, str2, str3, str4 };
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
                MessageBox.Show(table);
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

        private void LoadConstantsFromDB()
        {
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

        }

        private void LoadUsersRules()
        {
            users = new List<User>();
            if (functions.IntToBool(user.IsValidator) ? true : functions.IntToBool(user.IsAdmin))
            {
                user_name.ItemsSource = !(activeUsers.IsChecked ?? false) ? 
                    (
                        from X in queries.GetUser_All()
                        where functions.IntToBool(X.IsActive)
                        orderby X.UserName
                        select X
                    ).ToList<User>() :
                    (
                        from X in queries.GetUser_All()
                        orderby X.UserName
                        select X
                    ).ToList<User>();
            }
            else
            {
                users.Add(user);
                activeUsers.Visibility = System.Windows.Visibility.Hidden;
                user_name.SelectedItem = user;
                user_name.ItemsSource = users;
            }
            user_name.DisplayMemberPath = "UserName";
        }

        private List<string> SelectedTables()
        {
            selectedTables = new List<string>();
            if(table.SelectedItems != null)
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

        private void table_ItemSelectionChanged(object sender, SelectionChangedEventArgs e) // used
        {
            selectedTables = SelectedTables();
        }

        private void activeUsers_CheckedChanged(object sender, EventArgs e) //used 
        {
            LoadUsersRules();
        }

        private List<User> SelectedUsers()
        {
            selectedUsers = new List<User>();
            if(user_name.SelectedItems != null)
            {
                foreach(User user in user_name.SelectedItems)
                {
                    selectedUsers.Add(user);
                    Console.WriteLine(user);
                }
            }
            else
            {
                foreach(User user in user_name.Items)
                {
                    selectedUsers.Add(user);
                    Console.WriteLine(user);
                }
            }
            return selectedUsers;
        }

        private void user_name_ItemSelectionChanged(object sender, SelectionChangedEventArgs e) // used 
        {
            selectedUsers = SelectedUsers();
        }

        private void UpdateSections()
        {
            section.Items.Clear();
            if(projectSelect.SelectedItems != null || section.SelectedItems != null)
            {
                if(projectSelect.SelectedItems != null)
                {

                    List<string> openProjects = new List<string>();
                    foreach(string x in projectSelect.SelectedItems)
                    {
                        if (queries.ProjectIsOpen(x)) openProjects.Add(x);
                    }

                    if(task_type.SelectedItems != null)
                    {
                        foreach (string x in openProjects)
                        {
                            foreach(string y in task_type.SelectedItems)
                            {
                                foreach(string z in queries.SectionNumbers(queries.ProjectNumber_WarrantyNetwork(x), y))
                                {
                                    section.Items.Add(z);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (string x in openProjects)
                        {
                            foreach (string y in queries.SectionNumbers(queries.ProjectNumber_WarrantyNetwork(x)))
                            {
                                section.Items.Add(y);
                            }
                        }
                    }
                }
                else
                {
                    List<string> openProjects = new List<string>();
                    foreach (string x in projectSelect.Items)
                    {
                        if (queries.ProjectIsOpen(x)) openProjects.Add(x);
                    }
                    
                    foreach(string x in openProjects)
                    {
                        foreach(string y in task_type.SelectedItems)
                        {
                            foreach(string z in queries.SectionNumbers(queries.ProjectNumber_WarrantyNetwork(x), y))
                            {
                                section.Items.Add(z);
                            }
                        }
                    }
                }
            }
            else
            {
                List<string> openProjects = new List<string>();
                foreach (string x in projectSelect.Items)
                {
                    if (queries.ProjectIsOpen(x)) openProjects.Add(x);
                }

                foreach(string x in openProjects)
                {
                    foreach(string y in queries.SectionNumbers(queries.ProjectNumber_WarrantyNetwork(x)))
                    {
                        section.Items.Add(y);
                    }
                }
            }
        }
    }
}
