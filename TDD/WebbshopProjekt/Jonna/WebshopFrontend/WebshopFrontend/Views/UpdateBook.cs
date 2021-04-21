using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class UpdateBook
    {
        /// <summary>
        /// View of the Update book Method
        /// </summary>
        public static void UpdateBookInfo()
        {
            UpdateBookController.UpdateBookLogic();
            Console.ReadKey();
        }

    }
}
