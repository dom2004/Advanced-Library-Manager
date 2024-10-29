using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Library_Manager.Menus;

namespace Advanced_Library_Manager
{
    internal class DeleteBook : MenuItem
    {
        private Book _Book;

        public DeleteBook(Book book)
        {
            _Book = book;
        }

        public override string MenuText()
        {
            return "Delete a book";
        }

        public override void Select()
        {
            Book.DeleteBook(ID);
        }
    }
}
