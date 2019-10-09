using System;
using System.Globalization;
using System.Windows.Data;

namespace FivesBronxTimesheetManagement.Classes
{
	public class DateTimeConverter : IValueConverter
	{
		public DateTimeConverter()
		{
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object obj;
			int month;
			string str;
			string str1;
			try
			{
				DateTime dateTime = (DateTime)value;
				if (dateTime.Month.ToString().Length == 2)
				{
					month = dateTime.Month;
					str = month.ToString();
				}
				else
				{
					month = dateTime.Month;
					str = string.Concat("0", month.ToString());
				}
				string str2 = str;
				if (dateTime.Day.ToString().Length == 2)
				{
					month = dateTime.Day;
					str1 = month.ToString();
				}
				else
				{
					month = dateTime.Day;
					str1 = string.Concat("0", month.ToString());
				}
				string str3 = str1;
				month = dateTime.Year;
				string str4 = month.ToString();
				month = dateTime.Year;
				string str5 = str4.Substring(month.ToString().Length - 2);
				string[] strArrays = new string[] { str2, "/", str3, "/", str5 };
				obj = string.Concat(strArrays);
			}
			catch
			{
				obj = value;
			}
			return obj;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}