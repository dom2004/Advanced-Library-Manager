using Advanced_Library_Manager.Menus;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Data.SQLite;
using Advanced_Library_Manager;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Library Management System.");

            Book.InitializeDatabase();

            Book book = new Book();
            BookMenuItem menuItem = new BookMenuItem(book);
            menuItem.Select();


        }

    }
}