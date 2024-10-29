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

            var newBook = new Book
            {
                Author = "Dom",
                Title = "Test Book",
                Copies = 5,
                ISBN = "123453958292"
            };
            Book.AddBook(newBook);

            var books = Book.GetBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Quantity: {book.Copies}");
            }

            
        }

    }
}