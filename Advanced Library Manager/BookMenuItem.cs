using Advanced_Library_Manager.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Library_Manager
{
    internal class BookMenuItem : ConsoleMenu
    {
        private Book _Book;

        public BookMenuItem(Book book)
        {
            _Book = book;
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
            _menuItems.Add(new AddNewBook(_Book));
            _menuItems.Add(new DeleteBook(_Book));
            _menuItems.Add(new DisplayAllBooks(_Book.Books));
            _menuItems.Add(new ClearDatabase(_Book.Books));
            _menuItems.Add(new ExitMenu(this));
        }

        public override string MenuText()
        {
            return "Admin Menu";
        }
    }
}
