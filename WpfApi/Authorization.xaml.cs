
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using WpfApi.Data;
using WpfApi.Models;

namespace WpfApi
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        UserDbWpfContainer4 db;
        User User;
        Contacts Contacts;
        List<User> Users;
        public Authorization()
        {
            InitializeComponent();
            db = new UserDbWpfContainer4();
            Users = new List<User>();
        }
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            db.UserSet.Load();
            Users = db.UserSet.Local.ToList();
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Login == textBoxLogin.Text && Users[i].Password==textBoxPassword.Text)
                {
                    Contacts = new Contacts(Users[i].Role);
                    Contacts.Show();
                    this.Close();
                    return;
                }
            }
            MessageBox.Show("Пользователь не найден");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Regiser regiser = new Regiser();
            regiser.Show();
            this.Close();
        }
    }
}
