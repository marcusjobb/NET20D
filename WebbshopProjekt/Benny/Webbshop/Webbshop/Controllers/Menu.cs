using System;
using Webbshop.Utils;
using Webbshop.Views;
using webshopAPI;

namespace Webbshop.Controllers
{
    internal static class Menu
    {
        /// <summary>
        /// Simplifying what the X stands for. abort character
        /// </summary>
        private static string abortChar = "x";

        /// <summary>
        /// Method for printing the main menu
        /// </summary>
        public static void PrintMainMenu()
        {
            int userMenuChoice;
            string menuInput = default;
            do
            {
                Console.Clear();
                StartView.Print();
                menuInput = InputHelper.AskForMenuInput();
                userMenuChoice = InputHelper.ValidateMenuInput(menuInput);

                if (userMenuChoice == 0 && menuInput.ToLower() != "q")
                {
                    SharedError.PrintWrongMenuInput();
                }
                else
                {
                    var api = new WebShopApi();
                    switch (userMenuChoice)
                    {
                        case 1:
                            var userCredentials = LoginView.PrintLoginPage();
                            var user = api.Login(userCredentials.userName, userCredentials.password);

                            if (UserController.UserIsNull(user)
                                && !userCredentials.userName.Contains(abortChar))
                            {
                                SharedError.PrintWrongCredentials(user);

                                continue;
                            }
                            else if (userCredentials.userName.Contains(abortChar))
                            {
                                break;
                            }
                            else if (user.IsAdmin)
                            {
                                AdminController.PrintAdminSelectionMenu(user);
                            }
                            else
                            {
                                UserController.UserSelectionMenu(user);
                            }
                            break;

                        case 2:
                            var registererUserCredentials = UserView.Register();
                            if (!api.Register(registererUserCredentials.username,
                                registererUserCredentials.password,
                                registererUserCredentials.verifyPassword))
                            {
                                SharedError.Failed();
                                break;
                            }
                            SharedError.Success();
                            break;

                        case 0:
                            Environment.Exit(1);
                            break;

                        default:
                            SharedError.PrintWrongMenuInput();
                            break;
                    }
                }
            } while (menuInput.ToLower() != "q");
        }
    }
}