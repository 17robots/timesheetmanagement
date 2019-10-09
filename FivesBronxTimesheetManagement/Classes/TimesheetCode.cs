using System;
using System.Runtime.CompilerServices;

namespace FivesBronxTimesheetManagement.Classes
{
	public class TimesheetCode
	{
		private Queries queries = new Queries();

		public string Code
		{
			get;
			set;
		}

		public string Code_Description
		{
			get
			{
				return string.Concat(this.Code, "-", this.Description);
			}
			set
			{
				this.Code_Description = value;
			}
		}

		public string Description
		{
			get;
			set;
		}

		public TimesheetCode()
		{
			this.Code = "";
			this.Description = "";
		}

		public TimesheetCode(string Code)
		{
			this.Code = Code;
			this.Description = this.queries.TimeCodes_Description(Code);
		}
	}
}