using FivesBronxTimesheetManagement.Classes;
using System;
using System.CodeDom.Compiler;
using System.Collections;
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
	public partial class User_ApprovalHierarchy : Window
	{
		private Queries2 queries = new Queries2();

		private List<User> allApprovers;

		private List<User> allUsers;

		// private List<User> approvees;

		private Functions functions = new Functions();

		public User_ApprovalHierarchy()
		{
			this.InitializeComponent();
			this.allApprovers = (
				from X in this.queries.GetUser_All()
				where this.functions.IntToBool(X.IsValidator)
				where this.functions.IntToBool(X.IsActive)
				orderby X.UserName
				select X).ToList();
			this.allUsers = (
				from X in this.queries.GetUser_All()
				where this.functions.IntToBool(X.IsActive)
				orderby X.UserName
				select X).ToList();
			this.lbxApproverApprovee_Box1.DisplayMemberPath = "UserName";
			this.lbxApproverApprovee_Box2.DisplayMemberPath = "UserName";
			this.lbxApproverApprovee_Box3.DisplayMemberPath = "UserName";
			this.RefreshScreen();
		}

		private void btnAddApprovee_Click(object sender, RoutedEventArgs e)
		{
			User selectedItem = (User)this.lbxApproverApprovee_Box1.SelectedItem;
			foreach (User user in this.lbxApproverApprovee_Box3.SelectedItems)
			{
				this.queries.User_AddApprovee(selectedItem, user);
			}
			this.RefreshScreen();
		}

		/* private void btnApproveeApprover_Click(object sender, RoutedEventArgs e)
		{
			this.stkApproverApprovee.Visibility = System.Windows.Visibility.Collapsed;
		}

		private void btnApproverApprovee_Click(object sender, RoutedEventArgs e)
		{
			this.stkApproverApprovee.Visibility = System.Windows.Visibility.Visible;
		} */ 

		private void btnRemoveApprovee_Click(object sender, RoutedEventArgs e)
		{
			User selectedItem = (User)this.lbxApproverApprovee_Box1.SelectedItem;
			foreach (User user in this.lbxApproverApprovee_Box2.SelectedItems)
			{
				this.queries.User_RemoveApprovee(selectedItem, user);
			}
			this.RefreshScreen();
		}

		private void lbxApproverApprovee_Box1_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.RefreshApproverApproveeBoxes();
		}

		private void RefreshApproverApproveeBoxes()
		{
			User selectedApprover = (User)this.lbxApproverApprovee_Box1.SelectedItem;
			List<User> localApprovees = this.queries.User_GetApprovees(selectedApprover);
			this.lbxApproverApprovee_Box2.ItemsSource = (
				from X in localApprovees
				where this.functions.IntToBool(X.IsActive)
				orderby X.UserName
				select X).ToList<User>();

			List<User> users = new List<User>();
			foreach (User allUser in allUsers)
			{
				if(allUser.UserID != selectedApprover.UserID && localApprovees.IndexOf(allUser) == -1)
                {
					users.Add(allUser);
                }
			}

			lbxApproverApprovee_Box3.ItemsSource = users;
		}

		private void RefreshScreen()
		{
			this.lbxApproverApprovee_Box1.ItemsSource = this.allApprovers;
			if (this.lbxApproverApprovee_Box1.SelectedItem != null)
			{
				this.RefreshApproverApproveeBoxes();
			}
		}
	}
}