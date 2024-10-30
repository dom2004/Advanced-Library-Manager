using Advanced_Library_Manager.Menus;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Data.SQLite;
using System.Runtime.InteropServices.Marshalling;
using Advanced_Library_Manager;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Library Management System.");

            Book.InitializeDatabase();

            Console.WriteLine("Enter your username");
            string username = Console.ReadLine();

            Console.WriteLine("Are you an admin? (Y/N)");
            bool isAdmin = Console.ReadLine().ToLower() == "yes";

            User user = new User(1, username, isAdmin);

            if (user.isAdmin)
            {
                Console.WriteLine($"Admin granted!\nWelcome {username}\n");
                Book book = new Book();
                BookMenuItem menuItem = new BookMenuItem(book);
                menuItem.Select();
            }
            else
            {
                Console.WriteLine("Welcome User!");
            }

        }

    }
}