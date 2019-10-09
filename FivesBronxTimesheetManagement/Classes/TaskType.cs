using System;
using System.Runtime.CompilerServices;

namespace FivesBronxTimesheetManagement.Classes
{
	public class TaskType
	{
		private Queries queries = new Queries();

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

		public TaskType(string Id)
		{
			this.Id = Id;
			this.Description = this.queries.TaskTypeDescription(Id);
		}
	}
}