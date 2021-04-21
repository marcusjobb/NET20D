using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class Login
    {
        /// <summary>
        /// View of the Login Method
        /// </summary>
        public static void LoginMenu()
        {
            LoginController.LoginMenuLogic();
        }
    }
}
