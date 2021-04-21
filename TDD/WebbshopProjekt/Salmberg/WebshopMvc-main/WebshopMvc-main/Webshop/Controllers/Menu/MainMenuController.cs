using System;
using System.Collections.Generic;
using WebshopAPI;
using WebshopAPI.Models;
using WebshopAPI.Utils;
using WebshopMVC.Controllers.Menu;
using WebshopMVC.UtilsMVC;

namespace WebshopMVC.Controllers
{
    /// <summary>
    /// Base menu class. Program flow starts and ends here.
    /// </summary>
    internal class MainMenuController
    {
        /// <summary>
        /// Bool for creating while loop of Main Menu
        /// </summary>
        public static bool isMainMenuRunning = true;

        /// <summary>
        /// Main menu method. This is the center for the application, program flow starts and ends here.
        /// User object as parameter for handling session timer and ping function.
        /// Prints different menu's depending on user being logged in/logged out/have administrator privileges
        /// </summary>
        /// <param name="user"></param>
        public static void MainMenu(User user)
        {
            while (isMainMenuRunning)
            {
                UserController.SendPing(user.Id);
                user = Startup.sessionCookie;
                Console.Clear();
                ASCII.MainMenuASCII();

                //If user is logged out
                if (SessionTimer.CheckSessionTimer(user.SessionTimer) == true)
                {
                    Console.WriteLine("[1] Browse books");
                    Console.WriteLine("[2] Browse categories");
                    Console.WriteLine("[3] Buy book\n\n");
                    Console.WriteLine("[4] Register");
                    Console.WriteLine("[5] Login");
                    Console.WriteLine("[6] Quit application");

                    int.TryParse(Console.ReadLine(), out var mainMenuLoggedOutInput);

                    switch (mainMenuLoggedOutInput)
                    {
                        case 1:
                            BookMenuController.BookMenu();
                            break;

                        case 2:
                            CategoryMenuController.CategoryMenu();
                            break;

                        case 3:
                            UserController.BuyBook(user);
                            break;

                        case 4:
                            UserController.RegisterNewUser();
                            break;

                        case 5:
                            UserController.LogInUser();
                            break;

                        case 6:
                            isMainMenuRunning = false;
                            break;
                    }
                }

                //If user is logged in
                else if (SessionTimer.CheckSessionTimer(user.SessionTimer) == false && user.IsAdmin == false)
                {
                    Console.WriteLine("[1] Browse books");
                    Console.WriteLine("[2] Browse categories");
                    Console.WriteLine("[3] Buy book\n\n");
                    Console.WriteLine("[4] Logout");
                    Console.WriteLine("[5] Quit application");

                    int.TryParse(Console.ReadLine(), out var mainMenuLoggedInInput);

                    switch (mainMenuLoggedInInput)
                    {
                        case 1:
                            BookMenuController.BookMenu();
                            break;

                        case 2:
                            CategoryMenuController.CategoryMenu();
                            break;

                        case 3:
                            UserController.BuyBook(user);
                            break;

                        case 4:
                            UserController.LogOutUser(user);

                            break;

                        case 5:
                            isMainMenuRunning = false;
                            break;
                    }
                }

                //If user is logged in and is admin
                else if (SessionTimer.CheckSessionTimer(user.SessionTimer) == false && user.IsAdmin == true)
                {
                    Console.WriteLine("[1] Browse books");
                    Console.WriteLine("[2] Browse categories");
                    Console.WriteLine("[3] Buy book\n\n");
                    Console.WriteLine("[4] Administrator menu");
                    Console.WriteLine("[5] Logout");
                    Console.WriteLine("[6] Quit application");

                    int.TryParse(Console.ReadLine(), out var mainMenuAdminInput);

                    switch (mainMenuAdminInput)
                    {
                        case 1:
                            BookMenuController.BookMenu();
                            break;

                        case 2:
                            CategoryMenuController.CategoryMenu();
                            break;

                        case 3:
                            UserController.BuyBook(user);
                            break;

                        case 4:
                            AdminMenuController.AdminMainMenu(user);
                            break;

                        case 5:
                            UserController.LogOutUser(user);
                            break;

                        case 6:
                            isMainMenuRunning = false;
                            break;
                    }
                }
            }
        }
    }
}