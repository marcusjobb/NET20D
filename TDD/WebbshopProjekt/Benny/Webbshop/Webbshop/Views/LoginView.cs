using System;

namespace Webbshop.Views
{
    internal static class LoginView
    {
        /// <summary>
        /// Prints loginpage and takes input
        /// </summary>
        /// <returns>Returns username and password</returns>
        public static (string userName, string password) PrintLoginPage()
        {
            SharedView.PrintWithDarkGreyText("Logga in\n");
            Console.WriteLine("\tAvbryt när som helst genom att trycka x+enter");
            Console.Write("\tAnvändarnamn> ");
            var userName = Console.ReadLine();
            if (userName.ToLower() == "x")
            {
                return (userName.ToLower(), string.Empty);
            }
            Console.Write("\tLösenord> ");
            var password = Console.ReadLine();

            if (password.ToLower() == "x")
            {
                return (string.Empty, password.ToLower());
            }
            return (userName, password);
        }
    }
}