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
	public partial class AdminTools_CreateProject : Window
	{
		private Queries queries = new Queries();

		private Functions functions = new Functions();

		public AdminTools_CreateProject()
		{
			this.InitializeComponent();
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		private void btnCreate_Click(object sender, RoutedEventArgs e)
		{
			if (this.IsValidData())
			{
				try
				{
					this.queries.CreateProject(this.CreateProject());
				}
				catch (Exception exception)
				{
					MessageBox.Show(exception.ToString());
				}
			}
		}

		private Project CreateProject()
		{
			Project project = new Project()
			{
				Country = this.txtCountry.Text,
				Customer = this.txtCustomer.Text
			};
			Functions function = this.functions;
			bool? isChecked = this.ckbxIsOpen.IsChecked;
			project.IsOpen = function.BoolToInt(isChecked.Value);
			Functions function1 = this.functions;
			isChecked = this.ckbxIsWarrantyOpen.IsChecked;
			project.IsWarrantyOpen = function1.BoolToInt(isChecked.Value);
			project.Machine = this.txtMachine.Text;
			project.Number_BFC = this.txtBFCNumber.Text;
			project.Number_MAS90 = this.txtSAPNumber.Text;
			project.Number_Network = int.Parse(this.txtNetworkNumber.Text);
			project.Number_SAP = this.txtSAPNumber.Text;
			project.Number_Serial = this.txtSerialNumber.Text;
            // if (string.IsNullOrEmpty(this.txtWarrantyNetworkNumber.Text)) {
            //     project.Number_WarrantyNetwork = 0;
            // } else {
            //    project.Number_WarrantyNetwork = int.Parse(this.txtWarrantyNetworkNumber.Text);
            // }
            project.Number_WarrantyNetwork = int.Parse(this.txtWarrantyNetworkNumber.Text);
			return project;
		}

		private bool IsValidData()
		{
            // refactor so no use of flag variable and just make it easier to look at and make it prettier
			bool flag;
			if (string.IsNullOrEmpty(this.txtBFCNumber.Text))
			{
				MessageBox.Show("Invalid Data, Must have BFC Number");
				flag = false;
			}
			else if (string.IsNullOrEmpty(this.txtCountry.Text))
			{
				MessageBox.Show("Invalid Data, Must have Country");
				flag = false;
			}
			else if (string.IsNullOrEmpty(this.txtCustomer.Text))
			{
				MessageBox.Show("Invalid Data, Must have Customer");
				flag = false;
			}
			else if (string.IsNullOrEmpty(this.txtMachine.Text))
			{
				MessageBox.Show("Invalid Data, Must have Machine Description");
				flag = false;
			}
			else if (!(string.IsNullOrEmpty(this.txtNetworkNumber.Text) ? false : this.functions.IsNumeric(this.txtNetworkNumber.Text)))
			{
				MessageBox.Show("Invalid Data, Must have Network Number that is an integer value (Number with no decimal places)");
				flag = false;
			}
			else if (string.IsNullOrEmpty(this.txtSAPNumber.Text))
			{
				MessageBox.Show("Invalid Data, Must have SAP Number");
				flag = false;
			}
			else if (string.IsNullOrEmpty(this.txtSerialNumber.Text))
			{
				MessageBox.Show("Invalid Data, Must have Engineering Serial Number");
				flag = false;
			}
			else if ((string.IsNullOrEmpty(this.txtWarrantyNetworkNumber.Text) ? false : this.functions.IsNumeric(this.txtWarrantyNetworkNumber.Text)))
			{
				flag = true;
			}
            // remove this
			else
			{
				MessageBox.Show("Invalid Data, Must have Warranty Network Number.  If no Warranty, use the standard Network Number");
				flag = false;
			}
			return flag;

            // else if (this.functions.IsNumeric(this.txtWarrantyNetworkNumber.Text)) {
            //     MessageBox.Show("Invalid Data, Warranty Must Be A Number Or Must Be Left Blank");
            //     flag = false;
            // }
        }
    }
}