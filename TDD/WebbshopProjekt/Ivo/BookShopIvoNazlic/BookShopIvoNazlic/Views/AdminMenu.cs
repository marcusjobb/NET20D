using System;
using System.Collections.Generic;

namespace BookShopIvoNazlic.Views
{
    /// <remarks>
    /// Handles the content of admin menu
    /// </remarks>
    class AdminMenu : IMenu
    {
        public List<string> menuOptions = new List<string>() { "Add book", "Set amount of books",
            "List all users", "Search users by keyword", "Update book info", "Delete book",
            "Add category", "Add book to category", "Update category info","Delete category","Add user",
            "List all sold books", "Show money earned","Show best cutomer","Promote user","Demote user",
            "Activate user", "Deactivate user", "Exit program" };

        /// <summary>
        /// Prints admin menu
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
