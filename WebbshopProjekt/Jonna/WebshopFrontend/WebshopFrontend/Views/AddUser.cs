using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class AddUser
    {
        /// <summary>
        /// View for Add User Method
        /// </summary>
        public static void AddNewUser()
        {
            Console.Clear();
            AddUserController.AddUserLogic();
            Console.ReadKey();
        }
    }
}
