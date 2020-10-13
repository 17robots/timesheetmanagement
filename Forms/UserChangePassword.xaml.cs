using FivesBronxTimesheetManagement.Classes;
using System.Windows;
using System.Windows.Input;
namespace FivesBronxTimesheetManagement.Forms
{
	public partial class UserChangePassword : Window
	{
		private readonly User user;

		private Queries2 queries = new Queries2();

		public UserChangePassword(User User)
		{
			user = User;
			queries = new Queries2();
			InitializeComponent();
			lblUserId.Content = User.UserID;
			lblUserName.Content = User.UserName;
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void btnOK_Click(object sender, RoutedEventArgs e)
		{
			ChangePassword();
		}

		private void ChangePassword()
		{
			if (txtPassword1.Password == "" || txtPassword2.Password == "")
			{
				MessageBox.Show("New Password Cannot Be Empty");
			}
			else if (!(txtPassword1.Password == txtPassword2.Password))
			{
				MessageBox.Show("Password1 must equal Password2");
			}
			else
			{
				queries.UpdateUserPassword(user, txtPassword2.Password);
				Close();
			}
		}

		private void txtPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				ChangePassword();
			}
		}
	}
}