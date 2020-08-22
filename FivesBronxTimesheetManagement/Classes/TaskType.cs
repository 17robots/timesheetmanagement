using System;
using System.Runtime.CompilerServices;

namespace FivesBronxTimesheetManagement.Classes
{
	public class TaskType
	{
		private Queries queries = new Queries();
		private Queries2 queries2 = new Queries2();

		public string ActivityNumber
		{
			get;
			set;
		}

		public string ActNum_Id
		{
			get
			{
				return string.Concat(this.ActivityNumber, " - ", this.Id);
			}
		}

		public string Description
		{
			get;
			set;
		}

		public string Id
		{
			get;
			set;
		}

		public TaskType()
		{
			this.Id = "";
			this.Description = "";
		}

		public TaskType(string activityNumber, string description, string id)
        {
			Id = id;
			ActivityNumber = activityNumber;
			Description = description;
        }

		public TaskType(string Id)
		{
			this.Id = Id;
			Description = queries2.TaskTypeDescription(Id);
		}
	}
}