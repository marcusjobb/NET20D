using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{

    class AddBookToCategory
    {
        /// <summary>
        /// View for Add Book To Category Method
        /// </summary>
        public static void AddBookToThisCategory()
        {
            AddBookToCategoryController.AddBookToCategoryLogic();
            Console.ReadKey();
        }
    }
}
