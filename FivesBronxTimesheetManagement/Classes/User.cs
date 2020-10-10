using System;
using System.Runtime.CompilerServices;
using System.Windows.Media.Animation;

namespace FivesBronxTimesheetManagement.Classes
{
	public class User : IEquatable<User>
	{
		//private Queries queries = new Queries();
		private Queries2 queries = new Queries2();

		private Functions functions;

		private readonly StringComparer comparer = StringComparer.OrdinalIgnoreCase;

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
			this.queries = new Queries2();
			this.functions = new Functions();
			this.UserID = User_ID;
			this.UserName = User_Name;
			this.IsValidator = IsValidator;
			this.IsAdmin = IsAdmin;
			this.IsActive = IsActive;
			this.IsHourly = IsHourly;
		}

		public bool Equals(User other)
		{
			if (other == null) return false;
			return UserID == other.UserID;
		}

		public override bool Equals(object other)
		{
			return this.Equals(other as User);
		}

		public override int GetHashCode()
		{
			return comparer.GetHashCode(UserID);
		}
	}
}