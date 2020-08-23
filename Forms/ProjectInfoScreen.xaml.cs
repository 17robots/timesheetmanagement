using FivesBronxTimesheetManagement.Classes;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class ProjectInfoScreen : Window
	{
		private Connection myConnection;

		//private Queries queries = new Queries();
		private Queries2 queries;

		public ProjectInfoScreen()
		{
			this.InitializeComponent();
			this.myConnection = new Connection();
			this.queries = new Queries2();
			this.LoadConstantsFromDb();
		}

		private void cbxProjectNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Project project = queries.Project(cbxProjectNumber.SelectedItem.ToString());
			this.lblBFCReference.Content = project.Number_BFC;
			this.lblIsInWarranty.Content = project.IsWarrantyOpen;
			this.lblMAS90Reference.Content = project.Number_MAS90;
			this.lblProjectEquipment.Content = project.Machine;
			this.lblProjectName.Content = project.Customer;
			this.lblSAPReference.Content = project.Number_SAP;
			this.dgSections.DataContext = null;
			/*
			this.lblBFCReference.Content = this.queries.ProjectNumber_BFC(this.cbxProjectNumber.SelectedItem.ToString());
			this.lblIsInWarranty.Content = this.queries.ProjectIsWarrantyOpen(this.cbxProjectNumber.SelectedItem.ToString());
			this.lblMAS90Reference.Content = this.queries.ProjectNumber_MAS90(this.cbxProjectNumber.SelectedItem.ToString());
			this.lblProjectEquipment.Content = this.queries.ProjectMachine(this.cbxProjectNumber.SelectedItem.ToString());
			this.lblProjectName.Content = this.queries.ProjectName(this.cbxProjectNumber.SelectedItem.ToString());
			this.lblSAPReference.Content = this.queries.ProjectNumber_SAP(this.cbxProjectNumber.SelectedItem.ToString());
			this.dgSections.DataContext = null;
			*/
			string[] tSectionsCNumberSection = new string[] { "SELECT ", this.queries.t_Sections_c_Number_Section, ", ", this.queries.t_Sections_c_Description_Section, ", ", this.queries.t_Sections_c_Number_Activity, ", ", this.queries.t_Sections_c_Description_Activity, " FROM ", this.queries.t_Sections, " WHERE ", this.queries.t_Sections_c_Number_Project_Network, "= '", this.queries.ProjectNumber_Network(this.cbxProjectNumber.SelectedItem.ToString()), "'" };
			string str = string.Concat(tSectionsCNumberSection);
			MySqlCommand mySqlCommand = new MySqlCommand(str, this.myConnection.MySqlConnection);
			MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
			DataSet dataSet = new DataSet();
			mySqlDataAdapter.Fill(dataSet, "LoadDataBinding");
			this.dgSections.DataContext = dataSet;
		}

		public void LoadConstantsFromDb()
		{
			foreach (string str in this.queries.Projects())
			{
				this.cbxProjectNumber.Items.Add(str);
			}
		}
	}
}