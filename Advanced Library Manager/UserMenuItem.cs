using System.ComponentModel;
using Advanced_Library_Manager.Menus;

namespace Advanced_Library_Manager;

internal class UserMenuItem : ConsoleMenu
{
    private Book _Book;

    public UserMenuItem(Book book)
    {
        _Book = book;
    }

    public override void CreateMenu()
    {
        _menuItems.Clear();
        _menuItems.Add(new ExitMenu(this));
    }

    public override string MenuText()
    {
        return "User Menu";
    }
}