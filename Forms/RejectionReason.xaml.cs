using FivesBronxTimesheetManagement.Classes;
using System.Reflection;
using System.Windows;
using System;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class RejectionReason : Window
	{
        public Tuple<bool, string> result; // returns whether the cancel button was clicked and what the string is
        private string holderString = "";

		public RejectionReason()
		{
			InitializeComponent();
		}

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            if(duplicate.IsChecked ?? false)
            {
                holderString = "Duplicate Entry. Do not resubmit.";
                result = new Tuple<bool, string>(true, "Duplicate Entry. Do not resubmit.");
                Close();
            } else if (overHours.IsChecked ?? false)
            {
                holderString = "Entry Over Normal Number Of Hours. Please Edit And Resubmit.";
            }
            else if (incorrectValues.IsChecked ?? false)
            {
                holderString = "Incorrect Input Value. Please Edit And Resubmit";
            }
            else if (somethingElse.IsChecked ?? false)
            {
                holderString = "Incorrect Date. Please Edit and Resubmit";
            } else if (other.IsChecked ?? false)
            {
                if(otherReason.Text == "")
                {
                    MessageBox.Show("Other Reason Cannot Be Empty");
                    holderString = "";
                    return;
                } else if(otherReason.Text.Length > 255)
                {
                    MessageBox.Show("Other Reason Cannot Be More Than 255 Characters");
                    holderString = "";
                    return;
                }
                else
                {
                    holderString = otherReason.Text;
                }
            } else
            {
                MessageBox.Show("Please Select A Rejection Reason");
                return;
            }

            result = new Tuple<bool, string>(true, holderString);
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            result = new Tuple<bool, string>(false, "");
            Close();
        }
    }
}