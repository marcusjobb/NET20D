using BookShopFrontEnd.Views;
using System;
using System.Collections.Generic;
using System.Threading;
using WebbShopAPI.Models;

namespace BookShopFrontEnd.Utility
{
    /// <summary>
    /// Frequently used printouts.
    /// </summary>
    public class ExtractedView
    {
        /// <summary>
        /// Gives a notification based on if a boolean is true or false.
        /// </summary>
        /// <param name="success">bool.</param>
        public static void SuccessDBCalls(bool success)
        {
            if (success)
            {
                Console.WriteLine($"Database has successfully been updated.");
                Thread.Sleep(1500);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops something went wrong! Try again!");
                Thread.Sleep(1500);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Prints out users from a list.
        /// </summary>
        /// <returns>User.</returns>
        public static User SelectUserFromList(List<User> users)
        {
            int userIndex;
            Console.WriteLine("Here are all users:");
            Console.WriteLine("====================================================================");
            ExtractedView.PrintUserCredentials(users);
            userIndex = ExtractedLogic.GetUserInput(users);
            return users[userIndex];
        }

        /// <summary>
        /// Prints out books from a list.
        /// </summary>
        /// <param name="bookList"></param>
        public static void DisplayBooks(List<Book> bookList)
        {
            int index = 1;
            foreach (var book in bookList)
            {
                Console.WriteLine($"{index}: {book.Title}");
                Console.WriteLine($"Author: {book.Author.FullName}");
                if (book.Categories == null) { Console.WriteLine("Category: Not Implemented."); }
                else { Console.WriteLine($"Category: {book.Categories.Title}"); }
                Console.WriteLine($"{book.Price};-");
                Console.WriteLine($"{book.Stock}st");
                Console.WriteLine("========================================");
                index++;
            }
        }

        /// <summary>
        /// Prints out books from a list.
        /// </summary>
        /// <param name="bookList">List<Book>.</param>
        public static void DisplaySoldBooks(List<SoldBook> bookList)
        {
            int index = 1;
            foreach (var book in bookList)
            {
                Console.WriteLine($"Number: {index}");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author.FullName}");
                if (book.Categories != null) { Console.WriteLine($"Category: {book.Categories.Title}"); }
                else { Console.WriteLine("Category: Not implemented"); }
                Console.WriteLine($"{book.Price};-");
                Console.WriteLine("========================================");

                index++;
            }
        }

        /// <summary>
        /// Prints some credentials from a given list of users.
        /// </summary>
        /// <param name="list"></param>
        public static void PrintUserCredentials(List<User> list)
        {
            int index = 1;
            if (list.Count > 0)
            {
                foreach (var user in list)
                {
                    Console.WriteLine($"number: {index}");
                    Console.WriteLine($"Admin: {user.Admin}");
                    Console.WriteLine($"Full name: {user.FullName}");
                    Console.WriteLine($"Username: {user.Username}");
                    Console.WriteLine($"Active account: {user.IsActive}");
                    Console.WriteLine($"Last login:{user.LastLogIn}");
                    Console.WriteLine("========================================");
                    index++;
                }
            }
            else { Console.WriteLine("There are no users matching the requirements currently in the database."); }
        }

        /// <summary>
        /// Sets all the details for a book.
        /// </summary>
        /// <returns>List<Dynamic>.</returns>
        public static List<dynamic> SetBookDetails(List<Category> categories)
        {
            string title, firstName, surname, category;
            int price, stock;
            var dynamicList = new List<dynamic>();

            Console.Write("\nTitle: ");
            title = Console.ReadLine();
            Console.Write("Author first name: ");
            firstName = Console.ReadLine();
            Console.Write("Author surname: ");
            surname = Console.ReadLine();            
            DisplayCategories(categories);
            Console.Write("Category: ");
            var input = Helper.GetInputForOptions(1, categories.Count);
            int index = input - 1;
            category = categories[index].Title;
            Console.Write("(Only numbers) Price: ");
            string stringPrice = Console.ReadLine();
            price = Helper.ConvertToInt(stringPrice);
            Console.Write("(Only numbers) Stock: ");
            string stringStock = Console.ReadLine();
            stock = Helper.ConvertToInt(stringStock);
            Console.WriteLine("==========================");
            Console.Clear();
            Console.WriteLine("Is this correct?:");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Author first name: {firstName}");
            Console.WriteLine($"Author surname: {surname}");
            Console.WriteLine($"Category: {category}");
            Console.WriteLine($"Price: {price};-");
            Console.WriteLine($"Stock: {stock}st");
            Console.WriteLine("==========================");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            int answer = Helper.GetInputForOptions(1, 2);

            if (answer == 1)
            {
                dynamicList.Add(title);
                dynamicList.Add(firstName);
                dynamicList.Add(surname);
                dynamicList.Add(category);
                dynamicList.Add(price);
                dynamicList.Add(stock);
            }
            else { Admin.UpdateBook(); }
            return dynamicList;
        }

        /// <summary>
        /// Sets details for a book but skips category.
        /// </summary>
        /// <returns>List<Category>.</returns>
        public static List<dynamic> SetBookDetailsNoCategory()
        {
            string title, firstName, surname;
            int price, stock;
            var dynamicList = new List<dynamic>();
            Console.Write("Title: ");
            title = Console.ReadLine();
            Console.Write("Author first name: ");
            firstName = Console.ReadLine();
            Console.Write("Author surname: ");
            surname = Console.ReadLine();
            Console.Write("(Only numbers) Price: ");
            string stringPrice = Console.ReadLine();
            price = Helper.ConvertToInt(stringPrice);
            Console.Write("(Only numbers) Stock: ");
            string stringStock = Console.ReadLine();
            stock = Helper.ConvertToInt(stringStock);
            Console.WriteLine("==========================");
            Console.Clear();
            Console.WriteLine("Is this correct?:");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Author first name: {firstName}");
            Console.WriteLine($"Author surname: {surname}");
            Console.WriteLine($"Price: {price};-");
            Console.WriteLine($"Stock: {stock}st");
            Console.WriteLine("==========================");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            int answer = Helper.GetInputForOptions(1, 2);

            if (answer == 1)
            {
                dynamicList.Add(title);
                dynamicList.Add(firstName);
                dynamicList.Add(surname);
                dynamicList.Add(price);
                dynamicList.Add(stock);
            }
            else { Admin.UpdateBook(); }
            return dynamicList;
        }

        /// <summary>
        /// Prints out all categories.
        /// </summary>
        /// <param name="categoryList">List<Category>.</param>
        public static void DisplayCategories(IEnumerable<Category> categoryList)
        {
            Console.WriteLine("Here are all the current categories: ");
            Console.WriteLine("========================================");
            int index = 1;
            foreach (var category in categoryList)
            {
                Console.WriteLine($"{index}: {category.Title}");
                index++;
            }
        }
    }
}
