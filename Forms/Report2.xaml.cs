using FivesBronxTimesheetManagement.Classes;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Markup;

namespace FivesBronxTimesheetManagement.Forms
{
    public partial class Report2 : Window
    {
        private Queries queries;

        private Functions functions;

        private List<User> users;

        private List<User> selectedUsers;

        private List<string> availableTables;

        private List<string> selectedTables;

        private ExportToExcel<Entry, List<Entry>> export;

        private User user;

        public Report2(User User)
        {
            this.InitializeComponent();
            this.user = User;
            this.queries = new Queries();
            this.functions = new Functions();
            this.LoadConstantsFromDb();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            base.Close();
        }

        private void btn_generate_Click(object sender, RoutedEventArgs e)
        {
            this.export = new ExportToExcel<Entry, List<Entry>>()
            {
                // data to print here
            };
            this.export.GenerateReport();
        }

        private void section_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }


    }
}
