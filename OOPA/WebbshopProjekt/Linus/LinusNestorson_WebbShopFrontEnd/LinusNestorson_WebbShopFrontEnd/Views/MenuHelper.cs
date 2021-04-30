using LinusNestorson_WebbShopFrontEnd.Controller;
using System;

namespace LinusNestorson_WebbShopFrontEnd.Views
{
    class MenuHelper
    {
        private static AdminController adminCon = new AdminController();

        /// <summary>
        /// Helper method for checking if input from user is ok.
        /// </summary>
        /// <param name="adminId">Id of loged in admin</param>
        /// <param name="bookId">Id of book</param>
        /// <param name="input">Bool variable to see if input from user was ok</param>
        public static void CheckBookAmountInput(int adminId, int bookId, bool input)
        {
            if (input)
            {
                Console.WriteLine("How many books is in stock?");
                int amount;
                input = int.TryParse(Console.ReadLine(), out amount);
                if (input)
                {
                    Console.WriteLine($"Amount of books set to {adminCon.SetAmount(adminId, bookId, amount)}");
                }
                else if (!input)
                {
                    Console.WriteLine("Please enter a valid amount of books");
                }
            }
            else if (!input)
            {
                Console.WriteLine("Please enter a valid bookId");
            }
        }
        /// <summary>
        /// Helper method for checking if input from user is ok.
        /// </summary>
        /// <param name="input">Bool variable to see if input from user was ok</param>
        /// <param name="method">Bool method too see if executuion was successful or not</param>
        public static void CheckUserInput(bool input, bool method)
        {
            if (input)
            {
                if (method)
                {
                    Console.WriteLine("Action performed");
                }
                else
                {
                    Console.WriteLine("Something went wrong. Are you sure you entered a valid number that exist? Try again");
                }
            }
            else
            {
                Console.WriteLine("Please enter a number");
            }
        }
    }
}