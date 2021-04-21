using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class ShowAllCategories
    {
        /// <summary>
        /// View of the Display Categories method
        /// </summary>
        public static void DisplayCategories()
        {
            Console.Clear();
            ShowAllCategoriesController.ShowAllCategoriesLogic();
        }

    }
}
