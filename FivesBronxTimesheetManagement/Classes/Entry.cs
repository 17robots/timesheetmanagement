using System;
using System.Runtime.CompilerServices;

namespace FivesBronxTimesheetManagement.Classes
{
	public class Entry
	{
		public ApprovalStatus approval_status
		{
			get;
			set;
		}

		public int? approved_by_user_id
		{
			get;
			set;
		}

		public string approved_by_user_name
		{
			get;
			set;
		}

		public DateTime date
		{
			get;
			set;
		}

		public DateTime? date_approved
		{
			get;
			set;
		}

		public DateTime date_created
		{
			get;
			set;
		}

		public DateTime date_modified
		{
			get;
			set;
		}

		public string description
		{
			get;
			set;
		}

		public int? entry_id
		{
			get;
			set;
		}

		public double hours
		{
			get;
			set;
		}

		public string number_activity
		{
			get;
			set;
		}

		public int? number_network
		{
			get;
			set;
		}

		public string number_section
		{
			get;
			set;
		}

		public int period
		{
			get;
			set;
		}

		public string project_sap
		{
			get;
			set;
		}

		public string project_serial
		{
			get;
			set;
		}

		public string rejection_reason
		{
			get;
			set;
		}

		public int? section_id
		{
			get;
			set;
		}

		public string submitted_status
		{
			get;
			set;
		}

		public string task_type
		{
			get;
			set;
		}

		public string timesheet_code
		{
			get;
			set;
		}

		public int user_id
		{
			get;
			set;
		}

		public string user_name
		{
			get;
			set;
		}

		public int year
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

		public Entry(FivesBronxTimesheetManagement.Classes.Entry Entry, DateTime Date)
		{
			Functions function = new Functions();
			this.user_id = Entry.user_id;
			this.user_name = Entry.user_name;
			this.section_id = Entry.section_id;
			this.project_serial = Entry.project_serial;
			this.project_sap = Entry.project_sap;
			this.number_section = Entry.number_section;
			this.number_network = Entry.number_network;
			this.number_activity = Entry.number_activity;
			this.date = Date;
			this.period = Date.Month;
			this.year = Date.Year;
			this.hours = Entry.hours;
			this.description = Entry.description;
			this.timesheet_code = Entry.timesheet_code;
			this.task_type = Entry.task_type;
			this.submitted_status = function.approvalStatus(ApprovalStatus.NotSubmitted);
			this.approval_status = ApprovalStatus.Submitted;
			this.rejection_reason = this.rejection_reason;
			this.approved_by_user_id = this.approved_by_user_id;
			this.approved_by_user_name = this.approved_by_user_name;
			this.date_created = this.date_created;
			this.date_modified = this.date_modified;
			this.date_approved = this.date_approved;
		}
	}
}