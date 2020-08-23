using FivesBronxTimesheetManagement.Classes;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class UserRights : Window
	{
		private Connection myConnections = new Connection();

		//private Queries queries = new Queries();
		private Queries2 queries = new Queries2();

		private User user;

		private Functions functions = new Functions();

		public UserRights(FivesBronxTimesheetManagement.Classes.User User)
		{
			this.user = User;
			this.InitializeComponent();
			this.LoadFromDb();
			this.menuMain.Visibility = System.Windows.Visibility.Collapsed;
		}

		public void LoadFromDb()
		{
			this.lblUserId.Content = this.user.UserID;
			this.txtUserName.Text = this.user.UserName;
			this.lblIsApprover.Content = this.functions.IntToBool(this.user.IsValidator);
			this.lblIsActive.Content = this.functions.IntToBool(this.user.IsActive);
			this.lblIsAdmin.Content = this.functions.IntToBool(this.user.IsAdmin);
			this.dgApprovees.AutoGenerateColumns = true;
			this.dgApprovees.ItemsSource = this.queries.User_GetApprovees(this.user);
		}

		private void menuFileChangeName_Click(object sender, RoutedEventArgs e)
		{
			this.txtUserName.IsReadOnly = false;
		}
	}
}