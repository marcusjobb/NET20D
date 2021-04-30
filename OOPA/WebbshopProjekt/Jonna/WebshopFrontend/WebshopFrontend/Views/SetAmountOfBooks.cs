using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class SetAmountOfBooks
    {
        /// <summary>
        /// View of the Set Amount of books Method
        /// </summary>
        public static void UpdateBookAmount()
        {
            SetAmountOfBooksController.SetAmountOfBooksLogic();
            Console.ReadKey();
        }

    }
}
