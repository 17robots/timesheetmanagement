using System;

namespace FivesBronxTimesheetManagement.Classes
{
	internal class Functions
	{
		public Functions()
		{
		}

		public string approvalStatus(ApprovalStatus status)
		{
			string str;
			switch (status)
			{
				case ApprovalStatus.NotSubmitted:
				{
					str = "Not Submitted";
					break;
				}
				case ApprovalStatus.Submitted:
				{
					str = "Submitted";
					break;
				}
				case ApprovalStatus.Rejected:
				{
					str = "Rejected";
					break;
				}
				case ApprovalStatus.Approved:
				{
					str = "Approved";
					break;
				}
				default:
				{
					str = "Not Submitted";
					break;
				}
			}
			return str;
		}

		public ApprovalStatus approvalStatus(string status)
		{
			ApprovalStatus approvalStatu;
			string str = status;
			if (str == null)
			{
				approvalStatu = ApprovalStatus.NotSubmitted;
				return approvalStatu;
			}
			else if (str == "Not Submitted")
			{
				approvalStatu = ApprovalStatus.NotSubmitted;
			}
			else if (str == "Submitted")
			{
				approvalStatu = ApprovalStatus.Submitted;
			}
			else if (str == "Rejected")
			{
				approvalStatu = ApprovalStatus.Rejected;
			}
			else
			{
				if (str != "Approved")
				{
					approvalStatu = ApprovalStatus.NotSubmitted;
					return approvalStatu;
				}
				approvalStatu = ApprovalStatus.Approved;
			}
			return approvalStatu;
		}

		public int BoolToInt(bool Bool)
		{
			return (!Bool ? 0 : 1);
		}

		public bool IntToBool(int Int)
		{
			return (Int != 1 ? false : true);
		}

		public bool IsNumeric(string value)
		{
			double num;
			return double.TryParse(value, out num);
		}

		public double RoundedValueInRange(double value, double minValue, double maxValue)
		{
			double num;
			double nearestHalf = this.RoundToNearestHalf(Convert.ToDouble(value));
			if (nearestHalf > minValue)
			{
				num = (nearestHalf < maxValue ? nearestHalf : maxValue);
			}
			else
			{
				num = minValue;
			}
			return num;
		}

		public double RoundToNearestHalf(double value)
		{
			return Math.Round(value * 2) / 2;
		}

		public DateTime WeekEnding(DateTime date)
		{
			DateTime dateTime = date.AddDays((double)((int)(DayOfWeek.Monday | DayOfWeek.Tuesday | DayOfWeek.Wednesday | DayOfWeek.Thursday | DayOfWeek.Friday | DayOfWeek.Saturday) - ((int)date.DayOfWeek + (int)DayOfWeek.Monday)));
			return dateTime;
		}
	}
}