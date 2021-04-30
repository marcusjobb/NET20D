using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshop.Views.Shared
{
    public static class Messages
    {
        /// <summary>
        /// Prints the successfull login message.
        /// </summary>
        public static void SuccessfullLogin()
        {
            Console.SetCursorPosition(48, 18);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You are successfully logged in.");
            Thread.Sleep(2000);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints the login error message.
        /// </summary>
        public static void LoginError()
        {
            Console.SetCursorPosition(50, 18);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong username or password.");
            Thread.Sleep(2000);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints the account successfully created message.
        /// </summary>
        public static void AccountSuccessfullyCreated()
        {
            Console.SetCursorPosition(55, 18);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Congratulations!");
            Console.CursorLeft = 42;
            Console.WriteLine("Your account has been sucessfully created.");
            Thread.Sleep(3000);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints the account could not be created message.
        /// </summary>
        public static void AccountCouldNotBeCreated()
        {
            Console.SetCursorPosition(53, 18);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Registration failed!");
            Console.CursorLeft = 30;
            Console.WriteLine("The username is taken or the password confirmation does not match.");
            Thread.Sleep(3000);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints the logged in message.
        /// </summary>
        public static void NotLoggedIn()
        {
            Console.SetCursorPosition(52, 18);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You are not logged in.");
            Thread.Sleep(3000);
            Console.ResetColor();
        }
    }
}
