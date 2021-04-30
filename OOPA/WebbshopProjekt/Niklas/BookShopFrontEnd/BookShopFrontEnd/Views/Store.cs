using BookShopFrontEnd.Controllers;
using BookShopFrontEnd.Utility;
using System;
using System.Collections.Generic;
using System.Threading;
using WebbShopAPI.Models;

namespace BookShopFrontEnd.Views
{
    /// <summary>
    /// The view for the StoreController.Buy method
    /// </summary>
    public static class Store
    {                    
        /// <summary>
        /// Lets user pick which book to buy.
        /// </summary>
        /// <param name="bookIndex">Inputed number-1 so it will fit an array with 0 indexing.</param>
        /// <param name="booksByType">List of books.</param>
        public static List<Book> BuyBook()
        {
            Console.Clear();
            Logotypes.BookStore();
            var bookList = SpecifiedBookSearch.Alternatives();
            Console.Write("Buy book by entering book number ");
            Thread.Sleep(1200);
            return bookList;
        }
    }
}
