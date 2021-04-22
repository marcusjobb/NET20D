using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebbShopAPI.Data;
using WebbShopAPI.Mockdata;
using WebbShopAPI.Models;
using WebbShopAPI.Seeder;

namespace WebbShopAPI
{
    /// <summary>
    /// Tests of all the methods in the API-class are done here.
    /// </summary>
    public static class Tests
    {
        /// <summary>
        /// Displays total amount of money earned.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void MoneyEarned(int adminID)
        {
            int moneyEarned = new WebShopAPI().MoneyEarned(adminID);
            Console.WriteLine($"Total amount of money earned: {moneyEarned}kr");
        }

        /// <summary>
        /// Displays all items sold.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void SoldItems(int adminID)
        {
            foreach (var item in new WebShopAPI().SoldItems(adminID))
            {
                Console.WriteLine(item.Title);
            };
        }

        /// <summary>
        /// Displays all books by a given author > "Lee Child".
        /// </summary>
        public static void GetBooksByAuthor()
        {
            foreach (var item in WebShopAPI.GetBooksByAuthor("Lee", "Child"))
            {
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Category: {item.Categories.Title}");
                Console.WriteLine($"Author: {item.Author.FullName}");
                Console.WriteLine($"Stock: {item.Stock} st");
                Console.WriteLine($"Price: {item.Price};-");
                Console.WriteLine("__________________________________");
            }
        }

        /// <summary>
        /// Displays all books in given category > "Horror".
        /// </summary>
        public static void GetBooksByCategory()
        {
            foreach (var item in WebShopAPI.GetBooksByCategory("Horror"))
            {
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Category: {item.Categories.Title}");
                Console.WriteLine($"Author: {item.Author.FullName}");
                Console.WriteLine($"Stock: {item.Stock} st");
                Console.WriteLine($"Price: {item.Price};-");
                Console.WriteLine($"ID: {item.ID}");
                Console.WriteLine("__________________________________");
            }
        }

        /// <summary>
        /// Displays book by given ID.
        /// First I find the category ID by searching for "Science Fiction".
        /// </summary>
        public static void GetBooksByCategoryID()
        {
            int categoryID = WebShopAPI.GetCategoryID("Science Fiction");
            foreach (var item in WebShopAPI.GetBooksByCategoryID(categoryID))
            {
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Category: {item.Categories.Title}");
                Console.WriteLine($"Author: {item.Author.FullName}");
                Console.WriteLine($"Stock: {item.Stock} st");
                Console.WriteLine($"Price: {item.Price};-");
                Console.WriteLine($"Book-ID: {item.ID}");
                Console.WriteLine("__________________________________");
            }
        }

        /// <summary>
        /// Displays book by a given ID.
        /// First I find the book ID by searching for title > Personal.
        /// </summary>
        public static void GetBooksByBookId()
        {
            var bookID = WebShopAPI.GetBookID("Personal");
            foreach (var item in WebShopAPI.GetBookByBookID(bookID))
            {
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Category: {item.Categories.Title}");
                Console.WriteLine($"Author: {item.Author.FullName}");
                Console.WriteLine($"Stock: {item.Stock} st");
                Console.WriteLine($"Price: {item.Price};-");
                Console.WriteLine($"ID: {item.ID}");
                Console.WriteLine("__________________________________");
            }
        }

        /// <summary>
        /// Displays all books in database.
        /// </summary>
        public static void GetAllBooks()
        {
            foreach (var item in new WebShopAPI().GetAllBooks())
            {
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Category: {item.Categories.Title}");
                Console.WriteLine($"Author: {item.Author.FullName}");
                Console.WriteLine($"Stock: {item.Stock} st");
                Console.WriteLine($"Price: {item.Price};-");
                Console.WriteLine("__________________________________");
            }
        }

        /// <summary>
        /// Displays all books in database with a stock > 0.
        /// </summary>
        public static void GetAllAvailableBooks()
        {
            foreach (var item in new WebShopAPI().GetAvailableBooks())
            {
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Category: {item.Categories.Title}");
                Console.WriteLine($"Author: {item.Author.FullName}");
                Console.WriteLine($"Stock: {item.Stock} st");
                Console.WriteLine($"Price: {item.Price} ;-");
                Console.WriteLine("__________________________________");
            }
        }

        /// <summary>
        /// Lets admin create a new book.
        /// Here admin creates "Svampbobs Magiska Äventyr".
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void CreateNewBook(int adminID)
        {
            Console.WriteLine(new WebShopAPI().AddBook(adminID, "Svampbobs Magiska Äventyr", "Nicklas", "Eriksson", "Horror", 1000, 5));
        }

        /// <summary>
        /// Create a new category.
        /// Here the category "Myspys" is created.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void CreateNewCategory(int adminID)
        {
            Console.WriteLine(new WebShopAPI().AddCategory(adminID, "Myspys"));
        }

        /// <summary>
        /// Displays all Categories in database.
        /// </summary>
        public static void GetAllCategories()
        {
            foreach (var item in WebShopAPI.GetCategories())
            {
                Console.WriteLine(item.Title);
            }
        }

        /// <summary>
        /// Displays all authors in database.
        /// </summary>
        public static void GetAllAuthors()
        {
            foreach (var item in WebShopAPI.GetAuthors())
            {
                Console.WriteLine(item.FullName);
            }
        }

        /// <summary>
        /// Logs a user in and out. To check if it worked, check for session timer in database.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void LogInAndLogOutUser(int adminID)
        {
            WebShopAPI.Login("CodicRulez", "Codic2021"); Console.WriteLine("Logged in");
            new WebShopAPI().LogOut(adminID); Console.WriteLine("Logged out");
        }

        /// <summary>
        /// Pings the user to see if it is still active.
        /// </summary>
        /// <param name="adminID"></param>
        public static void Ping(int adminID)
        {
            new WebShopAPI().Ping(adminID);
        }

        /// <summary>
        /// Creates a new book with no category given.
        /// Title > "Cool Book".
        /// </summary>
        /// <param name="adminID">Book ID.</param>
        public static void CreateNewBookWithNoCategory(int adminID)
        {
            Console.WriteLine(new WebShopAPI().AddBook(adminID, "Cool Book", "Jazzcat", "Blue", 220, 2));

            foreach (var item in WebShopAPI.GetBooksByAuthor("Jazzcat", "Blue"))
            {
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Author: {item.Author.FullName}");
                Console.WriteLine($"Stock: {item.Stock} st");
                Console.WriteLine($"Price: {item.Price};-");
                Console.WriteLine("__________________________________");
            }
        }

        /// <summary>
        /// Adds the newly created book "Cool Book" to the category Biography.
        /// First I get the ID of the book. > Get the ID of the category "Biography"
        /// > Inserts the IDs into AddBookToCategory().
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void AddBookToCategory(int adminID)
        {
            var bookID = WebShopAPI.GetBookID("Cool Book");
            var categoryID = WebShopAPI.GetCategoryID("Biography");
            new WebShopAPI().AddBookToCategory(adminID, bookID, categoryID);
            foreach (var item in WebShopAPI.GetBooksByAuthor("Jazzcat", "Blue"))
            {
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Author: {item.Author.FullName}");
                Console.WriteLine($"Category: {item.Categories.Title}");
                Console.WriteLine($"Category ID: {item.Categories.ID}");
                Console.WriteLine($"Stock: {item.Stock} st");
                Console.WriteLine($"Price: {item.Price};-");
            }
        }

        /// <summary>
        /// Adds a new user to the database.
        /// Here we add "Tur Ture" to the database.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void AddUser(int adminID)
        {
            Console.WriteLine(new WebShopAPI().AddUser(adminID, "Cool", "Cat1234", "Tur", "Ture"));
        }

        /// <summary>
        /// Displays all users.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void ListUsers(int adminID)
        {
            foreach (var item in new WebShopAPI().ListActiveUsers(adminID))
            {
                Console.WriteLine(item.FullName);
            }
        }

        /// <summary>
        /// Displays a user by username.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void FindUserByUsername(int adminID)
        {
            try
            {
                foreach (var user in new WebShopAPI().FindUsers(adminID, "Test2"))
                {
                    Console.WriteLine($"Name: {user.FullName}");
                    Console.WriteLine($"Username: {user.Username}");
                    Console.WriteLine($"ID: {user.ID}");
                    Console.WriteLine($"Is Active: {user.IsActive}");
                    Console.WriteLine($"Is Admin: {user.Admin}");
                    Console.WriteLine($"Last Login: {user.LastLogIn}");
                    Console.WriteLine($"Session Timer: {user.SessionTimer}");
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        /// <summary>
        /// Can inactivates a user if user is active.
        /// </summary>
        /// <param name="adminID"></param>
        public static void InactivateUser(int adminID)
        {
            Console.WriteLine(new WebShopAPI().InactivateUser(adminID, adminID + 8));
        }

        /// <summary>
        /// Can activate a user if it is inactive.
        /// </summary>
        /// <param name="adminID"></param>
        public static void ActivateUser(int adminID)
        {
            Console.WriteLine(new WebShopAPI().ActivateUser(adminID, adminID + 8));
        }

        /// <summary>
        /// Here Admin buys book "I Robot".
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void BuyBook(int adminID)
        {
            var bookID = WebShopAPI.GetBookID("I Robot");
            Console.WriteLine(new WebShopAPI().BuyBook(adminID, bookID));
        }

        /// <summary>
        /// Updates the information of a book.
        /// Here The book "Make Me" is updated.
        /// </summary>
        /// <param name="adminID"></param>
        public static void UpdateBook(int adminID)
        {
            var bookID = WebShopAPI.GetBookID("Make Me");
            Console.WriteLine(new WebShopAPI().UpdateBook(adminID, bookID, "Test Title", "Nicke", "Nyfiken", "Comedy", 101, 33));
        }

        /// <summary>
        /// Updates the name of the category "Biography" to "Updated Category".
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void UpdateCategory(int adminID)
        {
            var categoryID = WebShopAPI.GetCategoryID("Biography");
            Console.WriteLine(new WebShopAPI().UpdateCategory(adminID, categoryID, "Updated Category"));
        }

        /// <summary>
        /// Promote user to admin.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void PromoteUser(int adminID)
        {
            Console.WriteLine(new WebShopAPI().Promote(adminID, adminID + 7));
        }

        /// <summary>
        /// Demotes a user from admin to regular user.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void DemoteUser(int adminID)
        {
            Console.WriteLine(new WebShopAPI().Demote(adminID, adminID + 7));
        }

        /// <summary>
        /// Deletes a book from database.
        /// Here the book "61 Hours" is deleted.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void DeleteBook(int adminID)
        {
            var bookID = WebShopAPI.GetBookID("61 Hours");
            Console.WriteLine(new WebShopAPI().DeleteBook(adminID, bookID));
        }

        /// <summary>
        /// Deletes a category from the database.
        /// Here we insert all the empty categories from the database and deletes
        /// the first empty element.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void DeleteCategory(int adminID)
        {
            var emptyCategories = GetEmptyCategories().ToArray();
            try
            {
                Console.WriteLine("Deleting category:" + new WebShopAPI().DeleteCategory(adminID, emptyCategories[0].ID));
                Console.WriteLine(new WebShopAPI().DeleteCategory(adminID, emptyCategories[0].ID));
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        /// <summary>
        /// Displays all remaining categories.
        /// </summary>
        /// <returns>Categories, used in testing block.</returns>
        public static IEnumerable<Category> GetEmptyCategories()
        {
            Console.WriteLine("Empty Categories:");
            Console.WriteLine("_______________________");
            foreach (var item in WebShopAPI.GetEmptyCategories())
            {
                Console.WriteLine($"Name: " + item.Title);
                Console.WriteLine($"ID: " + item.ID);
                Console.WriteLine("_______________________");
            }
            return WebShopAPI.GetEmptyCategories();
        }

        /// <summary>
        /// Updates the stock of a book.
        /// There the stock of "The Enemy" is set to 100.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void SetStockAmount(int adminID)
        {
            var bookID = WebShopAPI.GetBookID("The Enemy");
            Console.WriteLine(new WebShopAPI().SetAmount(adminID, bookID, 100));
        }

        /// <summary>
        /// Displays the name and ID of the customer that has bought the most books.
        /// The in the mockdata 3 different users bought books.
        /// </summary>
        /// <param name="adminID">Admin ID.</param>
        public static void BestCustomer(int adminID)
        {
            var users = new WebShopAPI().BestCustomer(adminID);
            foreach (var user in users)
            {
                Console.WriteLine($"User {user.FullName}");
                Console.WriteLine($"ID: {user.ID}");
                Console.WriteLine("Has bought most books");
            }
        }

        /// <summary>
        /// Empties all the tables if the data needs to be reset.
        /// Since no indexes is hard coded in any tests the IDs of objects does
        /// not need to be reseted.
        /// </summary>
        /// <returns>String - "Success".</returns>
        public static void EmptyAllTables()
        {
            using (var db = new DBContext())
            {
                try
                {
                    db.Authors.Clear();
                    db.Categories.Clear();
                    db.Books.Clear();
                    db.SoldBooks.Clear();
                    db.Users.Clear();
                    db.SaveChanges();

                    Console.WriteLine("Successfully deleted table contents.");
                }
                catch (Exception e) { Console.WriteLine(e); }
            }
        }

        /// <summary>
        /// Gets the ID of the first admin found in the database.
        /// In this case it is the example admin given from Marcus.
        /// </summary>
        /// <returns>Admin ID.</returns>
        public static int GetAdminID()
        {
            try
            {
                return WebShopAPI.GetUserID("CodicRulez");
            }
            catch (Exception e) { Console.WriteLine(e); return default; }
        }

        /// <summary>
        /// Logs in the administrator so tests can be done.
        /// </summary>
        public static void LogInAdmin()
        {
            try
            {
                WebShopAPI.Login("CodicRulez", "Codic2021");
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        /// <summary>
        /// Plats seeded books and mockdata for testing.
        /// </summary>
        public static void PlantSeedsAndMockData()
        {
            try
            {
                Seed.CategorySeed();
                Seed.AuthorSeed();
                Seed.BookSeed();
                Seed.AdminSeed();
                UserMD.NewUsers();
                UserMD.User1BuysBooks();
                UserMD.User2BuysBooks();
                UserMD.User3BuysBooks();
                Console.WriteLine("Seeds and Mockdata is successfully planted");
                Thread.Sleep(1500);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
    }
}
