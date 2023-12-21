using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApi.Models;

namespace WpfApi
{
    internal class Presenter
    {
        Model model;
        IContacts contacts;
        public Presenter(IContacts contacts)
        {
            this.contacts = contacts;
            model = new Model();
        }
        public void Load()
        {
            List<Contact> con = model.LoadContacts();
            contacts.LoadData(con);
        }
        public void Add() 
        { 
            model.AddContact(contacts);
            Load();
        }
        public void Update()
        {
            model.UpdatContact(contacts);
        }
        public void Delete()
        {
            model.DeleteContact(contacts);
            Load();
        }
    }
}
