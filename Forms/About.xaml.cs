using FivesBronxTimesheetManagement.Classes;
using System.Reflection;
using System.Windows;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class About : Window
	{
		private User user;
		public About(User user)
		{
			InitializeComponent();
			lblVersion.Content = string.Concat("    ", Assembly.GetExecutingAssembly().GetName().Version.ToString());
			this.user = user;
		}

		private void btnFileChangePassword_Click(object sender, RoutedEventArgs e)
		{
			new UserChangePassword(user).Show();
		}
	}
}