using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminStatistics
{
    public static class SoldItems
    {
        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Best customer",
            "Money earned", "Back"};

        /// <summary>
        /// Prints the sold items.
        /// </summary>
        /// <param name="soldItems"></param>
        public static void PrintSoldItems(List<Webbutik.Models.SoldBook> soldItems)
        {

            Console.SetCursorPosition(25, 9);
            foreach (var item in soldItems)
            {
                Console.Write(item.Title);
                Console.CursorLeft = 70;
                Console.WriteLine(item.PurchasedDate);
                Console.CursorLeft = 25;
            }
        }
    }
}
