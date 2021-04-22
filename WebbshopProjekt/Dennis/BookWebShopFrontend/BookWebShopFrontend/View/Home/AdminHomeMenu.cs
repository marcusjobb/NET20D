using System;

namespace BookWebShopFrontend.View.Home
{
    public static class AdminHomeMenu
    {
        /// <summary>
        /// Class for the view of AdminHomeMenu.
        /// </summary>
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Admin                                                  |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. Books Menu");
            Console.WriteLine("2. Users Menu");
            Console.WriteLine("3. Category Menu");
            Console.WriteLine("4. Sold Books Menu");
            Console.WriteLine("0. Logout");
        }
    }
}