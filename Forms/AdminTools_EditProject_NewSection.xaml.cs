using FivesBronxTimesheetManagement.Classes;
using System.Windows;


namespace FivesBronxTimesheetManagement.Forms
{
	public partial class AdminTools_EditProject_NewSection : Window
	{
		private AdminTools_EditProject parent;

		private readonly Project project;

		private readonly Queries2 queries = new Queries2();

		private readonly Functions functions = new Functions();

		public AdminTools_EditProject_NewSection(AdminTools_EditProject parent, Project project)
		{
			InitializeComponent();
			this.parent = parent;
			this.project = project;
			cbxTaskType.DisplayMemberPath = "Id";
			RefreshScreen();
		}

		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			int numberWarrantyNetwork;
			if (string.IsNullOrEmpty(txtSection.Text))
			{
				MessageBox.Show("Must Have Section Number");
			}
			else if (string.IsNullOrEmpty(txtSectionDescription.Text))
			{
				MessageBox.Show("Must Have Section Description");
			}
			else if (cbxTaskType.SelectedItem == null)
			{
				MessageBox.Show("Must Select A Task Type");
			}
			else if ((!functions.IsNumeric(txtActivity.Text) ? false : txtActivity.Text.Length == 4))
			{
				Section section = new Section();
				if (chbxWarranty.IsChecked.Value)
				{
					numberWarrantyNetwork = project.Number_WarrantyNetwork;
					section.Number_ProjectNetwork = numberWarrantyNetwork.ToString();
				}
				else
				{
					numberWarrantyNetwork = project.Number_Network;
					section.Number_ProjectNetwork = numberWarrantyNetwork.ToString();
				}
				section.Number_Section = txtSection.Text;
				section.Description_Section = txtSectionDescription.Text;
				section.TaskType = ((TaskType)cbxTaskType.SelectedItem).Id;
				section.Number_Activity = txtActivity.Text;
				section.Description_Activity = ((TaskType)cbxTaskType.SelectedItem).Description;
				queries.CreateSection(section);
				parent.RefreshListBox_Sections(project);
			}
			else
			{
				MessageBox.Show("Must be numeric: 4 digits, no commas, preceding zeros");
			}
		}

		public void RefreshScreen()
		{
			lblProject.Content = project.Serial_Customer_Machine;
			cbxTaskType.ItemsSource = queries.TaskTypesAll();
		}
	}
}