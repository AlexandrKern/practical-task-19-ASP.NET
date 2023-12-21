using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApi.Models;

namespace WpfApi
{

    public partial class Contacts : Window,IContacts
    {
        Presenter Presenter;
        public Contacts(string role)
        {
            InitializeComponent();
            if (role == "User")
            {
                buttonDeleteContact.Visibility = Visibility.Hidden;
                buttonUpdateContact.Visibility = Visibility.Hidden;
            }
            Presenter = new Presenter(this);
            Presenter.Load();
            buttonSave.Click += (s, e) => Presenter.Add();
            buttonUpdateContact.Click += (s, e) => Presenter.Update();
            buttonDeleteContact.Click += (s, e) => Presenter.Delete();
        }
        public Contact Contact { get =>(Contact) gridContacts.SelectedItem; }
        public string Name { get => textName.Text; }
        public string MiddleName { get => textMiddleName.Text; }
        public string LastName { get => textSurName.Text; }
        public int PhoneNumber { get => int.Parse(textPhoneNumber.Text); }
        public string Address { get => textAddress.Text; }
        public string Description { get => textDescription.Text; }
        public void LoadData(List<Contact> contacts)
        {
            gridContacts.ItemsSource = contacts;
        }
    }
}
