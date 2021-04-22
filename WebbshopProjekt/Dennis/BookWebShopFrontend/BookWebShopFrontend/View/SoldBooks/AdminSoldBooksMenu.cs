using System;

namespace BookWebShopFrontend.View.SoldBooks
{
    public static class AdminSoldBooksMenu
    {
        /// <summary>
        /// Class of the view of AdminSoldBooksMenu.
        /// </summary>
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Admin Sold Books Menu                                  |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. List all Sold Books");
            Console.WriteLine("2. Money Earned");
            Console.WriteLine("3. Best Customer");
            Console.WriteLine("0. Back");
        }
    }
}