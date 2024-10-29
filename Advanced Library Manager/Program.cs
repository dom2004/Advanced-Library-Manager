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


            var newBook = new Book()
            {
                Title = "Harry Potter",
                Author = "J.K. Rowling",
                ISBN = "12345678910",
                Copies = 5
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