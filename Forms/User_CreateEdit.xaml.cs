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
	public partial class User_CreateEdit : Window
	{
		//private Queries queries = new Queries();
		private Queries2 queries = new Queries2();

		private Functions functions;

		public User_CreateEdit()
		{
			this.InitializeComponent();
			this.queries = new Queries2();
			this.functions = new Functions();
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		private void btnOK_Click(object sender, RoutedEventArgs e)
		{
			int num = 0;
			string text = "";
			int num1 = this.functions.BoolToInt(false);
			int num2 = this.functions.BoolToInt(false);
			int num3 = this.functions.BoolToInt(false);
			int num4 = this.functions.BoolToInt(false);
			if (!string.IsNullOrEmpty(this.txtUserId.Text))
			{
				try
				{
					num = int.Parse(this.txtUserId.Text);
				}
				catch
				{
					MessageBox.Show("User ID must be an integer: 2XXXX");
					return;
				}
				if (!string.IsNullOrEmpty(this.txtUserName.Text))
				{
					num = int.Parse(this.txtUserId.Text);
					text = this.txtUserName.Text;
					Functions function = this.functions;
					bool? isChecked = this.ckbxIsActive.IsChecked;
					num1 = function.BoolToInt(isChecked.Value);
					Functions function1 = this.functions;
					isChecked = this.ckbxIsAdmin.IsChecked;
					num2 = function1.BoolToInt(isChecked.Value);
					Functions function2 = this.functions;
					isChecked = this.ckbxIsHourly.IsChecked;
					num3 = function2.BoolToInt(isChecked.Value);
					Functions function3 = this.functions;
					isChecked = this.ckbxIsValidator.IsChecked;
					num4 = function3.BoolToInt(isChecked.Value);
					User user = new User(num, text, num4, num2, num1, num3);
					try
					{
						this.queries.CreateUser(user);
						this.queries.CreateUserLogin(user);
						this.queries.CreateUser_Defaults(user);
						base.Close();
					}
					catch (Exception exception)
					{
						MessageBox.Show(exception.ToString());
					}
				}
				else
				{
					MessageBox.Show("Must Have A User Name");
				}
			}
			else
			{
				MessageBox.Show("Must Have A User Id Aligned with SAP");
			}
		}
	}
}