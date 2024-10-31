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
            User.InitializeDatabase();

            Console.WriteLine("Do you have an account? (yes/no)");
            string accountResponse = Console.ReadLine().ToLower();
            bool hasAccount = accountResponse == "yes";

            User user;

            if (hasAccount)
            {
                Console.WriteLine("Enter your username");
                string username = Console.ReadLine();

                Console.WriteLine("Enter your password");
                string password = Console.ReadLine();

                user = User.GetUser(username, password);

                if (user != null)
                {
                    if (user.isAdmin)
                    {
                        Console.WriteLine($"Admin access granted!\nWelcome, {user.UserName}\n");
                        Book book = new Book();
                        BookMenuItem menuItem = new BookMenuItem(book);
                        menuItem.Select();
                    }
                    else
                    {
                        Console.WriteLine($"Welcome, {user.UserName}\n");
                    
                    }
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            else
            {
                Console.WriteLine("Enter a new Username");
                string username = Console.ReadLine();
                
                Console.WriteLine("Enter a new Password");
                string password = Console.ReadLine();
                
                Console.WriteLine("Are you an admin? (yes/no)");
                bool isAdmin = Console.ReadLine().ToLower() == "yes";


                user = new User(username, password, isAdmin);
                User.AddUser(user);
                
                Console.WriteLine("Welcome, {0}\n", user.UserName);
                Console.WriteLine("Please restart the program ...");
            }
        }

    }
}