using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FivesBronxTimesheetManagement.Classes
{
    class Queries2
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

		public Queries2()
        {
			Connection connection = new Connection();
			t_Login = "login";
			t_Login_c_Login_Id = "login_id";
			t_Login_c_User_Id = "user_id";
			t_Login_c_password = "password";
			t_Users = "users";
			t_Users_c_User_Id = "user_id";
			t_Users_c_User_Name = "user_name";
			t_Users_c_Validator = "user_validator";
			t_Users_c_Admin = "user_admin";
			t_Users_c_IsActive = "user_isactive";
			t_Users_c_IsHourly = "user_ishourly";
			t_UsersDefaults = "users_defaults";
			t_UsersDefaults_c_User_Id = "user_id";
			t_UsersDefaults_c_TimesheetCode = "user_default1";
			t_UsersDefaults_c_TaskType = "user_default2";
			t_UsersDefaults_c_Project = "user_default3";
			t_UsersDefaults_c_Default4 = "user_default4";
			t_UsersDefaults_c_Default5 = "user_default5";
			t_UsersDefaults_c_Default6 = "user_default6";
			t_UsersDefaults_c_Default7 = "user_default7";
			t_UsersDefaults_c_Default8 = "user_default8";
			t_UsersDefaults_c_Default9 = "user_default9";
			t_UsersDefaults_c_Default10 = "user_default10";
			t_UsersDefaults_c_Default11 = "user_default11";
			t_UsersDefaults_c_Default12 = "user_default12";
			t_UsersDefaults_c_Default13 = "user_default13";
			t_UsersDefaults_c_Default14 = "user_default14";
			t_UsersDefaults_c_Default15 = "user_default15";
			t_UsersDefaults_c_Default16 = "user_default16";
			t_UsersDefaults_c_Default17 = "user_default17";
			t_UsersDefaults_c_Default18 = "user_default18";
			t_UsersDefaults_c_Default19 = "user_default19";
			t_UsersDefaults_c_Default20 = "user_default20";
			t_Timesheet_codes = "timesheet_codes";
			t_Timesheet_Codes_c_Timesheet_Code = "timesheet_code";
			t_Timesheet_Codes_c_Timesheet_Description = "timesheet_description";
			t_Task_type = "task_type";
			t_Task_Type_c_Task_Type = "task_type";
			t_Task_Type_c_Task_Type_description = "task_type_description";
			t_Projects = "projects";
			t_Projects_c_Number_Serial = "number_serial";
			t_Projects_c_Number_SAP = "number_sap";
			t_Projects_c_Number_MAS90 = "number_mas90";
			t_Projects_c_Number_BFC = "number_bfc";
			t_Projects_c_Number_Network = "number_network";
			t_Projects_c_Customer = "vendor";
			t_Projects_c_Machine = "machine";
			t_Projects_c_Country = "country";
			t_Projects_c_IsOpen = "isopen";
			t_Projects_c_IsWarrantyOpen = "iswarrantyopen";
			t_Projects_c_Number_WarrantyNetwork = "number_warrantynetwork";
			t_Sections = "sections";
			t_Sections_c_Entry_Id = "entry_id";
			t_Sections_c_Number_Project_Network = "number_project_network";
			t_Sections_c_Number_Section = "number_section";
			t_Sections_c_Description_Section = "description_section";
			t_Sections_c_Number_Activity = "number_activity";
			t_Sections_c_Task_Type = "task_type";
			t_Sections_c_Description_Activity = "description_activity";
			t_Timesheet_Prelim = "ts_prelim";
			t_Timesheet_Limbo = "ts_limbo";
			t_Timesheet_Final = "ts_final";
			t_Timesheet_Archive = "ts_archive";
			t_Timesheet_c_Entry_Id = "entry_id";
			t_Timesheet_c_User_Id = "user_id";
			t_Timesheet_c_User_Name = "user_name";
			t_Timesheet_c_Section_Id = "section_id";
			t_Timesheet_c_Project_Serial = "project_serial";
			t_Timesheet_c_Project_Sap = "project_sap";
			t_Timesheet_c_Number_Section = "number_section";
			t_Timesheet_c_Number_Network = "number_network";
			t_Timesheet_c_Number_Activity = "number_activity";
			t_Timesheet_c_Date = "date";
			t_Timesheet_c_Period = "period";
			t_Timesheet_c_Year = "year";
			t_Timesheet_c_Hours = "hours";
			t_Timesheet_c_Description = "description";
			t_Timesheet_c_Timesheet_Code = "timesheet_code";
			t_Timesheet_c_Task_Type = "task_type";
			t_Timesheet_c_Submitted_Status = "submitted_status";
			t_Timesheet_c_Approval_Status = "approval_status";
			t_Timesheet_c_Rejection_Reason = "rejection_reason";
			t_Timesheet_c_Approved_By_User_Id = "approved_by_user_id";
			t_Timesheet_c_Approved_By_User_Name = "approved_by_user_name";
			t_Timesheet_c_Date_Created = "date_created";
			t_Timesheet_c_Date_Modified = "date_modified";
			t_Timesheet_c_Date_Approved = "date_approved";
			t_Period = "period";
			t_Period_Id = "period_id";
			t_Period_Period = "period";
			t_Period_Year = "year";
			t_Period_Period_Open = "period_open";
			t_Period_Period_Current = "period_current";
			t_ApprovalHierarchy = "approval_hierarchy";
			t_ApprovalHierarchy_c_Hierarchy_Id = "hierarchy_id";
			t_ApprovalHierarchy_c_Approver_Id = "approver_id";
			t_ApprovalHierarchy_c_Approver_Name = "approver_name";
			t_ApprovalHierarchy_c_Approvee_Id = "approvee_Id";
			t_ApprovalHierarchy_c_Approvee_Name = "approvee_name";
		}

		public void Approval_SubmitFor(List<Entry> Entries)
		{
			try
			{
				DeleteTimeEntry(DeleteTimeEntryQStrings(t_Timesheet_Prelim, Entries));
				SaveTimeEntry(t_Timesheet_Limbo, Entries, ApprovalStatus.Submitted, ApprovalStatus.Submitted);
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

		public void Approval_Approve(List<Entry> Entries, FivesBronxTimesheetManagement.Classes.User User)
		{
			try
			{
				DeleteTimeEntry(DeleteTimeEntryQStrings(t_Timesheet_Limbo, Entries));
				SaveTimeEntry(t_Timesheet_Final, Entries, ApprovalStatus.Approved, ApprovalStatus.Submitted, User);
				MessageBox.Show("Successfully Approved");
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
			}
		}

		public void Approval_Reject(List<Entry> entries, string rejectionReason)
		{
			List<int> nums = new List<int>();
			try
			{
				DeleteTimeEntry(DeleteTimeEntryQStrings(t_Timesheet_Limbo, entries));
				SaveTimeEntry(t_Timesheet_Prelim, entries, ApprovalStatus.Rejected, ApprovalStatus.NotSubmitted, rejectionReason);
				MessageBox.Show("Successfully Rejected");
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
			}
		}

		public void CreateProject(Project project)
		{
			string[] tProjects = new string[] { "INSERT INTO ", t_Projects, " (", t_Projects_c_Country, ", ", t_Projects_c_IsOpen, ", ", t_Projects_c_IsWarrantyOpen, ", ", t_Projects_c_Machine, ", ", t_Projects_c_Number_BFC, ", ", t_Projects_c_Number_MAS90, ", ", t_Projects_c_Number_Network, ", ", t_Projects_c_Number_SAP, ", ", t_Projects_c_Number_Serial, ", ", t_Projects_c_Number_WarrantyNetwork, ", ", t_Projects_c_Customer, ") VALUES(@country, @isOpen, @isWarrantyOpen, @machine, @numberBFC, @numberMAS90, @numberNetwork, @numberSAP, @numberSerial, @numberWarrantyNetwork, @Customer)" };
			qString = string.Concat(tProjects);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
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
			Insert(mySqlCommand);
		}

		public void CreateSection(Section section)
		{
			string[] tSections = new string[] { "INSERT INTO ", t_Sections, " (", t_Sections_c_Description_Activity, ", ", t_Sections_c_Description_Section, ", ", t_Sections_c_Number_Activity, ", ", t_Sections_c_Number_Project_Network, ", ", t_Sections_c_Number_Section, ", ", t_Sections_c_Task_Type, ") VALUES(@descriptionActivity, @descriptionSection, @numberActivity, @numberProjectNetwork, @numberSection, @taskType)" };
			qString = string.Concat(tSections);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@descriptionActivity", section.Description_Activity);
			mySqlCommand.Parameters.AddWithValue("@descriptionSection", section.Description_Section);
			mySqlCommand.Parameters.AddWithValue("@numberActivity", section.Number_Activity);
			mySqlCommand.Parameters.AddWithValue("@numberProjectNetwork", section.Number_ProjectNetwork);
			mySqlCommand.Parameters.AddWithValue("@numberSection", section.Number_Section);
			mySqlCommand.Parameters.AddWithValue("@taskType", section.TaskType);
			Insert(mySqlCommand);
		}

		public void CreateUser(User user)
		{
			string[] tUsers = new string[] { "INSERT INTO ", t_Users, " (", t_Users_c_User_Id, ", ", t_Users_c_Admin, ", ", t_Users_c_IsActive, ", ", t_Users_c_User_Name, ", ", t_Users_c_Validator, ") VALUES(@userID, @admin, @isActive, @userName, @validator)" };
			qString = string.Concat(tUsers);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@userId", user.UserID);
			mySqlCommand.Parameters.AddWithValue("@admin", user.IsAdmin);
			mySqlCommand.Parameters.AddWithValue("@isActive", user.IsActive);
			mySqlCommand.Parameters.AddWithValue("@userName", user.UserName);
			mySqlCommand.Parameters.AddWithValue("@validator", user.IsValidator);
			Insert(mySqlCommand);
		}

		public void CreateUser_Defaults(User user)
		{
			string[] tUsersDefaults = new string[] { "INSERT INTO ", t_UsersDefaults, " (", t_UsersDefaults_c_User_Id, ") VALUES(@userID)" };
			qString = string.Concat(tUsersDefaults);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@userId", user.UserID);
			Insert(mySqlCommand);
		}

		public void CreateUserLogin(User user)
		{
			string[] tLogin = new string[] { "INSERT INTO ", t_Login, " (", t_Login_c_User_Id, ", ", t_Login_c_password, ") VALUES(@userID, @password)" };
			qString = string.Concat(tLogin);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@userId", user.UserID);
			mySqlCommand.Parameters.AddWithValue("@password", "letmein");
			Insert(mySqlCommand);
		}

		public void DeleteTimeEntry(int entryId)
		{
			object[] tTimesheetPrelim = new object[] { "DELETE FROM ", t_Timesheet_Prelim, " WHERE ", t_Timesheet_c_Entry_Id, "='", entryId, "'" };
			qString = string.Concat(tTimesheetPrelim);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			try
			{
				myConnection.Open();
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				MessageBox.Show("Entry Deleted");
				while (mySqlDataReader.Read())
				{
				}
				mySqlDataReader.Close();
				myConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				try
				{
					myConnection.Close();
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
			myConnection.Open();
			try
			{
				foreach (string qString in qStrings)
				{
					MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
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
			myConnection.Close();
		}

		public void DeleteTimeEntry(string tableName, int entryId)
		{
			object[] objArray = new object[] { "DELETE FROM ", tableName, " WHERE ", t_Timesheet_c_Entry_Id, "='", entryId, "'" };
			qString = string.Concat(objArray);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			try
			{
				myConnection.Open();
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				MessageBox.Show("Entry Deleted");
				while (mySqlDataReader.Read())
				{
				}
				mySqlDataReader.Close();
				myConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				try
				{
					myConnection.Close();
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
				object[] objArray = new object[] { "DELETE FROM ", tableName, " WHERE ", t_Timesheet_c_Entry_Id, "='", entryId, "'" };
				strs.Add(string.Concat(objArray));
			}
			return strs;
		}

		public List<string> DeleteTimeEntryQStrings(string tableName, List<Entry> entries)
		{
			List<string> strs = new List<string>();
			foreach (Entry entry in entries)
			{
				object[] value = new object[] { "DELETE FROM ", tableName, " WHERE ", t_Timesheet_c_Entry_Id, "='", null, null };
				value[5] = entry.entry_id.Value;
				value[6] = "'";
				strs.Add(string.Concat(value));
			}
			return strs;
		}

		/*public List<Entry> Entries(string table, List<int> entry_ids)
		{
			entry_ids.Sort();
			MessageBox.Show(entry_ids.Count.ToString());
			if(entry_ids.Count > 0)
			{
				string[] qString = new string[] { "Select * from ", table, " where ", t_Sections_c_Entry_Id, ">= ", entry_ids[0].ToString(), " and ", t_Sections_c_Entry_Id, " <= ", entry_ids[entry_ids.Count - 1].ToString() };
			}
			string[] qString = new string[] { "Select * from ", table, " where ", t_Sections_c_Entry_Id, ">= ", entry_ids[0].ToString(), " and ", t_Sections_c_Entry_Id, " <= ", entry_ids[entry_ids.Count - 1].ToString() };
			List<Entry> entries = new List<Entry>();
			myCommand = new MySqlCommand(string.Concat(qString), myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			while(reader.Read())
			{
				entries.Add(new Entry(
					int.Parse(reader.GetString(0)), // entry_id
					int.Parse(reader.GetString(1)), // user_id
					reader.GetString(2), // user_name
					reader.IsDBNull(reader.GetOrdinal("section_id")) ? null : new int?(int.Parse(reader.GetString(3))), // section_id
					reader.IsDBNull(reader.GetOrdinal("project_serial")) ? "" : reader.GetString(4), // project_serial
					reader.IsDBNull(reader.GetOrdinal("project_sap")) ? "" : reader.GetString(5), // project_sap
					reader.IsDBNull(reader.GetOrdinal("number_section")) ? "" : reader.GetString(6), // number_section
					reader.IsDBNull(reader.GetOrdinal("number_network")) ? null : new int?(int.Parse(reader.GetString(7))), // number_network
					reader.IsDBNull(reader.GetOrdinal("number_activity")) ? "" : reader.GetString(8), // number_activity
					DateTime.Parse(reader.GetString(9)), // date
					int.Parse(reader.GetString(10)), // period
					int.Parse(reader.GetString(11)), // year
					double.Parse(reader.GetString(12)), // hours
					reader.IsDBNull(reader.GetOrdinal("description")) ? "" : reader.GetString(13), // description
					reader.IsDBNull(reader.GetOrdinal("timesheet_code")) ? "" : reader.GetString(14), // timesheet_code
					reader.IsDBNull(reader.GetOrdinal("task_type")) ? "" : reader.GetString(15), // task_type
					reader.IsDBNull(reader.GetOrdinal("submitted_status")) ? "" : reader.GetString(16), // submitted_status
					reader.IsDBNull(reader.GetOrdinal("approval_status")) ? functions.approvalStatus(null) : functions.approvalStatus(reader.GetString(17)), // approval_status
					reader.IsDBNull(reader.GetOrdinal("rejection_reason")) ? "" : reader.GetString(18), // rejection_reason - check
					reader.IsDBNull(reader.GetOrdinal("approved_by_user_id")) ? null : new int?(int.Parse(reader.GetString(19))), // approved_by_user_id
					reader.IsDBNull(reader.GetOrdinal("approved_by_user_name")) ? "" : reader.GetString(20), // approved_by_user_name
					DateTime.Parse(reader.GetString(21)), // date_created
					DateTime.Parse(reader.GetString(22)), // date_modified
					reader.IsDBNull(reader.GetOrdinal("date_approved")) ? null : new DateTime?(DateTime.Parse(reader.GetString(22))) // date_approved
				));
			}
			reader.Close();
			myConnection.Close();
			return entries;
		}*/


		public List<Entry> Entries(List<string> qStrings)
		{
			List<Entry> entries = new List<Entry>();
			foreach (String qString in qStrings)
			{
				myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
				myConnection.Open();
				MySqlDataReader reader = myCommand.ExecuteReader();
				while (reader.Read())
				{
					entries.Add(new Entry(
						int.Parse(reader.GetString(0)), // entry_id
						int.Parse(reader.GetString(1)), // user_id
						reader.GetString(2), // user_name
						reader.IsDBNull(reader.GetOrdinal("section_id")) ? null : new int?(int.Parse(reader.GetString(3))), // section_id
						reader.IsDBNull(reader.GetOrdinal("project_serial")) ? "" : reader.GetString(4), // project_serial
						reader.IsDBNull(reader.GetOrdinal("project_sap")) ? "" : reader.GetString(5), // project_sap
						reader.IsDBNull(reader.GetOrdinal("number_section")) ? "" : reader.GetString(6), // number_section
						reader.IsDBNull(reader.GetOrdinal("number_network")) ? null : new int?(int.Parse(reader.GetString(7))), // number_network
						reader.IsDBNull(reader.GetOrdinal("number_activity")) ? "" : reader.GetString(8), // number_activity
						DateTime.Parse(reader.GetString(9)), // date
						int.Parse(reader.GetString(10)), // period
						int.Parse(reader.GetString(11)), // year
						double.Parse(reader.GetString(12)), // hours
						reader.IsDBNull(reader.GetOrdinal("description")) ? "" : reader.GetString(13), // description
						reader.IsDBNull(reader.GetOrdinal("timesheet_code")) ? "" : reader.GetString(14), // timesheet_code
						reader.IsDBNull(reader.GetOrdinal("task_type")) ? "" : reader.GetString(15), // task_type
						reader.IsDBNull(reader.GetOrdinal("submitted_status")) ? "" : reader.GetString(16), // submitted_status
						reader.IsDBNull(reader.GetOrdinal("approval_status")) ? functions.approvalStatus(null) : functions.approvalStatus(reader.GetString(17)), // approval_status
						reader.IsDBNull(reader.GetOrdinal("rejection_reason")) ? "" : reader.GetString(18), // rejection_reason - check
						reader.IsDBNull(reader.GetOrdinal("approved_by_user_id")) ? null : new int?(int.Parse(reader.GetString(19))), // approved_by_user_id
						reader.IsDBNull(reader.GetOrdinal("approved_by_user_name")) ? "" : reader.GetString(20), // approved_by_user_name
						DateTime.Parse(reader.GetString(21)), // date_created
						DateTime.Parse(reader.GetString(22)), // date_modified
						reader.IsDBNull(reader.GetOrdinal("date_approved")) ? null : new DateTime?(DateTime.Parse(reader.GetString(22))) // date_approved
					));
				}
				reader.Close();
				myConnection.Close();
			}

			return entries;
		}

		public List<Entry> Entries(string qString)
		{
			myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			List<Entry> entries = new List<Entry>();
			while(reader.Read())
			{
				entries.Add(new Entry(
					int.Parse(reader.GetString(0)), // entry_id
					int.Parse(reader.GetString(1)), // user_id
					reader.GetString(2), // user_name
					reader.IsDBNull(reader.GetOrdinal("section_id")) ? null : new int?(int.Parse(reader.GetString(3))), // section_id
					reader.IsDBNull(reader.GetOrdinal("project_serial")) ? "" : reader.GetString(4), // project_serial
					reader.IsDBNull(reader.GetOrdinal("project_sap")) ? "" : reader.GetString(5), // project_sap
					reader.IsDBNull(reader.GetOrdinal("number_section")) ? "" : reader.GetString(6), // number_section
					reader.IsDBNull(reader.GetOrdinal("number_network")) ? null : new int?(int.Parse(reader.GetString(7))), // number_network
					reader.IsDBNull(reader.GetOrdinal("number_activity")) ? "" : reader.GetString(8), // number_activity
					DateTime.Parse(reader.GetString(9)), // date
					int.Parse(reader.GetString(10)), // period
					int.Parse(reader.GetString(11)), // year
					double.Parse(reader.GetString(12)), // hours
					reader.IsDBNull(reader.GetOrdinal("description")) ? "" : reader.GetString(13), // description
					reader.IsDBNull(reader.GetOrdinal("timesheet_code")) ? "" : reader.GetString(14), // timesheet_code
					reader.IsDBNull(reader.GetOrdinal("task_type")) ? "" : reader.GetString(15), // task_type
					reader.IsDBNull(reader.GetOrdinal("submitted_status")) ? "" : reader.GetString(16), // submitted_status
					reader.IsDBNull(reader.GetOrdinal("approval_status")) ? functions.approvalStatus(null) : functions.approvalStatus(reader.GetString(17)), // approval_status
					reader.IsDBNull(reader.GetOrdinal("rejection_reason")) ? "" : reader.GetString(18), // rejection_reason - check
					reader.IsDBNull(reader.GetOrdinal("approved_by_user_id")) ? null : new int?(int.Parse(reader.GetString(19))), // approved_by_user_id
					reader.IsDBNull(reader.GetOrdinal("approved_by_user_name")) ? "" : reader.GetString(20), // approved_by_user_name
					DateTime.Parse(reader.GetString(21)), // date_created
					DateTime.Parse(reader.GetString(22)), // date_modified
					reader.IsDBNull(reader.GetOrdinal("date_approved")) ? null : new DateTime?(DateTime.Parse(reader.GetString(22))) // date_approved
				));
			}
			return entries;
		}

		private void Insert(MySqlCommand cmd)
		{
			try
			{
				myConnection.Open();
				cmd.ExecuteNonQuery();
				MessageBox.Show("Saved");
				myConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				try
				{
					myConnection.Close();
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
				myConnection.Open();
				foreach (MySqlCommand cmd in cmds)
				{
					cmd.ExecuteNonQuery();
				}
				myConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				try
				{
					myConnection.Close();
					MessageBox.Show(exception.Message);
				}
				catch
				{
					MessageBox.Show(exception.Message);
				}
			}
		}

		public void ResetUserLogin(User user)
		{
			string[] tLogin = new string[] { "Update ", t_Login, " SET ", t_Login_c_password, "=@password  WHERE ", t_Login_c_User_Id, "=@userId" };
			qString = string.Concat(tLogin);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@password", "letmein");
			mySqlCommand.Parameters.AddWithValue("@userId", user.UserID);
			Update(mySqlCommand);
		}

		public Entry Entry(string table, int entry_id)
        {
			object[] objArray = new object[] { "SELECT * FROM ", table, " WHERE ", t_Timesheet_c_Entry_Id, " = ", entry_id };
			myCommand = new MySqlCommand(string.Concat(objArray), myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			Entry returnedEntry;
			if(reader.HasRows)
            {
				returnedEntry = new Entry(
					int.Parse(reader.GetString(0)), // entry_id
					int.Parse(reader.GetString(1)), // user_id
					reader.GetString(2), // user_name
					reader.IsDBNull(reader.GetOrdinal("section_id")) ? null : new int?(int.Parse(reader.GetString(3))), // section_id
					reader.IsDBNull(reader.GetOrdinal("project_serial")) ? "" : reader.GetString(4), // project_serial
					reader.IsDBNull(reader.GetOrdinal("project_sap")) ? "" : reader.GetString(5), // project_sap
					reader.IsDBNull(reader.GetOrdinal("number_section")) ? "" : reader.GetString(6), // number_section
					reader.IsDBNull(reader.GetOrdinal("number_network")) ? null : new int?(int.Parse(reader.GetString(7))), // number_network
					reader.IsDBNull(reader.GetOrdinal("number_activity")) ? "" : reader.GetString(8), // number_activity
					DateTime.Parse(reader.GetString(9)), // date
					int.Parse(reader.GetString(10)), // period
					int.Parse(reader.GetString(11)), // year
					double.Parse(reader.GetString(12)), // hours
					reader.IsDBNull(reader.GetOrdinal("description")) ? "" : reader.GetString(13), // description
					reader.IsDBNull(reader.GetOrdinal("timesheet_code")) ? "" : reader.GetString(14), // timesheet_code
					reader.IsDBNull(reader.GetOrdinal("task_type")) ? "" : reader.GetString(15), // task_type
					reader.IsDBNull(reader.GetOrdinal("submitted_status")) ? "" : reader.GetString(16), // submitted_status
					reader.IsDBNull(reader.GetOrdinal("approval_status")) ? functions.approvalStatus(null) : functions.approvalStatus(reader.GetString(17)), // approval_status
					reader.IsDBNull(reader.GetOrdinal("rejection_reason")) ? "" : reader.GetString(18), // rejection_reason - check
					reader.IsDBNull(reader.GetOrdinal("approved_by_user_id")) ? null : new int?(int.Parse(reader.GetString(19))), // approved_by_user_id
					reader.IsDBNull(reader.GetOrdinal("approved_by_user_name")) ? "" : reader.GetString(20), // approved_by_user_name
					DateTime.Parse(reader.GetString(21)), // date_created
					DateTime.Parse(reader.GetString(22)), // date_modified
					reader.IsDBNull(reader.GetOrdinal("date_approved")) ? null : new DateTime?(DateTime.Parse(reader.GetString(22))) // date_approved
				);
				myConnection.Close();
				return returnedEntry;
			}
			return null;
		}

		public User GetUser(int user_id)
        {
			object[] objArray = { "SELECT * FROM ", t_Users, " WHERE ", t_Users_c_User_Id, " = ", user_id };
			myCommand = new MySqlCommand(string.Concat(objArray), myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			User returnedUser;
			reader.Read();
			if(reader.HasRows)
            {
				returnedUser = new User(
					int.Parse(reader.GetString(0)), // user id
					reader.GetString(1),
					int.Parse(reader.GetString(2)),
					int.Parse(reader.GetString(3)),
					int.Parse(reader.GetString(4)),
					int.Parse(reader.GetString(5))
				);
				myConnection.Close();
				return returnedUser;
            }
			return null;
		}

		public List<User> GetUser_All()
        {
			qString = string.Concat("SELECT * FROM ", t_Users);
			myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			List<User> returnedUsers = new List<User>();
			while(reader.Read())
            {
				returnedUsers.Add(new User(
					int.Parse(reader.GetString(0)), // user id
					reader.GetString(1),
					int.Parse(reader.GetString(2)),
					int.Parse(reader.GetString(3)),
					int.Parse(reader.GetString(4)),
					int.Parse(reader.GetString(5))
				));
            }
			myConnection.Close();
			return returnedUsers;
        }

		public bool Period_Open(int month, int year)
        {
			object[] tPeriod = new object[] { " SELECT *  FROM ", t_Period, " WHERE ", t_Period_Period, "='", month, "'  AND ", t_Period_Year, "='", year, "'" };
			myCommand = new MySqlCommand(string.Concat(tPeriod), myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			if(reader.HasRows)
            {
				reader.Read();
				myConnection.Close();
				return functions.IntToBool(int.Parse(reader.GetString(3)));
			}
			myConnection.Close();
			return false;
		}

		public Project Project(string numberSerial)
        {
			string[] tProjects = new string[] { "SELECT * FROM ", t_Projects, " WHERE ", t_Projects_c_Number_Serial, " ='", numberSerial, "'" };
			myCommand = new MySqlCommand(string.Concat(tProjects), myConnection.MySqlConnection);
			myConnection.Open();
			Project returnedProject = null;
			MySqlDataReader reader = myCommand.ExecuteReader();
			if(reader.HasRows)
            {
				reader.Read();
				returnedProject = new Project(
					reader.GetString(0), // numberSerial
					reader.GetString(1), // numberSAP
					reader.GetString(2), // numberMAS90
					reader.GetString(3), // numberBFC
					int.Parse(reader.GetString(4)), // numberNetwork
					reader.GetString(4), // customer
					reader.GetString(5), // machine
					reader.GetString(6), // country
					int.Parse(reader.GetString(7)), // isOpen
					int.Parse(reader.GetString(8)), // isWarrantyOpen
					int.Parse(reader.GetString(9)) // numberWarrantyNetwork
				);
            }
			myConnection.Close();
			return returnedProject;
		}

		public List<Project> ProjectAll()
        {
			qString = string.Concat("SELECT * FROM ", t_Projects);
			myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			myConnection.Open();
			List<Project> returnedProjects = new List<Project>();
			MySqlDataReader reader = myCommand.ExecuteReader();
			while(reader.Read())
            {
				returnedProjects.Add(new Project(
					reader.IsDBNull(0) ? "" : reader.GetString(0), // numberSerial
					reader.IsDBNull(1) ? "" : reader.GetString(1), // numberSAP
					reader.IsDBNull(2) ? "" : reader.GetString(2), // numberMAS90
					reader.IsDBNull(3) ? "" : reader.GetString(3), // numberBFC
					reader.IsDBNull(4) ? -1 : int.Parse(reader.GetString(4)), // numberNetwork
					reader.IsDBNull(5) ? "" : reader.GetString(5), // customer
					reader.IsDBNull(6) ? "" : reader.GetString(6), // machine
					reader.IsDBNull(7) ? "" : reader.GetString(7), // country
					reader.IsDBNull(8) ? -1 : int.Parse(reader.GetString(8)), // isOpen
					reader.IsDBNull(9) ? -1 : int.Parse(reader.GetString(9)), // isWarrantyOpen
					reader.IsDBNull(10) ? -1 : int.Parse(reader.GetString(10)) // numberWarrantyNetwork
				));
            }
			myConnection.Close();
			return returnedProjects;
		}

		public List<string> Projects()
        {
			qString = string.Concat("SELECT * FROM ", t_Projects);
			myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			List<string> returnedStrings = new List<string>();
			while(reader.Read())
            {
				returnedStrings.Add(reader.GetString(0));
            }
			myConnection.Close();
			return returnedStrings;
		}

		public void SaveTimeEntry(int userId, string userName, int? sectionId, string projectSerial, string projectSAP, string numberSection, int? network, string activity, DateTime date, int period, int year, double hours, string description, string timesheetCode, string taskType, string submittedStatus, string approvalStatus)
		{
			string[] tTimesheetPrelim = new string[] { "INSERT INTO ", t_Timesheet_Prelim, " (", t_Timesheet_c_User_Id, ", ", t_Timesheet_c_User_Name, ", ", t_Timesheet_c_Section_Id, ", ", t_Timesheet_c_Project_Serial, ", ", t_Timesheet_c_Project_Sap, ", ", t_Timesheet_c_Number_Section, ", ", t_Timesheet_c_Number_Network, ", ", t_Timesheet_c_Number_Activity, ", ", t_Timesheet_c_Date, ", ", t_Timesheet_c_Period, ", ", t_Timesheet_c_Year, ", ", t_Timesheet_c_Hours, ", ", t_Timesheet_c_Description, ", ", t_Timesheet_c_Timesheet_Code, ", ", t_Timesheet_c_Task_Type, ", ", t_Timesheet_c_Submitted_Status, ", ", t_Timesheet_c_Approval_Status, ", ", t_Timesheet_c_Date_Created, ") VALUES(@userId, @userName, @sectionId, @projectSerial, @projectSAP, @numberSection, @network, @activity, @date, @period, @year, @hours, @description, @timesheetCode, @taskType, @submittedStatus, @approvalStatus, @dateCreated)" };
			qString = string.Concat(tTimesheetPrelim);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
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
			Insert(mySqlCommand);
		}

		public void SaveTimeEntry(string tableName, int userId, string userName, int? sectionId, string projectSerial, string projectSAP, string numberSection, int? network, string activity, DateTime date, int period, int year, double hours, string description, string timesheetCode, string taskType, string submittedStatus, string approvalStatus)
		{
			string[] strArrays = new string[] { "INSERT INTO ", tableName, " (", t_Timesheet_c_User_Id, ", ", t_Timesheet_c_User_Name, ", ", t_Timesheet_c_Section_Id, ", ", t_Timesheet_c_Project_Serial, ", ", t_Timesheet_c_Project_Sap, ", ", t_Timesheet_c_Number_Section, ", ", t_Timesheet_c_Number_Network, ", ", t_Timesheet_c_Number_Activity, ", ", t_Timesheet_c_Date, ", ", t_Timesheet_c_Period, ", ", t_Timesheet_c_Year, ", ", t_Timesheet_c_Hours, ", ", t_Timesheet_c_Description, ", ", t_Timesheet_c_Timesheet_Code, ", ", t_Timesheet_c_Task_Type, ", ", t_Timesheet_c_Submitted_Status, ", ", t_Timesheet_c_Approval_Status, ", ", t_Timesheet_c_Date_Created, ") VALUES(@userId, @userName, @sectionId, @projectSerial, @projectSAP, @numberSection, @network, @activity, @date, @period, @year, @hours, @description, @timesheetCode, @taskType, @submittedStatus, @approvalStatus, @dateCreated)" };
			qString = string.Concat(strArrays);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
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
			Insert(mySqlCommand);
		}

		public void SaveTimeEntry(string tableName, Entry entry, ApprovalStatus approvalStatus, ApprovalStatus submittedStatus)
		{
			string[] strArrays = new string[] { "INSERT INTO ", tableName, " (", t_Timesheet_c_User_Id, ", ", t_Timesheet_c_User_Name, ", ", t_Timesheet_c_Section_Id, ", ", t_Timesheet_c_Project_Serial, ", ", t_Timesheet_c_Project_Sap, ", ", t_Timesheet_c_Number_Section, ", ", t_Timesheet_c_Number_Network, ", ", t_Timesheet_c_Number_Activity, ", ", t_Timesheet_c_Date, ", ", t_Timesheet_c_Period, ", ", t_Timesheet_c_Year, ", ", t_Timesheet_c_Hours, ", ", t_Timesheet_c_Description, ", ", t_Timesheet_c_Timesheet_Code, ", ", t_Timesheet_c_Task_Type, ", ", t_Timesheet_c_Submitted_Status, ", ", t_Timesheet_c_Approval_Status, ", ", t_Timesheet_c_Date_Created, ", ", t_Timesheet_c_Date_Modified, ") VALUES(@userId, @userName, @sectionId, @projectSerial, @projectSAP, @numberSection, @network, @activity, @date, @period, @year, @hours, @description, @timesheetCode, @taskType, @submittedStatus, @approvalStatus, @dateCreated, @dateModified)" };
			qString = string.Concat(strArrays);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
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
			mySqlCommand.Parameters.AddWithValue("@submittedStatus", functions.approvalStatus(submittedStatus));
			mySqlCommand.Parameters.AddWithValue("@approvalStatus", functions.approvalStatus(approvalStatus));
			MySqlParameterCollection mySqlParameterCollection = mySqlCommand.Parameters;
			dateCreated = entry.date_created;
			mySqlParameterCollection.AddWithValue("@dateCreated", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
			MySqlParameterCollection parameters1 = mySqlCommand.Parameters;
			dateCreated = entry.date_modified;
			parameters1.AddWithValue("@dateModified", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
			Insert(mySqlCommand);
		}

		public void SaveTimeEntry(string tableName, List<Entry> entries, ApprovalStatus approvalStatus, ApprovalStatus submittedStatus)
		{
			string[] strArrays = new string[] { "INSERT INTO ", tableName, " (", t_Timesheet_c_User_Id, ", ", t_Timesheet_c_User_Name, ", ", t_Timesheet_c_Section_Id, ", ", t_Timesheet_c_Project_Serial, ", ", t_Timesheet_c_Project_Sap, ", ", t_Timesheet_c_Number_Section, ", ", t_Timesheet_c_Number_Network, ", ", t_Timesheet_c_Number_Activity, ", ", t_Timesheet_c_Date, ", ", t_Timesheet_c_Period, ", ", t_Timesheet_c_Year, ", ", t_Timesheet_c_Hours, ", ", t_Timesheet_c_Description, ", ", t_Timesheet_c_Timesheet_Code, ", ", t_Timesheet_c_Task_Type, ", ", t_Timesheet_c_Submitted_Status, ", ", t_Timesheet_c_Approval_Status, ", ", t_Timesheet_c_Date_Created, ", ", t_Timesheet_c_Date_Modified, ") VALUES(@userId, @userName, @sectionId, @projectSerial, @projectSAP, @numberSection, @network, @activity, @date, @period, @year, @hours, @description, @timesheetCode, @taskType, @submittedStatus, @approvalStatus, @dateCreated, @dateModified)" };
			qString = string.Concat(strArrays);
			List<MySqlCommand> mySqlCommands = new List<MySqlCommand>();
			foreach (Entry entry in entries)
			{
				MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
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
				mySqlCommand.Parameters.AddWithValue("@submittedStatus", functions.approvalStatus(submittedStatus));
				mySqlCommand.Parameters.AddWithValue("@approvalStatus", functions.approvalStatus(approvalStatus));
				MySqlParameterCollection mySqlParameterCollection = mySqlCommand.Parameters;
				dateCreated = entry.date_created;
				mySqlParameterCollection.AddWithValue("@dateCreated", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
				MySqlParameterCollection parameters1 = mySqlCommand.Parameters;
				dateCreated = entry.date_modified;
				parameters1.AddWithValue("@dateModified", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
				mySqlCommands.Add(mySqlCommand);
			}
			Insert(mySqlCommands);
		}

		public void SaveTimeEntry(string tableName, List<Entry> entries, ApprovalStatus approvalStatus, ApprovalStatus submittedStatus, User Approver)
		{
			string[] strArrays = new string[] { "INSERT INTO ", tableName, " (", t_Timesheet_c_User_Id, ", ", t_Timesheet_c_User_Name, ", ", t_Timesheet_c_Section_Id, ", ", t_Timesheet_c_Project_Serial, ", ", t_Timesheet_c_Project_Sap, ", ", t_Timesheet_c_Number_Section, ", ", t_Timesheet_c_Number_Network, ", ", t_Timesheet_c_Number_Activity, ", ", t_Timesheet_c_Date, ", ", t_Timesheet_c_Period, ", ", t_Timesheet_c_Year, ", ", t_Timesheet_c_Hours, ", ", t_Timesheet_c_Description, ", ", t_Timesheet_c_Timesheet_Code, ", ", t_Timesheet_c_Task_Type, ", ", t_Timesheet_c_Submitted_Status, ", ", t_Timesheet_c_Approval_Status, ", ", t_Timesheet_c_Date_Created, ", ", t_Timesheet_c_Date_Modified, ", ", t_Timesheet_c_Approved_By_User_Id, ", ", t_Timesheet_c_Approved_By_User_Name, ", ", t_Timesheet_c_Date_Approved, ") VALUES(@userId, @userName, @sectionId, @projectSerial, @projectSAP, @numberSection, @network, @activity, @date, @period, @year, @hours, @description, @timesheetCode, @taskType, @submittedStatus, @approvalStatus, @dateCreated, @dateModified, @approvedByUserId, @approvedByUserName, @dateApproved)" };
			qString = string.Concat(strArrays);
			List<MySqlCommand> mySqlCommands = new List<MySqlCommand>();
			foreach (Entry entry in entries)
			{
				MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
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
				mySqlCommand.Parameters.AddWithValue("@submittedStatus", functions.approvalStatus(submittedStatus));
				mySqlCommand.Parameters.AddWithValue("@approvalStatus", functions.approvalStatus(approvalStatus));
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
			Insert(mySqlCommands);
		}

		public void SaveTimeEntry(string tableName, List<Entry> entries, ApprovalStatus approvalStatus, ApprovalStatus submittedStatus, string rejectionReason)
		{
			string[] strArrays = new string[] { "INSERT INTO ", tableName, " (", t_Timesheet_c_User_Id, ", ", t_Timesheet_c_User_Name, ", ", t_Timesheet_c_Section_Id, ", ", t_Timesheet_c_Project_Serial, ", ", t_Timesheet_c_Project_Sap, ", ", t_Timesheet_c_Number_Section, ", ", t_Timesheet_c_Number_Network, ", ", t_Timesheet_c_Number_Activity, ", ", t_Timesheet_c_Date, ", ", t_Timesheet_c_Period, ", ", t_Timesheet_c_Year, ", ", t_Timesheet_c_Hours, ", ", t_Timesheet_c_Description, ", ", t_Timesheet_c_Timesheet_Code, ", ", t_Timesheet_c_Task_Type, ", ", t_Timesheet_c_Submitted_Status, ", ", t_Timesheet_c_Approval_Status, ", ", t_Timesheet_c_Rejection_Reason, ", ", t_Timesheet_c_Date_Created, ",", t_Timesheet_c_Date_Modified, ") VALUES(@userId, @userName, @sectionId, @projectSerial, @projectSAP, @numberSection, @network, @activity, @date, @period, @year, @hours, @description, @timesheetCode, @taskType, @submittedStatus, @approvalStatus, @rejectionReason, @dateCreated, @dateModified)" };
			qString = string.Concat(strArrays);
			List<MySqlCommand> mySqlCommands = new List<MySqlCommand>();
			foreach (Entry entry in entries)
			{
				MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
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
				mySqlCommand.Parameters.AddWithValue("@submittedStatus", functions.approvalStatus(submittedStatus));
				mySqlCommand.Parameters.AddWithValue("@approvalStatus", functions.approvalStatus(approvalStatus));
				mySqlCommand.Parameters.AddWithValue("@rejectionReason", rejectionReason);
				MySqlParameterCollection mySqlParameterCollection = mySqlCommand.Parameters;
				dateCreated = entry.date_created;
				mySqlParameterCollection.AddWithValue("@dateCreated", dateCreated.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
				mySqlCommand.Parameters.AddWithValue("@dateModified", entry.date_modified);
				mySqlCommands.Add(mySqlCommand);
			}
			Insert(mySqlCommands);
		}

		public Section Section(int section_id)
		{
			object[] tSections = new object[] { " SELECT *  FROM ", t_Sections, " WHERE ", t_Sections_c_Entry_Id, "='", section_id, "'" };
			myCommand = new MySqlCommand(string.Concat(tSections), myConnection.MySqlConnection);
			myConnection.Open();
			Section returnedSection = null;
			MySqlDataReader reader = myCommand.ExecuteReader();
			if(reader.Read())
            {
				returnedSection = new Section(
					int.Parse(reader.GetString(0)),
					reader.GetString(1),
					reader.GetString(2),
					reader.GetString(3),
					reader.GetString(4),
					reader.GetString(5),
					reader.GetString(6)
				);
            }
			myConnection.Close();
			return returnedSection;
		}

		public List<Section> Sections(int project_number_network)
        {
			object[] tSections = new object[] { " SELECT *  FROM ", t_Sections, " WHERE ", t_Sections_c_Number_Project_Network, "='", project_number_network, "'" };
			myCommand = new MySqlCommand(string.Concat(tSections), myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			List<Section> returnedSections = new List<Section>();
			while(reader.Read())
            {
				returnedSections.Add(new Section(
					int.Parse(reader.GetString(0)),
					reader.GetString(1),
					reader.GetString(2),
					reader.GetString(3),
					reader.GetString(4),
					reader.GetString(5),
					reader.GetString(6)
				));
            }
			myConnection.Close();
			return returnedSections;
		}

		public List<Section> Sections(int project_number_network, string task_type)
		{
			object[] tSections = new object[] { " SELECT *  FROM ", t_Sections, " WHERE ", t_Sections_c_Number_Project_Network, "='", project_number_network, "' AND ", t_Sections_c_Task_Type, "='", task_type, "'" };
			qString = string.Concat(tSections);
			myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			myConnection.Open();
			List<Section> returnedSections = new List<Section>();
			MySqlDataReader reader = myCommand.ExecuteReader();
			while (reader.Read())
			{
				returnedSections.Add(new Section(
					int.Parse(reader.GetString(0)),
					reader.GetString(1),
					reader.GetString(2),
					reader.GetString(3),
					reader.GetString(4),
					reader.GetString(5),
					reader.GetString(6)
				));
			}
			myConnection.Close();
			return returnedSections;
		}

		public List<Section> Sections()
		{
			qString = string.Concat(" SELECT *  FROM ", t_Sections);
			myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			myConnection.Open();
			List<Section> returnedSections = new List<Section>();
			MySqlDataReader reader = myCommand.ExecuteReader();
			while (reader.Read())
			{
				returnedSections.Add(new Section(
					int.Parse(reader.GetString(0)),
					reader.GetString(1),
					reader.GetString(2),
					reader.GetString(3),
					reader.GetString(4),
					reader.GetString(5),
					reader.GetString(6)
				));
			}
			myConnection.Close();
			return returnedSections;
		}

		public string TaskTypeDescription(string taskType_Id)
        {
			string[] tTaskType = new string[] { "SELECT * FROM ", t_Task_type, " WHERE ", t_Task_Type_c_Task_Type, "='", taskType_Id, "'" };
			qString = string.Concat(tTaskType);
			myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			if (reader.Read())
			{
				return reader.GetString(1);
			}
			return "";
		}

		public List<string> TaskTypes()
		{
			qString = string.Concat("SELECT * FROM ", t_Task_type);
			myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			List<string> returnedStrings = new List<string>();
			while(reader.Read())
            {
				returnedStrings.Add(reader.GetString(0));
            }
			myConnection.Close();
			return returnedStrings;
		}

		public List<TaskType> TaskTypes(Section section)
		{
			string[] tSections = new string[] { "SELECT * FROM ", t_Sections, " WHERE ", t_Sections_c_Number_Section, "='", section.Number_Section, "' AND ", t_Sections_c_Number_Project_Network, "='", section.Number_ProjectNetwork, "'" };
			qString = string.Concat(tSections);
			myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			List<TaskType> returnedTasks = new List<TaskType>();
			while(reader.Read())
            {
				returnedTasks.Add(new TaskType()
				{
					ActivityNumber = reader.GetString(t_Sections_c_Number_Activity),
					Id = reader.GetString(t_Sections_c_Task_Type),
					Description = loadDescription(reader.GetString(t_Sections_c_Task_Type))
				});
            }
			reader.Close();
			myConnection.Close();
			return returnedTasks;
		}

		public string loadDescription(string taskType)
		{
			string[] descriptions = new string[] { "SELECT * FROM ", t_Task_type, " WHERE ", t_Task_Type_c_Task_Type, " = '", taskType, "'" };
			myCommand = new MySqlCommand(string.Concat(descriptions), myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			string returnedString = "";
			if(reader.Read())
			{
				returnedString = reader.GetString(1);
			}
			reader.Close();
			myConnection.Close();
			return returnedString;
		}

		public List<TaskType> TaskTypesAll()
		{
			qString = string.Concat("SELECT * FROM ", t_Task_type);
			myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			List<TaskType> returnedTaskTypes = new List<TaskType>();
			while(reader.Read())
			{
				returnedTaskTypes.Add(new TaskType()
				{
					Id = reader.GetString(0),
					Description = reader.GetString(1)
				});
			}
			reader.Close();
			myConnection.Close();
			return returnedTaskTypes;
		}

		public string TimeCodes_Description(string time_code)
		{
			string[] tTimesheetCodes = new string[] { "SELECT * FROM ", t_Timesheet_codes, " WHERE ", t_Timesheet_Codes_c_Timesheet_Code, " ='", time_code, "'" };
			qString = string.Concat(tTimesheetCodes);
			myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			string returnedString = "";
			if(reader.Read())
			{
				returnedString = reader.GetString(1);
			}
			reader.Close();
			myConnection.Close();
			return returnedString;
		}
		
		public TimesheetCode TimesheetCode(string time_code)
		{
			string[] tTimesheetCodes = new string[] { "SELECT * FROM ", t_Timesheet_codes, " WHERE ", t_Timesheet_Codes_c_Timesheet_Code, " ='", time_code, "'" };
			qString = string.Concat(tTimesheetCodes);
			myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			TimesheetCode returnedTimesheetCode = new TimesheetCode();
			if(reader.Read())
			{
				returnedTimesheetCode = new TimesheetCode(
					reader.GetString(0),
					reader.GetString(1)
				);
			}
			reader.Close();
			myConnection.Close();
			return returnedTimesheetCode;
		}

		public List<TimesheetCode> TimesheetCodeAll()
		{
			qString = string.Concat("SELECT * FROM ", t_Timesheet_codes);
			myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			List<TimesheetCode> returnedTimesheetCodes = new List<TimesheetCode>();
			while(reader.Read())
			{
				returnedTimesheetCodes.Add(new TimesheetCode(
					reader.GetString(0),
					reader.GetString(1)
				));
			}
			reader.Close();
			myConnection.Close();
			return returnedTimesheetCodes;
		}

		private void Update(MySqlCommand cmd)
		{
			try
			{
				myConnection.Open();
				cmd.ExecuteNonQuery();
				MessageBox.Show("Update made");
				myConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				try
				{
					myConnection.Close();
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
			string[] tProjects = new string[] { "Update ", t_Projects, " SET ", t_Projects_c_Country, "=@country, ", t_Projects_c_Customer, "=@customer, ", t_Projects_c_IsOpen, "=@isOpen, ", t_Projects_c_IsWarrantyOpen, "=@isWarrantyOpen, ", t_Projects_c_Machine, "=@machine, ", t_Projects_c_Number_BFC, "=@numberBFC, ", t_Projects_c_Number_MAS90, "=@numberMAS90, ", t_Projects_c_Number_Network, "=@numberNetwork, ", t_Projects_c_Number_SAP, "=@numberSAP, ", t_Projects_c_Number_WarrantyNetwork, "=@numberWarrantyNetwork WHERE ", t_Projects_c_Number_Serial, "=@numberSerial" };
			qString = string.Concat(tProjects);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
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
			Update(mySqlCommand);
		}

		public void UpdateTimeEntry(int entryId, int? sectionId, string projectSerial, string projectSAP, string numberSection, int? network, string activity, DateTime date, int period, int year, double hours, string description, string timesheetCode, string taskType)
		{
			string[] tTimesheetPrelim = new string[] { "Update ", t_Timesheet_Prelim, " SET ", t_Timesheet_c_Section_Id, "=@sectionId, ", t_Timesheet_c_Project_Serial, "=@projectSerial, ", t_Timesheet_c_Project_Sap, "=@projectSAP, ", t_Timesheet_c_Number_Section, "=@numberSection, ", t_Timesheet_c_Number_Network, "=@network, ", t_Timesheet_c_Number_Activity, "=@activity, ", t_Timesheet_c_Date, "=@date, ", t_Timesheet_c_Period, "=@period, ", t_Timesheet_c_Year, "=@year, ", t_Timesheet_c_Hours, "=@hours, ", t_Timesheet_c_Description, "=@description, ", t_Timesheet_c_Timesheet_Code, "=@timesheetCode, ", t_Timesheet_c_Task_Type, "=@taskType, ", t_Timesheet_c_Date_Modified, "=@dateModified WHERE ", t_Timesheet_c_Entry_Id, "=@entryId" };
			qString = string.Concat(tTimesheetPrelim);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
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
			Update(mySqlCommand);
		}

		public void UpdateTimeEntry(Entry entry)
		{
			string[] tTimesheetPrelim = new string[] { "Update ", t_Timesheet_Prelim, " SET ", t_Timesheet_c_Section_Id, "=@sectionId, ", t_Timesheet_c_Project_Serial, "=@projectSerial, ", t_Timesheet_c_Project_Sap, "=@projectSAP, ", t_Timesheet_c_Number_Section, "=@numberSection, ", t_Timesheet_c_Number_Network, "=@network, ", t_Timesheet_c_Number_Activity, "=@activity, ", t_Timesheet_c_Date, "=@date, ", t_Timesheet_c_Period, "=@period, ", t_Timesheet_c_Year, "=@year, ", t_Timesheet_c_Hours, "=@hours, ", t_Timesheet_c_Description, "=@description, ", t_Timesheet_c_Timesheet_Code, "=@timesheetCode, ", t_Timesheet_c_Task_Type, "=@taskType, ", t_Timesheet_c_Date_Modified, "=@dateModified WHERE ", t_Timesheet_c_Entry_Id, "=@entryId" };
			qString = string.Concat(tTimesheetPrelim);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
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
			Update(mySqlCommand);
		}

		public void UpdateUserDefaults(User_Defaults UserDefault)
		{
			string[] tUsersDefaults = new string[] { "Update ", t_UsersDefaults, " SET ", t_UsersDefaults_c_TimesheetCode, "=@timesheetCode, ", t_UsersDefaults_c_TaskType, "=@taskType, ", t_UsersDefaults_c_Project, "=@project, ", t_UsersDefaults_c_Default4, "=@default4, ", t_UsersDefaults_c_Default5, "=@default5, ", t_UsersDefaults_c_Default6, "=@default6, ", t_UsersDefaults_c_Default7, "=@default7, ", t_UsersDefaults_c_Default8, "=@default8, ", t_UsersDefaults_c_Default9, "=@default9, ", t_UsersDefaults_c_Default10, "=@default10, ", t_UsersDefaults_c_Default11, "=@default11, ", t_UsersDefaults_c_Default12, "=@default12, ", t_UsersDefaults_c_Default13, "=@default13, ", t_UsersDefaults_c_Default14, "=@default14, ", t_UsersDefaults_c_Default15, "=@default15, ", t_UsersDefaults_c_Default16, "=@default16, ", t_UsersDefaults_c_Default17, "=@default17, ", t_UsersDefaults_c_Default18, "=@default18, ", t_UsersDefaults_c_Default19, "=@default19, ", t_UsersDefaults_c_Default20, "=@default20  WHERE ", t_UsersDefaults_c_User_Id, "=@userId" };
			qString = string.Concat(tUsersDefaults);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
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
			Update(mySqlCommand);
		}

		public void UpdateUserPassword(User user, string password)
		{
			string[] tLogin = new string[] { "Update ", t_Login, " SET ", t_Login_c_password, "=@password  WHERE ", t_Login_c_User_Id, "=@userId" };
			qString = string.Concat(tLogin);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@password", password);
			mySqlCommand.Parameters.AddWithValue("@userId", user.UserID);
			Update(mySqlCommand);
		}

		public void User_AddApprovee(User approver, User approvee)
		{
			string[] tApprovalHierarchy = new string[] { "INSERT INTO ", t_ApprovalHierarchy, " (", t_ApprovalHierarchy_c_Approvee_Id, ", ", t_ApprovalHierarchy_c_Approvee_Name, ", ", t_ApprovalHierarchy_c_Approver_Id, ", ", t_ApprovalHierarchy_c_Approver_Name, ") VALUES(@approveeId, @approveeName, @approverId, @approverName)" };
			qString = string.Concat(tApprovalHierarchy);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			mySqlCommand.Parameters.AddWithValue("@approveeId", approvee.UserID);
			mySqlCommand.Parameters.AddWithValue("@approveeName", approvee.UserName);
			mySqlCommand.Parameters.AddWithValue("@approverId", approver.UserID);
			mySqlCommand.Parameters.AddWithValue("@approverName", approver.UserName);
			Insert(mySqlCommand);
		}

		public List<string> User_Defaults(int user_id)
		{
			List<string> strs = new List<string>();
			object[] tUsersDefaults = new object[] { "SELECT * FROM ", t_UsersDefaults, " WHERE ", t_UsersDefaults_c_User_Id, "= '", user_id, "'" };
			string str = string.Concat(tUsersDefaults);
			myCommand = new MySqlCommand(str, myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			if (reader.Read()) {
				for(int i = 1; i < reader.FieldCount; ++i)
				{
					strs.Add(reader.IsDBNull(i) ? "" : reader.GetString(i));
				}

			}
			reader.Close();
			myConnection.Close();
			return strs;
		}

		public List<User> User_GetApprovees(User User)
		{
			object[] tApprovalHierarchy = new object[] { "SELECT * FROM ", t_ApprovalHierarchy, " WHERE ", t_ApprovalHierarchy_c_Approver_Id, "= '", User.UserID, "'" };
			qString = string.Concat(tApprovalHierarchy);
			myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			List<User> returnedUsers = new List<User>();
			while (reader.Read())
			{
				returnedUsers.Add(GetUser(int.Parse(reader.GetString(3))));
			}
			myConnection.Close();
			return returnedUsers;
		}

		public string ProjectNumber_Network(string numberSerial)
		{
			string[] tProjects = new string[] { "SELECT * FROM ", t_Projects, " WHERE ", t_Projects_c_Number_Serial, " ='", numberSerial, "'" };
			qString = string.Concat(tProjects);
			myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			if(reader.Read())
            {
				reader.Close();
				myConnection.Close();
				return reader.IsDBNull(4) ? "" : reader.GetString(4);
            }
			reader.Close();
			myConnection.Close();
			return "";
		}

		public string User_AllEntries(int user_id, string table)
		{
			object[] objArray = new object[] { "SELECT * FROM ", table, " WHERE ", t_Timesheet_c_User_Id, "= '", user_id, "'" };
			return string.Concat(objArray);
		}

		public void User_RemoveApprovee(User approver, User approvee)
		{
			object[] tApprovalHierarchy = new object[] { "DELETE FROM ", t_ApprovalHierarchy, " WHERE ", t_ApprovalHierarchy_c_Approver_Id, "='", approver.UserID, "'  AND ", t_ApprovalHierarchy_c_Approvee_Id, "='", approvee.UserID, "'" };
			qString = string.Concat(tApprovalHierarchy);
			MySqlCommand mySqlCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			try
			{
				myConnection.Open();
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				MessageBox.Show("Entry Deleted");
				while (mySqlDataReader.Read())
				{
				}
				mySqlDataReader.Close();
				myConnection.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				try
				{
					myConnection.Close();
					MessageBox.Show(exception.Message);
				}
				catch
				{
					MessageBox.Show(exception.Message);
				}
			}
		}

		public List<User> User_GetApprovers(FivesBronxTimesheetManagement.Classes.User User)
		{
			List<User> users = new List<FivesBronxTimesheetManagement.Classes.User>();
			object[] tApprovalHierarchy = new object[] { "SELECT * FROM ", t_ApprovalHierarchy, " WHERE ", t_ApprovalHierarchy_c_Approvee_Id, "= '", User.UserID, "'" };
			qString = string.Concat(tApprovalHierarchy);
			myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
			myConnection.Open();
			MySqlDataReader reader = myCommand.ExecuteReader();
			while(reader.Read())
            {
				users.Add(GetUser(int.Parse(reader.GetString(t_ApprovalHierarchy_c_Approver_Id))));
            }
			reader.Close();
			myConnection.Close();
			return users;
		}
	}
}
