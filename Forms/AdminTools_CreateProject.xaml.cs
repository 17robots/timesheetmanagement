using FivesBronxTimesheetManagement.Classes;
using System;
using System.Windows;

namespace FivesBronxTimesheetManagement.Forms
{
    public partial class AdminTools_CreateProject : Window {
		private Queries2 queries = new Queries2();

		private Functions functions = new Functions();

		public AdminTools_CreateProject() {
			InitializeComponent();
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Close();
		}

		private void btnCreate_Click(object sender, RoutedEventArgs e) {
			if (IsValidData())
			{
				try
				{
					queries.CreateProject(CreateProject());
				}
				catch (Exception exception)
				{
					MessageBox.Show(exception.ToString());
				}
			}
		}

		private Project CreateProject() {
			Project project = new Project() {
				Country = txtCountry.Text,
				Customer = txtCustomer.Text
			};
			Functions function = functions;
			bool? isChecked = ckbxIsOpen.IsChecked;
			project.IsOpen = function.BoolToInt(isChecked.Value);
			Functions function1 = functions;
			isChecked = ckbxIsWarrantyOpen.IsChecked;
			project.IsWarrantyOpen = function1.BoolToInt(isChecked.Value);
			project.Machine = txtMachine.Text;
			project.Number_BFC = txtBFCNumber.Text;
			project.Number_MAS90 = txtSAPNumber.Text;
			project.Number_Network = int.Parse(txtNetworkNumber.Text);
			project.Number_SAP = txtSAPNumber.Text;
			project.Number_Serial = txtSerialNumber.Text;
            if (string.IsNullOrEmpty(txtWarrantyNetworkNumber.Text)) {
                project.Number_WarrantyNetwork = 0;
            } else {
                project.Number_WarrantyNetwork = int.Parse(txtWarrantyNetworkNumber.Text);
            }
			return project;
		}

		private bool IsValidData() { 

            if (string.IsNullOrEmpty(txtSerialNumber.Text)) {
                MessageBox.Show("Error Creating Project: Engineering Serial Number Cannot Be Blank");
                return false;
            }
            else if (string.IsNullOrEmpty(txtSAPNumber.Text)) {
                MessageBox.Show("Error Creating Project: SAP Number Cannot Be Blank");
                return false;
            }
            else if (string.IsNullOrEmpty(txtBFCNumber.Text)) {
				MessageBox.Show("Error Creating Project: BFC Number Cannot Be Blank");
                return false;
			}
            else if (!(string.IsNullOrEmpty(txtNetworkNumber.Text) ? false : functions.IsNumeric(txtNetworkNumber.Text))) {
                MessageBox.Show("Error Creating Project: Network Number Cannot Be Blank And Must Be An Integer (Number with no decimal places)");
                return false;
            }
            else if (string.IsNullOrEmpty(txtCustomer.Text)) {
                MessageBox.Show("Error Creating Project: Customer Cannot Be Blank");
                return false;
            }
            else if (string.IsNullOrEmpty(txtMachine.Text)) {
                MessageBox.Show("Error Creating Project: Description Cannot Be Blank");
                return false;
            }
            else if (string.IsNullOrEmpty(txtCountry.Text)) {
				MessageBox.Show("Error Creating Project: Country Cannot Be Blank");
                return false;
			}
			else if ((string.IsNullOrEmpty(txtWarrantyNetworkNumber.Text) ? false : functions.IsNumeric(txtWarrantyNetworkNumber.Text))) {
                return true;
			}
            else if(string.IsNullOrEmpty(txtWarrantyNetworkNumber.Text)) {
                return true;
            }
            else if (!functions.IsNumeric(txtWarrantyNetworkNumber.Text)) {
                MessageBox.Show("Error Creating Project: Warranty Must Be A Number Or Must Be Left Blank");
                return false;
            }
            return false;
        }
    }
}