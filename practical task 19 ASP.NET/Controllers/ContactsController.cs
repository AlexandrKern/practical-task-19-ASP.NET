using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practical_task_19_ASP.NET.DataContext;
using practical_task_19_ASP.NET.Models;

namespace practical_task_19_ASP.NET.Controllers
{
	public class ContactsController : Controller
	{
		List<Contact> contacts;
		Context db;
		Contact contact;
        public ContactsController()
        {
			db = new Context();
			contacts = new List<Contact>();
			db.contacts.Load();
			contacts = db.contacts.Local.ToList();
        }
        public IActionResult Index()
		{
            return View(contacts);
		}
		public IActionResult Details(int id)
		{
			contact = contacts.FirstOrDefault(c => c.ID == id);
			if (contacts == null) return NotFound();
			return View(contact);
		}
		[HttpPost]
		public IActionResult Delete(int id)
		{
           contact = contacts.FirstOrDefault(c => c.ID == id);
			db.contacts.Remove(contact);
			db.SaveChanges();
            return Redirect("~/");
		}
		public IActionResult AddContact()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddContactDb(string name
			,string middleName
			,string lastName,
			int phoneNumber,
			string address,
			string description)
		{
			db.contacts.Add(new Contact()
			{
				Name=name,
				MiddleName=middleName,
				LastName=lastName,
				PhoneNumber=phoneNumber,
				Address=address,
				Description=description
			});
			db.SaveChanges();
			return Redirect("~/");
		}
        [HttpPost]
        public IActionResult Update(int id)
		{
            contact = contacts.FirstOrDefault(c => c.ID == id);
            return View(contact);
		}
		public IActionResult UpdateDb(Contact contact)
		{
			db = new Context();
			db.contacts.Update(contact);
			db.SaveChanges();
            return Redirect("~/");
        }
    }
}

