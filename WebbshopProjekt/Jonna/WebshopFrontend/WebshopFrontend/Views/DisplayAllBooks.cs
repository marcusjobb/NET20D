using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class DisplayAllBooks
    {
        /// <summary>
        /// View for Displaying all books
        /// </summary>
        public static void ListOfBooks()
        {
            Console.Clear();
            DisplayAllBooksController.DisplayAllBooksLogic();
        }
    }
}
