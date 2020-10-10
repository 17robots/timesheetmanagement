namespace FivesBronxTimesheetManagement.Classes
{
	public class Project
	{

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
				string[] numberSerial = new string[] { Number_Serial, "-", Customer, "-", Machine };
				return string.Concat(numberSerial);
			}
		}

		public Project()
		{
			Number_Serial = "";
			Number_SAP = "";
			Number_MAS90 = "";
			Number_BFC = "";
			Number_Network = 0;
			Customer = "";
			Machine = "";
			Country = "";
			IsOpen = 0;
			IsWarrantyOpen = 0;
			Number_WarrantyNetwork = 0;
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
	}
}