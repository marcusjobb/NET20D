using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class DeleteBook
    {
        /// <summary>
        /// View for Delete Book Method
        /// </summary>
        public static void DeleteOneBook()
        {
            DeleteBookController.DeleteBookLogic();
            Console.ReadKey();
        }

    }
}
