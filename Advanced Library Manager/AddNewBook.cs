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

            var newBook = new Book
            {
                Title = "C# in Depth",
                Author = "Jon Skeet",
                ISBN = "9781617294532",
                Copies = 3
            };
            Book.AddBook(newBook);
        }
    }
}
