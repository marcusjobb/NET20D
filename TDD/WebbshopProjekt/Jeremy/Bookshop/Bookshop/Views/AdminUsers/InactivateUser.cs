using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminUsers
{
    public static class InactivateUser
    {
        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Add user", "List users",
            "Find user", "Activate user", "Promote user", "Demote user", "Back"};

        /// <summary>
        /// Prints the confirm message.
        /// </summary>
        public static void Confirm()
        {
            Layout layout = new Layout();
            layout.ClearMainContent();

            Console.SetCursorPosition(40, 15);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Are you sure you want to inactivate this user?");
            Console.ResetColor();
        }

        /// <summary>
        /// Prints that user is inactive.
        /// </summary>
        /// <param name="isActive"></param>
        public static void IsUserInactive(bool isActive)
        {
            Layout layout = new Layout();
            layout.ClearMainContent();

            if (isActive == true)
            {
                Console.SetCursorPosition(50, 18);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The user is now inactive");
                Thread.Sleep(3000);
                Console.ResetColor();
            }
        }
    }
}
