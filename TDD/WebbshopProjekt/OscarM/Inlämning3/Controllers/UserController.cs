using Inlämning2WebbShop;
using Inlämning2WebbShop.Models;
using Inlämning3.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inlämning3.Controllers
{
    internal class UserController
    {
        private WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// Calls Printbooks view to get the choice of a specific book.
        /// Then calls BuyBook method with the chosen book.
        /// </summary>
        /// <param name="books"></param>
        public void PrintBooks(List<Book> books)
        {
            Helpers.Helper.CheckPing(api.Ping(Account.UserId));
            var choice = Views.User.Books.PrintBooks(books);
            if (choice > books.Count() || choice < 0)
            {
                Console.Clear();
                Console.WriteLine("No books found");
            }
            else
            {
                BuyBook(books[choice].Id);
                Console.Clear();
            }
        }

        /// <summary>
        /// calls APIs buy book method if the user is logged in and if the book exists.
        /// </summary>
        /// <param name="bookId"></param>
        public void BuyBook(int bookId)
        {
            Helpers.Helper.CheckPing(api.Ping(Account.UserId));
            if (!Account.IsLoggedIn)
            {
                Console.Clear();
                Console.WriteLine("You have to be logged in to buy book!");
                var homeController = new HomeController();
                homeController.Home();
            }
            var book = api.GetBook(bookId);
            if (book == null)
            {
                Console.Clear();
                Console.WriteLine("Could not find the book you asked for!");
                var HomeController = new HomeController();
                HomeController.Home();
            }
            var choice = Views.User.Books.BuyBook(book);
            if (choice == "Y")
            {
                var PurchaseSuccessfull = api.BuyBook(Account.UserId, bookId);
                if (PurchaseSuccessfull)
                {
                    Console.Clear();
                    Messages.SuccessMessage();
                }
                else
                {
                    Console.Clear();
                    Messages.ErrorMessage();
                    var HomeController = new HomeController();
                    HomeController.Home();
                }
            }
        }
    }
}