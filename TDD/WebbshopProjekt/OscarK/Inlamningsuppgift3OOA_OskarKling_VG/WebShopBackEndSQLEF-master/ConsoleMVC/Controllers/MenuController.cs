using Pages;
using Structs;
using System;
using Views;

namespace Controllers
{
    internal class MenuController
    {
        private PageController pageController;
        private UserInputController userInputController;
        private ViewConsole view;
        #region Internal Methods

        internal MenuController()
        {
            view = new ViewConsole();
            pageController = new PageController();
            userInputController = new UserInputController();
        }

        /// <summary>
        /// Prints the Admin Menu to the console and gets user input about menu choices
        /// Also checks if user want to exit in out bool uswerwanttoexit, and returns out string error message
        /// </summary>
        /// <param name="menuChoice"></param>
        /// <param name="userWantToExitOut"></param>
        /// <param name="ErrorMsgOut"></param>
        /// <returns>True if successfull, else false</returns>
        internal bool AdminMenu(out int menuChoice, out bool userWantToExitOut, out string ErrorMsgOut)
        {
            menuChoice = 0;
            ErrorMsgOut = "";
            userWantToExitOut = false;

            view.Display(pageController.GetPage(PageType.AdminMenu));

            bool isInputValid = userInputController.GetIntInput(out int validUserInput,
            pageController.GetPage(PageType.AdminMenu).NrOfMenuOptions,
            out bool userWantToExitIn, out string errorMsgIn);

            if (userWantToExitIn)
            {
                userWantToExitOut = true;
                return false;
            }

            if (isInputValid)
            {
                menuChoice = validUserInput;
                return true;
            }
            else
            {
                ErrorMsgOut = errorMsgIn;
                return false;
            }
        }

        /// <summary>
        /// Calls consoleview to clear the console window of all text
        /// </summary>
        internal void ClearConsole()
        {
            view.ClearConsole();
        }

        /// <summary>
        /// Calls console view to print a message to the console widow form parameter input
        /// Only used for error messages May be depreciated now
        /// </summary>
        /// <param name="errorMsg"></param>
        internal void ErrorPrint(string errorMsg)
        {
            view.PrintToConsole(errorMsg);
        }

        /// <summary>
        /// Prints out a message to the console by parameter input.
        /// Then gets user input in form of a int
        /// returns the user input in a out int input
        /// Also checks if user want to exit in out bool uswerwanttoexit, and returns out string error message
        /// </summary>
        /// <param name="searchMsg"></param>
        /// <param name="input"></param>
        /// <param name="userWantToExitOut"></param>
        /// <param name="returnErrorMsg"></param>
        /// <returns>True if successfull, else false</returns>
        internal bool GetSearchIntInput(string searchMsg, out int input, out bool userWantToExitOut, out string returnErrorMsg)
        {
            input = 0;
            userWantToExitOut = false;
            returnErrorMsg = "";

            view.PrintToConsole(searchMsg);

            if (userInputController.GetIntInput(out int validUserInput, Int32.MaxValue, out bool userWantToExitIn, out string errorMsgIn))
            {
                if (userWantToExitIn)
                {
                    userWantToExitOut = true;
                    return false;
                }

                input = validUserInput;
                return true;
            }
            else
            {
                returnErrorMsg = errorMsgIn;
                return false;
            }
        }

        /// <summary>
        /// Prints out a message to the console by parameter input.
        /// Then gets user input in form of a string
        /// returns the user input in a out string input
        /// Also checks if user want to exit in out bool uswerwanttoexit, and returns out string error message
        /// </summary>
        /// <param name="searchMsg"></param>
        /// <param name="input"></param>
        /// <param name="userWantToExitOut"></param>
        /// <param name="returnErrorMsg"></param>
        /// <returns>True if successful else false</returns>
        internal bool GetSearchStringInput(string searchMsg, out string input, out bool userWantToExitOut, out string returnErrorMsg)
        {
            input = "";
            userWantToExitOut = false;
            returnErrorMsg = "";

            view.PrintToConsole(searchMsg);

            if (userInputController.GetStringInput(out string validUserInput, out bool userWantToExitIn, out string errorMsgIn))
            {
                if (userWantToExitIn)
                {
                    userWantToExitOut = true;
                    return false;
                }

                input = validUserInput;
                return true;
            }
            else
            {
                returnErrorMsg = errorMsgIn;
                return false;
            }
        }

        /// <summary>
        /// Returns a bool if logindetails are valid, return out LoginDetails of a users input.
        /// </summary>
        /// <param name="tempDetails"></param>
        /// <param name="userWantToExitOut"></param>
        /// <param name="newUser"></param>
        /// <returns>True if successfull, else false. Bool if user want to exit and string with errormessage</returns>
        internal bool LoginMenu(out LoginDetails tempDetails, out bool userWantToExitOut, out bool newUser)
        {
            tempDetails = new LoginDetails();
            userWantToExitOut = false;
            newUser = false;

            while (true)
            {
                //Prints the login menu
                view.Display(pageController.GetPage(PageType.LoginMenu));

                //Gets a userinput and if its valid and if user want to exit
                bool IsUserInputValid = userInputController.GetIntInput(out int validMenuUserInput,
                pageController.GetPage(PageType.LoginMenu).NrOfMenuOptions,
                out bool userWantToExitIn,
                out string errorMsg);

                if (userWantToExitIn)
                {
                    userWantToExitOut = true;
                    return false;
                }

                if (IsUserInputValid)
                {
                    switch (validMenuUserInput)
                    {
                        case 1:
                            if (GetLoginDetails(out LoginDetails userLoginDetails, out bool userWantToExitOut2, out string returnErrorMsg))
                            {
                                if (userWantToExitOut2)
                                {
                                    userWantToExitOut = true;
                                    return false;
                                }
                                tempDetails = userLoginDetails;
                            }
                            else
                            {
                                view.PrintToConsole(returnErrorMsg);
                            }
                            break;

                        case 2:
                            if (Register(out LoginDetails newUserLoginDetails, out bool userWantToExitOut3, out string returnErrorMsg2))
                            {
                                if (userWantToExitOut3)
                                {
                                    userWantToExitOut = true;
                                    return false;
                                }
                                tempDetails = newUserLoginDetails;
                                newUser = true;
                            }
                            else
                            {
                                view.PrintToConsole(returnErrorMsg2);
                            }
                            break;

                        default:
                            break;
                    }
                    break;
                }
                else
                {
                    view.PrintToConsole(errorMsg);
                }
            }
            return true;
        }

        /// <summary>
        /// Prints a string to the view.
        /// </summary>
        /// <param name="msg"></param>
        internal void PrintMsg(string msg)
        {
            view.PrintToConsole(msg);
        }

        /// <summary>
        /// Calls console view to clear console window then print a message to the console widow form parameter input
        /// </summary>
        /// <param name="msg"></param>
        internal void PrintResults(string msg)
        {
            ClearConsole();
            view.PrintToConsole(msg);
        }

        /// <summary>
        /// Returns true if user want to try again. Returns false if user want to exit
        /// </summary>
        /// <returns>True if successful else false</returns>
        internal bool TryAgain()
        {
            view.PrintToConsole("Try again? Y or N");
            if (userInputController.GetStringInput(out string validUserInput, out bool userWantToExitOut, out string errormsg))
            {
                if (validUserInput == "Y" || validUserInput == "y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                userWantToExitOut = true;
                return false;
            }
        }
        /// <summary>
        /// Prints the User Menu to the console and gets the user input of the menu choices
        /// Also checks if user want to exit in out bool uswerwanttoexit, and returns out string error message
        /// </summary>
        /// <returns>True if successfull, else false</returns>
        internal bool UserMenu(out int menuChoice, out bool userWantToExitOut, out string ErrorMsgOut)
        {
            menuChoice = 0;
            ErrorMsgOut = "";
            userWantToExitOut = false;

            view.Display(pageController.GetPage(PageType.UserMenu));

            bool isInputValid = userInputController.GetIntInput(out int validUserInput,
            pageController.GetPage(PageType.UserMenu).NrOfMenuOptions,
            out bool userWantToExitIn, out string errorMsgIn);

            if (userWantToExitIn)
            {
                userWantToExitOut = true;
                return false;
            }

            if (isInputValid)
            {
                menuChoice = validUserInput;
                return true;
            }
            else
            {
                ErrorMsgOut = errorMsgIn;
                return false;
            }
        }
        /// <summary>
        /// Load the welcome text for the console window
        /// </summary>
        internal void Welcome()
        {
            view.Display(pageController.GetPage(PageType.Welcome));
            view.ChangeForeGroundColor(ConsoleColor.Green);
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        /// Returns the LoginDetails of a users input. Also returns if the user wants to exit, and error message as a string.
        /// </summary>
        /// <param name="userLoginDetails"></param>
        /// <param name="userWantToExitOut"></param>
        /// <param name="returnErrorMsg"></param>
        /// <returns>True if sucessfull, else false. Bool if user want to exit and string with errormessage</returns>
        private bool GetLoginDetails(out LoginDetails userLoginDetails, out bool userWantToExitOut, out string returnErrorMsg)
        {
            userLoginDetails = new LoginDetails();
            returnErrorMsg = "";
            userWantToExitOut = false;

            view.PrintToConsole("Enter Username");
            if (userInputController.GetStringInput(out string validUserName, out bool userWantToExitIn, out string errorMsg))
            {
                if (userWantToExitIn)
                {
                    userWantToExitOut = true;
                    return false;
                }

                view.PrintToConsole("Enter Password");
                if (userInputController.GetStringInput(out string validPassword, out bool userWantToExitIn2, out string errorMsg2))
                {
                    if (userWantToExitIn2)
                    {
                        userWantToExitOut = true;
                        return false;
                    }
                    userLoginDetails = new LoginDetails(validUserName, validPassword, validPassword);
                    view.PrintToConsole("Trying to log in...");
                    return true;
                }
                else
                {
                    returnErrorMsg = errorMsg2;
                    return false;
                }
            }
            else
            {
                returnErrorMsg = errorMsg;
                return false;
            }
        }

        /// <summary>
        /// Returns the Register Details as LoginDetails type - of a users input.
        /// Also returns if the user wants to exit, and error message as a string.
        /// </summary>
        /// <param name="newUserLoginDetails"></param>
        /// <param name="verifiedPasswordOut"></param>
        /// <param name="userWantToExitOut"></param>
        /// <param name="returnErrorMsg"></param>
        /// <returns>True if sucessfull, else false. Bool if user want to exit and string with errormessage</returns>
        private bool Register(out LoginDetails newUserLoginDetails, out bool userWantToExitOut, out string returnErrorMsg)
        {
            newUserLoginDetails = new LoginDetails();
            returnErrorMsg = "";
            userWantToExitOut = false;

            view.PrintToConsole("---Register new account---");
            view.PrintToConsole("Enter a Username");
            if (userInputController.GetStringInput(out string validUserName, out bool userWantToExitIn, out string errorMsg))
            {
                if (userWantToExitIn)
                {
                    userWantToExitOut = true;
                    return false;
                }

                view.PrintToConsole("Enter a Password");
                if (userInputController.GetStringInput(out string validPassword, out bool userWantToExitIn2, out string errorMsg2))
                {
                    if (userWantToExitIn2)
                    {
                        userWantToExitOut = true;
                        return false;
                    }

                    view.PrintToConsole("Enter your password again to verify it");
                    if (userInputController.GetStringInput(out string verifiedPasswordIn, out bool userWantToExitIn3, out string errorMsg3))
                    {
                        if (userWantToExitIn3)
                        {
                            userWantToExitOut = true;
                            return false;
                        }
                        newUserLoginDetails = new LoginDetails(validUserName, validPassword, verifiedPasswordIn);
                        view.PrintToConsole("Trying to register..");
                        return true;
                    }
                    else
                    {
                        returnErrorMsg = errorMsg3;
                        return false;
                    }
                }
                else
                {
                    returnErrorMsg = errorMsg2;
                    return false;
                }
            }
            else
            {
                returnErrorMsg = errorMsg;
                return false;
            }
        }

        #endregion Private Methods
    }
}