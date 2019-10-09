using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FivesBronxTimesheetManagement.Classes
{
	public class Queries
	{
		public Connection myConnection = new Connection();

		private MySqlCommand myCommand;

		private string qString;

		private Functions functions = new Functions();

		public string t_ApprovalHierarchy
		{
			get;
			set;
		}

		public string t_ApprovalHierarchy_c_Approvee_Id
		{
			get;
			set;
		}

		public string t_ApprovalHierarchy_c_Approvee_Name
		{
			get;
			set;
		}

		public string t_ApprovalHierarchy_c_Approver_Id
		{
			get;
			set;
		}

		public string t_ApprovalHierarchy_c_Approver_Name
		{
			get;
			set;
		}

		public string t_ApprovalHierarchy_c_Hierarchy_Id
		{
			get;
			set;
		}

		public string t_Login
		{
			get;
			set;
		}

		public string t_Login_c_Login_Id
		{
			get;
			set;
		}

		public string t_Login_c_password
		{
			get;
			set;
		}

		public string t_Login_c_User_Id
		{
			get;
			set;
		}

		public string t_Period
		{
			get;
			set;
		}

		public string t_Period_Id
		{
			get;
			set;
		}

		public string t_Period_Period
		{
			get;
			set;
		}

		public string t_Period_Period_Current
		{
			get;
			set;
		}

		public string t_Period_Period_Open
		{
			get;
			set;
		}

		public string t_Period_Year
		{
			get;
			set;
		}

		public string t_Projects
		{
			get;
			set;
		}

		public string t_Projects_c_Country
		{
			get;
			set;
		}

		public string t_Projects_c_Customer
		{
			get;
			set;
		}

		public string t_Projects_c_IsOpen
		{
			get;
			set;
		}

		public string t_Projects_c_IsWarrantyOpen
		{
			get;
			set;
		}

		public string t_Projects_c_Machine
		{
			get;
			set;
		}

		public string t_Projects_c_Number_BFC
		{
			get;
			set;
		}

		public string t_Projects_c_Number_MAS90
		{
			get;
			set;
		}

		public string t_Projects_c_Number_Network
		{
			get;
			set;
		}

		public string t_Projects_c_Number_SAP
		{
			get;
			set;
		}

		public string t_Projects_c_Number_Serial
		{
			get;
			set;
		}

		public string t_Projects_c_Number_WarrantyNetwork
		{
			get;
			set;
		}

		public string t_Sections
		{
			get;
			set;
		}

		public string t_Sections_c_Description_Activity
		{
			get;
			set;
		}

		public string t_Sections_c_Description_Section
		{
			get;
			set;
		}

		public string t_Sections_c_Entry_Id
		{
			get;
			set;
		}

		public string t_Sections_c_Number_Activity
		{
			get;
			set;
		}

		public string t_Sections_c_Number_Project_Network
		{
			get;
			set;
		}

		public string t_Sections_c_Number_Section
		{
			get;
			set;
		}

		public string t_Sections_c_Task_Type
		{
			get;
			set;
		}

		public string t_Task_type
		{
			get;
			set;
		}

		public string t_Task_Type_c_Task_Type
		{
			get;
			set;
		}

		public string t_Task_Type_c_Task_Type_description
		{
			get;
			set;
		}

		public string t_Timesheet_Archive
		{
			get;
			set;
		}

		public string t_Timesheet_c_Approval_Status
		{
			get;
			set;
		}

		public string t_Timesheet_c_Approved_By_User_Id
		{
			get;
			set;
		}

		public string t_Timesheet_c_Approved_By_User_Name
		{
			get;
			set;
		}

		public string t_Timesheet_c_Date
		{
			get;
			set;
		}

		public string t_Timesheet_c_Date_Approved
		{
			get;
			set;
		}

		public string t_Timesheet_c_Date_Created
		{
			get;
			set;
		}

		public string t_Timesheet_c_Date_Modified
		{
			get;
			set;
		}

		public string t_Timesheet_c_Description
		{
			get;
			set;
		}

		public string t_Timesheet_c_Entry_Id
		{
			get;
			set;
		}

		public string t_Timesheet_c_Hours
		{
			get;
			set;
		}

		public string t_Timesheet_c_Number_Activity
		{
			get;
			set;
		}

		public string t_Timesheet_c_Number_Network
		{
			get;
			set;
		}

		public string t_Timesheet_c_Number_Section
		{
			get;
			set;
		}

		public string t_Timesheet_c_Period
		{
			get;
			set;
		}

		public string t_Timesheet_c_Project_Sap
		{
			get;
			set;
		}

		public string t_Timesheet_c_Project_Serial
		{
			get;
			set;
		}

		public string t_Timesheet_c_Rejection_Reason
		{
			get;
			set;
		}

		public string t_Timesheet_c_Section_Id
		{
			get;
			set;
		}

		public string t_Timesheet_c_Submitted_Status
		{
			get;
			set;
		}

		public string t_Timesheet_c_Task_Type
		{
			get;
			set;
		}

		public string t_Timesheet_c_Timesheet_Code
		{
			get;
			set;
		}

		public string t_Timesheet_c_User_Id
		{
			get;
			set;
		}

		public string t_Timesheet_c_User_Name
		{
			get;
			set;
		}

		public string t_Timesheet_c_Year
		{
			get;
			set;
		}

		public string t_Timesheet_codes
		{
			get;
			set;
		}

		public string t_Timesheet_Codes_c_Timesheet_Code
		{
			get;
			set;
		}

		public string t_Timesheet_Codes_c_Timesheet_Description
		{
			get;
			set;
		}

		public string t_Timesheet_Final
		{
			get;
			set;
		}

		public string t_Timesheet_Limbo
		{
			get;
			set;
		}

		public string t_Timesheet_Prelim
		{
			get;
			set;
		}

		public string t_Users
		{
			get;
			set;
		}

		public string t_Users_c_Admin
		{
			get;
			set;
		}

		public string t_Users_c_IsActive
		{
			get;
			set;
		}

		public string t_Users_c_IsHourly
		{
			get;
			set;
		}

		public string t_Users_c_User_Id
		{
			get;
			set;
		}

		public string t_Users_c_User_Name
		{
			get;
			set;
		}

		public string t_Users_c_Validator
		{
			get;
			set;
		}

		public string t_UsersDefaults
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default10
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default11
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default12
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default13
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default14
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default15
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default16
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default17
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default18
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default19
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default20
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default4
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default5
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default6
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default7
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default8
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Default9
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_Project
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_TaskType
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_TimesheetCode
		{
			get;
			set;
		}

		public string t_UsersDefaults_c_User_Id
		{
			get;
			set;
		}

		public Queries()
		{
			Connection connection = new Connection();
			this.t_Login = "login";
			this.t_Login_c_Login_Id = "login_id";
			this.t_Login_c_User_Id = "user_id";
			this.t_Login_c_password = "password";
			this.t_Users = "users";
			this.t_Users_c_User_Id = "user_id";
			this.t_Users_c_User_Name = "user_name";
			this.t_Users_c_Validator = "user_validator";
			this.t_Users_c_Admin = "user_admin";
			this.t_Users_c_IsActive = "user_isactive";
			this.t_Users_c_IsHourly = "user_ishourly";
			this.t_UsersDefaults = "users_defaults";
			this.t_UsersDefaults_c_User_Id = "user_id";
			this.t_UsersDefaults_c_TimesheetCode = "user_default1";
			this.t_UsersDefaults_c_TaskType = "user_default2";
			this.t_UsersDefaults_c_Project = "user_default3";
			this.t_UsersDefaults_c_Default4 = "user_default4";
			this.t_UsersDefaults_c_Default5 = "user_default5";
			this.t_UsersDefaults_c_Default6 = "user_default6";
			this.t_UsersDefaults_c_Default7 = "user_default7";
			this.t_UsersDefaults_c_Default8 = "user_default8";
			this.t_UsersDefaults_c_Default9 = "user_default9";
			this.t_UsersDefaults_c_Default10 = "user_default10";
			this.t_UsersDefaults_c_Default11 = "user_default11";
			this.t_UsersDefaults_c_Default12 = "user_default12";
			this.t_UsersDefaults_c_Default13 = "user_default13";
			this.t_UsersDefaults_c_Default14 = "user_default14";
			this.t_UsersDefaults_c_Default15 = "user_default15";
			this.t_UsersDefaults_c_Default16 = "user_default16";
			this.t_UsersDefaults_c_Default17 = "user_default17";
			this.t_UsersDefaults_c_Default18 = "user_default18";
			this.t_UsersDefaults_c_Default19 = "user_default19";
			this.t_UsersDefaults_c_Default20 = "user_default20";
			this.t_Timesheet_codes = "timesheet_codes";
			this.t_Timesheet_Codes_c_Timesheet_Code = "timesheet_code";
			this.t_Timesheet_Codes_c_Timesheet_Description = "timesheet_description";
			this.t_Task_type = "task_type";
			this.t_Task_Type_c_Task_Type = "task_type";
			this.t_Task_Type_c_Task_Type_description = "task_type_description";
			this.t_Projects = "projects";
			this.t_Projects_c_Number_Serial = "number_serial";
			this.t_Projects_c_Number_SAP = "number_sap";
			this.t_Projects_c_Number_MAS90 = "number_mas90";
			this.t_Projects_c_Number_BFC = "number_bfc";
			this.t_Projects_c_Number_Network = "number_network";
			this.t_Projects_c_Customer = "vendor";
			this.t_Projects_c_Machine = "machine";
			this.t_Projects_c_Country = "country";
			this.t_Projects_c_IsOpen = "isopen";
			this.t_Projects_c_IsWarrantyOpen = "iswarrantyopen";
			this.t_Projects_c_Number_WarrantyNetwork = "number_warrantynetwork";
			this.t_Sections = "sections";
			this.t_Sections_c_Entry_Id = "entry_id";
			this.t_Sections_c_Number_Project_Network = "number_project_network";
			this.t_Sections_c_Number_Section = "number_section";
			this.t_Sections_c_Description_Section = "description_section";
			this.t_Sections_c_Number_Activity = "number_activity";
			this.t_Sections_c_Task_Type = "task_type";
			this.t_Sections_c_Description_Activity = "description_activity";
			this.t_Timesheet_Prelim = "ts_prelim";
			this.t_Timesheet_Limbo = "ts_limbo";
			this.t_Timesheet_Final = "ts_final";
			this.t_Timesheet_Archive = "ts_archive";
			this.t_Timesheet_c_Entry_Id = "entry_id";
			this.t_Timesheet_c_User_Id = "user_id";
			this.t_Timesheet_c_User_Name = "user_name";
			this.t_Timesheet_c_Section_Id = "section_id";
			this.t_Timesheet_c_Project_Serial = "project_serial";
			this.t_Timesheet_c_Project_Sap = "project_sap";
			this.t_Timesheet_c_Number_Section = "number_section";
			this.t_Timesheet_c_Number_Network = "number_network";
			this.t_Timesheet_c_Number_Activity = "number_activity";
			this.t_Timesheet_c_Date = "date";
			this.t_Timesheet_c_Period = "period";
			this.t_Timesheet_c_Year = "year";
			this.t_Timesheet_c_Hours = "hours";
			this.t_Timesheet_c_Description = "description";
			this.t_Timesheet_c_Timesheet_Code = "timesheet_code";
			this.t_Timesheet_c_Task_Type = "task_type";
			this.t_Timesheet_c_Submitted_Status = "submitted_status";
			this.t_Timesheet_c_Approval_Status = "approval_status";
			this.t_Timesheet_c_Rejection_Reason = "rejection_reason";
			this.t_Timesheet_c_Approved_By_User_Id = "approved_by_user_id";
			this.t_Timesheet_c_Approved_By_User_Name = "approved_by_user_name";
			this.t_Timesheet_c_Date_Created = "date_created";
			this.t_Timesheet_c_Date_Modified = "date_modified";
			this.t_Timesheet_c_Date_Approved = "date_approved";
			this.t_Period = "period";
			this.t_Period_Id = "period_id";
			this.t_Period_Period = "period";
			this.t_Period_Year = "year";
			this.t_Period_Period_Open = "period_open";
			this.t_Period_Period_Current = "period_current";
			this.t_ApprovalHierarchy = "approval_hierarchy";
			this.t_ApprovalHierarchy_c_Hierarchy_Id = "hierarchy_id";
			this.t_ApprovalHierarchy_c_Approver_Id = "approver_id";
			this.t_ApprovalHierarchy_c_Approver_Name = "approver_name";
			this.t_ApprovalHierarchy_c_Approvee_Id = "approvee_Id";
			this.t_ApprovalHierarchy_c_Approvee_Name = "approvee_name";
		}

		public void Approval_Approve(List<Entry> Entries, FivesBronxTimesheetManagement.Classes.User User)
		{
			try
			{
				this.DeleteTimeEntry(this.DeleteTimeEntryQStrings(this.t_Timesheet_Limbo, Entries));
				this.SaveTimeEntry(this.t_Timesheet_Final, Entries, ApprovalStatus.Approved, ApprovalStatus.Submitted, User);
				MessageBox.Show("Successfully Approved");
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
			}
		}

		public List<string> Approval_ApproveeList(int approverID)
		{
			object[] tApprovalHierarchy = new object[] { " SELECT *  FROM ", this.t_ApprovalHierarchy, " WHERE ", this.t_ApprovalHierarchy_c_Approver_Id, "='", approverID, "'" };
			this.qString = string.Concat(tApprovalHierarchy);
			return this.ReturnStringList(this.qString, this.t_ApprovalHierarchy_c_Approvee_Id);
		}

		public void Approval_Reject(List<Entry> entries, string rejectionReason)
		{
			List<int> nums = new List<int>();
			try
			{
				this.DeleteTimeEntry(this.DeleteTimeEntryQStrings(this.t_Timesheet_Limbo, entries));
				this.SaveTimeEntry(this.t_Timesheet_Prelim, entries, ApprovalStatus.Rejected, ApprovalStatus.NotSubmitted, rejectionReason);
				MessageBox.Show("Successfully Rejected");
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
			}
		}

		public void Approval_SubmitFor(List<Entry> Entries)
		{
			try
			{
				this.DeleteTimeEntry(this.DeleteTimeEntryQStrings(this.t_Timesheet_Prelim, Entries));
				this.SaveTimeEntry(this.t_Timesheet_Limbo, Entries, ApprovalStatus.Submitted, ApprovalStatus.Submitted);
				if (Entries.Count <= 0)
				{
					MessageBox.Show("No Items Selected");
				}
				else
				{
					MessageBox.Show("Successfully Submitted for Approval");
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
			}
		}

		public void CreateProject(Project project)
		{
			string[] tProjects = new string[] { "INSERT INTO ", this.t_Projects, " (", this.t_Projects_c_Country, ", ", this.t_Projects_c_IsOpen, ", ", this.t_Projects_c_IsWarrantyOpen, ", ", this.t_Projects_c_Machine, ", ", this.t_Projects_c_Number_BFC, ", ", this.t_Projects_c_Number_MAS90, ", ", this.t_Projects_c_Number_Network, ", ", this.t_Projects_c_Number_SAP, ", ", this.t_Projects_c_Number_Serial, ", ", this.t_Projects_c_Number_WarrantyNetwork, ", ", this.t_Projects_c_Customer, ") VALUES(@country, @isOpen, @isWarrantyOpen, @machine, @numberBFC, @numberMAS90, @numberNetwork, @numberSAP, @numberSerial, @numberWarrantyNetwork, @Customer)" };
			this.qString = string.Concat(tProjects);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@country", project.Country);
			mySqlCommand.Parameters.AddWithValue("@isOpen", project.IsOpen);
			mySqlCommand.Parameters.AddWithValue("@isWarrantyOpen", project.IsWarrantyOpen);
			mySqlCommand.Parameters.AddWithValue("@machine", project.Machine);
			mySqlCommand.Parameters.AddWithValue("@numberBFC", project.Number_BFC);
			mySqlCommand.Parameters.AddWithValue("@numberMAS90", project.Number_MAS90);
			mySqlCommand.Parameters.AddWithValue("@numberNetwork", project.Number_Network);
			mySqlCommand.Parameters.AddWithValue("@numberSAP", project.Number_SAP);
			mySqlCommand.Parameters.AddWithValue("@numberSerial", project.Number_Serial);
			mySqlCommand.Parameters.AddWithValue("@numberWarrantyNetwork", project.Number_WarrantyNetwork);
			mySqlCommand.Parameters.AddWithValue("@Customer", project.Customer);
			this.Insert(mySqlCommand);
		}

		public void CreateSection(Section section)
		{
			string[] tSections = new string[] { "INSERT INTO ", this.t_Sections, " (", this.t_Sections_c_Description_Activity, ", ", this.t_Sections_c_Description_Section, ", ", this.t_Sections_c_Number_Activity, ", ", this.t_Sections_c_Number_Project_Network, ", ", this.t_Sections_c_Number_Section, ", ", this.t_Sections_c_Task_Type, ") VALUES(@descriptionActivity, @descriptionSection, @numberActivity, @numberProjectNetwork, @numberSection, @taskType)" };
			this.qString = string.Concat(tSections);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@descriptionActivity", section.Description_Activity);
			mySqlCommand.Parameters.AddWithValue("@descriptionSection", section.Description_Section);
			mySqlCommand.Parameters.AddWithValue("@numberActivity", section.Number_Activity);
			mySqlCommand.Parameters.AddWithValue("@numberProjectNetwork", section.Number_ProjectNetwork);
			mySqlCommand.Parameters.AddWithValue("@numberSection", section.Number_Section);
			mySqlCommand.Parameters.AddWithValue("@taskType", section.TaskType);
			this.Insert(mySqlCommand);
		}

		public void CreateUser(User user)
		{
			string[] tUsers = new string[] { "INSERT INTO ", this.t_Users, " (", this.t_Users_c_User_Id, ", ", this.t_Users_c_Admin, ", ", this.t_Users_c_IsActive, ", ", this.t_Users_c_User_Name, ", ", this.t_Users_c_Validator, ") VALUES(@userID, @admin, @isActive, @userName, @validator)" };
			this.qString = string.Concat(tUsers);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@userId", user.UserID);
			mySqlCommand.Parameters.AddWithValue("@admin", user.IsAdmin);
			mySqlCommand.Parameters.AddWithValue("@isActive", user.IsActive);
			mySqlCommand.Parameters.AddWithValue("@userName", user.UserName);
			mySqlCommand.Parameters.AddWithValue("@validator", user.IsValidator);
			this.Insert(mySqlCommand);
		}

		public void CreateUser_Defaults(User user)
		{
			string[] tUsersDefaults = new string[] { "INSERT INTO ", this.t_UsersDefaults, " (", this.t_UsersDefaults_c_User_Id, ") VALUES(@userID)" };
			this.qString = string.Concat(tUsersDefaults);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@userId", user.UserID);
			this.Insert(mySqlCommand);
		}

		public void CreateUserLogin(User user)
		{
			string[] tLogin = new string[] { "INSERT INTO ", this.t_Login, " (", this.t_Login_c_User_Id, ", ", this.t_Login_c_password, ") VALUES(@userID, @password)" };
			this.qString = string.Concat(tLogin);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@userId", user.UserID);
			mySqlCommand.Parameters.AddWithValue("@password", "letmein");
			this.Insert(mySqlCommand);
		}

		public void DeleteTimeEntry(int entryId)
		{
			object[] tTimesheetPrelim = new object[] { "DELETE FROM ", this.t_Timesheet_Prelim, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entryId, "'" };
			this.qString = string.Concat(tTimesheetPrelim);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			try
			{
				this.myConnection.Open();
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				MessageBox.Show("Entry Deleted");
				while (mySqlDataReader.Read())
				{
				}
				mySqlDataReader.Close();
				this.myConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				try
				{
					this.myConnection.Close();
					MessageBox.Show(exception.Message);
				}
				catch
				{
					MessageBox.Show(exception.Message);
				}
			}
		}

		public void DeleteTimeEntry(List<string> qStrings)
		{
			this.myConnection.Open();
			try
			{
				foreach (string qString in qStrings)
				{
					MySqlCommand mySqlCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
					}
					mySqlDataReader.Close();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
			this.myConnection.Close();
		}

		public void DeleteTimeEntry(string tableName, int entryId)
		{
			object[] objArray = new object[] { "DELETE FROM ", tableName, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entryId, "'" };
			this.qString = string.Concat(objArray);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			try
			{
				this.myConnection.Open();
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				MessageBox.Show("Entry Deleted");
				while (mySqlDataReader.Read())
				{
				}
				mySqlDataReader.Close();
				this.myConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				try
				{
					this.myConnection.Close();
					MessageBox.Show(exception.Message);
				}
				catch
				{
					MessageBox.Show(exception.Message);
				}
			}
		}

		public List<string> DeleteTimeEntryQStrings(string tableName, List<int> entryIds)
		{
			List<string> strs = new List<string>();
			foreach (int entryId in entryIds)
			{
				object[] objArray = new object[] { "DELETE FROM ", tableName, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entryId, "'" };
				strs.Add(string.Concat(objArray));
			}
			return strs;
		}

		public List<string> DeleteTimeEntryQStrings(string tableName, List<Entry> entries)
		{
			List<string> strs = new List<string>();
			foreach (Entry entry in entries)
			{
				object[] value = new object[] { "DELETE FROM ", tableName, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", null, null };
				value[5] = entry.entry_id.Value;
				value[6] = "'";
				strs.Add(string.Concat(value));
			}
			return strs;
		}

		public List<Entry> Entries(string table, List<int> entry_ids)
		{
			List<Entry> entries = new List<Entry>();
			List<string> strs = new List<string>();
			List<int> entryIds = entry_ids;
			List<int> nums = this.ReturnIntList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_User_Id);
			List<string> strs1 = this.ReturnStringList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_User_Name);
			List<int?> nullables = this.ReturnIntNList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Section_Id);
			List<string> strs2 = this.ReturnStringList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Project_Serial);
			List<string> strs3 = this.ReturnStringList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Project_Sap);
			List<string> strs4 = this.ReturnStringList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Number_Section);
			List<int?> nullables1 = this.ReturnIntNList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Number_Network);
			List<string> strs5 = this.ReturnStringList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Number_Activity);
			List<DateTime> dateTimes = this.ReturnDateList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Date);
			List<int> nums1 = this.ReturnIntList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Period);
			List<int> nums2 = this.ReturnIntList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Year);
			List<double> nums3 = this.ReturnDoubleList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Hours);
			List<string> strs6 = this.ReturnStringList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Description);
			List<string> strs7 = this.ReturnStringList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Timesheet_Code);
			List<string> strs8 = this.ReturnStringList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Task_Type);
			List<string> strs9 = this.ReturnStringList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Submitted_Status);
			List<string> strs10 = this.ReturnStringList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Approval_Status);
			List<string> strs11 = this.ReturnStringList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Rejection_Reason);
			List<int?> nullables2 = this.ReturnIntNList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Approved_By_User_Id);
			List<string> strs12 = this.ReturnStringList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Approved_By_User_Name);
			List<DateTime> dateTimes1 = this.ReturnDateList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Date_Created);
			List<DateTime> dateTimes2 = this.ReturnDateList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Date_Modified);
			List<DateTime?> nullables3 = this.ReturnDateNList(this.Entry_QStrings_FromEntryId(table, entry_ids), this.t_Timesheet_c_Date_Approved);
			for (int i = 0; i < entry_ids.Count; i++)
			{
				entries.Add(new Entry(new int?(entryIds[i]), nums[i], strs1[i], nullables[i], strs2[i], strs3[i], strs4[i], nullables1[i], strs5[i], dateTimes[i], nums1[i], nums2[i], nums3[i], strs6[i], strs7[i], strs8[i], strs9[i], this.functions.approvalStatus(strs10[i]), strs11[i], nullables2[i], strs12[i], dateTimes1[i], dateTimes2[i], nullables3[i]));
			}
			return entries;
		}

		public Entry Entry(string table, int entry_id)
		{
			Entry entry = new Entry(new int?(entry_id), this.Entry_UserId(table, entry_id), this.Entry_UserName(table, entry_id), new int?(this.Entry_SectionId(table, entry_id)), this.Entry_ProjectSerial(table, entry_id), this.Entry_ProjectSap(table, entry_id), this.Entry_NumberSection(table, entry_id), new int?(this.Entry_NumberNetwork(table, entry_id)), this.Entry_NumberActivity(table, entry_id), this.Entry_Date(table, entry_id), this.Entry_Period(table, entry_id), this.Entry_Year(table, entry_id), this.Entry_Hours(table, entry_id), this.Entry_Description(table, entry_id), this.Entry_TimesheetCode(table, entry_id), this.Entry_TaskType(table, entry_id), this.Entry_SubmittedStatus(table, entry_id), this.functions.approvalStatus(this.Entry_ApprovalStatus(table, entry_id)), this.Entry_RejectionReason(table, entry_id), this.Entry_ApprovedByUserId(table, entry_id), this.Entry_ApprovedByUserName(table, entry_id), this.Entry_DateCreated(table, entry_id), this.Entry_DateModified(table, entry_id), new DateTime?(this.Entry_DateApproved(table, entry_id)));
			return entry;
		}

		public string Entry_ApprovalStatus(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnString(this.qString, this.t_Timesheet_c_Approval_Status);
		}

		public int? Entry_ApprovedByUserId(string table, int entry_id)
		{
			int? nullable;
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			int num = 0;
			if (!int.TryParse(this.ReturnString(this.qString, this.t_Timesheet_c_Approved_By_User_Id), out num))
			{
				nullable = null;
			}
			else
			{
				nullable = new int?(num);
			}
			return nullable;
		}

		public string Entry_ApprovedByUserName(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnString(this.qString, this.t_Timesheet_c_Approved_By_User_Name);
		}

		public DateTime Entry_Date(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnDateTime(this.qString, this.t_Timesheet_c_Date);
		}

		public DateTime Entry_DateApproved(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnDateTime(this.qString, this.t_Timesheet_c_Date_Approved);
		}

		public DateTime Entry_DateCreated(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnDateTime(this.qString, this.t_Timesheet_c_Date_Created);
		}

		public DateTime Entry_DateModified(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnDateTime(this.qString, this.t_Timesheet_c_Date_Modified);
		}

		public string Entry_Description(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnString(this.qString, this.t_Timesheet_c_Description);
		}

		public double Entry_Hours(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnDouble(this.qString, this.t_Timesheet_c_Hours);
		}

		public string Entry_NumberActivity(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnString(this.qString, this.t_Timesheet_c_Number_Activity);
		}

		public int Entry_NumberNetwork(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnInt(this.qString, this.t_Timesheet_c_Number_Network);
		}

		public string Entry_NumberSection(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnString(this.qString, this.t_Timesheet_c_Number_Section);
		}

		public int Entry_Period(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnInt(this.qString, this.t_Timesheet_c_Period);
		}

		public string Entry_ProjectSap(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnString(this.qString, this.t_Timesheet_c_Project_Sap);
		}

		public string Entry_ProjectSerial(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnString(this.qString, this.t_Timesheet_c_Project_Serial);
		}

		public List<string> Entry_QStrings_FromEntryId(string table, List<int> entry_ids)
		{
			List<string> strs = new List<string>();
			foreach (int entryId in entry_ids)
			{
				object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entryId, "'" };
				strs.Add(string.Concat(objArray));
			}
			return strs;
		}

		public string Entry_RejectionReason(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnString(this.qString, this.t_Timesheet_c_Rejection_Reason);
		}

		public int Entry_SectionId(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnInt(this.qString, this.t_Timesheet_c_Section_Id);
		}

		public string Entry_SubmittedStatus(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnString(this.qString, this.t_Timesheet_c_Submitted_Status);
		}

		public string Entry_TaskType(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnString(this.qString, this.t_Timesheet_c_Task_Type);
		}

		public string Entry_TimesheetCode(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnString(this.qString, this.t_Timesheet_c_Timesheet_Code);
		}

		public int Entry_UserId(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnInt(this.qString, this.t_Timesheet_c_User_Id);
		}

		public string Entry_UserName(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnString(this.qString, this.t_Timesheet_c_User_Name);
		}

		public int Entry_Year(string table, int entry_id)
		{
			object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", this.t_Timesheet_c_Entry_Id, "='", entry_id, "'" };
			this.qString = string.Concat(objArray);
			return this.ReturnInt(this.qString, this.t_Timesheet_c_Year);
		}

		public User GetUser(int user_id)
		{
			return new User(user_id);
		}

		public List<User> GetUser_All()
		{
			List<User> users = new List<User>();
			this.qString = string.Concat("SELECT *  FROM ", this.t_Users);
			foreach (int num in this.ReturnIntList(this.qString, this.t_Users_c_User_Id))
			{
				users.Add(new User(num));
			}
			return users;
		}

		private void Insert(MySqlCommand cmd)
		{
			try
			{
				this.myConnection.Open();
				cmd.ExecuteNonQuery();
				MessageBox.Show("Saved");
				this.myConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				try
				{
					this.myConnection.Close();
					MessageBox.Show(exception.Message);
				}
				catch
				{
					MessageBox.Show(exception.Message);
				}
			}
		}

		private void Insert(List<MySqlCommand> cmds)
		{
			try
			{
				this.myConnection.Open();
				foreach (MySqlCommand cmd in cmds)
				{
					cmd.ExecuteNonQuery();
				}
				this.myConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				try
				{
					this.myConnection.Close();
					MessageBox.Show(exception.Message);
				}
				catch
				{
					MessageBox.Show(exception.Message);
				}
			}
		}

		public int Period_Id(int month, int year)
		{
			object[] tPeriod = new object[] { " SELECT *  FROM ", this.t_Period, " WHERE ", this.t_Period_Period, "='", month, "'  AND ", this.t_Period_Year, "='", year, "'" };
			this.qString = string.Concat(tPeriod);
			return this.ReturnInt(this.qString, this.t_Period_Id);
		}

		public bool Period_Open(int month, int year)
		{
			object[] tPeriod = new object[] { " SELECT *  FROM ", this.t_Period, " WHERE ", this.t_Period_Period, "='", month, "'  AND ", this.t_Period_Year, "='", year, "'" };
			this.qString = string.Concat(tPeriod);
			return this.ReturnBool(this.qString, this.t_Period_Period_Open);
		}

		public Project Project(string numberSerial)
		{
			string[] tProjects = new string[] { "SELECT * FROM ", this.t_Projects, " WHERE ", this.t_Projects_c_Number_Serial, " ='", numberSerial, "'" };
			this.qString = string.Concat(tProjects);
			return this.ReturnProject(this.qString);
		}

		public List<Project> ProjectAll()
		{
			this.qString = string.Concat("SELECT * FROM ", this.t_Projects);
			return this.ReturnProjectList(this.qString);
		}

		public string ProjectCountry(string numberSerial)
		{
			string[] tProjects = new string[] { "SELECT * FROM ", this.t_Projects, " WHERE ", this.t_Projects_c_Number_Serial, " ='", numberSerial, "'" };
			this.qString = string.Concat(tProjects);
			return this.ReturnString(this.qString, this.t_Projects_c_Country);
		}

		public bool ProjectIsOpen(string numberSerial)
		{
			string[] tProjects = new string[] { "SELECT * FROM ", this.t_Projects, " WHERE ", this.t_Projects_c_Number_Serial, " ='", numberSerial, "'" };
			this.qString = string.Concat(tProjects);
			return this.ReturnBool(this.qString, this.t_Projects_c_IsOpen);
		}

		public bool ProjectIsWarrantyOpen(string numberSerial)
		{
			string[] tProjects = new string[] { "SELECT * FROM ", this.t_Projects, " WHERE ", this.t_Projects_c_Number_Serial, " ='", numberSerial, "'" };
			this.qString = string.Concat(tProjects);
			return this.ReturnBool(this.qString, this.t_Projects_c_IsWarrantyOpen);
		}

		public string ProjectMachine(string numberSerial)
		{
			string[] tProjects = new string[] { "SELECT * FROM ", this.t_Projects, " WHERE ", this.t_Projects_c_Number_Serial, " ='", numberSerial, "'" };
			this.qString = string.Concat(tProjects);
			return this.ReturnString(this.qString, this.t_Projects_c_Machine);
		}

		public string ProjectName(string numberSerial)
		{
			string[] tProjects = new string[] { "SELECT * FROM ", this.t_Projects, " WHERE ", this.t_Projects_c_Number_Serial, " ='", numberSerial, "'" };
			this.qString = string.Concat(tProjects);
			return this.ReturnString(this.qString, this.t_Projects_c_Customer);
		}

		public string ProjectNameAndMachineName(string numberSerial)
		{
			string[] tProjects = new string[] { "SELECT * FROM ", this.t_Projects, " WHERE ", this.t_Projects_c_Number_Serial, " ='", numberSerial, "'" };
			this.qString = string.Concat(tProjects);
			string str = this.ReturnString(this.qString, this.t_Projects_c_Customer, this.t_Projects_c_Machine);
			return str;
		}

		public string ProjectNumber_BFC(string numberSerial)
		{
			string[] tProjects = new string[] { "SELECT * FROM ", this.t_Projects, " WHERE ", this.t_Projects_c_Number_Serial, " ='", numberSerial, "'" };
			this.qString = string.Concat(tProjects);
			return this.ReturnString(this.qString, this.t_Projects_c_Number_BFC);
		}

		public string ProjectNumber_MAS90(string numberSerial)
		{
			string[] tProjects = new string[] { "SELECT * FROM ", this.t_Projects, " WHERE ", this.t_Projects_c_Number_Serial, " ='", numberSerial, "'" };
			this.qString = string.Concat(tProjects);
			return this.ReturnString(this.qString, this.t_Projects_c_Number_MAS90);
		}

		public string ProjectNumber_Network(string numberSerial)
		{
			string[] tProjects = new string[] { "SELECT * FROM ", this.t_Projects, " WHERE ", this.t_Projects_c_Number_Serial, " ='", numberSerial, "'" };
			this.qString = string.Concat(tProjects);
			return this.ReturnString(this.qString, this.t_Projects_c_Number_Network);
		}

		public string ProjectNumber_SAP(string numberSerial)
		{
			string[] tProjects = new string[] { "SELECT * FROM ", this.t_Projects, " WHERE ", this.t_Projects_c_Number_Serial, "='", numberSerial, "'" };
			this.qString = string.Concat(tProjects);
			return this.ReturnString(this.qString, this.t_Projects_c_Number_SAP);
		}

		public string ProjectNumber_WarrantyNetwork(string numberSerial)
		{
			string[] tProjects = new string[] { "SELECT * FROM ", this.t_Projects, " WHERE ", this.t_Projects_c_Number_Serial, " ='", numberSerial, "'" };
			this.qString = string.Concat(tProjects);
			return this.ReturnString(this.qString, this.t_Projects_c_Number_WarrantyNetwork);
		}

		public List<string> Projects()
		{
			this.qString = string.Concat("SELECT * FROM ", this.t_Projects);
			return this.ReturnStringList(this.qString, this.t_Projects_c_Number_Serial);
		}

		public void ResetUserLogin(User user)
		{
			string[] tLogin = new string[] { "Update ", this.t_Login, " SET ", this.t_Login_c_password, "=@password  WHERE ", this.t_Login_c_User_Id, "=@userId" };
			this.qString = string.Concat(tLogin);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@password", "letmein");
			mySqlCommand.Parameters.AddWithValue("@userId", user.UserID);
			this.Update(mySqlCommand);
		}

		private bool ReturnBool(string qString, string tableColumn)
		{
			bool flag;
			this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
			this.myConnection.Open();
			MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
			if (mySqlDataReader.Read())
			{
				int num = mySqlDataReader.GetInt16(tableColumn);
				mySqlDataReader.Close();
				this.myConnection.Close();
				flag = (num != 1 ? false : true);
			}
			else
			{
				flag = false;
			}
			return flag;
		}

		private List<bool> ReturnBoolList(List<string> qStrings, string tableColumn)
		{
			List<bool> flags = new List<bool>();
			this.myConnection.Open();
			foreach (string qString in qStrings)
			{
				this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
				MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
				while (mySqlDataReader.Read())
				{
					int num = mySqlDataReader.GetInt16(tableColumn);
					mySqlDataReader.Close();
					if (num != 1)
					{
						flags.Add(false);
					}
					else
					{
						flags.Add(true);
					}
				}
			}
			this.myConnection.Close();
			return flags;
		}

		private List<DateTime> ReturnDateList(List<string> qStrings, string tableColumn)
		{
			List<DateTime> dateTimes = new List<DateTime>();
			this.myConnection.Open();
			foreach (string qString in qStrings)
			{
				this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
				MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
				while (mySqlDataReader.Read())
				{
					dateTimes.Add(DateTime.Parse(mySqlDataReader.GetString(tableColumn)));
				}
				mySqlDataReader.Close();
			}
			this.myConnection.Close();
			return dateTimes;
		}

		private List<DateTime?> ReturnDateNList(List<string> qStrings, string tableColumn)
		{
			List<DateTime?> nullables = new List<DateTime?>();
			this.myConnection.Open();
			foreach (string qString in qStrings)
			{
				this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
				MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
				while (mySqlDataReader.Read())
				{
					try
					{
						nullables.Add(new DateTime?(DateTime.Parse(mySqlDataReader.GetString(tableColumn))));
					}
					catch
					{
						nullables.Add(null);
					}
				}
				mySqlDataReader.Close();
			}
			this.myConnection.Close();
			return nullables;
		}

		private DateTime ReturnDateTime(string qString, string tableColumn)
		{
			DateTime now = DateTime.Now;
			this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
			this.myConnection.Open();
			MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
			while (mySqlDataReader.Read())
			{
				now = DateTime.Parse(mySqlDataReader.GetString(tableColumn));
			}
			mySqlDataReader.Close();
			this.myConnection.Close();
			return now;
		}

		private double ReturnDouble(string qString, string tableColumn)
		{
			double num = 0;
			this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
			this.myConnection.Open();
			MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
			while (mySqlDataReader.Read())
			{
				num = double.Parse(mySqlDataReader.GetString(tableColumn));
			}
			mySqlDataReader.Close();
			this.myConnection.Close();
			return num;
		}

		private List<double> ReturnDoubleList(List<string> qStrings, string tableColumn)
		{
			List<double> nums = new List<double>();
			this.myConnection.Open();
			foreach (string qString in qStrings)
			{
				this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
				MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
				while (mySqlDataReader.Read())
				{
					nums.Add(double.Parse(mySqlDataReader.GetString(tableColumn)));
				}
				mySqlDataReader.Close();
			}
			this.myConnection.Close();
			return nums;
		}

		private int ReturnInt(string qString, string tableColumn)
		{
			int num = 0;
			this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
			this.myConnection.Open();
			MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
			while (mySqlDataReader.Read())
			{
				num = int.Parse(mySqlDataReader.GetString(tableColumn));
			}
			mySqlDataReader.Close();
			this.myConnection.Close();
			return num;
		}

		private List<int> ReturnIntList(string qString, string tableColumn)
		{
			List<int> nums = new List<int>();
			this.myConnection.Open();
			this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
			MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
			try
			{
				while (mySqlDataReader.Read())
				{
					nums.Add(int.Parse(mySqlDataReader.GetString(tableColumn)));
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
			}
			mySqlDataReader.Close();
			this.myConnection.Close();
			return nums;
		}

		public List<int> ReturnIntList(List<string> qStrings, string tableColumn)
		{
			List<int> nums = new List<int>();
			this.myConnection.Open();
			foreach (string qString in qStrings)
			{
				this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
				MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
				while (mySqlDataReader.Read())
				{
					nums.Add(int.Parse(mySqlDataReader.GetString(tableColumn)));
				}
				mySqlDataReader.Close();
			}
			this.myConnection.Close();
			return nums;
		}

		private List<int?> ReturnIntNList(List<string> qStrings, string tableColumn)
		{
			List<int?> nullables = new List<int?>();
			this.myConnection.Open();
			foreach (string qString in qStrings)
			{
				this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
				MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
				while (mySqlDataReader.Read())
				{
					try
					{
						nullables.Add(new int?(int.Parse(mySqlDataReader.GetString(tableColumn))));
					}
					catch
					{
						nullables.Add(null);
					}
				}
				mySqlDataReader.Close();
			}
			this.myConnection.Close();
			return nullables;
		}

		private Project ReturnProject(string qString)
		{
			Project project = new Project();
			this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
			this.myConnection.Open();
			MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
			while (mySqlDataReader.Read())
			{
				project.Country = mySqlDataReader.GetString(this.t_Projects_c_Country);
				project.IsOpen = int.Parse(mySqlDataReader.GetString(this.t_Projects_c_IsOpen));
				project.IsWarrantyOpen = int.Parse(mySqlDataReader.GetString(this.t_Projects_c_IsWarrantyOpen));
				project.Machine = mySqlDataReader.GetString(this.t_Projects_c_Machine);
				project.Number_BFC = mySqlDataReader.GetString(this.t_Projects_c_Number_BFC);
				project.Number_MAS90 = mySqlDataReader.GetString(this.t_Projects_c_Number_MAS90);
				project.Number_Network = int.Parse(mySqlDataReader.GetString(this.t_Projects_c_Number_Network));
				project.Number_SAP = mySqlDataReader.GetString(this.t_Projects_c_Number_SAP);
				project.Number_Serial = mySqlDataReader.GetString(this.t_Projects_c_Number_Serial);
				project.Number_WarrantyNetwork = int.Parse(mySqlDataReader.GetString(this.t_Projects_c_Number_WarrantyNetwork));
				project.Customer = mySqlDataReader.GetString(this.t_Projects_c_Customer);
			}
			mySqlDataReader.Close();
			this.myConnection.Close();
			return project;
		}

		private List<Project> ReturnProjectList(string qString)
		{
			List<Project> projects = new List<Project>();
			this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
			this.myConnection.Open();
			MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
			while (mySqlDataReader.Read())
			{
                Project project = new Project();
                project.Country = mySqlDataReader.GetString(this.t_Projects_c_Country);
                project.IsOpen = int.Parse(mySqlDataReader.GetString(this.t_Projects_c_IsOpen));
                project.IsWarrantyOpen = int.Parse(mySqlDataReader.GetString(this.t_Projects_c_IsWarrantyOpen));
                project.Machine = mySqlDataReader.GetString(this.t_Projects_c_Machine);
                project.Number_BFC = mySqlDataReader.GetString(this.t_Projects_c_Number_BFC);
                project.Number_MAS90 = mySqlDataReader.GetString(this.t_Projects_c_Number_MAS90);
                project.Number_Network = int.Parse(mySqlDataReader.GetString(this.t_Projects_c_Number_Network));
                project.Number_SAP = mySqlDataReader.GetString(this.t_Projects_c_Number_SAP);
                project.Number_Serial = mySqlDataReader.GetString(this.t_Projects_c_Number_Serial);
                project.Number_WarrantyNetwork = int.Parse(mySqlDataReader.GetString(this.t_Projects_c_Number_WarrantyNetwork));
				project.Customer = mySqlDataReader.GetString(this.t_Projects_c_Customer);
				projects.Add(project);
			}
			mySqlDataReader.Close();
			this.myConnection.Close();
			return projects;
		}

		private Section ReturnSection(string qString)
		{
			Section section = new Section();
			this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
			this.myConnection.Open();
			MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
			while (mySqlDataReader.Read())
			{
				section.Id = int.Parse(mySqlDataReader.GetString(this.t_Sections_c_Entry_Id));
				section.Number_ProjectNetwork = mySqlDataReader.GetString(this.t_Sections_c_Number_Project_Network);
				section.Number_Section = mySqlDataReader.GetString(this.t_Sections_c_Number_Section);
				section.Description_Section = mySqlDataReader.GetString(this.t_Sections_c_Description_Section);
				section.Number_Activity = mySqlDataReader.GetString(this.t_Sections_c_Number_Activity);
				section.TaskType = mySqlDataReader.GetString(this.t_Sections_c_Task_Type);
				section.Description_Activity = mySqlDataReader.GetString(this.t_Sections_c_Description_Activity);
			}
			mySqlDataReader.Close();
			this.myConnection.Close();
			return section;
		}

		private List<Section> ReturnSectionList(string qString)
		{
			List<Section> sections = new List<Section>();
			this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
			this.myConnection.Open();
			MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
			while (mySqlDataReader.Read())
			{
				Section section = new Section()
				{
					Id = int.Parse(mySqlDataReader.GetString(this.t_Sections_c_Entry_Id)),
					Number_ProjectNetwork = mySqlDataReader.GetString(this.t_Sections_c_Number_Project_Network),
					Number_Section = mySqlDataReader.GetString(this.t_Sections_c_Number_Section),
					Description_Section = mySqlDataReader.GetString(this.t_Sections_c_Description_Section),
					Number_Activity = mySqlDataReader.GetString(this.t_Sections_c_Number_Activity),
					TaskType = mySqlDataReader.GetString(this.t_Sections_c_Task_Type),
					Description_Activity = mySqlDataReader.GetString(this.t_Sections_c_Description_Activity)
				};
				sections.Add(section);
			}
			mySqlDataReader.Close();
			this.myConnection.Close();
			return sections;
		}

		private string ReturnString(string qString, string tableColumn)
		{
			string str = "";
			this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
			this.myConnection.Open();
			MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
			while (mySqlDataReader.Read())
			{
				try
				{
					str = mySqlDataReader.GetString(tableColumn);
				}
				catch
				{
					str = "";
				}
			}
			mySqlDataReader.Close();
			this.myConnection.Close();
			return str;
		}

		private string ReturnString(string qString, string tableColumn, string tableColumn2)
		{
			string str = "";
			string str1 = "";
			this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
			this.myConnection.Open();
			MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
			while (mySqlDataReader.Read())
			{
				str = mySqlDataReader.GetString(tableColumn);
				str1 = mySqlDataReader.GetString(tableColumn2);
			}
			mySqlDataReader.Close();
			this.myConnection.Close();
			return string.Concat(str, "-", str1);
		}

		private List<string> ReturnStringList(string qString, string tableColumn)
		{
			List<string> strs = new List<string>();
			this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
			this.myConnection.Open();
			MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
			while (mySqlDataReader.Read())
			{
				strs.Add(mySqlDataReader.GetString(tableColumn));
			}
			mySqlDataReader.Close();
			this.myConnection.Close();
			return strs;
		}

		private List<string> ReturnStringList(List<string> qStrings, string tableColumn)
		{
			List<string> strs = new List<string>();
			this.myConnection.Open();
			foreach (string qString in qStrings)
			{
				this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
				MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
				while (mySqlDataReader.Read())
				{
					try
					{
						strs.Add(mySqlDataReader.GetString(tableColumn));
					}
					catch
					{
						strs.Add("");
					}
				}
				mySqlDataReader.Close();
			}
			this.myConnection.Close();
			return strs;
		}

		private List<TaskType> ReturnTaskTypeList(string qString)
		{
			List<TaskType> taskTypes = new List<TaskType>();
			this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
			this.myConnection.Open();
			MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
			while (mySqlDataReader.Read())
			{
				TaskType taskType = new TaskType()
				{
					Id = mySqlDataReader.GetString(this.t_Task_Type_c_Task_Type),
					Description = mySqlDataReader.GetString(this.t_Task_Type_c_Task_Type_description)
				};
				taskTypes.Add(taskType);
			}
			mySqlDataReader.Close();
			this.myConnection.Close();
			return taskTypes;
		}

		private List<TaskType> ReturnTaskTypeUsedList(string qString)
		{
			List<TaskType> taskTypes = new List<TaskType>();
			List<TaskType> taskTypes1 = this.TaskTypesAll();
			this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
			this.myConnection.Open();
			MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
			while (mySqlDataReader.Read())
			{
                TaskType taskType = new TaskType();
                taskType.ActivityNumber = mySqlDataReader.GetString(this.t_Sections_c_Number_Activity);
				taskType.Id = mySqlDataReader.GetString(this.t_Sections_c_Task_Type);
				taskType.Description = (
					from X in taskTypes1
					where X.Id == taskType.Id
					select X.Description).First<string>().ToString();
				taskTypes.Add(taskType);
			}
			mySqlDataReader.Close();
			this.myConnection.Close();
			return taskTypes;
		}

		private TimesheetCode ReturnTimesheetCode(string qString)
		{
			TimesheetCode timesheetCode = new TimesheetCode();
			this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
			this.myConnection.Open();
			MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
			while (mySqlDataReader.Read())
			{
				timesheetCode.Code = mySqlDataReader.GetString(this.t_Timesheet_Codes_c_Timesheet_Code);
				timesheetCode.Description = mySqlDataReader.GetString(this.t_Timesheet_Codes_c_Timesheet_Description);
			}
			mySqlDataReader.Close();
			this.myConnection.Close();
			return timesheetCode;
		}

		private List<TimesheetCode> ReturnTimesheetCodeList(string qString)
		{
			List<TimesheetCode> timesheetCodes = new List<TimesheetCode>();
			this.myCommand = new MySqlCommand(qString, this.myConnection.MySqlConnection);
			this.myConnection.Open();
			MySqlDataReader mySqlDataReader = this.myCommand.ExecuteReader();
			while (mySqlDataReader.Read())
			{
				TimesheetCode timesheetCode = new TimesheetCode()
				{
					Code = mySqlDataReader.GetString(this.t_Timesheet_Codes_c_Timesheet_Code),
					Description = mySqlDataReader.GetString(this.t_Timesheet_Codes_c_Timesheet_Description)
				};
				timesheetCodes.Add(timesheetCode);
			}
			mySqlDataReader.Close();
			this.myConnection.Close();
			return timesheetCodes;
		}

		public void SaveTimeEntry(int userId, string userName, int? sectionId, string projectSerial, string projectSAP, string numberSection, int? network, string activity, DateTime date, int period, int year, double hours, string description, string timesheetCode, string taskType, string submittedStatus, string approvalStatus)
		{
			string[] tTimesheetPrelim = new string[] { "INSERT INTO ", this.t_Timesheet_Prelim, " (", this.t_Timesheet_c_User_Id, ", ", this.t_Timesheet_c_User_Name, ", ", this.t_Timesheet_c_Section_Id, ", ", this.t_Timesheet_c_Project_Serial, ", ", this.t_Timesheet_c_Project_Sap, ", ", this.t_Timesheet_c_Number_Section, ", ", this.t_Timesheet_c_Number_Network, ", ", this.t_Timesheet_c_Number_Activity, ", ", this.t_Timesheet_c_Date, ", ", this.t_Timesheet_c_Period, ", ", this.t_Timesheet_c_Year, ", ", this.t_Timesheet_c_Hours, ", ", this.t_Timesheet_c_Description, ", ", this.t_Timesheet_c_Timesheet_Code, ", ", this.t_Timesheet_c_Task_Type, ", ", this.t_Timesheet_c_Submitted_Status, ", ", this.t_Timesheet_c_Approval_Status, ", ", this.t_Timesheet_c_Date_Created, ") VALUES(@userId, @userName, @sectionId, @projectSerial, @projectSAP, @numberSection, @network, @activity, @date, @period, @year, @hours, @description, @timesheetCode, @taskType, @submittedStatus, @approvalStatus, @dateCreated)" };
			this.qString = string.Concat(tTimesheetPrelim);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@userId", userId);
			mySqlCommand.Parameters.AddWithValue("@userName", userName);
			mySqlCommand.Parameters.AddWithValue("@sectionId", sectionId);
			mySqlCommand.Parameters.AddWithValue("@projectSerial", projectSerial);
			mySqlCommand.Parameters.AddWithValue("@projectSAP", projectSAP);
			mySqlCommand.Parameters.AddWithValue("@numberSection", numberSection);
			mySqlCommand.Parameters.AddWithValue("@network", network);
			mySqlCommand.Parameters.AddWithValue("@activity", activity);
			mySqlCommand.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
			mySqlCommand.Parameters.AddWithValue("@period", period);
			mySqlCommand.Parameters.AddWithValue("@year", year);
			mySqlCommand.Parameters.AddWithValue("@hours", hours);
			mySqlCommand.Parameters.AddWithValue("@description", description);
			mySqlCommand.Parameters.AddWithValue("@timesheetCode", timesheetCode);
			mySqlCommand.Parameters.AddWithValue("@taskType", taskType);
			mySqlCommand.Parameters.AddWithValue("@submittedStatus", submittedStatus);
			mySqlCommand.Parameters.AddWithValue("@approvalStatus", approvalStatus);
			MySqlParameterCollection parameters = mySqlCommand.Parameters;
			DateTime now = DateTime.Now;
			parameters.AddWithValue("@dateCreated", now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
			this.Insert(mySqlCommand);
		}

		public void SaveTimeEntry(string tableName, int userId, string userName, int? sectionId, string projectSerial, string projectSAP, string numberSection, int? network, string activity, DateTime date, int period, int year, double hours, string description, string timesheetCode, string taskType, string submittedStatus, string approvalStatus)
		{
			string[] strArrays = new string[] { "INSERT INTO ", tableName, " (", this.t_Timesheet_c_User_Id, ", ", this.t_Timesheet_c_User_Name, ", ", this.t_Timesheet_c_Section_Id, ", ", this.t_Timesheet_c_Project_Serial, ", ", this.t_Timesheet_c_Project_Sap, ", ", this.t_Timesheet_c_Number_Section, ", ", this.t_Timesheet_c_Number_Network, ", ", this.t_Timesheet_c_Number_Activity, ", ", this.t_Timesheet_c_Date, ", ", this.t_Timesheet_c_Period, ", ", this.t_Timesheet_c_Year, ", ", this.t_Timesheet_c_Hours, ", ", this.t_Timesheet_c_Description, ", ", this.t_Timesheet_c_Timesheet_Code, ", ", this.t_Timesheet_c_Task_Type, ", ", this.t_Timesheet_c_Submitted_Status, ", ", this.t_Timesheet_c_Approval_Status, ", ", this.t_Timesheet_c_Date_Created, ") VALUES(@userId, @userName, @sectionId, @projectSerial, @projectSAP, @numberSection, @network, @activity, @date, @period, @year, @hours, @description, @timesheetCode, @taskType, @submittedStatus, @approvalStatus, @dateCreated)" };
			this.qString = string.Concat(strArrays);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@userId", userId);
			mySqlCommand.Parameters.AddWithValue("@userName", userName);
			mySqlCommand.Parameters.AddWithValue("@sectionId", sectionId);
			mySqlCommand.Parameters.AddWithValue("@projectSerial", projectSerial);
			mySqlCommand.Parameters.AddWithValue("@projectSAP", projectSAP);
			mySqlCommand.Parameters.AddWithValue("@numberSection", numberSection);
			mySqlCommand.Parameters.AddWithValue("@network", network);
			mySqlCommand.Parameters.AddWithValue("@activity", activity);
			mySqlCommand.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
			mySqlCommand.Parameters.AddWithValue("@period", period);
			mySqlCommand.Parameters.AddWithValue("@year", year);
			mySqlCommand.Parameters.AddWithValue("@hours", hours);
			mySqlCommand.Parameters.AddWithValue("@description", description);
			mySqlCommand.Parameters.AddWithValue("@timesheetCode", timesheetCode);
			mySqlCommand.Parameters.AddWithValue("@taskType", taskType);
			mySqlCommand.Parameters.AddWithValue("@submittedStatus", submittedStatus);
			mySqlCommand.Parameters.AddWithValue("@approvalStatus", approvalStatus);
			MySqlParameterCollection parameters = mySqlCommand.Parameters;
			DateTime now = DateTime.Now;
			parameters.AddWithValue("@dateCreated", now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
			this.Insert(mySqlCommand);
		}

		public void SaveTimeEntry(string tableName, Entry entry, ApprovalStatus approvalStatus, ApprovalStatus submittedStatus)
		{
			string[] strArrays = new string[] { "INSERT INTO ", tableName, " (", this.t_Timesheet_c_User_Id, ", ", this.t_Timesheet_c_User_Name, ", ", this.t_Timesheet_c_Section_Id, ", ", this.t_Timesheet_c_Project_Serial, ", ", this.t_Timesheet_c_Project_Sap, ", ", this.t_Timesheet_c_Number_Section, ", ", this.t_Timesheet_c_Number_Network, ", ", this.t_Timesheet_c_Number_Activity, ", ", this.t_Timesheet_c_Date, ", ", this.t_Timesheet_c_Period, ", ", this.t_Timesheet_c_Year, ", ", this.t_Timesheet_c_Hours, ", ", this.t_Timesheet_c_Description, ", ", this.t_Timesheet_c_Timesheet_Code, ", ", this.t_Timesheet_c_Task_Type, ", ", this.t_Timesheet_c_Submitted_Status, ", ", this.t_Timesheet_c_Approval_Status, ", ", this.t_Timesheet_c_Date_Created, ", ", this.t_Timesheet_c_Date_Modified, ") VALUES(@userId, @userName, @sectionId, @projectSerial, @projectSAP, @numberSection, @network, @activity, @date, @period, @year, @hours, @description, @timesheetCode, @taskType, @submittedStatus, @approvalStatus, @dateCreated, @dateModified)" };
			this.qString = string.Concat(strArrays);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@userId", entry.user_id);
			mySqlCommand.Parameters.AddWithValue("@userName", entry.user_name);
			mySqlCommand.Parameters.AddWithValue("@sectionId", entry.section_id);
			mySqlCommand.Parameters.AddWithValue("@projectSerial", entry.project_serial);
			mySqlCommand.Parameters.AddWithValue("@projectSAP", entry.project_sap);
			mySqlCommand.Parameters.AddWithValue("@numberSection", entry.number_section);
			mySqlCommand.Parameters.AddWithValue("@network", entry.number_network);
			mySqlCommand.Parameters.AddWithValue("@activity", entry.number_activity);
			MySqlParameterCollection parameters = mySqlCommand.Parameters;
			DateTime dateCreated = entry.date;
			parameters.AddWithValue("@date", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
			mySqlCommand.Parameters.AddWithValue("@period", entry.period);
			mySqlCommand.Parameters.AddWithValue("@year", entry.year);
			mySqlCommand.Parameters.AddWithValue("@hours", entry.hours);
			mySqlCommand.Parameters.AddWithValue("@description", entry.description);
			mySqlCommand.Parameters.AddWithValue("@timesheetCode", entry.timesheet_code);
			mySqlCommand.Parameters.AddWithValue("@taskType", entry.task_type);
			mySqlCommand.Parameters.AddWithValue("@submittedStatus", this.functions.approvalStatus(submittedStatus));
			mySqlCommand.Parameters.AddWithValue("@approvalStatus", this.functions.approvalStatus(approvalStatus));
			MySqlParameterCollection mySqlParameterCollection = mySqlCommand.Parameters;
			dateCreated = entry.date_created;
			mySqlParameterCollection.AddWithValue("@dateCreated", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
			MySqlParameterCollection parameters1 = mySqlCommand.Parameters;
			dateCreated = entry.date_modified;
			parameters1.AddWithValue("@dateModified", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
			this.Insert(mySqlCommand);
		}

		public void SaveTimeEntry(string tableName, List<Entry> entries, ApprovalStatus approvalStatus, ApprovalStatus submittedStatus)
		{
			string[] strArrays = new string[] { "INSERT INTO ", tableName, " (", this.t_Timesheet_c_User_Id, ", ", this.t_Timesheet_c_User_Name, ", ", this.t_Timesheet_c_Section_Id, ", ", this.t_Timesheet_c_Project_Serial, ", ", this.t_Timesheet_c_Project_Sap, ", ", this.t_Timesheet_c_Number_Section, ", ", this.t_Timesheet_c_Number_Network, ", ", this.t_Timesheet_c_Number_Activity, ", ", this.t_Timesheet_c_Date, ", ", this.t_Timesheet_c_Period, ", ", this.t_Timesheet_c_Year, ", ", this.t_Timesheet_c_Hours, ", ", this.t_Timesheet_c_Description, ", ", this.t_Timesheet_c_Timesheet_Code, ", ", this.t_Timesheet_c_Task_Type, ", ", this.t_Timesheet_c_Submitted_Status, ", ", this.t_Timesheet_c_Approval_Status, ", ", this.t_Timesheet_c_Date_Created, ", ", this.t_Timesheet_c_Date_Modified, ") VALUES(@userId, @userName, @sectionId, @projectSerial, @projectSAP, @numberSection, @network, @activity, @date, @period, @year, @hours, @description, @timesheetCode, @taskType, @submittedStatus, @approvalStatus, @dateCreated, @dateModified)" };
			this.qString = string.Concat(strArrays);
			List<MySqlCommand> mySqlCommands = new List<MySqlCommand>();
			foreach (Entry entry in entries)
			{
				MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
				if (entry.date_created == DateTime.MinValue)
				{
					entry.date_created = DateTime.Now;
				}
				if (entry.date_modified == DateTime.MinValue)
				{
					entry.date_modified = DateTime.Now;
				}
				mySqlCommand.Parameters.AddWithValue("@userId", entry.user_id);
				mySqlCommand.Parameters.AddWithValue("@userName", entry.user_name);
				mySqlCommand.Parameters.AddWithValue("@sectionId", entry.section_id);
				mySqlCommand.Parameters.AddWithValue("@projectSerial", entry.project_serial);
				mySqlCommand.Parameters.AddWithValue("@projectSAP", entry.project_sap);
				mySqlCommand.Parameters.AddWithValue("@numberSection", entry.number_section);
				mySqlCommand.Parameters.AddWithValue("@network", entry.number_network);
				mySqlCommand.Parameters.AddWithValue("@activity", entry.number_activity);
				MySqlParameterCollection parameters = mySqlCommand.Parameters;
				DateTime dateCreated = entry.date;
				parameters.AddWithValue("@date", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
				mySqlCommand.Parameters.AddWithValue("@period", entry.period);
				mySqlCommand.Parameters.AddWithValue("@year", entry.year);
				mySqlCommand.Parameters.AddWithValue("@hours", entry.hours);
				mySqlCommand.Parameters.AddWithValue("@description", entry.description);
				mySqlCommand.Parameters.AddWithValue("@timesheetCode", entry.timesheet_code);
				mySqlCommand.Parameters.AddWithValue("@taskType", entry.task_type);
				mySqlCommand.Parameters.AddWithValue("@submittedStatus", this.functions.approvalStatus(submittedStatus));
				mySqlCommand.Parameters.AddWithValue("@approvalStatus", this.functions.approvalStatus(approvalStatus));
				MySqlParameterCollection mySqlParameterCollection = mySqlCommand.Parameters;
				dateCreated = entry.date_created;
				mySqlParameterCollection.AddWithValue("@dateCreated", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
				MySqlParameterCollection parameters1 = mySqlCommand.Parameters;
				dateCreated = entry.date_modified;
				parameters1.AddWithValue("@dateModified", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
				mySqlCommands.Add(mySqlCommand);
			}
			this.Insert(mySqlCommands);
		}

		public void SaveTimeEntry(string tableName, List<Entry> entries, ApprovalStatus approvalStatus, ApprovalStatus submittedStatus, User Approver)
		{
			string[] strArrays = new string[] { "INSERT INTO ", tableName, " (", this.t_Timesheet_c_User_Id, ", ", this.t_Timesheet_c_User_Name, ", ", this.t_Timesheet_c_Section_Id, ", ", this.t_Timesheet_c_Project_Serial, ", ", this.t_Timesheet_c_Project_Sap, ", ", this.t_Timesheet_c_Number_Section, ", ", this.t_Timesheet_c_Number_Network, ", ", this.t_Timesheet_c_Number_Activity, ", ", this.t_Timesheet_c_Date, ", ", this.t_Timesheet_c_Period, ", ", this.t_Timesheet_c_Year, ", ", this.t_Timesheet_c_Hours, ", ", this.t_Timesheet_c_Description, ", ", this.t_Timesheet_c_Timesheet_Code, ", ", this.t_Timesheet_c_Task_Type, ", ", this.t_Timesheet_c_Submitted_Status, ", ", this.t_Timesheet_c_Approval_Status, ", ", this.t_Timesheet_c_Date_Created, ", ", this.t_Timesheet_c_Date_Modified, ", ", this.t_Timesheet_c_Approved_By_User_Id, ", ", this.t_Timesheet_c_Approved_By_User_Name, ", ", this.t_Timesheet_c_Date_Approved, ") VALUES(@userId, @userName, @sectionId, @projectSerial, @projectSAP, @numberSection, @network, @activity, @date, @period, @year, @hours, @description, @timesheetCode, @taskType, @submittedStatus, @approvalStatus, @dateCreated, @dateModified, @approvedByUserId, @approvedByUserName, @dateApproved)" };
			this.qString = string.Concat(strArrays);
			List<MySqlCommand> mySqlCommands = new List<MySqlCommand>();
			foreach (Entry entry in entries)
			{
				MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
				mySqlCommand.Parameters.AddWithValue("@userId", entry.user_id);
				mySqlCommand.Parameters.AddWithValue("@userName", entry.user_name);
				mySqlCommand.Parameters.AddWithValue("@sectionId", entry.section_id);
				mySqlCommand.Parameters.AddWithValue("@projectSerial", entry.project_serial);
				mySqlCommand.Parameters.AddWithValue("@projectSAP", entry.project_sap);
				mySqlCommand.Parameters.AddWithValue("@numberSection", entry.number_section);
				mySqlCommand.Parameters.AddWithValue("@network", entry.number_network);
				mySqlCommand.Parameters.AddWithValue("@activity", entry.number_activity);
				MySqlParameterCollection parameters = mySqlCommand.Parameters;
				DateTime dateCreated = entry.date;
				parameters.AddWithValue("@date", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
				mySqlCommand.Parameters.AddWithValue("@period", entry.period);
				mySqlCommand.Parameters.AddWithValue("@year", entry.year);
				mySqlCommand.Parameters.AddWithValue("@hours", entry.hours);
				mySqlCommand.Parameters.AddWithValue("@description", entry.description);
				mySqlCommand.Parameters.AddWithValue("@timesheetCode", entry.timesheet_code);
				mySqlCommand.Parameters.AddWithValue("@taskType", entry.task_type);
				mySqlCommand.Parameters.AddWithValue("@submittedStatus", this.functions.approvalStatus(submittedStatus));
				mySqlCommand.Parameters.AddWithValue("@approvalStatus", this.functions.approvalStatus(approvalStatus));
				MySqlParameterCollection mySqlParameterCollection = mySqlCommand.Parameters;
				dateCreated = entry.date_created;
				mySqlParameterCollection.AddWithValue("@dateCreated", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
				MySqlParameterCollection parameters1 = mySqlCommand.Parameters;
				dateCreated = entry.date_modified;
				parameters1.AddWithValue("@dateModified", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
				mySqlCommand.Parameters.AddWithValue("@approvedByUserId", Approver.UserID);
				mySqlCommand.Parameters.AddWithValue("@approvedByUserName", Approver.UserName);
				MySqlParameterCollection mySqlParameterCollection1 = mySqlCommand.Parameters;
				dateCreated = DateTime.Now;
				mySqlParameterCollection1.AddWithValue("@dateApproved", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
				mySqlCommands.Add(mySqlCommand);
			}
			this.Insert(mySqlCommands);
		}

		public void SaveTimeEntry(string tableName, List<Entry> entries, ApprovalStatus approvalStatus, ApprovalStatus submittedStatus, string rejectionReason)
		{
			string[] strArrays = new string[] { "INSERT INTO ", tableName, " (", this.t_Timesheet_c_User_Id, ", ", this.t_Timesheet_c_User_Name, ", ", this.t_Timesheet_c_Section_Id, ", ", this.t_Timesheet_c_Project_Serial, ", ", this.t_Timesheet_c_Project_Sap, ", ", this.t_Timesheet_c_Number_Section, ", ", this.t_Timesheet_c_Number_Network, ", ", this.t_Timesheet_c_Number_Activity, ", ", this.t_Timesheet_c_Date, ", ", this.t_Timesheet_c_Period, ", ", this.t_Timesheet_c_Year, ", ", this.t_Timesheet_c_Hours, ", ", this.t_Timesheet_c_Description, ", ", this.t_Timesheet_c_Timesheet_Code, ", ", this.t_Timesheet_c_Task_Type, ", ", this.t_Timesheet_c_Submitted_Status, ", ", this.t_Timesheet_c_Approval_Status, ", ", this.t_Timesheet_c_Rejection_Reason, ", ", this.t_Timesheet_c_Date_Created, ",", this.t_Timesheet_c_Date_Modified, ") VALUES(@userId, @userName, @sectionId, @projectSerial, @projectSAP, @numberSection, @network, @activity, @date, @period, @year, @hours, @description, @timesheetCode, @taskType, @submittedStatus, @approvalStatus, @rejectionReason, @dateCreated, @dateModified)" };
			this.qString = string.Concat(strArrays);
			List<MySqlCommand> mySqlCommands = new List<MySqlCommand>();
			foreach (Entry entry in entries)
			{
				MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
				mySqlCommand.Parameters.AddWithValue("@userId", entry.user_id);
				mySqlCommand.Parameters.AddWithValue("@userName", entry.user_name);
				mySqlCommand.Parameters.AddWithValue("@sectionId", entry.section_id);
				mySqlCommand.Parameters.AddWithValue("@projectSerial", entry.project_serial);
				mySqlCommand.Parameters.AddWithValue("@projectSAP", entry.project_sap);
				mySqlCommand.Parameters.AddWithValue("@numberSection", entry.number_section);
				mySqlCommand.Parameters.AddWithValue("@network", entry.number_network);
				mySqlCommand.Parameters.AddWithValue("@activity", entry.number_activity);
				MySqlParameterCollection parameters = mySqlCommand.Parameters;
				DateTime dateCreated = entry.date;
				parameters.AddWithValue("@date", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
				mySqlCommand.Parameters.AddWithValue("@period", entry.period);
				mySqlCommand.Parameters.AddWithValue("@year", entry.year);
				mySqlCommand.Parameters.AddWithValue("@hours", entry.hours);
				mySqlCommand.Parameters.AddWithValue("@description", entry.description);
				mySqlCommand.Parameters.AddWithValue("@timesheetCode", entry.timesheet_code);
				mySqlCommand.Parameters.AddWithValue("@taskType", entry.task_type);
				mySqlCommand.Parameters.AddWithValue("@submittedStatus", this.functions.approvalStatus(submittedStatus));
				mySqlCommand.Parameters.AddWithValue("@approvalStatus", this.functions.approvalStatus(approvalStatus));
				mySqlCommand.Parameters.AddWithValue("@rejectionReason", rejectionReason);
				MySqlParameterCollection mySqlParameterCollection = mySqlCommand.Parameters;
				dateCreated = entry.date_created;
				mySqlParameterCollection.AddWithValue("@dateCreated", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
				mySqlCommand.Parameters.AddWithValue("@dateModified", entry.date_modified);
				mySqlCommands.Add(mySqlCommand);
			}
			this.Insert(mySqlCommands);
		}

		public Section Section(int section_id)
		{
			object[] tSections = new object[] { " SELECT *  FROM ", this.t_Sections, " WHERE ", this.t_Sections_c_Entry_Id, "='", section_id, "'" };
			this.qString = string.Concat(tSections);
			return this.ReturnSection(this.qString);
		}

		public string SectionActivity(int sectionId)
		{
			object[] tSections = new object[] { " SELECT *  FROM ", this.t_Sections, " WHERE ", this.t_Sections_c_Entry_Id, "='", sectionId, "'" };
			this.qString = string.Concat(tSections);
			return this.ReturnString(this.qString, this.t_Sections_c_Number_Activity);
		}

		public string SectionDescription(string project_number_network, string section_number)
		{
			string[] tSections = new string[] { " SELECT *  FROM ", this.t_Sections, " WHERE ", this.t_Sections_c_Number_Project_Network, " ='", project_number_network, "' AND ", this.t_Sections_c_Number_Section, " ='", section_number, "'" };
			this.qString = string.Concat(tSections);
			this.myCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			return this.ReturnString(this.qString, this.t_Sections_c_Description_Section);
		}

		public int SectionId(string section_number, string task_type)
		{
			string[] tSections = new string[] { " SELECT *  FROM ", this.t_Sections, " WHERE ", this.t_Sections_c_Number_Section, "='", section_number, "' AND ", this.t_Sections_c_Task_Type, "='", task_type, "'" };
			this.qString = string.Concat(tSections);
			return this.ReturnInt(this.qString, this.t_Sections_c_Entry_Id);
		}

		public int SectionNetwork(int sectionId)
		{
			object[] tSections = new object[] { " SELECT *  FROM ", this.t_Sections, " WHERE ", this.t_Sections_c_Entry_Id, "='", sectionId, "'" };
			this.qString = string.Concat(tSections);
			return this.ReturnInt(this.qString, this.t_Sections_c_Number_Project_Network);
		}

		public List<string> SectionNumbers(string project_number_network)
		{
			string[] tSections = new string[] { " SELECT *  FROM ", this.t_Sections, " WHERE ", this.t_Sections_c_Number_Project_Network, "='", project_number_network, "'" };
			this.qString = string.Concat(tSections);
			return this.ReturnStringList(this.qString, this.t_Sections_c_Number_Section);
		}

		public List<string> SectionNumbers(string project_number_network, string task_type)
		{
			string[] tSections = new string[] { " SELECT *  FROM ", this.t_Sections, " WHERE ", this.t_Sections_c_Number_Project_Network, "='", project_number_network, "' AND ", this.t_Sections_c_Task_Type, "='", task_type, "'" };
			this.qString = string.Concat(tSections);
			return this.ReturnStringList(this.qString, this.t_Sections_c_Number_Section);
		}

		public List<Section> Sections(int project_number_network)
		{
			object[] tSections = new object[] { " SELECT *  FROM ", this.t_Sections, " WHERE ", this.t_Sections_c_Number_Project_Network, "='", project_number_network, "'" };
			this.qString = string.Concat(tSections);
			return this.ReturnSectionList(this.qString);
		}

		public List<Section> Sections(int project_number_network, string task_type)
		{
			object[] tSections = new object[] { " SELECT *  FROM ", this.t_Sections, " WHERE ", this.t_Sections_c_Number_Project_Network, "='", project_number_network, "' AND ", this.t_Sections_c_Task_Type, "='", task_type, "'" };
			this.qString = string.Concat(tSections);
			return this.ReturnSectionList(this.qString);
		}

		public List<Section> Sections()
		{
			this.qString = string.Concat(" SELECT *  FROM ", this.t_Sections);
			return this.ReturnSectionList(this.qString);
		}

		public string TaskTypeDescription(string taskType_Id)
		{
			string[] tTaskType = new string[] { "SELECT * FROM ", this.t_Task_type, " WHERE ", this.t_Task_Type_c_Task_Type, "='", taskType_Id, "'" };
			this.qString = string.Concat(tTaskType);
			return this.ReturnString(this.qString, this.t_Task_Type_c_Task_Type_description);
		}

		public List<string> TaskTypes()
		{
			this.qString = string.Concat("SELECT * FROM ", this.t_Task_type);
			return this.ReturnStringList(this.qString, this.t_Task_Type_c_Task_Type);
		}

		public List<TaskType> TaskTypes(Section section)
		{
			string[] tSections = new string[] { "SELECT * FROM ", this.t_Sections, " WHERE ", this.t_Sections_c_Number_Section, "='", section.Number_Section, "' AND ", this.t_Sections_c_Number_Project_Network, "='", section.Number_ProjectNetwork, "'" };
			this.qString = string.Concat(tSections);
			return this.ReturnTaskTypeUsedList(this.qString);
		}

		public List<TaskType> TaskTypesAll()
		{
			this.qString = string.Concat("SELECT * FROM ", this.t_Task_type);
			return this.ReturnTaskTypeList(this.qString);
		}

		public List<string> TimeCodes()
		{
			this.qString = string.Concat("SELECT * FROM ", this.t_Timesheet_codes);
			return this.ReturnStringList(this.qString, this.t_Timesheet_Codes_c_Timesheet_Code);
		}

		public string TimeCodes_Description(string time_code)
		{
			string[] tTimesheetCodes = new string[] { "SELECT * FROM ", this.t_Timesheet_codes, " WHERE ", this.t_Timesheet_Codes_c_Timesheet_Code, " ='", time_code, "'" };
			this.qString = string.Concat(tTimesheetCodes);
			return this.ReturnString(this.qString, this.t_Timesheet_Codes_c_Timesheet_Description);
		}

		public TimesheetCode TimesheetCode(string time_code)
		{
			string[] tTimesheetCodes = new string[] { "SELECT * FROM ", this.t_Timesheet_codes, " WHERE ", this.t_Timesheet_Codes_c_Timesheet_Code, " ='", time_code, "'" };
			this.qString = string.Concat(tTimesheetCodes);
			return this.ReturnTimesheetCode(this.qString);
		}

		public List<TimesheetCode> TimesheetCodeAll()
		{
			this.qString = string.Concat("SELECT * FROM ", this.t_Timesheet_codes);
			return this.ReturnTimesheetCodeList(this.qString);
		}

		private void Update(MySqlCommand cmd)
		{
			try
			{
				this.myConnection.Open();
				cmd.ExecuteNonQuery();
				MessageBox.Show("Update made");
				this.myConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				try
				{
					this.myConnection.Close();
					MessageBox.Show(exception.Message);
				}
				catch
				{
					MessageBox.Show(exception.Message);
				}
			}
		}

		public void UpdateProject(Project project)
		{
			string[] tProjects = new string[] { "Update ", this.t_Projects, " SET ", this.t_Projects_c_Country, "=@country, ", this.t_Projects_c_Customer, "=@customer, ", this.t_Projects_c_IsOpen, "=@isOpen, ", this.t_Projects_c_IsWarrantyOpen, "=@isWarrantyOpen, ", this.t_Projects_c_Machine, "=@machine, ", this.t_Projects_c_Number_BFC, "=@numberBFC, ", this.t_Projects_c_Number_MAS90, "=@numberMAS90, ", this.t_Projects_c_Number_Network, "=@numberNetwork, ", this.t_Projects_c_Number_SAP, "=@numberSAP, ", this.t_Projects_c_Number_WarrantyNetwork, "=@numberWarrantyNetwork WHERE ", this.t_Projects_c_Number_Serial, "=@numberSerial" };
			this.qString = string.Concat(tProjects);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@country", project.Country);
			mySqlCommand.Parameters.AddWithValue("@customer", project.Customer);
			mySqlCommand.Parameters.AddWithValue("@isOpen", project.IsOpen);
			mySqlCommand.Parameters.AddWithValue("@isWarrantyOpen", project.IsWarrantyOpen);
			mySqlCommand.Parameters.AddWithValue("@machine", project.Machine);
			mySqlCommand.Parameters.AddWithValue("@numberBFC", project.Number_BFC);
			mySqlCommand.Parameters.AddWithValue("@numberMAS90", project.Number_MAS90);
			mySqlCommand.Parameters.AddWithValue("@numberNetwork", project.Number_Network);
			mySqlCommand.Parameters.AddWithValue("@numberSAP", project.Number_SAP);
			mySqlCommand.Parameters.AddWithValue("@numberWarrantyNetwork", project.Number_WarrantyNetwork);
			mySqlCommand.Parameters.AddWithValue("@numberSerial", project.Number_Serial);
			this.Update(mySqlCommand);
		}

		public void UpdateTimeEntry(int entryId, int? sectionId, string projectSerial, string projectSAP, string numberSection, int? network, string activity, DateTime date, int period, int year, double hours, string description, string timesheetCode, string taskType)
		{
			string[] tTimesheetPrelim = new string[] { "Update ", this.t_Timesheet_Prelim, " SET ", this.t_Timesheet_c_Section_Id, "=@sectionId, ", this.t_Timesheet_c_Project_Serial, "=@projectSerial, ", this.t_Timesheet_c_Project_Sap, "=@projectSAP, ", this.t_Timesheet_c_Number_Section, "=@numberSection, ", this.t_Timesheet_c_Number_Network, "=@network, ", this.t_Timesheet_c_Number_Activity, "=@activity, ", this.t_Timesheet_c_Date, "=@date, ", this.t_Timesheet_c_Period, "=@period, ", this.t_Timesheet_c_Year, "=@year, ", this.t_Timesheet_c_Hours, "=@hours, ", this.t_Timesheet_c_Description, "=@description, ", this.t_Timesheet_c_Timesheet_Code, "=@timesheetCode, ", this.t_Timesheet_c_Task_Type, "=@taskType, ", this.t_Timesheet_c_Date_Modified, "=@dateModified WHERE ", this.t_Timesheet_c_Entry_Id, "=@entryId" };
			this.qString = string.Concat(tTimesheetPrelim);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@sectionId", sectionId);
			mySqlCommand.Parameters.AddWithValue("@projectSerial", projectSerial);
			mySqlCommand.Parameters.AddWithValue("@projectSAP", projectSAP);
			mySqlCommand.Parameters.AddWithValue("@numberSection", numberSection);
			mySqlCommand.Parameters.AddWithValue("@network", network);
			mySqlCommand.Parameters.AddWithValue("@activity", activity);
			mySqlCommand.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
			mySqlCommand.Parameters.AddWithValue("@period", period);
			mySqlCommand.Parameters.AddWithValue("@year", year);
			mySqlCommand.Parameters.AddWithValue("@hours", hours);
			mySqlCommand.Parameters.AddWithValue("@description", description);
			mySqlCommand.Parameters.AddWithValue("@timesheetCode", timesheetCode);
			mySqlCommand.Parameters.AddWithValue("@taskType", taskType);
			MySqlParameterCollection parameters = mySqlCommand.Parameters;
			DateTime now = DateTime.Now;
			parameters.AddWithValue("@dateModified", now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
			mySqlCommand.Parameters.AddWithValue("@entryId", entryId);
			this.Update(mySqlCommand);
		}

		public void UpdateTimeEntry(Entry entry)
		{
			string[] tTimesheetPrelim = new string[] { "Update ", this.t_Timesheet_Prelim, " SET ", this.t_Timesheet_c_Section_Id, "=@sectionId, ", this.t_Timesheet_c_Project_Serial, "=@projectSerial, ", this.t_Timesheet_c_Project_Sap, "=@projectSAP, ", this.t_Timesheet_c_Number_Section, "=@numberSection, ", this.t_Timesheet_c_Number_Network, "=@network, ", this.t_Timesheet_c_Number_Activity, "=@activity, ", this.t_Timesheet_c_Date, "=@date, ", this.t_Timesheet_c_Period, "=@period, ", this.t_Timesheet_c_Year, "=@year, ", this.t_Timesheet_c_Hours, "=@hours, ", this.t_Timesheet_c_Description, "=@description, ", this.t_Timesheet_c_Timesheet_Code, "=@timesheetCode, ", this.t_Timesheet_c_Task_Type, "=@taskType, ", this.t_Timesheet_c_Date_Modified, "=@dateModified WHERE ", this.t_Timesheet_c_Entry_Id, "=@entryId" };
			this.qString = string.Concat(tTimesheetPrelim);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@sectionId", entry.section_id);
			mySqlCommand.Parameters.AddWithValue("@projectSerial", entry.project_serial);
			mySqlCommand.Parameters.AddWithValue("@projectSAP", entry.project_sap);
			mySqlCommand.Parameters.AddWithValue("@numberSection", entry.number_section);
			mySqlCommand.Parameters.AddWithValue("@network", entry.number_network);
			mySqlCommand.Parameters.AddWithValue("@activity", entry.number_activity);
			MySqlParameterCollection parameters = mySqlCommand.Parameters;
			DateTime now = entry.date;
			parameters.AddWithValue("@date", now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
			mySqlCommand.Parameters.AddWithValue("@period", entry.period);
			mySqlCommand.Parameters.AddWithValue("@year", entry.year);
			mySqlCommand.Parameters.AddWithValue("@hours", entry.hours);
			mySqlCommand.Parameters.AddWithValue("@description", entry.description);
			mySqlCommand.Parameters.AddWithValue("@timesheetCode", entry.timesheet_code);
			mySqlCommand.Parameters.AddWithValue("@taskType", entry.task_type);
			MySqlParameterCollection mySqlParameterCollection = mySqlCommand.Parameters;
			now = DateTime.Now;
			mySqlParameterCollection.AddWithValue("@dateModified", now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
			mySqlCommand.Parameters.AddWithValue("@entryId", entry.entry_id);
			this.Update(mySqlCommand);
		}

		public void UpdateUserDefaults(User_Defaults UserDefault)
		{
			string[] tUsersDefaults = new string[] { "Update ", this.t_UsersDefaults, " SET ", this.t_UsersDefaults_c_TimesheetCode, "=@timesheetCode, ", this.t_UsersDefaults_c_TaskType, "=@taskType, ", this.t_UsersDefaults_c_Project, "=@project, ", this.t_UsersDefaults_c_Default4, "=@default4, ", this.t_UsersDefaults_c_Default5, "=@default5, ", this.t_UsersDefaults_c_Default6, "=@default6, ", this.t_UsersDefaults_c_Default7, "=@default7, ", this.t_UsersDefaults_c_Default8, "=@default8, ", this.t_UsersDefaults_c_Default9, "=@default9, ", this.t_UsersDefaults_c_Default10, "=@default10, ", this.t_UsersDefaults_c_Default11, "=@default11, ", this.t_UsersDefaults_c_Default12, "=@default12, ", this.t_UsersDefaults_c_Default13, "=@default13, ", this.t_UsersDefaults_c_Default14, "=@default14, ", this.t_UsersDefaults_c_Default15, "=@default15, ", this.t_UsersDefaults_c_Default16, "=@default16, ", this.t_UsersDefaults_c_Default17, "=@default17, ", this.t_UsersDefaults_c_Default18, "=@default18, ", this.t_UsersDefaults_c_Default19, "=@default19, ", this.t_UsersDefaults_c_Default20, "=@default20  WHERE ", this.t_UsersDefaults_c_User_Id, "=@userId" };
			this.qString = string.Concat(tUsersDefaults);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@timesheetCode", (UserDefault.TimesheetCode != null ? UserDefault.TimesheetCode.Code : ""));
			mySqlCommand.Parameters.AddWithValue("@taskType", UserDefault.TaskType);
			mySqlCommand.Parameters.AddWithValue("@project", (UserDefault.Project != null ? UserDefault.Project.Number_Serial : ""));
			mySqlCommand.Parameters.AddWithValue("@default4", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@default5", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@default6", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@default7", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@default8", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@default9", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@default10", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@default11", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@default12", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@default13", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@default14", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@default15", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@default16", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@default17", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@default18", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@default19", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@default20", UserDefault.userDefault4);
			mySqlCommand.Parameters.AddWithValue("@userId", UserDefault.UserId);
			this.Update(mySqlCommand);
		}

		public void UpdateUserPassword(User user, string password)
		{
			string[] tLogin = new string[] { "Update ", this.t_Login, " SET ", this.t_Login_c_password, "=@password  WHERE ", this.t_Login_c_User_Id, "=@userId" };
			this.qString = string.Concat(tLogin);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@password", password);
			mySqlCommand.Parameters.AddWithValue("@userId", user.UserID);
			this.Update(mySqlCommand);
		}

		public void User_AddApprovee(User approver, User approvee)
		{
			string[] tApprovalHierarchy = new string[] { "INSERT INTO ", this.t_ApprovalHierarchy, " (", this.t_ApprovalHierarchy_c_Approvee_Id, ", ", this.t_ApprovalHierarchy_c_Approvee_Name, ", ", this.t_ApprovalHierarchy_c_Approver_Id, ", ", this.t_ApprovalHierarchy_c_Approver_Name, ") VALUES(@approveeId, @approveeName, @approverId, @approverName)" };
			this.qString = string.Concat(tApprovalHierarchy);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@approveeId", approvee.UserID);
			mySqlCommand.Parameters.AddWithValue("@approveeName", approvee.UserName);
			mySqlCommand.Parameters.AddWithValue("@approverId", approver.UserID);
			mySqlCommand.Parameters.AddWithValue("@approverName", approver.UserName);
			this.Insert(mySqlCommand);
		}

		public List<int> User_AllEntries(int user_id, string table)
		{
			List<int> nums = new List<int>();
			object[] objArray = new object[] { "SELECT * FROM ", table, " WHERE ", this.t_Timesheet_c_User_Id, "= '", user_id, "'" };
			string str = string.Concat(objArray);
			return this.ReturnIntList(str, this.t_Timesheet_c_Entry_Id);
		}

		public List<string> User_Defaults(int user_id)
		{
			List<string> strs = new List<string>();
			object[] tUsersDefaults = new object[] { "SELECT * FROM ", this.t_UsersDefaults, " WHERE ", this.t_UsersDefaults_c_User_Id, "= '", user_id, "'" };
			string str = string.Concat(tUsersDefaults);
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_TimesheetCode));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_TaskType));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Project));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default4));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default5));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default6));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default7));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default8));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default9));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default10));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default11));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default12));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default13));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default14));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default15));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default16));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default17));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default18));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default19));
			strs.Add(this.ReturnString(str, this.t_UsersDefaults_c_Default20));
			return strs;
		}

		public string User_EmployeeName(int user_id)
		{
			object[] tUsers = new object[] { "SELECT * FROM ", this.t_Users, " WHERE ", this.t_Users_c_User_Id, "='", user_id, "'" };
			this.qString = string.Concat(tUsers);
			return this.ReturnString(this.qString, this.t_Users_c_User_Name);
		}

		public List<FivesBronxTimesheetManagement.Classes.User> User_GetApprovees(FivesBronxTimesheetManagement.Classes.User User)
		{
			List<FivesBronxTimesheetManagement.Classes.User> users = new List<FivesBronxTimesheetManagement.Classes.User>();
			object[] tApprovalHierarchy = new object[] { "SELECT * FROM ", this.t_ApprovalHierarchy, " WHERE ", this.t_ApprovalHierarchy_c_Approver_Id, "= '", User.UserID, "'" };
			this.qString = string.Concat(tApprovalHierarchy);
			foreach (int num in this.ReturnIntList(this.qString, this.t_ApprovalHierarchy_c_Approvee_Id))
			{
				users.Add(this.GetUser(num));
			}
			return users;
		}

		public List<FivesBronxTimesheetManagement.Classes.User> User_GetApprovers(FivesBronxTimesheetManagement.Classes.User User)
		{
			List<FivesBronxTimesheetManagement.Classes.User> users = new List<FivesBronxTimesheetManagement.Classes.User>();
			object[] tApprovalHierarchy = new object[] { "SELECT * FROM ", this.t_ApprovalHierarchy, " WHERE ", this.t_ApprovalHierarchy_c_Approvee_Id, "= '", User.UserID, "'" };
			this.qString = string.Concat(tApprovalHierarchy);
			foreach (int num in this.ReturnIntList(this.qString, this.t_ApprovalHierarchy_c_Approver_Id))
			{
				users.Add(this.GetUser(num));
			}
			return users;
		}

		public bool User_IsActive(int user_id)
		{
			object[] tUsers = new object[] { "SELECT * FROM ", this.t_Users, " WHERE ", this.t_Users_c_User_Id, "='", user_id, "'" };
			this.qString = string.Concat(tUsers);
			return this.ReturnBool(this.qString, this.t_Users_c_IsActive);
		}

		public bool User_IsAdmin(int user_id)
		{
			object[] tUsers = new object[] { "SELECT * FROM ", this.t_Users, " WHERE ", this.t_Users_c_User_Id, "='", user_id, "'" };
			this.qString = string.Concat(tUsers);
			return this.ReturnBool(this.qString, this.t_Users_c_Admin);
		}

		public bool User_IsHourly(int user_id)
		{
			object[] tUsers = new object[] { "SELECT * FROM ", this.t_Users, " WHERE ", this.t_Users_c_User_Id, "='", user_id, "'" };
			this.qString = string.Concat(tUsers);
			return this.ReturnBool(this.qString, this.t_Users_c_IsHourly);
		}

		public bool User_IsValidator(int user_id)
		{
			object[] tUsers = new object[] { "SELECT * FROM ", this.t_Users, " WHERE ", this.t_Users_c_User_Id, "='", user_id, "'" };
			this.qString = string.Concat(tUsers);
			return this.ReturnBool(this.qString, this.t_Users_c_Validator);
		}

		public void User_RemoveApprovee(User approver, User approvee)
		{
			object[] tApprovalHierarchy = new object[] { "DELETE FROM ", this.t_ApprovalHierarchy, " WHERE ", this.t_ApprovalHierarchy_c_Approver_Id, "='", approver.UserID, "'  AND ", this.t_ApprovalHierarchy_c_Approvee_Id, "='", approvee.UserID, "'" };
			this.qString = string.Concat(tApprovalHierarchy);
			MySqlCommand mySqlCommand = new MySqlCommand(this.qString, this.myConnection.MySqlConnection);
			try
			{
				this.myConnection.Open();
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				MessageBox.Show("Entry Deleted");
				while (mySqlDataReader.Read())
				{
				}
				mySqlDataReader.Close();
				this.myConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				try
				{
					this.myConnection.Close();
					MessageBox.Show(exception.Message);
				}
				catch
				{
					MessageBox.Show(exception.Message);
				}
			}
		}
	}
}