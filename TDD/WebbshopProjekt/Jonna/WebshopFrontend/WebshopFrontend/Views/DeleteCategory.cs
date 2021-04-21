using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class DeleteCategory
    {
        /// <summary>
        /// View for Delete Category method
        /// </summary>
        public static void DeleteThisCategory()
        {
            DeleteCategoryController.DeleteCategoryLogic();
            Console.ReadKey();
        }

    }
}
