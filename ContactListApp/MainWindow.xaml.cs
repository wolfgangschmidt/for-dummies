﻿using ContactListApp.classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactListApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            readDB();
        }

        private void click_new_contact_window(object sender, RoutedEventArgs e)
        {

            NewContact newContact = new NewContact();
            newContact.ShowDialog();
            readDB();
        }
        void readDB()
        {
            List<Contact> contacts;
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList();
            }
            if (contacts != null)
            {
                ContactListView.ItemsSource = contacts; 
            }
        }
    }
}
