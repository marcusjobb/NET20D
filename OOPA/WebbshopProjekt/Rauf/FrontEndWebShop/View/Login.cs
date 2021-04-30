using ConsoleTableExt;
using FrontEndWebShop.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontEndWebShop.View
{
    public  class Login
    {
        public static void ShowFirstMenu()
        {
            Console.WriteLine("Welcome to the webshop");
            Console.Write("Username: ");
            LoginController.username = Console.ReadLine();
            Console.Write("Password: ");
            LoginController.password = Console.ReadLine();
        }
    }
}
