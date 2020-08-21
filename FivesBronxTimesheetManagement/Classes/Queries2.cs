using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
				myConnection.Close();
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
			qString = string.Concat("SELECT * FROM", t_Users);
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
			return returnedUsers;
        }

		public bool Period_Open()

		public Project Project(string numberSerial)
        {
			string[] tProject
        }
	}
}
