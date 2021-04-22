using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminUsers
{
    public static class PromoteUser
    {
        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Add user", "List users",
            "Find user", "Activate user", "Inactivate user", "Demote user", "Back"};

        /// <summary>
        /// Prints the confirm message.
        /// </summary>
        public static void Confirm()
        {
            Layout layout = new Layout();
            layout.ClearMainContent();

            Console.SetCursorPosition(42, 15);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Are you sure you want to promote this user?");
            Console.ResetColor();
        }

        /// <summary>
        /// Prints that the user has been promoted.
        /// </summary>
        /// <param name="isPromoted"></param>
        public static void IsUserPromoted(bool isPromoted)
        {
            Layout layout = new Layout();
            layout.ClearMainContent();

            if (isPromoted == true)
            {
                Console.SetCursorPosition(48, 18);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The user has now been promoted");
                Thread.Sleep(3000);
                Console.ResetColor();
            }
        }
    }
}
