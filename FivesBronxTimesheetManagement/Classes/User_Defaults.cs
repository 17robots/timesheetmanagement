using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace FivesBronxTimesheetManagement.Classes
{
	public class User_Defaults
	{
		//private Queries queries = new Queries();
		private Queries2 queries = new Queries2();

		public FivesBronxTimesheetManagement.Classes.Project Project
		{
			get;
			set;
		}

		public string TaskType
		{
			get;
			set;
		}

		public FivesBronxTimesheetManagement.Classes.TimesheetCode TimesheetCode
		{
			get;
			set;
		}

		public string userDefault10
		{
			get;
			set;
		}

		public string userDefault11
		{
			get;
			set;
		}

		public string userDefault12
		{
			get;
			set;
		}

		public string userDefault13
		{
			get;
			set;
		}

		public string userDefault14
		{
			get;
			set;
		}

		public string userDefault15
		{
			get;
			set;
		}

		public string userDefault16
		{
			get;
			set;
		}

		public string userDefault17
		{
			get;
			set;
		}

		public string userDefault18
		{
			get;
			set;
		}

		public string userDefault19
		{
			get;
			set;
		}

		public string userDefault20
		{
			get;
			set;
		}

		public string userDefault4
		{
			get;
			set;
		}

		public string userDefault5
		{
			get;
			set;
		}

		public string userDefault6
		{
			get;
			set;
		}

		public string userDefault7
		{
			get;
			set;
		}

		public string userDefault8
		{
			get;
			set;
		}

		public string userDefault9
		{
			get;
			set;
		}

		public int UserId
		{
			get;
			private set;
		}

		public User_Defaults(FivesBronxTimesheetManagement.Classes.User User)
		{
			this.queries = new Queries2();
			this.UserId = User.UserID;
			List<string> strs = this.queries.User_Defaults(this.UserId);
			this.TimesheetCode = this.queries.TimesheetCode(strs[0]);
			this.TaskType = strs[1];
			this.Project = this.queries.Project(strs[2]);
			this.userDefault4 = strs[3];
			this.userDefault5 = strs[4];
			this.userDefault6 = strs[5];
			this.userDefault7 = strs[6];
			this.userDefault8 = strs[7];
			this.userDefault9 = strs[8];
			this.userDefault10 = strs[9];
			this.userDefault11 = strs[10];
			this.userDefault12 = strs[11];
			this.userDefault13 = strs[12];
			this.userDefault14 = strs[13];
			this.userDefault15 = strs[14];
			this.userDefault16 = strs[15];
			this.userDefault17 = strs[16];
			this.userDefault18 = strs[17];
			this.userDefault19 = strs[18];
			this.userDefault20 = strs[19];
		}
	}
}