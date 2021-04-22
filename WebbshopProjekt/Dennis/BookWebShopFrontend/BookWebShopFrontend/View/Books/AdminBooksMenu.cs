using System;

namespace BookWebShopFrontend.View.Books
{
    public static class AdminBooksMenu
    {
        /// <summary>
        /// Class for the view of AdminBooksMenu.
        /// </summary>
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Admin Book Menu                                        |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Update Book");
            Console.WriteLine("3. Delete Book");
            Console.WriteLine("4. Set Amount");
            Console.WriteLine("0. Back");
        }
    }
}