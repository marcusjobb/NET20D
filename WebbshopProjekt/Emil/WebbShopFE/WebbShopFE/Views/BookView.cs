using System;
using System.Collections.Generic;
using WebbShopEmil.Models;
using WebbShopFE.Helper;

namespace WebbShopFE.Views
{
    /// <summary>
    /// Methods that prints out info concerning books.
    /// </summary>
    public static class BookView
    {
        /// <summary>
        /// Prints out earned money.
        /// </summary>
        /// <param name="money"></param>
        public static void DisplayMoney(int money)
        {
            Console.WriteLine($"Earned money: {money}");
        }

        /// <summary>
        /// Prints out new book amount.
        /// </summary>
        /// <param name="amount"></param>
        public static void NewAmount(int amount)
        {
            HelpMethods.GreenTextWL($"New book amount is: {amount}");
        }

        /// <summary>
        /// Takes in a list of books
        /// and prints out info about books in list.
        /// </summary>
        /// <param name="books"></param>
        public static void ShowBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(
                   $"(Id: {book.Id}.)" +
                   $" (Title: {book.Title})" +
                   $" (Author: {book.Author})" +
                   $" (Price: {book.Price})" +
                   $" (Amount: {book.Amount})"
                  );
            }
        }

        /// <summary>
        /// Takes in a list of sold books
        /// and prints out the titles of sold books.
        /// </summary>
        /// <param name="soldItems"></param>
        public static void ShowSoldItems(List<SoldBook> soldItems)
        {
            foreach (var sold in soldItems)
            {
                Console.WriteLine($"Title: {sold.Title}");
            }
        }
    }
}