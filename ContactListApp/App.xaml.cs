using ContactListApp.classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ContactListApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       // creating the db connection
       public static string databasename = "contact_db";
       public static string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
       public static string databasePath = System.IO.Path.Combine(folderpath, databasename);
    }
}
