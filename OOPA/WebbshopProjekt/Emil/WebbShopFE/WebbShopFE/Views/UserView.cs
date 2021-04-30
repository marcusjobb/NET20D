using System;
using System.Collections.Generic;
using System.Threading;
using WebbShopEmil.Models;
using WebbShopFE.Helper;

namespace WebbShopFE.Views
{
    /// <summary>
    /// Methods that prints out info concerning users.
    /// </summary>
    public static class UserView
    {
        /// <summary>
        /// Prints out info if admin is logged in.
        /// </summary>
        /// <param name="user"></param>
        public static void AdminIsLoggedIn(User user)
        {
            HelpMethods.GreenTextWL($"You ar logged in as admin: {user.Name}");
        }

        /// <summary>
        /// Prints out best customer.
        /// </summary>
        /// <param name="user"></param>
        public static void DisplayBestCustomer(User user)
        {
            Console.WriteLine($"Best customer: {user.Name}");
        }

        /// <summary>
        /// Prints out info if the user is registered.
        /// </summary>
        /// <param name="userName"></param>
        public static void IsRegistered(string userName)
        {
            HelpMethods.GreenTextWL($"{userName} is registered!");
        }

        /// <summary>
        /// Logging out message.
        /// </summary>
        public static void LoggingOut()
        {
            HelpMethods.BlueTextWL("Logging out......");
            Thread.Sleep(1500);
        }

        /// <summary>
        /// Takes in a list
        /// and prints out info about users.
        /// </summary>
        /// <param name="users"></param>
        public static void ShowUsers(List<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine(
                    $"(Id:{user.Id}) " +
                    $"(Name: {user.Name}) " +
                    $"(Is active: {user.IsActive}) " +
                    $"(Is admin: {user.IsAdmin})");
            }
        }

        /// <summary>
        /// Prints out info if user is logged in.
        /// </summary>
        /// <param name="user"></param>
        public static void UserIsLoggedIn(User user)
        {
            HelpMethods.GreenTextWL($"You ar logged in as user: {user.Name}");
        }
    }
}