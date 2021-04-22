using Bokhandel.Controller;
using System;

namespace Bokhandel.View
{
    internal class UserView
    {
        /// <summary>
        /// Choose if user want to buy book
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        public static void BuyBook()
        {
            Console.WriteLine("[1] Buy this book");
            Console.WriteLine("[x] Go back");
        }

        /// <summary>
        /// Start meny
        /// </summary>
        public static void FirstMenu()
        {
            Console.WriteLine("**********************");
            Console.WriteLine("[1] See categories");
            Console.WriteLine("[2] Search book");
            Console.WriteLine("[3] Login");
            Console.WriteLine("[4] Logout");
            Console.WriteLine("[5] Register");
            Console.WriteLine("[6] Administrate");
            Console.WriteLine("**********************");
        }

        /// <summary>
        /// Choose what to search
        /// </summary>
        /// <param name="userId"></param>
        public static void SearchBook()
        {
            Console.WriteLine("[1] Search category");
            Console.WriteLine("[2] Search author");
            Console.WriteLine("[3] Search book");
            Console.WriteLine("[x] Go back");
        }

        /// <summary>
        /// Choose  all or only available books
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="categoryId"></param>
        public static void SeeAllOrOnlyAvailableBooks()
        {
            Console.WriteLine("[1] List all books in category");
            Console.WriteLine("[2] List only available books in category");
            Console.WriteLine("[x] Go back");
        }

        /// <summary>
        /// Welcome message
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Welcome to a Bookstore");
            var menu = new MenuController();
            menu.StartChoice();
        }
    }
}