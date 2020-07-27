using FivesBronxTimesheetManagement.Classes;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Markup;

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
            this.InitializeComponent();
            this.user = User;
            this.queries = new Queries();
            this.functions = new Functions();
            this.LoadConstantsFromDB();
            this.table.SelectedItem = this.table.Items[0]; // force at least one to be selected
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            base.Close();
        }

        private void btn_generate_Click(object sender, RoutedEventArgs e)
        {
            this.export = new ExportToExcel<Entry, List<Entry>>()
            {
                dataToPrint = this.GetEntries(this.SelectedUsers(), this.SelectedTables())
            };
            this.export.GenerateReport();
        }

        private void task_type_ItemSelectionChanged(object sender, SelectionChangedEventArgs e) // used
        {
            this.UpdateSections();
        }

        private void project_ItemSelectionChanged(object sender, SelectionChangedEventArgs e) // used
        {
            this.UpdateSections();
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

            if(timesheet_code.SelectedItems != null)
            {
                tTimesheetCTimesheetCode = new string[] { " AND ", this.queries.t_Timesheet_Codes_c_Timesheet_Code, " in (", string.Join(",", timesheet_code.SelectedItems), ")'" };
                str = string.Concat(tTimesheetCTimesheetCode);
            }

            if(task_type.SelectedItems != null)
            {
                tTimesheetCTimesheetCode = new string[] { " AND ", this.queries.t_Timesheet_c_Task_Type, " in (", string.Join(",", task_type.SelectedItems), ")'" };
                str1 = string.Concat(tTimesheetCTimesheetCode);
            }

            if(projectSelect.SelectedItems != null)
            {
                tTimesheetCTimesheetCode = new string[] { " AND ", this.queries.t_Timesheet_c_Project_Serial, " in (", string.Join(",", projectSelect.SelectedItems), ")'" };
                str2 = string.Concat(tTimesheetCTimesheetCode);
            }

            if(section.SelectedItems != null)
            {
                tTimesheetCTimesheetCode = new string[] { " AND ", this.queries.t_Timesheet_c_Number_Section, " in (", string.Join(",", section.SelectedItems), ")'" };
                str3 = string.Concat(tTimesheetCTimesheetCode);
            }

            if(from.SelectedDate.HasValue)
            {
                hasValue = false;
            }
            else
            {
                selectedDate = this.to.SelectedDate;
                hasValue = !selectedDate.HasValue;
            }
            if(!hasValue)
            {
                if(this.from.SelectedDate.HasValue)
                {
                    flag = true;
                }
                else
                {
                    selectedDate = this.to.SelectedDate;
                    flag = !selectedDate.HasValue;
                }
                if(flag)
                {
                    if(!this.from.SelectedDate.HasValue)
                    {
                        hasValue1 = true;
                    }
                    else
                    {
                        selectedDate = this.to.SelectedDate;
                        hasValue1 = this.to.SelectedDate.HasValue;
                    }
                    if(hasValue1)
                    {
                        tTimesheetCTimesheetCode = new string[] { " AND ", this.queries.t_Timesheet_c_Date, ">= '", 
                            from.SelectedDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), "' AND ", 
                            this.queries.t_Timesheet_c_Date, "<= '", this.from.SelectedDate.Value.ToString("yyyy-MM-dd", 
                            CultureInfo.InvariantCulture), "'" };
                        str4 = string.Concat(tTimesheetCTimesheetCode);
                    }
                    else if(!this.from.SelectedDate.HasValue ? false : !this.to.SelectedDate.HasValue)
                    {
                        tTimesheetCTimesheetCode = new string[] { " AND ", this.queries.t_Timesheet_c_Date, "='", this.from.SelectedDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), "'" };
                        str4 = string.Concat(tTimesheetCTimesheetCode);
                    }
                }
                else
                {
                    tTimesheetCTimesheetCode = new string[] { " AND ", this.queries.t_Timesheet_c_Date, "='", this.to.SelectedDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), "'" };
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

        private void LoadConstantsFromDB()
        {
            this.LoadUsersRules();
            this.availableTables = new List<string>()
            {
                "Not Submitted",
                "Submitted, Not Approved",
                "Approved",
                "Archived"
            };

            table.ItemsSource = this.availableTables;
            foreach(TimesheetCode timesheetCode in this.queries.TimesheetCodeAll()) timesheet_code.Items.Add(timesheetCode);
            foreach (string str in this.queries.TaskTypes()) task_type.Items.Add(str);
            foreach (Project project in this.queries.ProjectAll()) if(this.functions.IntToBool(project.IsOpen)) projectSelect.Items.Add(project.Number_Serial);
            timesheet_code.DisplayMemberPath = "Code_Description";
            timesheet_code.SelectedValuePath = "Code";

        }

        private void LoadUsersRules()
        {
            this.users = new List<User>();
            if (this.functions.IntToBool(this.user.IsValidator) ? true : this.functions.IntToBool(user.IsAdmin))
            {
                this.user_name.ItemsSource = !(this.activeUsers.IsChecked ?? false) ? 
                    (
                        from X in this.queries.GetUser_All()
                        where this.functions.IntToBool(X.IsActive)
                        orderby X.UserName
                        select X
                    ).ToList<User>() :
                    (
                        from X in this.queries.GetUser_All()
                        orderby X.UserName
                        select X
                    ).ToList<User>();
            }
            else
            {
                this.users.Add(this.user);
                this.activeUsers.Visibility = System.Windows.Visibility.Hidden;
                this.user_name.SelectedItem = this.user;
                this.user_name.ItemsSource = this.users;
            }
        }

        private List<string> SelectedTables()
        {
            this.selectedTables = new List<string>();
            if(this.table.SelectedItems != null)
            {
                if (this.table.SelectedItems.Contains("Not Submitted")) this.selectedTables.Add(this.queries.t_Timesheet_Prelim);
                if (this.table.SelectedItems.Contains("Submitted, Not Approved")) this.selectedTables.Add(this.queries.t_Timesheet_Limbo);
                if (this.table.SelectedItems.Contains("Approved")) this.selectedTables.Add(this.queries.t_Timesheet_Final);
                if (this.table.SelectedItems.Contains("Archived")) this.selectedTables.Add(this.queries.t_Timesheet_Archive);
            }
            else
            {
                this.selectedTables.Add(this.queries.t_Timesheet_Prelim);
                this.selectedTables.Add(this.queries.t_Timesheet_Limbo);
                this.selectedTables.Add(this.queries.t_Timesheet_Final);
                this.selectedTables.Add(this.queries.t_Timesheet_Archive);
            }

            return this.selectedTables;
        }

        private void table_ItemSelectionChanged(object sender, SelectionChangedEventArgs e) // used
        {
            this.selectedTables = SelectedTables();
        }

        private void activeUsers_CheckedChanged(object sender, EventArgs e) //used 
        {
            this.LoadUsersRules();
        }

        private List<User> SelectedUsers()
        {
            this.selectedUsers = new List<User>();
            if(this.user_name.SelectedItems != null)
            {
                foreach(User user in this.user_name.SelectedItems)
                {
                    this.selectedUsers.Add(user);
                }
            }
            else
            {
                foreach(User user in this.user_name.Items)
                {
                    this.selectedUsers.Add(user);
                }
            }
            return selectedUsers;
        }

        private void user_name_ItemSelectionChanged(object sender, SelectionChangedEventArgs e) // used 
        {
            this.selectedUsers = SelectedUsers();
        }

        private void UpdateSections()
        {
            this.section.Items.Clear();
            if(this.projectSelect.SelectedItems != null || this.section.SelectedItems != null)
            {
                if(this.projectSelect.SelectedItems != null)
                {

                    List<string> openProjects = new List<string>();
                    foreach(string x in this.projectSelect.SelectedItems)
                    {
                        if (this.queries.ProjectIsOpen(x)) openProjects.Add(x);
                    }

                    if(this.task_type.SelectedItems != null)
                    {
                        foreach (string x in openProjects)
                        {
                            foreach(string y in this.task_type.SelectedItems)
                            {
                                foreach(string z in this.queries.SectionNumbers(this.queries.ProjectNumber_WarrantyNetwork(x), y))
                                {
                                    this.section.Items.Add(z);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (string x in openProjects)
                        {
                            foreach (string y in this.queries.SectionNumbers(this.queries.ProjectNumber_WarrantyNetwork(x)))
                            {
                                this.section.Items.Add(y);
                            }
                        }
                    }
                }
                else
                {
                    List<string> openProjects = new List<string>();
                    foreach (string x in this.projectSelect.Items)
                    {
                        if (this.queries.ProjectIsOpen(x)) openProjects.Add(x);
                    }
                    
                    foreach(string x in openProjects)
                    {
                        foreach(string y in this.task_type.SelectedItems)
                        {
                            foreach(string z in this.queries.SectionNumbers(this.queries.ProjectNumber_WarrantyNetwork(x), y))
                            {
                                this.section.Items.Add(z);
                            }
                        }
                    }
                }
            }
            else
            {
                List<string> openProjects = new List<string>();
                foreach (string x in this.projectSelect.Items)
                {
                    if (this.queries.ProjectIsOpen(x)) openProjects.Add(x);
                }

                foreach(string x in openProjects)
                {
                    foreach(string y in this.queries.SectionNumbers(this.queries.ProjectNumber_WarrantyNetwork(x)))
                    {
                        this.section.Items.Add(y);
                    }
                }
            }
        }
    }
}
