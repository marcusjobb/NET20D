﻿using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class Register
    {
        /// <summary>
        /// View of the Register Method
        /// </summary>
        public static void RegisterMenu()
        {
            RegisterController.RegisterMenuController();
            Console.ReadKey();
        }
    }
}
