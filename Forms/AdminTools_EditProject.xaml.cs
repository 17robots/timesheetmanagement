using FivesBronxTimesheetManagement.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class AdminTools_EditProject : Window
	{
		private Queries2 queries = new Queries2();

		private List<TaskType> allTaskTypes;

		private List<TaskType> usedTaskTypes;

		private List<TaskType> unusedTaskTypes;

		private List<Section> reducedSections;

		public AdminTools_EditProject()
		{
			InitializeComponent();
			cbxSerialNumber.ItemsSource = queries.ProjectAll();
			allTaskTypes = queries.TaskTypesAll();
			cbxSerialNumber.DisplayMemberPath = "Serial_Customer_Machine";
			lbxSections_TaskTypes_ActNumber.DisplayMemberPath = "ActNum_Id";
			lbxSections_TaskTypes_Unused.DisplayMemberPath = "Id";
		}

		private void btnAddSection_Click(object sender, RoutedEventArgs e)
		{
			(new AdminTools_EditProject_NewSection(this, (Project)cbxSerialNumber.SelectedItem)).Show();
		}

		private void btnAddTaskType_Click(object sender, RoutedEventArgs e)
		{
		}

		private void btnRemoveTaskType_Click(object sender, RoutedEventArgs e)
		{
		}

		private void cbxSerialNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			RefreshScreen(cbxSerialNumber.SelectedItem as Project);
		}

		private void lbxSections_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			RefreshListBox_TaskTypes();
		}

		public void RefreshListBox_Sections(Project project)
		{
			List<Section> sections = queries.Sections(project.Number_Network);
			reducedSections = new List<Section>();
			foreach (Section section in sections)
			{
				if (!reducedSections.Any<Section>((Section X) => X.Number_Section == section.Number_Section))
				{
					reducedSections.Add(section);
				}
			}
			lbxSections.ItemsSource = reducedSections;
		}

		public void RefreshListBox_TaskTypes()
		{
			unusedTaskTypes = allTaskTypes;
			usedTaskTypes = new List<TaskType>();
			if (lbxSections.SelectedItem != null)
			{
				Section selectedItem = lbxSections.SelectedItem as Section;
				foreach (TaskType taskType in queries.TaskTypes(selectedItem))
				{
					usedTaskTypes.Add(taskType);
					unusedTaskTypes = (
						from X in unusedTaskTypes
						where X.Id != taskType.Id
						select X).ToList<TaskType>();
				}
			}
			else
			{
				usedTaskTypes = null;
			}
			lbxSections_TaskTypes_ActNumber.ItemsSource = usedTaskTypes;
			lbxSections_TaskTypes_Unused.ItemsSource = unusedTaskTypes;
		}

		public void RefreshScreen(Project project)
		{
			RefreshListBox_Sections(project);
		}
	}
}