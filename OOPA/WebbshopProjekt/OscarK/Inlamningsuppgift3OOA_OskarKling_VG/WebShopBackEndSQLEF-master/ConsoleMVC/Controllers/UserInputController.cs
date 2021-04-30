using System;
using System.Diagnostics;

namespace Controllers
{
    internal class UserInputController
    {
        #region Internal Methods

        internal UserInputController()
        {
        }

        /// <summary>
        /// Asks Console for Readline.
        /// Then validates this input if its empty, valid or if the user wants to exit
        /// Returns out bool userwanttoexit if user wants to exit the program(input was e or E)
        /// If something goes wrong the out string error message gets a value
        /// </summary>
        /// <param name="validUserInput"></param>
        /// <param name="nrOfMenuOptions"></param>
        /// <param name="userWantToExit"></param>
        /// <param name="errorMsg"></param>
        /// <returns>True if successfull, else false</returns>
        internal bool GetIntInput(out int validUserInput, int nrOfMenuOptions, out bool userWantToExit, out string errorMsg)
        {
            errorMsg = "";
            validUserInput = 0;
            userWantToExit = false;
            string input = Console.ReadLine();
            if (!IsInputEmpty(input))
            {
                if (!UserWantToExit(input))
                {
                    if (IsInputValid(input, out validUserInput, nrOfMenuOptions))
                    {
                        return true;
                    }
                    else
                    {
                        errorMsg = "Input is not valid";
                        Debug.WriteLine(errorMsg);
                        return false;
                    }
                }
                else
                {
                    userWantToExit = true;
                    return true;
                }
            }
            else
            {
                errorMsg = "No input";
                Debug.WriteLine(errorMsg);
                return false;
            }
        }

        /// <summary>
        /// Asks Console for Readline.
        /// Then validates this input if its empty, valid or if the user wants to exit
        /// Returns out bool userwanttoexit if user wants to exit the program(input was e or E)
        /// If something goes wrong the out string error message gets a value
        /// </summary>
        /// <param name="validUserInput"></param>
        /// <param name="userWantToExit"></param>
        /// <param name="errorMsg"></param>
        /// <returns>True if successfull, else false</returns>
        internal bool GetStringInput(out string validUserInput, out bool userWantToExit, out string errorMsg)
        {
            errorMsg = "";
            validUserInput = "";
            userWantToExit = false;
            string input = Console.ReadLine();
            if (!IsInputEmpty(input))
            {
                if (!UserWantToExit(input))
                {
                    validUserInput = input;
                    return true;
                }
                else
                {
                    userWantToExit = true;
                    return true;
                }
            }
            else
            {
                errorMsg = "No input";
                Debug.WriteLine(errorMsg);
                return false;
            }
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        /// Checks if a string is empty
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True if string is empty, else false.</returns>
        private bool IsInputEmpty(string input)
        {
            if (input == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the string input is a number
        /// Then checks if input is a number and within the menu options. also returns the number out int.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="number"></param>
        /// <returns>True if input is a number, else false. Also return out int the number</returns>
        private bool IsInputValid(string input, out int number, int nrOfMenuOptions)
        {
            if (Int32.TryParse(input, out number))
            {
                //Checks if the number is within the range of menu options.
                if (number > 0 && number <= nrOfMenuOptions)
                {
                    return true;
                }
                else
                {
                    Debug.WriteLine("Input is not within menu choice range");
                    return false;
                }
            }
            else
            {
                Debug.WriteLine("Input is not a number");
                return false;
            }
        }

        /// <summary>
        /// Checks if the user want to exit if the input is e Or E
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True if input is e/E, else false</returns>
        private bool UserWantToExit(string input)
        {
            if (input == "E" || input.ToLower() == "e")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Private Methods
    }
}