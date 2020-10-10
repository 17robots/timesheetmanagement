using System;

namespace FivesBronxTimesheetManagement.Classes
{
	public class User : IEquatable<User>
	{

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
			UserID = User_ID;
			UserName = User_Name;
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
			return Equals(other as User);
		}

		public override int GetHashCode()
		{
			return comparer.GetHashCode(UserID);
		}
	}
}