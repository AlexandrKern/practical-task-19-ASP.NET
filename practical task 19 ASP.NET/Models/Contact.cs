namespace practical_task_19_ASP.NET.Models
{
	public class Contact
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public int PhoneNumber { get; set; }
		public string Address { get; set; }
		public string Description { get; set; }
		public Contact(int ID, string Name, string MiddleName, string LastName, int PhoneNumber, string Address, string Description)
		{
			this.ID = ID;
			this.Name = Name;
			this.MiddleName = MiddleName;
			this.LastName = LastName;
			this.PhoneNumber = PhoneNumber;
			this.Address = Address;
			this.Description = Description;
		}
	}
}
