using FivesBronxTimesheetManagement.Classes;
using System.Windows;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class UserDefaults : Window
	{
		private Queries2 queries = new Queries2();

		private User user;

		private User_Defaults user_Defaults;

		public UserDefaults(User User)
		{
			user = User;
			user_Defaults = new User_Defaults(user);
			InitializeComponent();
			LoadConstantsFromDb();
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			base.DialogResult = new bool?(false);
		}

		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			if (cbxTimesheetCode.SelectedItem == null)
			{
				user_Defaults.TimesheetCode = null;
			}
			else
			{
				user_Defaults.TimesheetCode = (TimesheetCode)cbxTimesheetCode.SelectedItem;
			}
			if (cbxTaskType.SelectedItem == null)
			{
				user_Defaults.TaskType = "";
			}
			else
			{
				user_Defaults.TaskType = cbxTaskType.SelectedValue.ToString();
			}
			if (cbxProject.SelectedItem == null)
			{
				user_Defaults.Project = null;
			}
			else
			{
				user_Defaults.Project = (Project)cbxProject.SelectedItem;
			}
			queries.UpdateUserDefaults(user_Defaults);
			base.DialogResult = new bool?(true);
		}

		private void btnProject_Click(object sender, RoutedEventArgs e)
		{
			cbxProject.SelectedItem = null;
		}

		private void btnTaskType_Click(object sender, RoutedEventArgs e)
		{
			cbxTaskType.SelectedItem = null;
		}

		private void btnTimesheetCode_Click(object sender, RoutedEventArgs e)
		{
			cbxTimesheetCode.SelectedItem = null;
		}

		private void LoadConstantsFromDb()
		{
			cbxProject.DisplayMemberPath = "Serial_Customer_Machine";
			cbxProject.SelectedValuePath = "Serial_Customer_Machine";
			cbxTimesheetCode.DisplayMemberPath = "Code_Description";
			cbxTimesheetCode.SelectedValuePath = "Code_Description";
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
				cbxProject.Items.Add(project);
			}
			if (user_Defaults.TimesheetCode != null)
			{
				cbxTimesheetCode.SelectedValue = user_Defaults.TimesheetCode.Code_Description;
			}
			if (!string.IsNullOrEmpty(user_Defaults.TaskType))
			{
				cbxTaskType.SelectedValue = user_Defaults.TaskType;
			}
			if (user_Defaults.Project != null)
			{
				cbxProject.SelectedValue = user_Defaults.Project.Serial_Customer_Machine;
			}
		}
	}
}