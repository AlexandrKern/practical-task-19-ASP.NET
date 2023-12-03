using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        Context db;
        List<Contact> contacts;
        public HomeController()
        {
            db = new Context();
            contacts = new List<Contact>();
            db.contacts.Load();
            contacts = db.contacts.Local.ToList();
        }
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }
    }
}
