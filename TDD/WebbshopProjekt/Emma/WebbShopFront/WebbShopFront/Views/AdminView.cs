using System;
using System.Collections.Generic;
using WebbShopInlamningsUppgift.Models;

namespace WebbShopFrontInlamning.Views
{
    /// <summary>
    /// Displays the view for Admin
    /// </summary>
    class AdminView
    {
        /// <summary>
        /// Displays the start page, asking user to login upon entering
        /// </summary>
        public static void StartPage()
        {
            Console.WriteLine();
            Console.WriteLine("You have to be logged in to proceed.");
        }

        /// <summary>
        /// Displays Admin meny
        /// </summary>
        public static void AdminPage()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add book");
            Console.WriteLine("2. Set Amount");
            Console.WriteLine("3. View all users");
            Console.WriteLine("4. Find user");
            Console.WriteLine("5. Update book");
            Console.WriteLine("6. Delete book");
            Console.WriteLine("7. Add category");
            Console.WriteLine("8. Add a book to category");
            Console.WriteLine("9. Update category");
            Console.WriteLine("10. Delete category");
            Console.WriteLine("11. Add a new user");
            Console.WriteLine("12. View all sold items");
            Console.WriteLine("13. View total income");
            Console.WriteLine("14. View best customer");
            Console.WriteLine("15. Promote user");
            Console.WriteLine("16. Demote user");
            Console.WriteLine("17. Activate user");
            Console.WriteLine("18. Inactivate user");
            Console.WriteLine("19. Return to main meny");

        }

        /// <summary>
        /// Displays fail message if user is not admin
        /// </summary>
        public static void VerifyAdminFailed()
        {
            Console.WriteLine();
            Console.WriteLine("You're not authorized.");
        }

        /// <summary>
        /// Displays the information needed to add book
        /// </summary>
        public static void AddBookPage()
        {
            Console.WriteLine();
            Console.WriteLine("Please fill in the following");
            Console.WriteLine("1. Title");
            Console.WriteLine("2. Author");
            Console.WriteLine("3. Price");
            Console.WriteLine("4. Amount");
        }

        /// <summary>
        /// Asks for which book will be added to category
        /// </summary>
        public static void AddBookCategory()
        {
            Console.WriteLine();
            Console.WriteLine("Which book would you like to add to category? You can search by title");
        }

        /// <summary>
        /// Displays the information needed to add category
        /// </summary>
        public static void AddCategoryPage()
        {
            Console.WriteLine();
            Console.WriteLine("Please fill in the following");
            Console.WriteLine("1. Genere");
        }

        /// <summary>
        /// Displays the information needed to update book
        /// </summary>
        public static void UpdateBookPage()
        {
            Console.WriteLine();
            Console.WriteLine("Please fill in the following");
            Console.WriteLine("1. Title");
            Console.WriteLine("2. Author");
            Console.WriteLine("3. Price");
        }

        /// <summary>
        /// Displays the information needed to update category
        /// </summary>
        public static void UpdateCategoryPage()
        {
            Console.WriteLine();
            Console.WriteLine("Please fill in the following");
            Console.WriteLine("1. genere");
        }

        /// <summary>
        /// Displays the information needed to set a new book amount
        /// </summary>
        public static void SetAmountPage()
        {
            Console.WriteLine();
            Console.WriteLine("Please fill in the following ");
            Console.WriteLine("1. Book number: ");
            Console.WriteLine("2. New amount: ");
        }

        /// <summary>
        /// Displays the information needed to search
        /// </summary>
        public static void SearchPage()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter search word: ");
        }

        /// <summary>
        /// Displays the information for best customer
        /// </summary>
        public static void DisplayBestCustomer(int customerId)
        {
            Console.WriteLine();
            Console.WriteLine($"Best customer with the most bought books, has ID: {customerId}");
        }

        /// <summary>
        /// Displays the information for the total of sold books
        /// </summary>
        public static void DisplayMoneyEarned(int totalIncome)
        {
            Console.WriteLine();
            Console.WriteLine($"Total income: {totalIncome}");
        }

        /// <summary>
        /// Displays a list of users
        /// </summary>
        public static void DisplayUsers(List<Users> listOfUsers)
        {
            Console.WriteLine();
            Console.WriteLine("Result for users: ");
            foreach(var user in listOfUsers)
            {
                Console.WriteLine($"{user.ID}.{user.Name}");
            }
        }

        /// <summary>
        /// Displays all sold books
        /// </summary>
        public static void DisplaySoldItems(List<SoldBooks> listOfSoldItems)
        {
            Console.WriteLine();
            Console.WriteLine("Search result for books: ");
            foreach (var book in listOfSoldItems)
            {
                Console.WriteLine($"{book.ID}.{book.Title} - By: {book.Author}\nAmount: {book.Amount} Purchase date: {book.PurchaseDate}");
            }
        }

    }
}
