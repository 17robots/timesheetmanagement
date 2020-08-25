using FivesBronxTimesheetManagement.Classes;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class AdminTools_EditProject : Window
	{
		//private Queries queries = new Queries();
		private Queries2 queries = new Queries2();

		private Functions functions = new Functions();

		private Section section = new Section();

		private List<TaskType> allTaskTypes;

		private List<TaskType> usedTaskTypes;

		private List<TaskType> unusedTaskTypes;

		private List<Section> reducedSections;

		public AdminTools_EditProject()
		{
			this.InitializeComponent();
			this.cbxSerialNumber.ItemsSource = this.queries.ProjectAll();
			this.allTaskTypes = this.queries.TaskTypesAll();
			this.cbxSerialNumber.DisplayMemberPath = "Serial_Customer_Machine";
			this.lbxSections_TaskTypes_ActNumber.DisplayMemberPath = "ActNum_Id";
			this.lbxSections_TaskTypes_Unused.DisplayMemberPath = "Id";
		}

		private void btnAddSection_Click(object sender, RoutedEventArgs e)
		{
			(new AdminTools_EditProject_NewSection(this, (Project)this.cbxSerialNumber.SelectedItem)).Show();
		}

		private void btnAddTaskType_Click(object sender, RoutedEventArgs e)
		{
		}

		private void btnRemoveTaskType_Click(object sender, RoutedEventArgs e)
		{
		}

		private void cbxSerialNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.RefreshScreen(this.cbxSerialNumber.SelectedItem as Project);
		}

		private void lbxSections_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.RefreshListBox_TaskTypes();
		}

		public void RefreshListBox_Sections(Project project)
		{
			List<Section> sections = this.queries.Sections(project.Number_Network);
			this.reducedSections = new List<Section>();
			foreach (Section section in sections)
			{
				if (!this.reducedSections.Any<Section>((Section X) => X.Number_Section == section.Number_Section))
				{
					this.reducedSections.Add(section);
				}
			}
			this.lbxSections.ItemsSource = this.reducedSections;
		}

		public void RefreshListBox_TaskTypes()
		{
			this.unusedTaskTypes = this.allTaskTypes;
			this.usedTaskTypes = new List<TaskType>();
			if (this.lbxSections.SelectedItem != null)
			{
				Section selectedItem = this.lbxSections.SelectedItem as Section;
				foreach (TaskType taskType in this.queries.TaskTypes(selectedItem))
				{
					this.usedTaskTypes.Add(taskType);
					this.unusedTaskTypes = (
						from X in this.unusedTaskTypes
						where X.Id != taskType.Id
						select X).ToList<TaskType>();
				}
			}
			else
			{
				this.usedTaskTypes = null;
			}
			this.lbxSections_TaskTypes_ActNumber.ItemsSource = this.usedTaskTypes;
			this.lbxSections_TaskTypes_Unused.ItemsSource = this.unusedTaskTypes;
		}

		public void RefreshScreen(Project project)
		{
			this.RefreshListBox_Sections(project);
		}
	}
}