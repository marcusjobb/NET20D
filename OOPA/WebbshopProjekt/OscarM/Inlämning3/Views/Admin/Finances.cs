using Inlämning2WebbShop.Models;
using Inlämning3.Helpers;
using System;
using System.Collections.Generic;

namespace Inlämning3.Views.Admin
{
    internal class Finances
    {
        /// <summary>
        /// prints how much money the store has earnedö
        /// </summary>
        /// <param name="money"></param>
        public static void MoneyEarned(double money)
        {
            Console.WriteLine($"Money earned : {money}");
        }

        /// <summary>
        /// shows all soldbooks if there are any.
        /// </summary>
        /// <param name="soldBooks"></param>
        public static void ShowSoldBooks(List<SoldBook> soldBooks)
        {
            if (soldBooks.Count > 0)
            {
                foreach (var book in soldBooks)
                {
                    Console.WriteLine($"title: {book.Title} price: {book.Price}");
                }
            }
            else
            {
                Messages.ErrorMessage();
            }
        }

        /// <summary>
        /// prints the user who have bought the most books.
        /// </summary>
        /// <param name="user"></param>
        public static void ShowBestCustomer(Inlämning2WebbShop.Models.User user)
        {
            Console.WriteLine("User with most purchased books: \n");
            Console.WriteLine(user);
        }
    }
}