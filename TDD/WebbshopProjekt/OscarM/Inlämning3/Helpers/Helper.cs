using System;

namespace Inlämning3.Helpers
{
    public static class Helper
    {
        /// <summary>
        /// try to parse input to string, and returns the result.
        /// </summary>
        /// <returns></returns>
        public static int GetUserChoiceNumber()
        {
            int.TryParse(Console.ReadLine(), out int choice);
            return choice;
        }

        /// <summary>
        /// returns user input in text
        /// </summary>
        /// <returns></returns>
        public static string GetUserChoiceText()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// check ping result, and sets the account IsLoggedIn property to false if the result is an empty string
        /// </summary>
        /// <param name="pingResult"></param>
        public static void CheckPing(string pingResult)
        {
            if (pingResult == string.Empty)
            {
                Account.IsLoggedIn = false;
            }
        }
    }
}