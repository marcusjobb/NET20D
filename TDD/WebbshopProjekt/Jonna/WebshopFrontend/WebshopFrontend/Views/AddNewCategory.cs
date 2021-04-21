using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class AddNewCategory
    {
        /// <summary>
        /// View for Add Category method
        /// </summary>
        public static void AddCategory()
        {
            Console.Clear();
            AddNewCategoryController.AddNewCategoryLogic();
            Console.ReadKey();

        }
    }
}
