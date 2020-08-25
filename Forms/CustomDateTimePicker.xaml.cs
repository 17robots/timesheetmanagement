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
		private double hoursMax;

		private double hoursMin;

		private double hoursIncrement;

		private Functions functions;

		//private Queries queries = new Queries();
		private Queries2 queries = new Queries2();

		public DateTime date = DateTime.Now;

		public double hours;

		public CustomDateTimePicker()
		{
			this.InitializeComponent();
			this.dtpDate.SelectedDate = new DateTime?(this.date);
			this.hoursMax = 24;
			this.hoursMin = 0.5;
			this.hoursIncrement = 0.5;
			this.functions = new Functions();
			this.txtHours.Text = this.hoursMin.ToString();
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		private void btnHoursDecrement_Click(object sender, RoutedEventArgs e)
		{
			double num = double.Parse(this.txtHours.Text);
			num -= this.hoursIncrement;
			TextBox str = this.txtHours;
			double num1 = this.functions.RoundedValueInRange(num, this.hoursMin, this.hoursMax);
			str.Text = num1.ToString();
		}

		private void btnHoursIncrement_Click(object sender, RoutedEventArgs e)
		{
			double num = double.Parse(this.txtHours.Text);
			num += this.hoursIncrement;
			TextBox str = this.txtHours;
			double num1 = this.functions.RoundedValueInRange(num, this.hoursMin, this.hoursMax);
			str.Text = num1.ToString();
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
				this.hours = double.Parse(this.txtHours.Text);
				base.DialogResult = new bool?(true);
			}
		}

		private bool IsValidDate(DatePicker dtpDate)
		{
			bool flag;
			try
			{
				Queries2 query = this.queries;
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

		private void txtHours_LostFocus(object sender, RoutedEventArgs e)
		{
			if (this.functions.IsNumeric(this.txtHours.Text))
			{
				TextBox str = this.txtHours;
				double num = this.functions.RoundedValueInRange(double.Parse(this.txtHours.Text), this.hoursMin, this.hoursMax);
				str.Text = num.ToString();
			}
			else
			{
				this.txtHours.Text = this.hoursMin.ToString();
			}
		}

		private void TxtHoursSelectAll(object sender, RoutedEventArgs e)
		{
			this.txtHours.SelectAll();
		}
	}
}