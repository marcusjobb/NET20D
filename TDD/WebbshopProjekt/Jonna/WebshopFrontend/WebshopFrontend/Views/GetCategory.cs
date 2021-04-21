using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class GetCategory
    {
        /// <summary>
        /// View of the Get Category method
        /// </summary>
        public static void GetBooksInCategory()
        {
            GetCategoryController.GetCategoryLogic();
            Console.ReadKey();
        }
    }
}
