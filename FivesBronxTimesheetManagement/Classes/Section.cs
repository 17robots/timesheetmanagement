using System;
using System.Runtime.CompilerServices;

namespace FivesBronxTimesheetManagement.Classes
{
	public class Section
	{
		//private Queries queries = new Queries();
		private Queries2 queries = new Queries2();

		public string Description_Activity
		{
			get;
			set;
		}

		public string Description_Section
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}

		public string Number_Activity
		{
			get;
			set;
		}

		public string Number_ProjectNetwork
		{
			get;
			set;
		}

		public string Number_Section
		{
			get;
			set;
		}

		public string SectionNumber_SectionDescription
		{
			get
			{
				return string.Concat(this.Number_Section, "-", this.Description_Section);
			}
		}

		public string TaskType
		{
			get;
			set;
		}

		public Section()
		{
			this.Id = 0;
			this.Number_ProjectNetwork = "";
			this.Number_Section = "";
			this.Description_Section = "";
			this.Number_Activity = "";
			this.TaskType = "";
			this.Description_Activity = "";
		}

		public Section(int id, string numberProjectNetwork, string numberSection, string descriptionSection, string numberActivity, 
			string taskType, string descriptionActivity)
        {
			Id = id;
			Number_ProjectNetwork = numberProjectNetwork;
			Number_Section = numberSection;
			Description_Section = descriptionSection;
			Number_Activity = numberActivity;
			TaskType = taskType;
			Description_Activity = descriptionActivity;
        }
	}
}