using Inlämning3.Helpers;
using System;
using System.Collections.Generic;

namespace Inlämning3.Views.Admin
{
    internal class ManageUser
    {
        /// <summary>
        /// prints a list of users and lets the user choose a user. Returns the userchoice.
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static int PrintUsers(List<Inlämning2WebbShop.Models.User> users)
        {
            int counter = 1;
            foreach (var user in users)
            {
                Console.WriteLine($"[{counter}] Username: {user.Name}");
                counter++;
            }
            Console.Write("Select the number next to a user you want to manage : ");

            return Helpers.Helper.GetUserChoiceNumber() - 1;
        }

        /// <summary>
        /// lets the user enter a username to search for and returns the input.
        /// </summary>
        /// <returns></returns>
        public static string SearchUsers()
        {
            Console.Write("Enter username to search for: ");
            return Helpers.Helper.GetUserChoiceText();
        }

        /// <summary>
        /// lets the user enter username and password to create a new user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void AddUser(out string username, out string password)
        {
            Console.Write("Enter your username: ");
            username = Helper.GetUserChoiceText();
            Console.Write("Enter your password: ");
            password = Helper.GetUserChoiceText();
        }

        /// <summary>
        /// Confrims with the user if the user wants to promote the chosen user. Returns the user choice in text.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string PromoteUser(Inlämning2WebbShop.Models.User user)
        {
            Console.WriteLine($"are you sure you want do promote {user.Name}? Y/N");
            return Helpers.Helper.GetUserChoiceText().ToUpper();
        }

        /// <summary>
        /// Confrims with the user if the user wants to Demote the chosen user. Returns the user choice in text.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string DemoteUser(Inlämning2WebbShop.Models.User user)
        {
            Console.WriteLine($"are you sure you want do demote {user.Name}? Y/N");
            return Helpers.Helper.GetUserChoiceText().ToUpper();
        }

        /// <summary>
        /// Confrims with the user if the user wants to Activate the chosen user. Returns the user choice in text.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string ActivateUser(Inlämning2WebbShop.Models.User user)
        {
            Console.WriteLine($"are you sure you want do activate {user.Name}? Y/N");
            return Helpers.Helper.GetUserChoiceText().ToUpper();
        }

        /// <summary>
        /// Confrims with the user if the user wants to Deactivate the chosen user. Returns the user choice in text.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string DeactivateUser(Inlämning2WebbShop.Models.User user)
        {
            Console.WriteLine($"are you sure you want do Deactivate {user.Name}? Y/N");
            return Helpers.Helper.GetUserChoiceText().ToUpper();
        }
    }
}