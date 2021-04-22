using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class UpdateCategory
    {
        /// <summary>
        /// View of the UpdateCategory Method
        /// </summary>
        public static void UpdateCategoryDetails()
        {
            UpdateCategoryController.UpdateCategoryLogic();
            Console.ReadKey();
        }

    }
}
