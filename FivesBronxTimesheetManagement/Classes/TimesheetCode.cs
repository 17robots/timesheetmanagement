namespace FivesBronxTimesheetManagement.Classes
{
	public class TimesheetCode
	{
		private Queries2 queries = new Queries2();

		public string Code
		{
			get;
			set;
		}

		public string Code_Description
		{
			get
			{
				return string.Concat(Code, "-", Description);
			}
			set
			{
				Code_Description = value;
			}
		}

		public string Description
		{
			get;
			set;
		}

		public TimesheetCode()
		{
			Code = "";
			Description = "";
		}

		public TimesheetCode(string code, string description)
		{
			Code = code;
			Description = description;
		}

		public TimesheetCode(string Code)
		{
			this.Code = Code;
			Description = queries.TimeCodes_Description(Code);
		}
	}
}