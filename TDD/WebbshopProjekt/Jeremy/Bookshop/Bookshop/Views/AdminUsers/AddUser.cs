using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshop.Views.AdminUsers
{
    public static class AddUser
    {
        /// <summary>
        /// The menu options.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "List users", "Find user", 
            "Back"};

        /// <summary>
        /// Prints the add user page.
        /// </summary>
        public static void PrintAddUserPage()
        {
            Console.SetCursorPosition(38, 12);
            Console.WriteLine("Username:" + new string(' ', 56));
            Console.CursorLeft = 38;
            Console.WriteLine("Password:" + new string(' ', 56));
        }

        /// <summary>
        /// Prints the add user page and lets the user enter a username and a password for the new 
        /// user.
        /// </summary>
        /// <returns></returns>
        public static List<string> UseAddUserPage()
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
        /// Prints the confirm message.
        /// </summary>
        public static void Confirm()
        {
            Console.SetCursorPosition(42, 15);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Are you sure you want to create this user?");
            Console.ResetColor();
        }

        /// <summary>
        /// Prints that the user does already exist.
        /// </summary>
        public static void UserDoesAlreadyExist()
        {
            Console.SetCursorPosition(49, 18);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The user does already exist.");
            Thread.Sleep(3000);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints that the user is successfully created.
        /// </summary>
        public static void UserSuccessfullyCreated()
        {
            Console.SetCursorPosition(47, 18);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The user is successfully created.");
            Thread.Sleep(3000);
            Console.ResetColor();
        }
    }
}
