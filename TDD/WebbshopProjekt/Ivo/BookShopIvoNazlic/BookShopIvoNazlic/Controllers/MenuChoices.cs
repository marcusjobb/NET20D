using System;
using System.Collections.Generic;

namespace BookShopIvoNazlic.Controllers
{
    /// <remarks>
    /// Handles inputs and outputs of choices user makes in the menues
    /// </remarks>
    class MenuChoices
    {
        private static int userMenuChoice;
        private static object[] menuChoiceToReturn = new object[2];
        private static string userInputDescription;

        /// <summary>
        ///  Handles the choices user makes in the menu
        /// </summary>
        /// <param name="menuOptions">Containing all menu options</param>
        /// <returns>Array cointaining menu option number(int) and chosen menu option description (string)</returns>
        public static object[] UserChoice(List<string> menuOptions)
        {
            Console.Write($"\nWhat would you like to do? ");
            string menuChoice = Console.ReadLine();
            Console.Clear();

            if (CheckIfNotEmpty(menuChoice) && CheckIfInt(menuChoice))
            {
                userMenuChoice = Convert.ToInt32(menuChoice);
                if (CheckIfInRange(userMenuChoice, menuOptions))
                {
                    menuChoiceToReturn[0] = userMenuChoice;
                    userInputDescription = menuOptions[userMenuChoice - 1];
                    menuChoiceToReturn[1] = userInputDescription;
                    return menuChoiceToReturn;
                }

                ReturnErrorMsg();
                return menuChoiceToReturn;
            }

            ReturnErrorMsg();
            return menuChoiceToReturn;
        }

        /// <summary>
        /// Checks if user made an empty choice
        /// </summary>
        /// <returns>True if not empty, otherwise false</returns>
        public static bool CheckIfNotEmpty(string menuChoice)
        {
            if (!string.IsNullOrEmpty(menuChoice)) //Handles exceptions if user misses to make a choice in the menu
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if user made a choice that is not number
        /// </summary>
        /// <returns>True if number, otherwise false</returns>
        public static bool CheckIfInt(string menuChoice)
        {
            if (int.TryParse(menuChoice, out int userMenuChoice))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if user made a choice outside of menu range based
        /// on the lenghts of the list containing all the menu options
        /// </summary>
        /// <param name="menuOptions">Containing all menu options</param>
        /// <param name="userMenuChoice">Id of the chosen menu option</param>
        /// <returns>True if choice within range, otherwise false</returns>
        public static bool CheckIfInRange(int userMenuChoice, List<string> menuOptions)
        {
            if (userMenuChoice > 0 && userMenuChoice <= menuOptions.Count) //if-else condition for error handling (user making choices out of menu range).
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        /// <summary>
        /// Fills an array with 0 value at first position &  
        /// error message at second array position 
        /// </summary>
        /// <returns>Array with two values</returns>
        public static object ReturnErrorMsg()
        {
            menuChoiceToReturn[0] = 0;
            menuChoiceToReturn[1] = $"unavailable option.\n\nSo you dont get dissapointed your choice got you " +
                        $"nowhere, here is a website you should visit.\n\nivonazlic.com";
            return menuChoiceToReturn;
        }


    }
}
