using System;
using System.Collections.Generic;

namespace BookShopIvoNazlic.Views
{
    /// <remarks>
    /// Handles the content and messages of user menu
    /// </remarks>
    class MainMenu :IMenu
    {

        public List<string> menuOptions = new List<string>() { "Login", "Logout", 
            "List all categories", "Search category by keyword", "List books by category", "Show available books", 
            "Book info", "List books by keyword", "List books by author","Buy book","Ping user","Register", "Exit program" };

        /// <summary>
        /// Prints user menu
        /// </summary>
        /// <param name="menu">Containing strings for all menu options</param>
        public void ProgramMenu(List<string> menu)
        {
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menu[i]}");
            }
        }


    }
}
