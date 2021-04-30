using Inlamning2TrialRunHE.Models;
using System;

namespace Inlamning3HakanEriksson.Views
{
    public class ViewMenues
    {   
        /// <summary>
        /// This is the menu a logged in Administrator gets access to.
        /// </summary>
        /// <param name="user"></param>
        public static void AdminMenu(User user)
        {
            Console.WriteLine($"Welcome {user.Name}. What do you want to do?");
            Console.WriteLine("1. Add a book.");
            Console.WriteLine("2. Set amount of books.");
            Console.WriteLine("3. List User.");
            Console.WriteLine("4. Find user.");
            Console.WriteLine("5. Update a book.");
            Console.WriteLine("6. Delete a book.");
            Console.WriteLine("7. Add a category");
            Console.WriteLine("8. Add a book to category.");
            Console.WriteLine("9. Update a category.");
            Console.WriteLine("10. Delete a category.");
            Console.WriteLine("11. Add a user.");
            Console.WriteLine("12. Log out and exit.");
        }
        /// <summary>
        /// This is the menu a logged in User gets access to.
        /// </summary>
        /// <param name="user"></param>
        public static void LoggedInUserMenu(User user)
        {
            Console.WriteLine($"Welcome {user.Name}. What do you want to do?");
            Console.WriteLine("1. Buy a book.");
            Console.WriteLine("2. Get all categories.");
            Console.WriteLine("3. Get categories by keyword.");
            Console.WriteLine("4. Get books from a category.");
            Console.WriteLine("5. Search books by keyword.");
            Console.WriteLine("6. Search books by authors using a keyword.");
            Console.WriteLine("7. Show books in stock.");
            Console.WriteLine("8. Log out and exit.");
        }
        /// <summary>
        /// This is the menu everyone sees before logging in.
        /// </summary>
        public static void startMenu()
        {
            Console.WriteLine("Welcome to the book store.");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Register a new user.");
            Console.WriteLine("2. Log in.");
            Console.WriteLine("3. Exit.");
        }
    }
}