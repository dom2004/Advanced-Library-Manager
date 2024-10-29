using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Library_Manager.Menus;

namespace Advanced_Library_Manager
{
    internal class ClearDatabase : MenuItem
    {
        private IEnumerable<Book> _books;

        public ClearDatabase(IEnumerable<Book> books)
        {
            _books = books;
        }

        public override string MenuText()
        {
            return "Clear the database";
        }

        public override void Select()
        {
            Book.ClearDB();
        }
    }
}
