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
using WpfApi.Data;

namespace WpfApi
{
    /// <summary>
    /// Логика взаимодействия для Regiser.xaml
    /// </summary>
    public partial class Regiser : Window
    {
        UserDbWpfContainer4 db;
        User User;
        Contacts Contacts;
        public Regiser()
        {
            InitializeComponent();
            db = new UserDbWpfContainer4();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User = new User()
            {
                Login = txtLogin.Text,
                Password = txtPassword.Text,
                Role = comboBoxRole.Text
            };
            db.UserSet.Add(User);
            db.SaveChanges();
            if (comboBoxRole.Text == "Admin")
            {
                Contacts = new Contacts("Admin");
                Contacts.Show();
            }
            if (comboBoxRole.Text == "User")
            {
                Contacts = new Contacts("User");
                Contacts.Show();
            }
            this.Close();
        }
    }
}
