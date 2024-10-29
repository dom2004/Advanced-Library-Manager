using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Library_Manager.Menus
{
    internal class ExitMenu : MenuItem
    {
        private ConsoleMenu _menu;

        public ExitMenu(ConsoleMenu menu)
        {
            _menu = menu;
        }

        public override string MenuText()
        {
            return "Exit";
        }

        public override void Select()
        {
            _menu.IsActive = false;
        }
    }
}
