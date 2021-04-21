using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class GetAvailableBooks
    {
        /// <summary>
        /// View of the Get Available Books method
        /// </summary>
        public static void GetBooksInStock() 
        {
            GetAvailableBooksController.GetAvailableBooksLogic();
            Console.ReadKey();
        }
    }
}
