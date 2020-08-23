using FivesBronxTimesheetManagement.Classes;
using System;
using System.Windows;

namespace FivesBronxTimesheetManagement.Forms
{
    public partial class AdminTools_CreateProject : Window {
		//private Queries queries = new Queries();
		private Queries2 queries = new Queries2();

		private Functions functions = new Functions();

		public AdminTools_CreateProject() {
			InitializeComponent();
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Close();
		}

		private void btnCreate_Click(object sender, RoutedEventArgs e) {
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

		private Project CreateProject() {
			Project project = new Project() {
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
            if (string.IsNullOrEmpty(this.txtWarrantyNetworkNumber.Text)) {
                project.Number_WarrantyNetwork = 0;
            } else {
                project.Number_WarrantyNetwork = int.Parse(this.txtWarrantyNetworkNumber.Text);
            }
			return project;
		}

		private bool IsValidData() { 

            if (string.IsNullOrEmpty(this.txtSerialNumber.Text)) {
                MessageBox.Show("Error Creating Project: Engineering Serial Number Cannot Be Blank");
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtSAPNumber.Text)) {
                MessageBox.Show("Error Creating Project: SAP Number Cannot Be Blank");
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtBFCNumber.Text)) {
				MessageBox.Show("Error Creating Project: BFC Number Cannot Be Blank");
                return false;
			}
            else if (!(string.IsNullOrEmpty(this.txtNetworkNumber.Text) ? false : this.functions.IsNumeric(this.txtNetworkNumber.Text))) {
                MessageBox.Show("Error Creating Project: Network Number Cannot Be Blank And Must Be An Integer (Number with no decimal places)");
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtCustomer.Text)) {
                MessageBox.Show("Error Creating Project: Customer Cannot Be Blank");
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtMachine.Text)) {
                MessageBox.Show("Error Creating Project: Description Cannot Be Blank");
                return false;
            }
            else if (string.IsNullOrEmpty(this.txtCountry.Text)) {
				MessageBox.Show("Error Creating Project: Country Cannot Be Blank");
                return false;
			}
			else if ((string.IsNullOrEmpty(this.txtWarrantyNetworkNumber.Text) ? false : this.functions.IsNumeric(this.txtWarrantyNetworkNumber.Text))) {
                return true;
			}
            else if(string.IsNullOrEmpty(this.txtWarrantyNetworkNumber.Text)) {
                return true;
            }
            else if (!this.functions.IsNumeric(this.txtWarrantyNetworkNumber.Text)) {
                MessageBox.Show("Error Creating Project: Warranty Must Be A Number Or Must Be Left Blank");
                return false;
            }
            return false;
        }
    }
}