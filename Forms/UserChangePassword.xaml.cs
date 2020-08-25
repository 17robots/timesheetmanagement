using FivesBronxTimesheetManagement.Classes;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class UserChangePassword : Window
	{
		private User user;

		//private Queries queries = new Queries();
		private Queries2 queries = new Queries2();

		public UserChangePassword(FivesBronxTimesheetManagement.Classes.User User)
		{
			this.user = User;
			this.queries = new Queries2();
			this.InitializeComponent();
			this.lblUserId.Content = User.UserID;
			this.lblUserName.Content = User.UserName;
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		private void btnOK_Click(object sender, RoutedEventArgs e)
		{
			this.ChangePassword();
		}

		private void ChangePassword()
		{
			if (!(this.txtPassword1.Password == this.txtPassword2.Password))
			{
				MessageBox.Show("Password1 must equal Password2");
			}
			else
			{
				this.queries.UpdateUserPassword(this.user, this.txtPassword2.Password);
				base.Close();
			}
		}

		private void txtPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.ChangePassword();
			}
		}
	}
}