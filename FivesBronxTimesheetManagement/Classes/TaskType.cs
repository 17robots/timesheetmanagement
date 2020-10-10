namespace FivesBronxTimesheetManagement.Classes
{
	public class TaskType
	{
		private Queries2 queries = new Queries2();

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
			Id = "";
			Description = "";
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
			Description = queries.TaskTypeDescription(Id);
		}
	}
}