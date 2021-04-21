using System;
using System.Threading;
using Webbshop.Views;
using WebbshopProject.Models;
using WebbshopProject;
using Webbshop.Helpers;

namespace Webbshop.Controllers
{
    class StartupControllers
    {
        public static WebbshopAPI shop = new WebbshopAPI();

        /// <summary>
        /// Controller for the startup Menu.
        /// </summary>
        public static void WelcomeAndStartupMenu()
        {
            StartupView.WelcomeView();
            var input = Console.ReadLine();
            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Register();
                        break;
                    case 3:
                        Menu(10000);
                        break;
                    default:
                        Messages.ErrorMessage("Invalid choice!");
                        break;
                }
            }
            else
            {
                Messages.ErrorMessage("Invalid choice!");
            }
        }

        /// <summary>
        /// Login controller. Creates a user with 
        /// the username and password created in LoginView.
        /// Sends the user to Register if user does not exist.
        /// </summary>
        public static void Login()
        {
            var user = new User();
            var userData = StartupView.LoginView();
            user = shop.Login(userData.username, userData.password);

            if (user != null)
            {
                Menu(user.Id);
            }
            else
            {
                Messages.ErrorMessage("You don't have an account.");
                Console.WriteLine("Do you want to registrer? y/n");
                var answer = Console.ReadLine().ToLower();
                if (answer == "y")
                {
                    Register();
                }

                else if (answer == "n")
                {
                    Messages.SuccessMessage("Going back to the main menu.");
                    Thread.Sleep(2000);
                    WelcomeAndStartupMenu();
                }

                else
                {
                    Messages.ErrorMessage("Invalid input!");
                    Thread.Sleep(2000);
                    return;
                }
            }
        }

        /// <summary>
        /// A controller for registration. If password and
        /// verify match, then registration vill 
        /// succeed.
        /// </summary>
        public static void Register()
        {
            var newUserData = StartupView.RegisterView();
            var check = shop.Register(
                newUserData.username,
                newUserData.password,
                newUserData.passwordVerify);
            if (check)
            {
                Messages.SuccessMessage("User registrated.");
            }

            else
            {
                Messages.ErrorMessage("Something went wrong.");
            }

            Console.ReadKey();
            WelcomeAndStartupMenu();
        }

        /// <summary>
        /// A main menu for the users that is not admin,
        /// and that sends you to other menus depending on
        /// the choice.
        /// </summary>
        /// <param name="userId">Id of the user of the program.</param>
        public static void Menu(int userId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                AdminMenu(userId);
            }
            var input = "x";
            while (true)
            {
                if (HelperMethods.IsUserActiveAndLoggedIn(userId))
                {
                    Messages.ColorText("[E] Logout",
                        ConsoleColor.Yellow);
                }
                StartupView.PrintMenu(userId);
                Console.Write("Enter choice: ");
                input = Console.ReadLine().ToLower();
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            BookControllers.BookChoices(userId);
                            break;
                        case 2:
                            CategoriesControllers.CategoriesChoices(userId);
                            break;
                        case 3:
                            StartupControllers.WelcomeAndStartupMenu();
                            break;
                        default:
                            Messages.ErrorMessage(
                                "Invalid choice. try again!");
                            break;
                    }
                }

                else if (HelperMethods.IsUserActiveAndLoggedIn
                    (userId) && input == "e")
                {
                    Messages.SuccessMessage(
                        "You will now be logged out..");
                    Thread.Sleep(2000);
                    shop.Logout(userId);
                    StartupControllers.WelcomeAndStartupMenu();
                }

                else
                {
                    Messages.ErrorMessage("Invalid choice. try again!");
                }
                Console.ReadKey();
            }
        }

        /// <summary>
        /// A main menu for admins.
        /// </summary>
        /// <param name="userId">The id of user of the program.</param>
        private static void AdminMenu(int userId)
        {
            var input = "x";
            while (input != "e")
            {
                StartupView.PrintMenu(userId);
                Console.Write("Enter choice: ");
                input = Console.ReadLine().ToLower();

                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            BookControllers.BookChoicesAdmin(userId);
                            break;
                        case 2:
                            CategoriesControllers.
                                CategoriesChoicesAdmin(userId);
                            break;
                        case 3:
                            UsersControllers.UserChoicesAdmin(userId);
                            break;
                        default:
                            Messages.ErrorMessage(
                                "Invalid choice. try again!");
                            break;
                    }
                }

                else if (input == "e")
                {
                    Messages.SuccessMessage(
                        "You will now be logged out..");
                    Thread.Sleep(2000);
                    shop.Logout(userId);
                    StartupControllers.WelcomeAndStartupMenu();
                }

                else
                {
                    Messages.ErrorMessage("Invalid choice. try again!");
                }

                Console.ReadKey();
            }
        }
    }
}
