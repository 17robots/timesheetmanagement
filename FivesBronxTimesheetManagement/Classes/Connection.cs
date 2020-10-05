using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FivesBronxTimesheetManagement.Classes
{
	public class Connection
	{
		private MySql.Data.MySqlClient.MySqlConnection myConnection;

		private string path = "";

		public string MyConnectionString
		{
			get;
			set;
		}

		public MySql.Data.MySqlClient.MySqlConnection MySqlConnection
		{
			get
			{
				return this.myConnection;
			}
		}

		public Connection()
		{
			StreamReader streamReader;
			string str = "";
			string str1 = "F!vesBronx_Employee";
			string str2 = "FivesEmployee";
			try
			{
				path = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "\\connectionString.txt");
				if (!File.Exists(this.path))
				{
					TextWriter textWriter = File.CreateText(string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "\\connectionString.txt"));
					textWriter.WriteLine("localhost");
					textWriter.Close();
					streamReader = new StreamReader(this.path);
					try
					{
						str = streamReader.ReadLine();
					}
					finally
					{
						if (streamReader != null)
						{
							((IDisposable)streamReader).Dispose();
						}
					}
				}
				else
				{
					streamReader = new StreamReader(this.path);
					try
					{
						str = streamReader.ReadLine();
					}
					finally
					{
						if (streamReader != null)
						{
							((IDisposable)streamReader).Dispose();
						}
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
			}
			string[] strArrays = new string[] { "datasource=", str, ";port=3306;Database=timereporting;username=", str2, ";password=", str1 };
			this.myConnection = new MySql.Data.MySqlClient.MySqlConnection(string.Concat(strArrays));
		}

		public void ChangeConnectionString(string newConnectionString)
		{
			File.WriteAllText(this.path, newConnectionString);
		}

		public void Close()
		{
			if (this.myConnection.State == ConnectionState.Open)
			{
				this.myConnection.Close();
			}
		}

		public void Open()
		{
			if (this.myConnection.State == ConnectionState.Closed)
			{
				this.myConnection.Open();
			}
			else if (this.myConnection.State == ConnectionState.Open)
			{
				this.myConnection.Close();
				this.myConnection.Open();
			}
		}

		public void SetConnectionString()
		{
			this.MyConnectionString = this.myConnection.ToString();
		}

		public void Test()
		{
			try
			{
				MySql.Data.MySqlClient.MySqlConnection mySqlConnection = this.myConnection;
				MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter()
				{
					SelectCommand = new MySqlCommand("select all TimesheetsModel.Employee ;", mySqlConnection)
				};
				MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);
				mySqlConnection.Open();
				MessageBox.Show("Connected");
				mySqlConnection.Close();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
	}
}