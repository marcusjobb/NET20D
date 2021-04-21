using BookShopFrontEnd.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebbShopAPI;
using WebbShopAPI.Models;

namespace BookShopFrontEnd.Views
{
   /// <summary>
   /// The view for all the AdminController methods.
   /// </summary>
    public class Admin
    {
        /// <summary>
        /// Displays the administrators options.
        /// </summary>
        private readonly string[] Alternative = { "Add Book", "Add Book With No Category", "Set Amount", "List Users", "Find Users", "Update Book", "Delete Book", "Add Category", "Add Book To Category", "Update Category", "Delete Category", "Add User", "Sold Items", "Money Earned", "Best Customer", "Promote User", "Demote User", "Activate User", "Inactivate User", "Log out" };


        /// <summary>
        /// Displays the UI for the admin.
        /// </summary>
        public static void AdminInterface()
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new Admin().Alternative);
        }

        public static void AddBook()
        {
            Console.Clear();
            Logotypes.AdminPanel();
            Console.WriteLine("Add a new book to the database.");
        }

        public static void AddBookWithNoCategory()
        {
            Console.Clear();
            Logotypes.AdminPanel();
            Console.WriteLine("Add a new book to the database.");
        }
        
        public static int ChooseBookSetAmount(List<Book> bookList)
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new string[1] { "Update stock on a book." });
            Console.WriteLine("Here are all the books in database:\n");
            ExtractedView.DisplayBooks(bookList);
            Console.Write("Update book number: ");
            var bookNumber = Helper.GetInputForOptions(1, bookList.Count);
            int index = bookNumber - 1;
            Console.Write($"Set new stock for {bookList[index].Title}: ");
            return index;
        }

        public static void ListUsers(List<User> listUsers)
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new string[1] { "Here are all active users." });
            ExtractedView.PrintUserCredentials(listUsers);
            Console.WriteLine("Press any key to return.");
        }
       
        public static string GetUsername()
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new string[1] { "Find user by username:" });
            Console.Write("Username: ");
            string username = Console.ReadLine().Trim();
            return username;
        }

        public static void PrintUser(List<User> listUsers)
        {
            ExtractedView.PrintUserCredentials(listUsers);
            Console.WriteLine("Press any key to return.");
        }

        public static Tuple<Book, List<dynamic>> UpdateBook()
        {
            Console.Clear();
            Logotypes.AdminPanel();
            var categories = WebShopAPI.GetCategories().ToList();
            MenuFrames.Frame(new string[1] { "Update book" });
            Console.WriteLine("Here are the available books:\n");
            var bookList = SpecifiedBookSearch.Alternatives();
            var bookIndex = ExtractedLogic.GetUserInput(bookList);
            var newBookAsList = ExtractedView.SetBookDetails(categories); ;
            Book book = bookList[bookIndex];
            return new Tuple<Book, List<dynamic>>(book, newBookAsList);
        }

        public static Book DeleteBook()
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new string[1] { "Delete Book:" });
            var bookList = SpecifiedBookSearch.Alternatives().ToList();
            var index = ExtractedLogic.GetUserInput(bookList);
            return bookList[index];
        }

        public static string AddCategory(List<Category> categoryList)
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new string[1] { "\nAdd New Category:" });
            ExtractedView.DisplayCategories(categoryList);
            Console.Write("New Category name: ");
            string categoryName = Console.ReadLine().Trim();
            return categoryName;
        }

        public static Book AddBookToCategory(List<Book> allBooks)
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new string[1] { "Add Book To Category:" });
            var booksWithNoCategory = ExtractedLogic.FindBooksWithNoCategory(allBooks).ToList();
            if (booksWithNoCategory.Count > 0)
            {
                Console.WriteLine("Here are all the books currently missing a category:\n");
                ExtractedView.DisplayBooks(booksWithNoCategory);
                Console.WriteLine("\nNow choose a book to add a category to.\n");
                var index = ExtractedLogic.GetUserInput(booksWithNoCategory);
                return booksWithNoCategory[index];
            }
            else
            {
                Console.WriteLine("Currently there are not any books missing a category.");
                Console.WriteLine("Try creating one without category?");
                Thread.Sleep(1600);
                return null;
            }
        }

        public static Category ChooseACategoryToBook(List<Category> categoryList)
        {
            Console.WriteLine("\nNow choose a category to add to your chosen book.");
            ExtractedView.DisplayCategories(categoryList);
            var index = ExtractedLogic.GetUserInput(categoryList);
            return categoryList[index];
        }

        public static int UpdateCategory(List<Category> categoryList)
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new string[1] { "Update Category Name:" });
            ExtractedView.DisplayCategories(categoryList);
            var categoryIndex = ExtractedLogic.GetUserInput(categoryList);
            Console.Write("New category name: ");
            return categoryIndex;
        }

        public static Category DeleteCategory()
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new string[1] { "Delete Category:" });
            var categoryList = WebShopAPI.GetCategories().ToList();
            ExtractedView.DisplayCategories(categoryList);
            var index = ExtractedLogic.GetUserInput(categoryList);
            return categoryList[index];
        }

        public static string[] AddUser()
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new string[1] { "Add New User To Database:" });
            Console.Write("Username: ");
            string username = Console.ReadLine().Trim();
            Console.Write("Password: ");
            string password = Console.ReadLine().Trim();
            Console.Write("First name: ");
            string firstName = Console.ReadLine().Trim();
            Console.Write("Surname: ");
            string surname = Console.ReadLine().Trim();
            return new string[] { username, password, firstName, surname };
        }
       
        public static void SoldItems(List<SoldBook> soldItems)
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new string[1] { "Items Sold:" });
            if (soldItems != null)
            {
                ExtractedView.DisplaySoldBooks(soldItems);
                Console.WriteLine("Press any key to continue.");
            }
            else
            {
                Console.WriteLine("No items has been sold yet!");
                Console.WriteLine("Press any key to continue.");
            }
        }

        public static void MoneyEarned(int moneyEarned)
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new string[1] { "Money Earned:" });
            Console.WriteLine($"{moneyEarned}kr");
            Console.WriteLine("Press any key to continue.");
        }

        public static void BestCustomer(List<User> bestCustomers)
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new string[1] { "Best Customer" });
            foreach (var customer in bestCustomers)
            {
                Console.WriteLine("User:");
                Console.WriteLine($"Username{customer.Username}");
                Console.WriteLine($"Name: {customer.FullName}");
                Console.WriteLine("====================================================================");
            }

            Console.WriteLine("Press any key to return.");
        }

        public static int Promote(List<User> users)
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new string[1] { "Promote User:" });
            var user = ExtractedView.SelectUserFromList(users);
            return user.ID;
        }

        public static int Demote(List<User> users)
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new string[1] { "Demote User:" });
            var user = ExtractedView.SelectUserFromList(users);
            return user.ID;
        }

        public static int ActivateUser(List<User> users)
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new string[1] { "Activate User:" });
            var user = ExtractedView.SelectUserFromList(users);
            return user.ID;
        }

        public static int InactivateUser(List<User> users)
        {
            Console.Clear();
            Logotypes.AdminPanel();
            MenuFrames.Frame(new string[1] { "Inactivate User:" });
            var user = ExtractedView.SelectUserFromList(users);
            return user.ID;
        }
    }
}
