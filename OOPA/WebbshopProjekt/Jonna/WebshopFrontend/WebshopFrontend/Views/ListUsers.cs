using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class ListUsers
    {
        /// <summary>
        /// View of the List Users Method
        /// </summary>
        public static void ShowAllUsers()
        {
            Console.Clear();
            ListUsersController.ShowAllUsersLogic();
            Console.ReadKey();
        }

    }
}
