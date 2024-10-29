using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Library_Manager.Menus;

namespace Advanced_Library_Manager
{
    internal class AddNewBook : MenuItem
    {
        private Book _Book;

        public AddNewBook(Book book)
        {
            _Book = book;
        }

        public override string MenuText()
        {
            return "Add new book";
        }

        public override void Select()
        {
            Console.WriteLine("Please enter the book title");
            string title = Console.ReadLine();
            Console.WriteLine("Please enter the book author");
            string author = Console.ReadLine();
            Console.WriteLine("Please enter the ISBN");
            string ISBN = Console.ReadLine();
            Console.WriteLine("Please enter the quantity");
            string input = Console.ReadLine();
            int copies = int.Parse(input);

            var newBook = new Book
            {
                Title = title,
                Author = author,
                ISBN = ISBN,
                Copies = copies
            };
            Book.AddBook(newBook);
        }
    }
}
