using ContactListApp.classes;
using SQLite;
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

namespace ContactListApp
{
    /// <summary>
    /// Interaction logic for NewContact.xaml
    /// </summary>
    public partial class NewContact : Window
    {
        public NewContact()
        {
            InitializeComponent();
        }
        private void button_click(object sender, RoutedEventArgs e)
        {
            // create the contact object mapping
            Contact contact = new Contact();
            contact.Name = textboxName.Text;
            contact.Email = textboxEmail.Text;
            contact.Number = textboxNumber.Text;

            // connectiong
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                // inserting
                connection.Insert(contact);
            }

            this.Close();
        }
    }
}
