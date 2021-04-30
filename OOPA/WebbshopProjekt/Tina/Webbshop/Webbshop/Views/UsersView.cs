using System;
using System.Threading;
using System.Collections.Generic;
using WebbshopProject.Models;

namespace Webbshop.Views
{
   class UsersView
    {
        /// <summary>
        /// Prints a menu of the user-choices.
        /// </summary>
        /// <param name="userId"></param>
        public static void UserChoices(int userId)
        {
            Console.Clear();
            Console.WriteLine("What do you want to do?");
            Messages.ColorText("[1] List Users\n" +
                "[2] Find User\n[3] Add User\n[4] Promote user\n" +
                "[5] Demote\n[6] Activate user\n[7] Deactivate user\n" +
                "[8] Best customer\n[E] Exit to main",
                ConsoleColor.Yellow);
        }

        /// <summary>
        /// Prints all users in the database.
        /// </summary>
        /// <param name="listOfUsers">A list of users in the database.</param>
        public static void PrintUsers(List<User> listOfUsers)
        {
            foreach (var user in listOfUsers)
            {
                Console.WriteLine(user.Name);
            }
        }
        /// <summary>
        /// Prints the users and if they are active or admin.
        /// </summary>
        /// <param name="listOfUsers"></param>
        public static void PrintUserStats(List<User> listOfUsers)
        {
            foreach (var user in listOfUsers)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine($"{user.Name} ");
                if (user.IsActive)
                {
                    Messages.ColorText("-Is active", ConsoleColor.Green);
                    if (user.IsAdmin)
                    {
                        Messages.ColorText("-Is admin", ConsoleColor.Green);
                    }

                    else
                    {
                        Messages.ColorText("-Is not admin", ConsoleColor.Red);
                    }
                }

                else
                {
                    Messages.ColorText("-Is inactive", ConsoleColor.Red);
                }

                Console.WriteLine("-------------------");
            }
        }
        /// <summary>
        /// Prints the question for input and takes input from user, 
        /// for creating a new user.
        /// </summary>
        /// <returns></returns>
        public static (string username,
            string password) CreateAccountAskUserForInput()
        {
            Console.Clear();
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            return (username, password);
        }
        /// <summary>
        /// Prints the best customer in the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="books"></param>
        public static void PrintBestCustomer(User name, int books)
        {
            Messages.ColorText($"{name} is the best customer " +
                   $"with {books} books bought.", ConsoleColor.Cyan);
        }
        /// <summary>
        /// Prints "pong" when called for.
        /// </summary>
        internal static void PrintIfPinged()
        {
            Messages.ColorText("Pong.", ConsoleColor.Blue);
            Thread.Sleep(1500);
        }
    }
}

