using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models;
using System.Net.Http;


namespace MyApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        List<Contact> contacts;
        DataContacts db;
        public ContactController()
        {
            db = new DataContacts();
            contacts = new List<Contact>();
            db.contacts.Load();
            contacts = db.contacts.Local.ToList();
        }
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
           return contacts;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Get(int id)
        {
            Contact contact = await db.contacts.FirstOrDefaultAsync(x => x.ID == id);
            if (contact == null)
                return NotFound();
            return new ObjectResult(contact);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(Contact contact)
        {
            db.contacts.Add(contact);
            await db.SaveChangesAsync();
            return contact.ID;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Contact contact = await db.contacts.FirstOrDefaultAsync(x => x.ID == id);
            db.contacts.Remove(contact);
            await db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Put(Contact contact)
        {
            db = new DataContacts();
            db.contacts.Update(contact);
            await db.SaveChangesAsync();
            return NoContent();
        }
    } 
}
