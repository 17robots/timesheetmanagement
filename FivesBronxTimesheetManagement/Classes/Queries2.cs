using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * approval_heirarchy columns:
 * approval_heirarchy_id - int
 * approver_id - int
 * approver_name - varchar
 * approvee_id - int
 * approvee_name - varchar
 */


/*
 * login columns
 * login_id - int
 * user_id - int
 * password - varchar
 */

/*
 * period columns
 * period_id - int
 * period - int
 * year - int
 * period_open - tinyint(4)
 * period_current - varchar(45)
 */

/*
 * projects columns
 * number_serial - varchar
 * number_sap - varchar
 * number_MAS90 - varchar
 * number_bfc - varchar
 * number_network - int
 * vendor - varchar
 * machine - varchar
 * country - varchar
 * isOpen - int
 * isWarrantyOpen - int
 * number_warrantynetwork - int
 */

/*
 * section columns
 * entry_id - int
 * number_project_network - varchar
 * number_section - varchar
 * description_section - longtext
 * number_activity - varchar
 * task_type - varchar
 * description_activity - varchar
 */

/*
 * task_type columns
 * task_type - varchar
 * task_type_description - varchar
 */

/*
 * timesheet_codes columns
 * timesheet_code - varchar
 * timesheet_description varchar
 */

/* 
 * ts_archive columns
 * entry_id - int
 * user_id - int
 * username - varchar
 * section_id - int
 * project_serial - varchar
 * project_sap - varchar
 * number_section - varchar
 * number_network - int
 * number_activity - varchar
 * date - datetime
 * period - int
 * year - int
 * hours - double
 * description - mediumtext
 * timesheet_code - varchar
 * task_type - varchar
 * submitted_status - varchar
 * approval_status - varchar
 * rejection_reason - varchar
 * approved_by_user_id - int
 * approved_by_user_name - varchar
 * date_created - datetime
 * date_modified - datetime
 * date_approval - datetime
 * ts_prelimcol - varchar
 */

/* 
 * ts_final columns
 * entry_id - int
 * user_id - int
 * username - varchar
 * section_id - int
 * project_serial - varchar
 * project_sap - varchar
 * number_section - varchar
 * number_network - int
 * number_activity - varchar
 * date - datetime
 * period - int
 * year - int
 * hours - double
 * description - mediumtext
 * timesheet_code - varchar
 * task_type - varchar
 * submitted_status - varchar
 * approval_status - varchar
 * rejection_reason - varchar
 * approved_by_user_id - int
 * approved_by_user_name - varchar
 * date_created - datetime
 * date_modified - datetime
 * date_approval - datetime
 * ts_prelimcol - varchar
 */

/* 
 * ts_limbo columns
 * entry_id - int
 * user_id - int
 * username - varchar
 * section_id - int
 * project_serial - varchar
 * project_sap - varchar
 * number_section - varchar
 * number_network - int
 * number_activity - varchar
 * date - datetime
 * period - int
 * year - int
 * hours - double
 * description - mediumtext
 * timesheet_code - varchar
 * task_type - varchar
 * submitted_status - varchar
 * approval_status - varchar
 * rejection_reason - varchar
 * approved_by_user_id - int
 * approved_by_user_name - varchar
 * date_created - datetime
 * date_modified - datetime
 * date_approval - datetime
 * ts_prelimcol - varchar
 */

/* 
 * ts_prelim columns
 * entry_id - int
 * user_id - int
 * username - varchar
 * section_id - int
 * project_serial - varchar
 * project_sap - varchar
 * number_section - varchar
 * number_network - int
 * number_activity - varchar
 * date - datetime
 * period - int
 * year - int
 * hours - double
 * description - mediumtext
 * timesheet_code - varchar
 * task_type - varchar
 * submitted_status - varchar
 * approval_status - varchar
 * rejection_reason - varchar
 * approved_by_user_id - int
 * approved_by_user_name - varchar
 * date_created - datetime
 * date_modified - datetime
 * date_approval - datetime
 * ts_prelimcol - varchar
 */

/*
 * users columns
 * user_id - int
 * user_name - varchar
 * user_validator - int
 * user_admin - int
 * user_isactive - int
 * user_ishourly - int
 * user_iscontractor - int
 */

/*
 * users_defaults columns
 * user_id - int
 * user_default1 - varchar
 * user_default2 - varchar
 * user_default3 - varchar
 * user_default4 - varchar
 * user_default5 - varchar
 * user_default6 - varchar
 * user_default7 - varchar
 * user_default8 - varchar
 * user_default9 - varchar
 * user_default10 - varchar
 * user_default11 - varchar
 * user_default12 - varchar
 * user_default13 - varchar
 * user_default14 - varchar
 * user_default15 - varchar
 * user_default16 - varchar
 * user_default17 - varchar
 * user_default18 - varchar
 * user_default19 - varchar
 * user_default20 - varchar
 */

// fast queries for report2
namespace FivesBronxTimesheetManagement.Classes
{
    class Queries2
    {
        /*private Functions functions;

        private Connection myConnection = new Connection();

        private MySqlCommand myCommand;
		public Queries2()
		{
			Connection connection = new Connection();
			
		}

        public List<string> Entry_QStrings_FromEntryId(string table, List<int> entry_ids)
        {
            List<string> strs = new List<string>();
            foreach (int entryId in entry_ids)
            {
                object[] objArray = new object[] { " SELECT *  FROM ", table, " WHERE ", t_Timesheet_c_Entry_Id, "='", entryId, "'" };
                strs.Add(string.Concat(objArray));
            }
            return strs;
        }

        public List<int> ReturnIntList(List<string> qStrings, string tableColumn)
        {
            List<int> nums = new List<int>();
            myConnection.Open();
            foreach (string qString in qStrings)
            {
                myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
                MySqlDataReader mySqlDataReader = myCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    nums.Add(int.Parse(mySqlDataReader.GetString(tableColumn)));
                    mySqlDataReader.GetValues()
                }
                mySqlDataReader.Close();
            }
            myConnection.Close();
            return nums;
        }

        private List<string> ReturnStringList(List<string> qStrings, string tableColumn)
        {
            List<string> strs = new List<string>();
            myConnection.Open();
            foreach (string qString in qStrings)
            {
                myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
                MySqlDataReader mySqlDataReader = myCommand.ExecuteReader();
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
            myConnection.Close();
            return strs;
        }

        private List<int?> ReturnIntNList(List<string> qStrings, string tableColumn)
        {
            List<int?> nullables = new List<int?>();
            myConnection.Open();
            foreach (string qString in qStrings)
            {
                myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
                MySqlDataReader mySqlDataReader = myCommand.ExecuteReader();
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
            myConnection.Close();
            return nullables;
        }

        private List<DateTime> ReturnDateList(List<string> qStrings, string tableColumn)
        {
            List<DateTime> dateTimes = new List<DateTime>();
            myConnection.Open();
            foreach (string qString in qStrings)
            {
                myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
                MySqlDataReader mySqlDataReader = myCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    dateTimes.Add(DateTime.Parse(mySqlDataReader.GetString(tableColumn)));
                }
                mySqlDataReader.Close();
            }
            myConnection.Close();
            return dateTimes;
        }

        private List<double> ReturnDoubleList(List<string> qStrings, string tableColumn)
        {
            List<double> nums = new List<double>();
            myConnection.Open();
            foreach (string qString in qStrings)
            {
                myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
                MySqlDataReader mySqlDataReader = myCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    nums.Add(double.Parse(mySqlDataReader.GetString(tableColumn)));
                }
                mySqlDataReader.Close();
            }
            myConnection.Close();
            return nums;
        }

        private List<DateTime?> ReturnDateNList(List<string> qStrings, string tableColumn)
        {
            List<DateTime?> nullables = new List<DateTime?>();
            myConnection.Open();
            foreach (string qString in qStrings)
            {
                myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
                MySqlDataReader mySqlDataReader = myCommand.ExecuteReader();
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
            myConnection.Close();
            return nullables;
        }

        /*public List<Entry> Entries(string table, List<int> entry_ids)
        {
            List<Entry> entries = new List<Entry>();
            List<string> strs = new List<string>();
            List<int> entryIds = entry_ids;
            List<int> nums = ReturnIntList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_User_Id);
            List<string> strs1 = ReturnStringList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_User_Name);
            List<int?> nullables = ReturnIntNList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Section_Id);
            List<string> strs2 = ReturnStringList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Project_Serial);
            List<string> strs3 = ReturnStringList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Project_Sap);
            List<string> strs4 = ReturnStringList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Number_Section);
            List<int?> nullables1 = ReturnIntNList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Number_Network);
            List<string> strs5 = ReturnStringList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Number_Activity);
            List<DateTime> dateTimes = ReturnDateList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Date);
            List<int> nums1 = ReturnIntList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Period);
            List<int> nums2 = ReturnIntList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Year);
            List<double> nums3 = ReturnDoubleList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Hours);
            List<string> strs6 = ReturnStringList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Description);
            List<string> strs7 = ReturnStringList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Timesheet_Code);
            List<string> strs8 = ReturnStringList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Task_Type);
            List<string> strs9 = ReturnStringList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Submitted_Status);
            List<string> strs10 = ReturnStringList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Approval_Status);
            List<string> strs11 = ReturnStringList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Rejection_Reason);
            List<int?> nullables2 = ReturnIntNList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Approved_By_User_Id);
            List<string> strs12 = ReturnStringList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Approved_By_User_Name);
            List<DateTime> dateTimes1 = ReturnDateList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Date_Created);
            List<DateTime> dateTimes2 = ReturnDateList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Date_Modified);
            List<DateTime?> nullables3 = ReturnDateNList(Entry_QStrings_FromEntryId(table, entry_ids), t_Timesheet_c_Date_Approved);
            for (int i = 0; i < entry_ids.Count; i++)
            {
                entries.Add(new Entry(new int?(entryIds[i]), nums[i], strs1[i], nullables[i], strs2[i], strs3[i], strs4[i], nullables1[i], strs5[i], dateTimes[i], nums1[i], nums2[i], nums3[i], strs6[i], strs7[i], strs8[i], strs9[i], functions.approvalStatus(strs10[i]), strs11[i], nullables2[i], strs12[i], dateTimes1[i], dateTimes2[i], nullables3[i]));
            }
            return entries;
        }

		// public Entry(, , , , , , , , , 
        // , , , , , , string task_type, string submitted_status, ApprovalStatus approval_status, string rejection_reason, 
        // int? approved_by_user_id, string approved_by_user_name, DateTime date_created, DateTime date_modified, DateTime? date_approved)
        
        public List<Entry> Entries(List<string> qStrings)
        {
            List<Entry> entries = new List<Entry>();

            foreach(String qString in qStrings)
            {
                int dummy;
                DateTime dummy2;
                myCommand = new MySqlCommand(qString, myConnection.MySqlConnection);
                MySqlDataReader reader = myCommand.ExecuteReader();
                while(reader.Read())
                {
                    entries.Add(new Entry(
                        int.Parse(reader.GetString(0)), // entry_id
                        int.Parse(reader.GetString(1)), // user_id
                        reader.GetString(2), // user_name
                        int.TryParse(reader.GetString(3), out dummy) ? new int?(int.Parse(reader.GetString(3))) : null, // section_id
                        reader.GetString(4), // project_serial
                        reader.GetString(5), // project_sap
                        reader.GetString(6), // number_section
                        int.TryParse(reader.GetString(7), out dummy) ? new int?(int.Parse(reader.GetString(7))) : null, // number_network
                        reader.GetString(8), // number_activity
                        DateTime.Parse(reader.GetString(9)), // date
                        int.Parse(reader.GetString(10)), // period
                        int.Parse(reader.GetString(11)), // year
                        double.Parse(reader.GetString(12)), // hours
                        reader.GetString(13), // description
                        reader.GetString(14), // timesheet_code
                        reader.GetString(15), // task_type
                        reader.GetString(16), // submitted_status
                        functions.approvalStatus(reader.GetString(17)), // approval_status
                        reader.GetString(18), // rejection_reason
                        int.TryParse(reader.GetString(19), out dummy) ? new int?(int.Parse(reader.GetString(18))) : null, // approved_by_user_id
                        reader.GetString(20), // approved_by_user_name
                        DateTime.Parse(reader.GetString(21)), // date_created
                        DateTime.Parse(reader.GetString(22)), // date_modified
                        DateTime.TryParse(reader.GetString(23), out dummy2) ? new DateTime?(DateTime.Parse(reader.GetString(22))) : null // date_approved
                    ));
                }
            }

            return entries;
        }*/
    }
}
