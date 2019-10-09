using System;
using System.Runtime.CompilerServices;

namespace FivesBronxTimesheetManagement.Classes
{
	public class User
	{
		private Queries queries;

		private Functions functions;

		public int IsActive
		{
			get;
			private set;
		}

		public int IsAdmin
		{
			get;
			private set;
		}

		public int IsHourly
		{
			get;
			private set;
		}

		public int IsValidator
		{
			get;
			private set;
		}

		public int UserID
		{
			get;
			private set;
		}

		public string UserName
		{
			get;
			private set;
		}

		public User(int User_ID, string User_Name, int IsValidator, int IsAdmin, int IsActive, int IsHourly)
		{
			this.queries = new Queries();
			this.functions = new Functions();
			this.UserID = User_ID;
			this.UserName = User_Name;
			this.IsValidator = IsValidator;
			this.IsAdmin = IsAdmin;
			this.IsActive = IsActive;
			this.IsHourly = IsHourly;
		}

		public User(int User_Id)
		{
			this.queries = new Queries();
			this.functions = new Functions();
			this.UserID = User_Id;
			this.UserName = this.queries.User_EmployeeName(User_Id);
			this.IsValidator = this.functions.BoolToInt(this.queries.User_IsValidator(User_Id));
			this.IsAdmin = this.functions.BoolToInt(this.queries.User_IsAdmin(User_Id));
			this.IsActive = this.functions.BoolToInt(this.queries.User_IsActive(User_Id));
			this.IsHourly = this.functions.BoolToInt(this.queries.User_IsHourly(User_Id));
		}
	}
}