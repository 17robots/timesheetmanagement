using System;
using System.Runtime.CompilerServices;

namespace FivesBronxTimesheetManagement.Classes
{
	public class Project
	{
		//private Queries queries = new Queries();
		private Queries2 queries = new Queries2();

		private Functions functions = new Functions();

		public string Country
		{
			get;
			set;
		}

		public string Customer
		{
			get;
			set;
		}

		public int IsOpen
		{
			get;
			set;
		}

		public int IsWarrantyOpen
		{
			get;
			set;
		}

		public string Machine
		{
			get;
			set;
		}

		public string Number_BFC
		{
			get;
			set;
		}

		public string Number_MAS90
		{
			get;
			set;
		}

		public int Number_Network
		{
			get;
			set;
		}

		public string Number_SAP
		{
			get;
			set;
		}

		public string Number_Serial
		{
			get;
			set;
		}

		public int Number_WarrantyNetwork
		{
			get;
			set;
		}

		public string Serial_Customer_Machine
		{
			get
			{
				string[] numberSerial = new string[] { this.Number_Serial, "-", this.Customer, "-", this.Machine };
				return string.Concat(numberSerial);
			}
		}

		public Project()
		{
			this.Number_Serial = "";
			this.Number_SAP = "";
			this.Number_MAS90 = "";
			this.Number_BFC = "";
			this.Number_Network = 0;
			this.Customer = "";
			this.Machine = "";
			this.Country = "";
			this.IsOpen = 0;
			this.IsWarrantyOpen = 0;
			this.Number_WarrantyNetwork = 0;
		}

		public Project(string numberSerial, string numberSAP, string numberMAS90, string numberBFC, int numberNetwork, 
			string customer, string machine, string country, int isOpen, int isWarrantyOpen, int numberWarrantyNetwork)
        {
			Country = country;
			Customer = customer;
			IsOpen = isOpen;
			IsWarrantyOpen = isWarrantyOpen;
			Machine = machine;
			Number_BFC = numberBFC;
			Number_MAS90 = numberMAS90;
			Number_Network = numberNetwork;
			Number_SAP = numberSAP;
			Number_Serial = numberSerial;
			Number_WarrantyNetwork = numberWarrantyNetwork;
        }

		/*public Project(string Serial)
		{
			this.Number_Serial = Serial;
			this.Number_SAP = this.queries.ProjectNumber_SAP(Serial);
			this.Number_MAS90 = this.queries.ProjectNumber_MAS90(Serial);
			this.Number_BFC = this.queries.ProjectNumber_BFC(Serial);
			this.Number_Network = int.Parse(this.queries.ProjectNumber_Network(Serial));
			this.Customer = this.queries.ProjectName(Serial);
			this.Machine = this.queries.ProjectMachine(Serial);
			this.Country = this.queries.ProjectCountry(Serial);
			this.IsOpen = this.functions.BoolToInt(this.queries.ProjectIsOpen(Serial));
			this.IsWarrantyOpen = this.functions.BoolToInt(this.queries.ProjectIsWarrantyOpen(Serial));
			this.Number_WarrantyNetwork = int.Parse(this.queries.ProjectNumber_WarrantyNetwork(Serial));
		}*/
	}
}