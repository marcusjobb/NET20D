using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminStatistics
{
    public static class MoneyEarned
    {
        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Sold items", "Best customer",
            "Back"};

        /// <summary>
        /// Prints the money earned page with the total amount of money earned.
        /// </summary>
        /// <param name="moneyEarned"></param>
        public static void PrintMoneyEarnedPage(int moneyEarned)
        {
            Console.SetCursorPosition(25, 9);
            Console.WriteLine($"Total money earned: {moneyEarned} kr");
        }
    }
}
