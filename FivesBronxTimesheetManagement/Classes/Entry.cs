using System;

namespace FivesBronxTimesheetManagement.Classes
{
	public class Entry
	{
		[Order]
		public int? entry_id
		{
			get;
			set;
		}

		[Order]
		public int user_id
		{
			get;
			set;
		}

		[Order]
		public string user_name
		{
			get;
			set;
		}

		[Order]
		public int? section_id
		{
			get;
			set;
		}

		[Order]
		public string project_serial
		{
			get;
			set;
		}

		[Order]
		public string project_sap
		{
			get;
			set;
		}

		[Order]
		public string number_section
		{
			get;
			set;
		}

		[Order]
		public int? number_network
		{
			get;
			set;
		}

		[Order]
		public string number_activity
		{
			get;
			set;
		}

		[Order]
		public DateTime date
		{
			get;
			set;
		}

		[Order]
		public int period
		{
			get;
			set;
		}

		[Order]
		public int year
		{
			get;
			set;
		}

		[Order]
		public double hours
		{
			get;
			set;
		}

		[Order]
		public string description
		{
			get;
			set;
		}

		[Order]
		public string timesheet_code
		{
			get;
			set;
		}

		[Order]
		public string task_type
		{
			get;
			set;
		}

		[Order]
		public string submitted_status
		{
			get;
			set;
		}

		[Order]
		public ApprovalStatus approval_status
		{
			get;
			set;
		}

		[Order]
		public string rejection_reason
		{
			get;
			set;
		}

		[Order]
		public int? approved_by_user_id
		{
			get;
			set;
		}

		[Order]
		public string approved_by_user_name
		{
			get;
			set;
		}

		[Order]
		public DateTime date_created
		{
			get;
			set;
		}

		[Order]
		public DateTime date_modified
		{
			get;
			set;
		}

		[Order]
		public DateTime? date_approved
		{
			get;
			set;
		}

		public Entry(int? entry_id, int user_id, string user_name, int? section_id, string project_serial, string project_sap, string number_section, int? number_network, string number_activity, DateTime date, int period, int year, double hours, string description, string timesheet_code, string task_type, string submitted_status, ApprovalStatus approval_status, string rejection_reason, int? approved_by_user_id, string approved_by_user_name, DateTime date_created, DateTime date_modified, DateTime? date_approved)
		{
			this.entry_id = entry_id;
			this.user_id = user_id;
			this.user_name = user_name;
			this.section_id = section_id;
			this.project_serial = project_serial;
			this.project_sap = project_sap;
			this.number_section = number_section;
			this.number_network = number_network;
			this.number_activity = number_activity;
			this.date = date;
			this.period = period;
			this.year = year;
			this.hours = hours;
			this.description = description;
			this.timesheet_code = timesheet_code;
			this.task_type = task_type;
			this.submitted_status = submitted_status;
			this.approval_status = approval_status;
			this.rejection_reason = rejection_reason;
			this.approved_by_user_id = approved_by_user_id;
			this.approved_by_user_name = approved_by_user_name;
			this.date_created = date_created;
			this.date_modified = date_modified;
			this.date_approved = date_approved;
		}

		public Entry()
		{
		}

		public Entry(Entry Entry, DateTime Date)
		{
			Functions function = new Functions();
			user_id = Entry.user_id;
			user_name = Entry.user_name;
			section_id = Entry.section_id;
			project_serial = Entry.project_serial;
			project_sap = Entry.project_sap;
			number_section = Entry.number_section;
			number_network = Entry.number_network;
			number_activity = Entry.number_activity;
			date = Date;
			period = Date.Month;
			year = Date.Year;
			hours = Entry.hours;
			description = Entry.description;
			timesheet_code = Entry.timesheet_code;
			task_type = Entry.task_type;
			submitted_status = function.approvalStatus(ApprovalStatus.NotSubmitted);
			approval_status = ApprovalStatus.Submitted;
			rejection_reason = rejection_reason;
			approved_by_user_id = approved_by_user_id;
			approved_by_user_name = approved_by_user_name;
			date_created = date_created;
			date_modified = date_modified;
			date_approved = date_approved;
		}

		public Entry(Entry Entry, DateTime Date, double Hours)
		{
			Functions function = new Functions();
			user_id = Entry.user_id;
			user_name = Entry.user_name;
			section_id = Entry.section_id;
			project_serial = Entry.project_serial;
			project_sap = Entry.project_sap;
			number_section = Entry.number_section;
			number_network = Entry.number_network;
			number_activity = Entry.number_activity;
			date = Date;
			period = Date.Month;
			year = Date.Year;
			hours = Hours;
			description = Entry.description;
			timesheet_code = Entry.timesheet_code;
			task_type = Entry.task_type;
			submitted_status = function.approvalStatus(ApprovalStatus.NotSubmitted);
			approval_status = ApprovalStatus.Submitted;
			rejection_reason = rejection_reason;
			approved_by_user_id = approved_by_user_id;
			approved_by_user_name = approved_by_user_name;
			date_created = date_created;
			date_modified = date_modified;
			date_approved = date_approved;
		}

		public Entry(Entry Entry)
		{
			Functions function = new Functions();
			user_id = Entry.user_id;
			user_name = Entry.user_name;
			section_id = Entry.section_id;
			project_serial = Entry.project_serial;
			project_sap = Entry.project_sap;
			number_section = Entry.number_section;
			number_network = Entry.number_network;
			number_activity = Entry.number_activity;
			date = Entry.date;
			period = Entry.date.Month;
			year = Entry.date.Year;
			hours = Entry.hours;
			description = Entry.description;
			timesheet_code = Entry.timesheet_code;
			task_type = Entry.task_type;
			submitted_status = function.approvalStatus(ApprovalStatus.NotSubmitted);
			approval_status = ApprovalStatus.Submitted;
			rejection_reason = rejection_reason;
			approved_by_user_id = approved_by_user_id;
			approved_by_user_name = approved_by_user_name;
			date_created = date_created;
			date_modified = date_modified;
			date_approved = date_approved;
		}
	}
}