using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class BookInfo
    {
        /// <summary>
        /// View for Book Info Method
        /// </summary>
        public static void ShowBookInfo()
        {
            BookInfoController.BookInfoLogic();
            Console.ReadKey();
        }
    }
}
