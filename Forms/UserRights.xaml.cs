using FivesBronxTimesheetManagement.Classes;
using System.Windows;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class UserRights : Window
	{

		private Queries2 queries = new Queries2();

		private User user;

		private Functions functions = new Functions();

		public UserRights(User User)
		{
			user = User;
			InitializeComponent();
			LoadFromDb();
			menuMain.Visibility = Visibility.Collapsed;
		}

		public void LoadFromDb()
		{
			lblUserId.Content = user.UserID;
			txtUserName.Text = user.UserName;
			lblIsApprover.Content = functions.IntToBool(user.IsValidator);
			lblIsActive.Content = functions.IntToBool(user.IsActive);
			lblIsAdmin.Content = functions.IntToBool(user.IsAdmin);
			dgApprovees.AutoGenerateColumns = true;
			dgApprovees.ItemsSource = queries.User_GetApprovees(user);
		}

		private void menuFileChangeName_Click(object sender, RoutedEventArgs e)
		{
			txtUserName.IsReadOnly = false;
		}
	}
}