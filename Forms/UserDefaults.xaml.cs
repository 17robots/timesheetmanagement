using FivesBronxTimesheetManagement.Classes;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class UserDefaults : Window
	{
		private Queries queries = new Queries();

		private User user;

		private User_Defaults user_Defaults;

		public UserDefaults(FivesBronxTimesheetManagement.Classes.User User)
		{
			this.user = User;
			this.user_Defaults = new User_Defaults(this.user);
			this.InitializeComponent();
			this.LoadConstantsFromDb();
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			base.DialogResult = new bool?(false);
		}

		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			if (this.cbxTimesheetCode.SelectedItem == null)
			{
				this.user_Defaults.TimesheetCode = null;
			}
			else
			{
				this.user_Defaults.TimesheetCode = (TimesheetCode)this.cbxTimesheetCode.SelectedItem;
			}
			if (this.cbxTaskType.SelectedItem == null)
			{
				this.user_Defaults.TaskType = "";
			}
			else
			{
				this.user_Defaults.TaskType = this.cbxTaskType.SelectedValue.ToString();
			}
			if (this.cbxProject.SelectedItem == null)
			{
				this.user_Defaults.Project = null;
			}
			else
			{
				this.user_Defaults.Project = (Project)this.cbxProject.SelectedItem;
			}
			this.queries.UpdateUserDefaults(this.user_Defaults);
			base.DialogResult = new bool?(true);
		}

		private void btnProject_Click(object sender, RoutedEventArgs e)
		{
			this.cbxProject.SelectedItem = null;
		}

		private void btnTaskType_Click(object sender, RoutedEventArgs e)
		{
			this.cbxTaskType.SelectedItem = null;
		}

		private void btnTimesheetCode_Click(object sender, RoutedEventArgs e)
		{
			this.cbxTimesheetCode.SelectedItem = null;
		}

		private void LoadConstantsFromDb()
		{
			this.cbxProject.DisplayMemberPath = "Serial_Customer_Machine";
			this.cbxProject.SelectedValuePath = "Serial_Customer_Machine";
			this.cbxTimesheetCode.DisplayMemberPath = "Code_Description";
			this.cbxTimesheetCode.SelectedValuePath = "Code_Description";
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
				this.cbxProject.Items.Add(project);
			}
			if (this.user_Defaults.TimesheetCode != null)
			{
				this.cbxTimesheetCode.SelectedValue = this.user_Defaults.TimesheetCode.Code_Description;
			}
			if (!string.IsNullOrEmpty(this.user_Defaults.TaskType))
			{
				this.cbxTaskType.SelectedValue = this.user_Defaults.TaskType;
			}
			if (this.user_Defaults.Project != null)
			{
				this.cbxProject.SelectedValue = this.user_Defaults.Project.Serial_Customer_Machine;
			}
		}
	}
}