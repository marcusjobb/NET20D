using System;
using System.Collections.Generic;
using WebbShop.Models;

namespace WebbutikFrontend.Views.Shared
{
    public static class Display
    {
        /// <summary>
        /// Shows all the details about a specified <paramref name="book"/>
        /// including the available amount.
        /// </summary>
        /// <param name="book"></param>
        public static void BookDetails(Book book, string prefix = "")
        {
            Console.Write($"{prefix}{book.Title}, {book.Author}, ");
            if (book.Category != null)
            {
                Console.Write($"{book.Category.Name}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("unknown");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine($", {book.Amount} st, {book.Price} kr");
        }

        /// <summary>
        /// Shows all the books in <paramref name="books"/>
        /// in a menu like manner.
        /// </summary>
        /// <param name="books"></param>
        /// <returns>The highest choice available
        /// to make from the menu.</returns>
        public static int Books(List<Book> books, string option)
        {
            Console.WriteLine($"\n\tChoose a book to {option}:");
            var ctr = 1;
            foreach (var book in books)
            {
                Console.Write($"\t{ctr++}. ");
                BookDetails(book);
            }

            Console.WriteLine($"\t{ctr}. None of the above");
            return ctr;
        }

        /// <summary>
        /// Shows all the categories in <paramref name="categories"/>
        /// in a menu like manner.
        /// </summary>
        /// <param name="categories"></param>
        /// <returns>The highest choice available
        /// to make from the menu.</returns>
        public static int Categories(List<BookCategory> categories)
        {
            Console.WriteLine("\n\tChoose a category:");
            var ctr = 1;
            foreach (var category in categories)
            {
                Console.WriteLine($"\t{ctr++}. {category.Name}");
            }

            Console.WriteLine($"\t{ctr}. None of the above");
            return ctr;
        }

        /// <summary>
        /// Shows the details of the specified <paramref name="user"/>.
        /// </summary>
        /// <param name="user"></param>
        public static void UserDetails(User user, string prefix = "")
        {
            Console.WriteLine($"{prefix}Name: {user.Name}, " +
                    $"Password: {user.Password}, " +
                    $"Active: {user.IsActive}, " +
                    $"Admin: {user.IsAdmin}");
        }

        /// <summary>
        /// Shows all the users in <paramref name="users"/>
        /// in a menu like manner.
        /// </summary>
        /// <param name="users"></param>
        /// <returns>The highest choice available
        /// to make from the menu.</returns>
        public static int Users(List<User> users)
        {
            Console.WriteLine("\n\tChoose a user:");
            var ctr = 1;
            foreach (var user in users)
            {
                Console.Write($"\t{ctr++}. ");
                UserDetails(user);
            }

            Console.WriteLine($"\t{ctr}. None of the above");
            return ctr;
        }
    }
}
