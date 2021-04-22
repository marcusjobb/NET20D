using System;
using Webbshop.Utils;
using Webbshop.Views;
using webshopAPI;

namespace Webbshop.Controllers
{
    internal class SharedController
    {
        /// <summary>
        /// Initializing the API for further use.
        /// </summary>
        private static WebShopApi api = new WebShopApi();

        /// <summary>
        /// Gets and validates the menu input from the user.
        /// </summary>
        /// <returns>Returns a tuple. menuInput is the string input from user, 
        /// and validatedInput is the tryparsed menuchoice</returns>
        public static (string menuInput, int validatedInput) GetAndValidateInput()
        {
            var menuInput = InputHelper.AskForMenuInput();
            var validatedInput = InputHelper.ValidateMenuInput(menuInput);
            return (menuInput, validatedInput);
        }

        /// <summary>
        /// Gets the input from the user and returns it
        /// </summary>
        /// <returns>Returns the input from the user</returns>
        public static string GetSearchInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Is used in menues to see if user pressed x. if not, print errormessage
        /// </summary>
        /// <param name="menuInput">Takes the input user have made</param>
        /// <returns>returns false if x has been pressed, true otherwise. 
        /// This is meant to be used in the ContinueLoop bool of Do While Loops.</returns>
        public static bool GoBackIf_X_IsPressedOrPrintErrorMsg(string menuInput)
        {
            var continueLoop = true;
            if (menuInput.ToLower() == "x")
            {
                continueLoop = false;
            }
            else
            {
                SharedError.PrintWrongMenuInput();
            }

            return continueLoop;
        }

        /// <summary>
        /// Logs out the user if X was pressed.
        /// </summary>
        /// <param name="user">Takes the user to log out</param>
        /// <param name="menuInput">takes the menu choice of the user</param>
        /// <param name="validatedInput">takes the validated input from the user</param>
        /// <returns>Returns true if user was logged out. false otherwise</returns>
        public static bool LogoutIf_X_IsPressed(User user, string menuInput, int validatedInput)
        {
            var logoutUser = false;
            if (validatedInput == 0 && menuInput.ToLower() == "x")
            {
                WebShopApi api = new WebShopApi();
                api.Logout(user.Id);
                logoutUser = true;
                Console.Clear();
            }

            return logoutUser;
        }

        /// <summary>
        /// The first menu user sees when buy book has been pressed.
        /// </summary>
        /// <param name="user">takes a user to be connected with eventual purchase</param>
        internal static void BuyBookMenu(User user)
        {
            var continueLoop = true;
            do
            {
                Console.Clear();
                SharedView.BuyBook();
                var input = GetAndValidateInput();
                switch (input.validatedInput)
                {
                    case 1:
                        BookController.BuyBySearchByBook(user);
                        break;

                    case 2:
                        BookController.BuyBySearchByAuthor(user);
                        break;

                    case 3:
                        BookController.BuyBySearchByCategory(user);
                        break;

                    case 4:
                        BookController.BuyByChooseByCategory(user);

                        break;

                    case 0:
                        continueLoop = GoBackIf_X_IsPressedOrPrintErrorMsg(input.menuInput);
                        break;
                }
            } while (continueLoop);
        }

        /// <summary>
        /// Method for checking if input is null, empty or whitespace.
        /// </summary>
        /// <param name="text">Takes a text to check</param>
        /// <returns>returns true if this was found, false if not.</returns>
        internal static bool CheckIfNullOrEmptyOrWhiteSpace(string text)
        {
            return string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text);
        }
    }
}