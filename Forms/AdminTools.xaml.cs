using FivesBronxTimesheetManagement.Classes;
using Microsoft.VisualBasic;
using System;
using System.Windows;

namespace FivesBronxTimesheetManagement.Forms
{
    public partial class AdminTools : Window
	{
		private Queries queries;

		private User user;

		public AdminTools()
		{
			this.InitializeComponent();
			this.queries = new Queries();
		}

		private void btnApprovalHierarchy_Click(object sender, RoutedEventArgs e)
		{
			(new User_ApprovalHierarchy()).Show();
		}

		private void btnCreateProject_Click(object sender, RoutedEventArgs e)
		{
			(new AdminTools_CreateProject()).Show();
		}

		private void btnCreateUser_Click(object sender, RoutedEventArgs e)
		{
			(new User_CreateEdit()).Show();
		}

		private void btnEditProject_Click(object sender, RoutedEventArgs e)
		{
			(new AdminTools_EditProject()).Show();
		}

		private void btnPasswordReset_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.user = new User(int.Parse(Interaction.InputBox("Enter user id to reset", "", "", -1, -1)));
				this.queries.ResetUserLogin(this.user);
				MessageBox.Show("Password has been reset");
				base.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
			}
		}

        private void BtnTaskTypes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnUserOptions_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}