using FivesBronxTimesheetManagement.Classes;
using System;
using System.Windows;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class User_CreateEdit : Window
	{
		private Queries2 queries = new Queries2();

		private Functions functions;

		public User_CreateEdit()
		{
			InitializeComponent();
			queries = new Queries2();
			functions = new Functions();
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void btnOK_Click(object sender, RoutedEventArgs e)
		{
			int num;
			string text;
			int num1;
			int num2;
			int num3;
			int num4;
			if (!string.IsNullOrEmpty(txtUserId.Text))
			{
				try
				{
					num = int.Parse(txtUserId.Text);
				}
				catch
				{
					MessageBox.Show("User ID must be an integer: 2XXXX");
					return;
				}
				if (!string.IsNullOrEmpty(txtUserName.Text))
				{
					num = int.Parse(txtUserId.Text);
					text = txtUserName.Text;
					Functions function = functions;
					bool? isChecked = ckbxIsActive.IsChecked;
					num1 = function.BoolToInt(isChecked.Value);
					Functions function1 = functions;
					isChecked = ckbxIsAdmin.IsChecked;
					num2 = function1.BoolToInt(isChecked.Value);
					Functions function2 = functions;
					isChecked = ckbxIsHourly.IsChecked;
					num3 = function2.BoolToInt(isChecked.Value);
					Functions function3 = functions;
					isChecked = ckbxIsValidator.IsChecked;
					num4 = function3.BoolToInt(isChecked.Value);
					User user = new User(num, text, num4, num2, num1, num3);
					try
					{
						queries.CreateUser(user);
						queries.CreateUserLogin(user);
						queries.CreateUser_Defaults(user);
						Close();
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