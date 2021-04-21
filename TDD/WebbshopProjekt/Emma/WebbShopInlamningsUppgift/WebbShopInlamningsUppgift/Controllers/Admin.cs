using System;
using WebbShopInlamningsUppgift.Helpers;

namespace WebbShopInlamningsUppgift.Controllers
{
    /// <summary>
    /// Admin allows you to run a scenario with an imaginary admin-user
    /// </summary>
    class Admin
    {
        /// <summary>
        /// Runs the scenario
        /// </summary>
        public static void Run()
        {
            var api = new WebbShopAPI();

            Console.Write("Logged in as: ");
            int userId = api.Login("Administrator", "CodicRulez");
            Console.WriteLine(userId);

            //-------------------------------------------------------------------------

            Console.WriteLine("Adding new book... ");
            bool success = api.AddBook(userId, "Sagan om ringen", "J.R.R Tolkien", 300, 5);
            if (success)
            {
                Console.WriteLine("Added book: Sagan om ringen by J.R.R Tolkien");
            }

            //-------------------------------------------------------------------------

            Console.WriteLine("Setting amount... ");
            success = api.SetAmount(userId, 2, 4);
            if (success)
            {
                Console.WriteLine("Successfully added new amount.");
            }

            //-------------------------------------------------------------------------
            Console.WriteLine("Searching for all users...");
            var list = api.ListUsers(userId);
            foreach (var user in list)
            {
                Console.WriteLine(user.Name);
            }

            //-------------------------------------------------------------------------

            Console.WriteLine("Searching for all users matching keyword \"te\"... ");
            list = api.FindUser(userId, "te");
            foreach (var user in list)
            {
                Console.WriteLine(user.Name);
            }

            //-------------------------------------------------------------------------
            
            var book = Helper.GetBookObject("Sagan om ringen");
            if (book != null)
            {
                Console.WriteLine($"Updating {book.Title} with new price 350...");
                success = api.UpdateBook(userId, book.ID, book.Title, book.Author, 350);
                if (success)
                {
                    Console.WriteLine("Sucessfully updated book");
                }
            }

            //-------------------------------------------------------------------------

            Console.WriteLine("Adding new category... ");
            success = api.AddCategory(userId, "Fantasy");
            if (success)
            {
                Console.WriteLine("Added category: Fantasy");
            }

            Console.WriteLine("Adding new category... ");
            success = api.AddCategory(userId, "Action");
            if (success)
            {
                Console.WriteLine("Added category: Action");
            }

            //-------------------------------------------------------------------------

            Console.WriteLine("Adding book to category... ");
            var bookId = Helper.GetBookID("Sagan om ringen");
            var categoryId = Helper.GetCategoryId("Fantasy");

            success = api.AddBookToCategory(userId, bookId, categoryId);
            if (success)
            {
                Console.WriteLine("Successfully added book Sagan om ringen to category Fantasy");
            }

            //-------------------------------------------------------------------------

            Console.WriteLine("Updating category... ");
            categoryId = Helper.GetCategoryId("Action");
            success = api.UpdateCategory(userId, categoryId, "ActionPower");
            if (success)
            {
                Console.WriteLine("Successfully updated category genere Action to ActionPower.");
            }

            //-------------------------------------------------------------------------

            Console.WriteLine("Adding new user... ");
            success = api.AddUser(userId, "Legolas", "L3mb4sBr34d");
            if (success)
            {
                Console.WriteLine("Successfully added user: Legolas");
            }

            //-------------------------------------------------------------------------

            Console.WriteLine("Promoting \"Legolas\"... ");
            var customerId = Helper.GetUserID("Legolas");
            success = api.Promote(userId, customerId);
            if (success)
            {
                Console.WriteLine("Sucessfully promoted Legolas to Admin");
            }

            api.Logout(userId);

            //-------------------------------------------------------------------------

            Console.Write("Logged in as: ");
            userId = api.Login("Legolas", "L3mb4sBr34d");
            Console.WriteLine(userId);

            Console.WriteLine("Purchasing \"Sagan om ringen\"... ");
            bookId = Helper.GetBookID("Sagan om ringen");
            success = api.BuyBook(userId, bookId);
            if (success)
            {
                Console.WriteLine("Purchase successful.");
            }

            Console.WriteLine("Purchasing \"Sagan om ringen\"... ");
            success = api.BuyBook(userId, bookId);
            if (success)
            {
                Console.WriteLine("Purchase successful.");
            }

            Console.WriteLine("Purchasing \"Sagan om ringen\"... ");
            success = api.BuyBook(userId, bookId);
            if (success)
            {
                Console.WriteLine("Purchase successful.");
            }

            api.Logout(userId);

            //-------------------------------------------------------------------------

            Console.Write("Logged in as: ");
            userId = api.Login("Administrator", "CodicRulez");
            Console.WriteLine(userId);

            Console.WriteLine("Searching for all sold items...");
            var soldBooks = api.SoldItems(userId);
            if(soldBooks.Count > 0)
            {
                foreach(var item in soldBooks)
                {
                    Console.WriteLine($"{item.Title} - {item.Author}");
                }
            }

            Console.WriteLine("Searching for total price of all sold items... ");
            int moneyEarned = api.MoneyEarned(userId);
            if(moneyEarned > 0)
            {
                Console.WriteLine($"Money earned: {moneyEarned}");
            }

            Console.WriteLine("Searching \"Best customer\"... ");
            int bestCustomer = api.BestCustomer(userId);
            if(bestCustomer > 0)
            {
                Console.WriteLine($"Best customer's ID: {bestCustomer}");
            }

            Console.WriteLine("Deleting book \"I Robot\"... ");
            bookId = Helper.GetBookID("I Robot");
            success = api.DeleteBook(userId, bookId);
            if (success)
            {
                Console.WriteLine("Successfully deleted book");
            }

            Console.WriteLine("Deleting category \"Romance\"... ");
            categoryId = Helper.GetCategoryId("Romance");
            success = api.DeleteCategory(userId, categoryId);
            if (success)
            {
                Console.WriteLine("Successfully deleted category");
            }

            Console.WriteLine("Deleting category \"Fantasy\"... ");
            categoryId = Helper.GetCategoryId("Fantasy");
            success = api.DeleteCategory(userId, categoryId);
            if (success)
            {
                Console.WriteLine("Successfully deleted category");
            }

            api.Logout(userId);
        }
    }
}
