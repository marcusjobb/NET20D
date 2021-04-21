using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class BuyBook
    {

        /// <summary>
        /// View for Buy Book Method
        /// </summary>
        public static void BuyThisBook()
        {
            BuyBookController.BuyBookLogic();
            Console.ReadKey();
        }

    }
}
