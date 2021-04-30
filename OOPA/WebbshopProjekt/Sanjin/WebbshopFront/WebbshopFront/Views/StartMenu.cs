using InlamningDB2;
using System;
using System.Collections.Generic;
using System.Text;
using WebbshopFront.Controllers;
using WebbshopFront.Helpers;

namespace WebbshopFront.Views
{
    class StartMenu
    {
        public void Show()
        {
            bool exit = false;
            var userId = 0;
            while (!exit)
            {
                var api = new WebbShopAPI();
                api.Ping(userId);
                    var homeController = new HomeController();
                    var categoriesController = new CategoriesAndBookController();
                    var adminController = new AdminController();
                    WelcomLogs.StartLog();
                    Console.WriteLine("1. Kategori meny");
                    if (userId == 0)
                    {
                        Console.WriteLine("2. Login");
                    }
                    else
                    {
                        Console.WriteLine("2. Logout");
                    }
                    Console.WriteLine("3. Sök efter en kategori");
                    Console.WriteLine("4. Sök efter en bok");
                    Console.WriteLine("5. Sök efter en författare");
                    if (api.UserIsAdmin(userId)) Console.WriteLine("6. Admin meny");
                    if (userId == 0) Console.WriteLine("98. Registrera");
                    Console.WriteLine("99. Stäng av programmet");  
                    Int32.TryParse(Console.ReadLine(), out int choice);  
                    switch (choice)
                    {
                    case 1:
                        Rensaren.RensaRader();
                        WelcomLogs.KategoriLog();
                        categoriesController.GetBooksByCategory(userId);
                            break;
                        case 2:
                        Rensaren.RensaRader();
                        WelcomLogs.LogInLog();
                        if (userId == 0)
                            {
                                userId = homeController.Login();
                            }
                            else
                            {
                                homeController.Logout(userId);
                                userId = 0;
                            }
                            break;
                        case 98:
                        Rensaren.RensaRader();
                        WelcomLogs.RegisterLog();
                        homeController.Register();
                            break;
                        case 3:
                        Rensaren.RensaRader();
                        WelcomLogs.SearchForCategoryLog();
                        Console.ResetColor();
                        categoriesController.Search(userId);
                            break;
                        case 4:
                        Rensaren.RensaRader();
                        WelcomLogs.SearchForBookLog();
                        categoriesController.SearchBook(userId);
                            break;
                        case 5:
                        Rensaren.RensaRader();
                        WelcomLogs.SearchForAuthorLog();
                        categoriesController.SearchAuthor(userId);
                            break;
                        case 6:
                        if (api.UserIsAdmin(userId))
                        {
                            Rensaren.RensaRader();
                            new Home.AdminMenu().AdminStuff(userId); 
                        }
                            break;
                        case 99:
                        Rensaren.RensaRader();
                        exit = true;
                            break;
                        default:
                            break;
                    } 
            }
        }
    }
}
