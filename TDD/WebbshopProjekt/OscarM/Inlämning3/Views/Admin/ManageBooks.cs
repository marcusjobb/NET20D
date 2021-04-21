using Inlämning2WebbShop.Models;
using System;
using System.Collections.Generic;

namespace Inlämning3.Views.Admin
{
    internal class ManageBooks
    {
        /// <summary>
        /// ask admin for input to create a new book.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        public static void AddNewBook(out string title, out string author, out int price, out int amount)
        {
            Console.Write("Enter Title: ");
            title = Helpers.Helper.GetUserChoiceText();
            Console.Write("Enter Author: ");
            author = Helpers.Helper.GetUserChoiceText();
            Console.WriteLine("Enter Price: ");
            price = Helpers.Helper.GetUserChoiceNumber();
            Console.WriteLine("Enter Amount: ");
            amount = Helpers.Helper.GetUserChoiceNumber();
        }

        /// <summary>
        /// asks admin for a bookname and a categoryName.
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="categoryName"></param>
        public static void AddBookToCategory(out string bookName, out string categoryName)
        {
            Console.Write("Enter title of the book you want to add a category to: ");
            bookName = Console.ReadLine();
            Console.Write($"Enter the name of the category that you want to add to {bookName}: ");
            categoryName = Console.ReadLine();
        }

        /// <summary>
        /// asks admin for a bookname, title, author, and a price.
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        public static void UpdateBook(out string bookName, out string title, out string author, out int price)
        {
            Console.Write("Enter the name of the book that you want to update: ");
            bookName = Console.ReadLine();
            Console.Write("Enter the new title of the book: ");
            title = Console.ReadLine();
            Console.Write("Enter the new author of the book: ");
            author = Console.ReadLine();
            Console.Write("Enter the new price of the book: ");
            price = Helpers.Helper.GetUserChoiceNumber();
        }

        /// <summary>
        /// Lets the admin enter the name of the book to delete.
        /// </summary>
        /// <returns></returns>
        public static string DeleteBook()
        {
            Console.Write("Enter the name of the book you want to delete: ");
            return Helpers.Helper.GetUserChoiceText();
        }

        /// <summary>
        /// asks the admin for a categoryname that the admin wants to add. Returns the choice in text.
        /// </summary>
        /// <returns></returns>
        public static string AddCategory()
        {
            Console.Write("Enter the name of the category you want to Add: ");
            return Helpers.Helper.GetUserChoiceText();
        }

        /// <summary>
        /// lists categories and lets the admin choose a category to update, also lets the user enter a new category name,
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="categoryToChange"></param>
        /// <param name="newCategoryName"></param>
        public static void UpdateCategory(List<BookCategory> categories, out BookCategory categoryToChange, out string newCategoryName)
        {
            int choice;
            int count = 1;
            do
            {
                foreach (var category in categories)
                {
                    Console.WriteLine($"[{count}] {category}");
                    count++;
                }
                Console.Write("Select the number next to the category that you want to update: ");
                choice = Helpers.Helper.GetUserChoiceNumber();
                if (choice < 0 || choice > categories.Count)
                {
                    Console.WriteLine("Not valid choice, try again!");
                }
            } while (choice < 0 || choice > categories.Count);

            categoryToChange = categories[choice - 1];
            Console.WriteLine("Enter new name of the category: ");
            newCategoryName = Console.ReadLine();
        }

        /// <summary>
        /// prints a list of bookcategories and lets the admin choose which of the categories to delete.
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="chosenCategory"></param>
        public static void DeleteCategory(List<BookCategory> categories, out BookCategory chosenCategory)
        {
            int choice;
            int count = 1;
            do
            {
                foreach (var category in categories)
                {
                    Console.WriteLine($"[{count}] {category}");
                    count++;
                }
                Console.Write("Select the number next to the category that you want to delete: ");
                choice = Helpers.Helper.GetUserChoiceNumber();
                if (choice < 0 || choice > categories.Count)
                {
                    Console.WriteLine("Not valid choice, try again!");
                }
            } while (choice < 0 || choice > categories.Count);

            chosenCategory = categories[choice - 1];
        }

        /// <summary>
        /// asks the admin for a bookname, and a amount number.
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="amount"></param>
        public static void SetAmount(out string bookName, out int amount)
        {
            Console.WriteLine("Enter the title of the book that you want to set amount : ");
            bookName = Helpers.Helper.GetUserChoiceText();
            Console.WriteLine("enter amount: ");
            amount = Helpers.Helper.GetUserChoiceNumber();
        }
    }
}