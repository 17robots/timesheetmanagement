using System;
using System.Globalization;
using System.Windows.Data;

namespace FivesBronxTimesheetManagement.Classes
{
	public class HoursWorkedConverter : IValueConverter
	{
		public HoursWorkedConverter()
		{
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object obj;
			try
			{
				double num = (double)value;
				obj = (num.ToString().IndexOf('.') == -1 ? string.Concat(num.ToString(), ".0 ") : string.Concat(num.ToString(), " "));
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