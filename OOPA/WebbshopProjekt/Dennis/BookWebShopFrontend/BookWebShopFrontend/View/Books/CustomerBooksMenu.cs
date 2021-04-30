using System;

namespace BookWebShopFrontend.View.Books
{
    public static class CustomerBooksMenu
    {
        /// <summary>
        /// Class for the view of CustomerBooksMenu.
        /// </summary>
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Customer Book Menu                                     |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. Get Book Info");
            Console.WriteLine("2. Search Book");
            Console.WriteLine("3. Search Book By Author");
            Console.WriteLine("4. Buy Book");
            Console.WriteLine("0. Back");
        }
    }
}