using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminBooks
{
    public static class ChangeCategory
    {
        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Change amount",
            "Update book", "Remove book", "Back"};

        /// <summary>
        /// Prints the success message.
        /// </summary>
        public static void Success()
        {
            Console.SetCursorPosition(35, 18);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The category has been successfully changed for this book");
            Console.ResetColor();
            Thread.Sleep(3000);
        }
    }
}
