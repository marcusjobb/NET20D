using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class AddBook
    {
        /// <summary>
        /// View for Add Book Method
        /// </summary>
        public static void AddNewBook()
        {
            Console.Clear();
            AddBookController.AddBookLogic();
            Console.ReadKey();
        }

    }
}
