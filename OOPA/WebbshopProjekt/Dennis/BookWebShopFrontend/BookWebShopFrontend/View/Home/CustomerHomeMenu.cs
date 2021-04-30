using System;

namespace BookWebShopFrontend.View.Home
{
    public static class CustomerHomeMenu
    {
        /// <summary>
        /// Class for the view of CustomerHomeMenu.
        /// </summary>
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Customer                                               |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. Book Menu");
            Console.WriteLine("2. Category Menu");
            Console.WriteLine("0. Logout");
        }
    }
}