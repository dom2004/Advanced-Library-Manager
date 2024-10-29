using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Library_Manager.Menus;

namespace Advanced_Library_Manager
{
    internal class DisplayAllBooks : MenuItem
    {
        private IEnumerable<Book> _books;

        public DisplayAllBooks(IEnumerable<Book> books)
        {
            _books = books;
        }


        public override string MenuText()
        {
            return "Display all books";
        }

        public override void Select()
        {
            var books = Book.GetBooks();

            if (books.Count > 0)
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}");
                }
            }
            else
            {
                Console.WriteLine("No books in the database.");
            }
        }
    }
}
