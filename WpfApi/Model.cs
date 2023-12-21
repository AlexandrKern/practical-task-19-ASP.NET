using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WpfApi.Models;


namespace WpfApi
{
    internal class Model
    {
        HttpClient HttpClient { get; set; }
        List<Contact> contacts;
        Contact contact;
        public Model()
        {
           HttpClient = new HttpClient();
            contacts = new List<Contact>();
        }
        /// <summary>
        /// Загрузка контактов
        /// </summary>
        /// <returns></returns>
        public List<Contact> LoadContacts()
        {
            string url = @"https://localhost:44333/api/Contact";
            string json = HttpClient.GetStringAsync(url).Result;
            contacts = JsonConvert.DeserializeObject<IEnumerable<Contact>>(json).ToList();
            return contacts;
        }
        /// <summary>
        /// Добавление контакта
        /// </summary>
        /// <param name="contacts"></param>
        public async void AddContact(IContacts contacts)
        {
            contact = new Contact()
            {
                Name = contacts.Name,
                LastName = contacts.LastName,
                MiddleName = contacts.MiddleName,
                Address = contacts.Address,
                PhoneNumber = contacts.PhoneNumber,
                Description = contacts.Description
            };
            var myContent = JsonConvert.SerializeObject(contact);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            string url = @"https://localhost:44333/api/Contact";
            await HttpClient.PostAsync(url, byteContent);
        }
        public async void UpdatContact(IContacts contacts)
        {
            contact = contacts.Contact;
            var myContent = JsonConvert.SerializeObject(contact);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            string url = @"https://localhost:44333/api/Contact";
            await HttpClient.PutAsync(url, byteContent);
        }
        public async void DeleteContact(IContacts contacts)
        {
            contact = contacts.Contact;
            string url = $"https://localhost:44333/api/Contact/{contact.ID}";
            await HttpClient.DeleteAsync(url);
        }
    }
}
