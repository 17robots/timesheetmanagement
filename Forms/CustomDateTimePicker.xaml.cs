using FivesBronxTimesheetManagement.Classes;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class CustomDateTimePicker : Window
	{
		private Queries queries = new Queries();

		public DateTime date = DateTime.Now;

		public CustomDateTimePicker()
		{
			this.InitializeComponent();
			this.dtpDate.SelectedDate = new DateTime?(this.date);
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		private void btnOK_Click(object sender, RoutedEventArgs e)
		{
			if (!this.IsValidDate(this.dtpDate))
			{
				MessageBox.Show("This Date is not Valid");
			}
			else
			{
				this.date = this.dtpDate.SelectedDate.Value;
				base.DialogResult = new bool?(true);
			}
		}

		private bool IsValidDate(DatePicker dtpDate)
		{
			bool flag;
			try
			{
				Queries query = this.queries;
				DateTime value = dtpDate.SelectedDate.Value;
				int month = value.Month;
				value = dtpDate.SelectedDate.Value;
				flag = query.Period_Open(month, value.Year);
			}
			catch
			{
				flag = false;
			}
			return flag;
		}
	}
}