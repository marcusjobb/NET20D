using System;

namespace WebbutikFrontend.Views.SoldBooksMenu
{
    public static class MoneyEarned
    {
        /// <summary>
        /// The money earned view for the sold books menu.
        /// </summary>
        public static void View(double total)
        {
            Console.WriteLine($"\n\tMoney earned: {total} kr.");
        }
    }
}
