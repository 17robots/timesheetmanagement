using FivesBronxTimesheetManagement.Classes;
using System.Windows;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class MainWindow : Window
	{
		private User user;

		private Functions functions = new Functions();

		public MainWindow(User User)
		{
			InitializeComponent();
			user = User;
			LimitButtonVisibility(user);
		}

		private void btnAdministratorTools_Click(object sender, RoutedEventArgs e)
		{
			new AdminTools().Show();
		}

		private void btnApprovalScreen_Click(object sender, RoutedEventArgs e)
		{
			new TimesheetApproval(user).Show();
		}

		private void btnReports_Click(object sender, RoutedEventArgs e)
		{
			new Report2(user).Show();
		}

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            new About().Show();
        }

		private void btnTimeEntryScreen_Click(object sender, RoutedEventArgs e)
		{
			new TimesheetEntry(user).Show();
		}

		private void btnLogout_Click(object sender, RoutedEventArgs e)
		{
			Session.Logout();
			for(int i = 1; i < App.Current.Windows.Count; ++i)
			{
				Application.Current.Windows[i].Close();
			}
			new UserLogin().Show(); // open a new login window
			Close(); // close this one
		}

		private void LimitButtonVisibility(User User)
		{
			if (functions.IntToBool(User.IsAdmin))
			{
				btnAdministratorTools.Visibility = Visibility.Visible;
			}
			else
			{
				btnAdministratorTools.Visibility = Visibility.Collapsed;
			}
			if (!functions.IntToBool(User.IsValidator))
			{
				btnApprovalScreen.Visibility = Visibility.Collapsed;
			}
			if (!functions.IntToBool(User.IsActive))
			{
				btnTimeEntryScreen.Visibility = Visibility.Collapsed;
			}
		}
	}
}