using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.Home
{
    public static class Logout
    {
        /// <summary>
        /// Prints the confirm logout.
        /// </summary>
        public static void ConfirmLogout()
        {
            Console.SetCursorPosition(45, 15);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Are you sure you want to Logout?");
            Console.ResetColor();
        }
    }
}
