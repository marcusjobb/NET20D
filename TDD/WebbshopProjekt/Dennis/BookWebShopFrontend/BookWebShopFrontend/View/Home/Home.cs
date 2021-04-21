using System;

namespace BookWebShopFrontend.View.Home
{
    public static class Home
    {
        /// <summary>
        /// Class for the view of Home.
        /// </summary>
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Home                                                   |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("0. Exit");
        }
    }
}