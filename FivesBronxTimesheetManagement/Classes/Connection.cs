using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows;

namespace FivesBronxTimesheetManagement.Classes
{
	public class Connection
	{
		private string path = "";

		public string MyConnectionString
		{
			get;
			set;
		}

		public MySqlConnection MySqlConnection { get; }

		public Connection()
		{
			StreamReader streamReader;
			string str = "";
			string str1 = "F!vesBronx_Employee";
			string str2 = "FivesEmployee";
			try
			{
				path = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "\\connectionString.txt");
				if (!File.Exists(path))
				{
					TextWriter textWriter = File.CreateText(string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "\\connectionString.txt"));
					textWriter.WriteLine("localhost");
					textWriter.Close();
					streamReader = new StreamReader(path);
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
					streamReader = new StreamReader(path);
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
			MyConnectionString = str;
			string[] strArrays = new string[] { "datasource=", str, ";port=3306;Database=timereporting;username=", str2, ";password=", str1 };
			MySqlConnection = new MySqlConnection(string.Concat(strArrays));
		}

		public void ChangeConnectionString(string newConnectionString)
		{
			File.WriteAllText(path, newConnectionString);
		}

		public void Close()
		{
			if (MySqlConnection.State == ConnectionState.Open)
			{
				MySqlConnection.Close();
			}
		}

		public void Open()
		{
			if (MySqlConnection.State == ConnectionState.Closed)
			{
				MySqlConnection.Open();
			}
			else if (MySqlConnection.State == ConnectionState.Open)
			{
				MySqlConnection.Close();
				MySqlConnection.Open();
			}
		}
	}
}