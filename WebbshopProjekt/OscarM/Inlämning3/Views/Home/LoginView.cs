using Inlämning3.Helpers;
using System;

namespace Inlämning3.Views.Home
{
    public class LoginView
    {
        /// <summary>
        ///  lets the user login by asking for username and password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void Display(out string username, out string password)
        {
            Console.WriteLine(@" __        ______     _______  __  .__   __. ");
            Console.WriteLine(@"|  |      /  __  \   /  _____||  | |  \ |  | ");
            Console.WriteLine(@"|  |     |  |  |  | |  |  __  |  | |   \|  | ");
            Console.WriteLine(@"|  |     |  |  |  | |  | |_ | |  | |  . `  | ");
            Console.WriteLine(@"|  `----.|  `--'  | |  |__| | |  | |  |\   | ");
            Console.WriteLine(@"|_______| \______/   \______| |__| |__| \__| ");
            Console.Write("Enter username: ");
            username = Helper.GetUserChoiceText();
            Console.Write("Enter password: ");
            password = Helper.GetUserChoiceText();
        }
    }
}