using FivesBronxTimesheetManagement.Classes;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class MainWindow : Window
	{
		private int user_id;

		private User user;

		private Functions functions = new Functions();

		public MainWindow(FivesBronxTimesheetManagement.Classes.User User)
		{
			this.InitializeComponent();
			this.user_id = User.UserID;
			this.user = User;
			this.LimitButtonVisibility(this.user);
		}

		private void btnAdministratorTools_Click(object sender, RoutedEventArgs e)
		{
			(new AdminTools()).Show();
		}

		private void btnApprovalScreen_Click(object sender, RoutedEventArgs e)
		{
			(new TimesheetApproval(this.user)).Show();
		}

		private void btnReports_Click(object sender, RoutedEventArgs e)
		{
			(new Report2(this.user)).Show();
		}

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            (new About()).Show();
        }

		private void btnTimeEntryScreen_Click(object sender, RoutedEventArgs e)
		{
			(new TimesheetEntry(this.user)).Show();
		}

		private void LimitButtonVisibility(FivesBronxTimesheetManagement.Classes.User User)
		{
			if (this.functions.IntToBool(User.IsAdmin))
			{
				this.btnAdministratorTools.Visibility = System.Windows.Visibility.Visible;
			}
			else
			{
				this.btnAdministratorTools.Visibility = System.Windows.Visibility.Collapsed;
			}
			if (!this.functions.IntToBool(User.IsValidator))
			{
				this.btnApprovalScreen.Visibility = System.Windows.Visibility.Collapsed;
			}
			if (!this.functions.IntToBool(User.IsActive))
			{
				this.btnTimeEntryScreen.Visibility = System.Windows.Visibility.Collapsed;
			}
		}
	}
}