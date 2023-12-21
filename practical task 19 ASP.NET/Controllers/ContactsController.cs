using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using practical_task_19_ASP.NET.DataContext;
using practical_task_19_ASP.NET.Models;
using System.Text;
using System.Text.Json;
using System.Net.Http;


namespace practical_task_19_ASP.NET.Controllers
{
	public class ContactsController : Controller
	{
		List<Contact> contacts;
		Contact contact;
		private HttpClient httpClient { get; set; }

        public ContactsController()
        {
            httpClient = new HttpClient();
            contacts = new List<Contact>();
        }
        public IActionResult Index()
		{
            string url = @"https://localhost:44333/api/Contact";
            string json = httpClient.GetStringAsync(url).Result;
			contacts = JsonConvert.DeserializeObject<IEnumerable<Contact>>(json).ToList();
            return View(contacts);
		}
		[Authorize]
		public IActionResult Details(int id)
		{
			string url = $"https://localhost:44333/api/Contact/{id}";
			string json = httpClient.GetStringAsync(url).Result;
            contact = JsonConvert.DeserializeObject<Contact>(json);
            return View(contact);
		}
        [Authorize]
        public IActionResult AddContact()
		{
			return View();
		}
		[HttpPost]
		public async Task< IActionResult> AddContactDb(string name
			,string middleName
			,string lastName,
			int phoneNumber,
			string address,
			string description)
		{
			contact = new Contact()
			{
				Name=name,
				MiddleName=middleName,
				LastName=lastName,
				PhoneNumber=phoneNumber,
				Address=address,
				Description=description
			};
			string url = @"https://localhost:44333/api/Contact";
			 await httpClient.PostAsJsonAsync(url, contact);
            return Redirect("~/");
        }
        [HttpPost]
        public IActionResult Update(int id)
		{
            string url = $"https://localhost:44333/api/Contact/{id}";
            string json = httpClient.GetStringAsync(url).Result;
            contact = JsonConvert.DeserializeObject<Contact>(json);
            return View(contact);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateDb(Contact contact)
		{
			string url = $"https://localhost:44333/api/Contact";
			await httpClient.PutAsJsonAsync(url, contact);
			return Redirect("~/");
		}
		[HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            string url = $"https://localhost:44333/api/Contact/{id}";
            await httpClient.DeleteAsync(url);
            return Redirect("~/");
        }
    }
}

