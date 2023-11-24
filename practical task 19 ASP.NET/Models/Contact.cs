using System.ComponentModel.DataAnnotations;

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
	}
}
