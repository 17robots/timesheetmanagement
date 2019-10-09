using FivesBronxTimesheetManagement.Classes;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
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
	public partial class UserLogin : Window
	{
		private Connection myConnection = new Connection();

		private Queries queries = new Queries();

		public UserLogin()
		{
			this.InitializeComponent();
		}

		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
			this.Login();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		private void Login()
		{
			try
			{
				string[] text = new string[] { "SELECT * FROM login WHERE user_id='", this.txtEmployeeId.Text, "' AND password='", this.txtPassword.Password, "'" };
				MySqlCommand mySqlCommand = new MySqlCommand(string.Concat(text), this.myConnection.MySqlConnection);
				this.myConnection.Open();
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				int num = 0;
				while (mySqlDataReader.Read())
				{
					num++;
				}
				if (num == 1)
				{
					this.myConnection.Close();
					MainWindow mainWindow = new MainWindow(this.queries.GetUser(int.Parse(this.txtEmployeeId.Text)));
					mainWindow.Show();
					base.Close();
				}
				else if (num <= 1)
				{
					MessageBox.Show("Incorrect Username and/or Password");
					this.myConnection.Close();
				}
				else
				{
					MessageBox.Show("Duplicate Username and password.... Access Denied");
					this.myConnection.Close();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		private void menuFile_ChangeConnectionString_Click(object sender, RoutedEventArgs e)
		{
			string str = Interaction.InputBox("Enter A New Connection String", "Connection String", "", -1, -1);
			if (!string.IsNullOrEmpty(str))
			{
				this.myConnection.ChangeConnectionString(str);
				this.myConnection = new Connection();
			}
		}

		private void txtPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.Login();
			}
		}
	}
}