using System.Collections.Generic;

namespace FivesBronxTimesheetManagement.Classes
{
	public class User_Defaults
	{
		private Queries2 queries;

		public Project Project
		{
			get;
			set;
		}

		public string TaskType
		{
			get;
			set;
		}

		public TimesheetCode TimesheetCode
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

		public User_Defaults(User User)
		{
			queries = new Queries2();
			UserId = User.UserID;
			List<string> strs = queries.User_Defaults(UserId);
			TimesheetCode = queries.TimesheetCode(strs[0]);
			TaskType = strs[1];
			Project = queries.Project(strs[2]);
			userDefault4 = strs[3];
			userDefault5 = strs[4];
			userDefault6 = strs[5];
			userDefault7 = strs[6];
			userDefault8 = strs[7];
			userDefault9 = strs[8];
			userDefault10 = strs[9];
			userDefault11 = strs[10];
			userDefault12 = strs[11];
			userDefault13 = strs[12];
			userDefault14 = strs[13];
			userDefault15 = strs[14];
			userDefault16 = strs[15];
			userDefault17 = strs[16];
			userDefault18 = strs[17];
			userDefault19 = strs[18];
			userDefault20 = strs[19];
		}
	}
}