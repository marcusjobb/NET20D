using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminStatistics
{
    public static class BestCustomer
    {
        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Sold items", "Money earned",
            "Back"};

        /// <summary>
        /// Prints the best customer page with the best customer.
        /// </summary>
        /// <param name="bestCustomer"></param>
        public static void PrintBestCustomerPage(string bestCustomer)
        {
            Console.SetCursorPosition(25, 9);
            Console.WriteLine($"The best customer is: {bestCustomer}");
        }
    }
}
