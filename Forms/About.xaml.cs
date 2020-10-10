using System.Reflection;
using System.Windows;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class About : Window
	{
		public About()
		{
			InitializeComponent();
			lblVersion.Content = string.Concat("    ", Assembly.GetExecutingAssembly().GetName().Version.ToString());
		}
	}
}