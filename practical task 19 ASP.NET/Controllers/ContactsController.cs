using Microsoft.AspNetCore.Mvc;
using practical_task_19_ASP.NET.Models;

namespace practical_task_19_ASP.NET.Controllers
{
	public class ContactsController : Controller
	{
		private List<Contact> contacts;
		public ContactsController()
		{
			contacts = new List<Contact>();
			for (int i = 0; i < 10; i++)
			{
				contacts.Add(new Contact(i, $"Имя_{i}",
					$"Отчество_{i}",
					$"Фамилия_{i}",
					8900 + i,
					$"Адрес_{i}",
					$"Описание_{i}"));
			}
		}
		public IActionResult Index()
		{
			return View(contacts);
		}
		public IActionResult Details(int id)
		{
			Contact contact = contacts.FirstOrDefault(c => c.ID == id);
			if (contacts == null) return NotFound();
			return View(contact);
		}
	}
}

