using FivesBronxTimesheetManagement.Classes;
using Microsoft.VisualBasic;
using System;
using System.Windows;

namespace FivesBronxTimesheetManagement.Forms
{
    public partial class AdminTools : Window
	{
		private Queries2 queries;

		private User user;

		public AdminTools()
		{
			InitializeComponent();
			queries = new Queries2();
		}

		private void btnApprovalHierarchy_Click(object sender, RoutedEventArgs e)
		{
			new User_ApprovalHierarchy().Show();
		}

		private void btnCreateProject_Click(object sender, RoutedEventArgs e)
		{
			new AdminTools_CreateProject().Show();
		}

		private void btnCreateUser_Click(object sender, RoutedEventArgs e)
		{
			new User_CreateEdit().Show();
		}

		private void btnEditProject_Click(object sender, RoutedEventArgs e)
		{
			new AdminTools_EditProject().Show();
		}

		private void btnPasswordReset_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string str = Interaction.InputBox("Enter user id to reset", "", "", -1, -1);
				if (str == "") return;
				int tmp;
				if(!int.TryParse(str, out tmp))
				{
					MessageBox.Show("Invalid ID");
					return;
				}
				user = queries.GetUser(tmp);
				if(user == null)
				{
					MessageBox.Show("Unable To Find User");
					return;
				}
				queries.ResetUserLogin(user);
				MessageBox.Show("Password has been reset");
				Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
    }
}