using FivesBronxTimesheetManagement.Classes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class ProjectInfoScreen : Window
	{
		private Connection myConnection;

		private Queries2 queries;

		public ProjectInfoScreen()
		{
			InitializeComponent();
			myConnection = new Connection();
			queries = new Queries2();
			LoadConstantsFromDb();
		}

		private void cbxProjectNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Project project = queries.Project(cbxProjectNumber.SelectedItem.ToString());
			lblBFCReference.Content = project.Number_BFC;
			lblIsInWarranty.Content = project.IsWarrantyOpen;
			lblMAS90Reference.Content = project.Number_MAS90;
			lblProjectEquipment.Content = project.Machine;
			lblProjectName.Content = project.Customer;
			lblSAPReference.Content = project.Number_SAP;
			dgSections.DataContext = null;
			string[] tSectionsCNumberSection = new string[] { "SELECT ", queries.t_Sections_c_Number_Section, ", ", queries.t_Sections_c_Description_Section, ", ", queries.t_Sections_c_Number_Activity, ", ", queries.t_Sections_c_Description_Activity, " FROM ", queries.t_Sections, " WHERE ", queries.t_Sections_c_Number_Project_Network, "= '", queries.ProjectNumber_Network(cbxProjectNumber.SelectedItem.ToString()), "'" };
			string str = string.Concat(tSectionsCNumberSection);
			MySqlCommand mySqlCommand = new MySqlCommand(str, myConnection.MySqlConnection);
			MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
			DataSet dataSet = new DataSet();
			mySqlDataAdapter.Fill(dataSet, "LoadDataBinding");
			dgSections.DataContext = dataSet;
		}

		public void LoadConstantsFromDb()
		{
			foreach (string str in queries.Projects())
			{
				cbxProjectNumber.Items.Add(str);
			}
		}
	}
}