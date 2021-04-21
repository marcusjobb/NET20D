using System;
using System.Collections.Generic;
using ConsoleTableExt;
using FrontEndWebShop.Controllers;
using FrontEndWebShop.View;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyBackend;


namespace FrontEndWebShop
{
    class Program
    {
        public static string choise = "";
        public static int userId;
        static void Main(string[] args)
        {
            do
            {
                Login.ShowFirstMenu();
                userId = WebbShopAPI.Login(Controllers.LoginController.username, Controllers.LoginController.password);

                if (userId > 0)
                {
                    if (WebbShopAPI.user.IsAdmin)
                    {
                        Console.Clear();
                        Console.WriteLine("Du är inloggad som Administrator");
                        do
                        {
                            View.AdminMenu.ShowAdminMenu();
                            choise = Console.ReadLine();
                            Controllers.AdminControllers.AdminMenuController.AdminMenu();

                        } while (choise != "q");
                    }
                    else 
                    {
                        Console.WriteLine("Du är inloggad som user");
                        do
                        {
                            View.UserMenu.ShowUserMenu();
                            choise = Console.ReadLine();
                            Controllers.UserControllers.UserMenuController.ShowUserMenu();

                        } while (choise != "q");
                    }
                    if (choise == "q") choise = "n";

                }
                else
                {
                    Console.WriteLine("Wrong username or password");
                    Console.Write("Try again (y/n): ");
                    choise = Console.ReadLine();
                }
            } while (choise != "n");
        }
    }
}
