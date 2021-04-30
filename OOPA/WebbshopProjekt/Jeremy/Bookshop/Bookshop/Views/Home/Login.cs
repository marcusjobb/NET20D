using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.Home
{
    public static class Login
    {
        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Register", "Back"};

        /// <summary>
        /// Prints the login page.
        /// </summary>
        public static void PrintLoginPage()
        {
            Console.SetCursorPosition(38, 12);
            Console.WriteLine("Username:" + new string(' ', 56));
            Console.CursorLeft = 38;
            Console.WriteLine("Password:" + new string(' ', 56));
        }

        /// <summary>
        /// Prints the login page and lets the user enter the username and password.
        /// </summary>
        /// <returns>The username and password.</returns>
        public static List<string> UseLoginPage()
        {
            List<string> userInput = new List<string>();

            Console.SetCursorPosition(50, 12);
            Console.CursorVisible = true;
            userInput.Add(Console.ReadLine());
            Console.CursorLeft = 50;
            userInput.Add(Console.ReadLine());
            Console.CursorVisible = false;

            return userInput;
        }

        /// <summary>
        /// Prints whitespaces to remove the login message.
        /// </summary>
        public static void RemoveLoginMessage()
        {
            Console.SetCursorPosition(33, 18);
            Console.WriteLine(new string(' ', 70));
        }
    }
}
