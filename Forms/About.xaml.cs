using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace FivesBronxTimesheetManagement.Forms
{
	public partial class About : Window
	{
		public About()
		{
			this.InitializeComponent();
			this.lblVersion.Content = string.Concat("    ", Assembly.GetExecutingAssembly().GetName().Version.ToString());
		}
	}
}