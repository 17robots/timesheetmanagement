using FivesBronxTimesheetManagement.Classes;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class AdminTools_EditProject_NewSection : Window
	{
		private AdminTools_EditProject parent;

		private Project project;

		private Queries queries = new Queries();

		private Functions functions = new Functions();

		public AdminTools_EditProject_NewSection(AdminTools_EditProject parent, Project project)
		{
			this.InitializeComponent();
			this.parent = parent;
			this.project = project;
			this.cbxTaskType.DisplayMemberPath = "Id";
			this.RefreshScreen();
		}

		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			int numberWarrantyNetwork;
			if (string.IsNullOrEmpty(this.txtSection.Text))
			{
				MessageBox.Show("Must Have Section Number");
			}
			else if (string.IsNullOrEmpty(this.txtSectionDescription.Text))
			{
				MessageBox.Show("Must Have Section Description");
			}
			else if (this.cbxTaskType.SelectedItem == null)
			{
				MessageBox.Show("Must Select A Task Type");
			}
			else if ((!this.functions.IsNumeric(this.txtActivity.Text) ? false : this.txtActivity.Text.Length == 4))
			{
				Section section = new Section();
				if (this.chbxWarranty.IsChecked.Value)
				{
					numberWarrantyNetwork = this.project.Number_WarrantyNetwork;
					section.Number_ProjectNetwork = numberWarrantyNetwork.ToString();
				}
				else
				{
					numberWarrantyNetwork = this.project.Number_Network;
					section.Number_ProjectNetwork = numberWarrantyNetwork.ToString();
				}
				section.Number_Section = this.txtSection.Text;
				section.Description_Section = this.txtSectionDescription.Text;
				section.TaskType = ((TaskType)this.cbxTaskType.SelectedItem).Id;
				section.Number_Activity = this.txtActivity.Text;
				section.Description_Activity = ((TaskType)this.cbxTaskType.SelectedItem).Description;
				this.queries.CreateSection(section);
				this.parent.RefreshListBox_Sections(this.project);
			}
			else
			{
				MessageBox.Show("Must be numeric: 4 digits, no commas, preceding zeros");
			}
		}

		public void RefreshScreen()
		{
			this.lblProject.Content = this.project.Serial_Customer_Machine;
			this.cbxTaskType.ItemsSource = this.queries.TaskTypesAll();
		}
	}
}