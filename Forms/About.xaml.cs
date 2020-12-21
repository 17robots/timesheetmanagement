using FivesBronxTimesheetManagement.Classes;
using System.Reflection;
using System.Windows;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class About : Window
	{
		private User user;
		private Connection myConnection;
		public About(User user)
		{
			InitializeComponent();
			myConnection = new Connection();
			lblVersion.Content = string.Concat("    ", Assembly.GetExecutingAssembly().GetName().Version.ToString());
			ConnectionString.Content = string.Concat("Connected To: ", myConnection.MyConnectionString);
			this.user = user;
		}

		private void btnFileChangePassword_Click(object sender, RoutedEventArgs e)
		{
			new UserChangePassword(user).Show();
		}
	}
}