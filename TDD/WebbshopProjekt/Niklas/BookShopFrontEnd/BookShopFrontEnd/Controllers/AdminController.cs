using BookShopFrontEnd.Utility;
using BookShopFrontEnd.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopAPI;
using WebbShopAPI.Models;

namespace BookShopFrontEnd.Controllers
{
    /// <summary>
    /// Lets administrator add/update/delete and monitor users and books.
    /// </summary>
    public class AdminController
    {
        private static readonly int AdminID = UserController.LoggedUserID;

        /// <summary>
        /// Lets the admin navigate his options in a menu.
        /// </summary>
        public static void AdminInterface()
        {
            Admin.AdminInterface();
            var inputNumber = Helper.GetInputForOptions(1, 20);
            if (inputNumber == 1) { AddBook(); }
            else if (inputNumber == 2) { AddBookWithNoCategory(); }
            else if (inputNumber == 3) { SetStock(); }
            else if (inputNumber == 4) { ListUsers(); }
            else if (inputNumber == 5) { FindUser(); }
            else if (inputNumber == 6) { UpdateBook(); }
            else if (inputNumber == 7) { DeleteBook(); }
            else if (inputNumber == 8) { AddCategory(); }
            else if (inputNumber == 9) { AddBookToCategory(); }
            else if (inputNumber == 10) { UpdateCategory(); }
            else if (inputNumber == 11) { DeleteCategory(); }
            else if (inputNumber == 12) { AddUser(); }
            else if (inputNumber == 13) { SoldItems(); }
            else if (inputNumber == 14) { MoneyEarned(); }
            else if (inputNumber == 15) { BestCustomer(); }
            else if (inputNumber == 16) { Promote(); }
            else if (inputNumber == 17) { Demote(); }
            else if (inputNumber == 18) { ActivateUserAccount(); }
            else if (inputNumber == 19) { InactivateUserAccount(); }
            else {UserController.UserLogout();}
        }

        /// <summary>
        /// Lets admin create a new book in database.
        /// 0] = Book title , [1] = Author first name, [2] = Author surname, [3] = Category, [4] = Price , [5] = Stock. 
        /// </summary>
        public static void AddBook()
        {
            var categories = WebShopAPI.GetCategories().ToList();
            Admin.AddBook();
            var newBook = ExtractedView.SetBookDetails(categories);
            bool success = new WebShopAPI().AddBook(AdminController.AdminID, newBook[0], newBook[1], newBook[2], newBook[3], newBook[4], newBook[5]);
            ExtractedView.SuccessDBCalls(success);
            if (success)
            {
                ExtractedView.SuccessDBCalls(success);
                AdminInterface();
            }
            else { AdminInterface(); }
        }

        /// <summary>
        /// Lets admin create a new book in database.
        /// [0] = Book title , [1] = Author first name, [2] = Author surname, [3] = Price , [4] = Stock.
        /// </summary>
        public static void AddBookWithNoCategory()
        {
            Admin.AddBookWithNoCategory();
            var newBook = ExtractedView.SetBookDetailsNoCategory();
            bool success = new WebShopAPI().AddBook(AdminController.AdminID, newBook[0], newBook[1], newBook[2], newBook[3], newBook[4]);
            if (success)
            {
                ExtractedView.SuccessDBCalls(success);
                AdminInterface();
            }
            else { AdminInterface(); }
        }

        /// <summary>
        /// Updates a books stock.
        /// </summary>
        public static void SetStock()
        {
            var bookList = new WebShopAPI().GetAllBooks().ToList();
            var index = Admin.ChooseBookSetAmount(bookList);
            var bookID = WebShopAPI.GetBookID(bookList[index].Title);
            int newStock = Helper.GetInputForOptions(1, Int32.MaxValue);
            bool success = new WebShopAPI().SetAmount(AdminController.AdminID, bookID, newStock);
            ExtractedView.SuccessDBCalls(success);
            AdminInterface();
        }

        /// <summary>
        /// Lists all active users in database.
        /// </summary>
        public static void ListUsers()
        {
            var listUsers = new WebShopAPI().ListActiveUsers(AdminController.AdminID).ToList();
            Admin.ListUsers(listUsers);
            Console.ReadKey();
            AdminInterface();
        }

        /// <summary>
        /// Finds a user by username.
        /// </summary>
        public static void FindUser()
        {
            var username = Admin.GetUsername();
            var listUsers = new WebShopAPI().FindUsers(AdminController.AdminID, username).ToList();
            Admin.PrintUser(listUsers);
            Console.ReadKey();
            AdminInterface();
        }

        /// <summary>
        /// Updates the book.
        /// </summary>
        public static void UpdateBook()
        {
            var bookTuple = Admin.UpdateBook();
            var book = bookTuple.Item1;
            var newBook = bookTuple.Item2;
            var bookID = WebShopAPI.GetBookID(book.Title);
            bool success = new WebShopAPI().UpdateBook(AdminController.AdminID, bookID, newBook[0], newBook[1], newBook[2], newBook[3], newBook[4], newBook[5]);
            ExtractedView.SuccessDBCalls(success);
            AdminInterface();
        }

        /// <summary>
        /// Deletes a book from the database.
        /// Each deletes removes 1 from its stock. If stock is lower than 0 it is removed from the database.
        /// </summary>
        public static void DeleteBook()
        {
            var book = Admin.DeleteBook();
            var bookID = WebShopAPI.GetBookID(book.Title);
            var success = new WebShopAPI().DeleteBook(AdminController.AdminID, bookID);
            ExtractedView.SuccessDBCalls(success);
            AdminInterface();
        }

        /// <summary>
        /// Adds a new category to the database.
        /// </summary>
        public static void AddCategory()
        {
            var categoryList = WebShopAPI.GetCategories().ToList();
            var categoryName = Admin.AddCategory(categoryList);
            bool success = new WebShopAPI().AddCategory(AdminID, categoryName);
            ExtractedView.SuccessDBCalls(success);
            AdminInterface();
        }

        /// <summary>
        /// Adds a book with no current category to a existing category.
        /// </summary>
        public static void AddBookToCategory()
        {
            var allBooks = new WebShopAPI().GetAllBooks().ToList();
            var categoryList = WebShopAPI.GetCategories().ToList();
            var book  =  Admin.AddBookToCategory(allBooks);
            if (book == null) { AdminInterface(); }            
            var category = Admin.ChooseACategoryToBook(categoryList);
            bool success = new WebShopAPI().AddBookToCategory(AdminController.AdminID, book.ID, category.ID);
            ExtractedView.SuccessDBCalls(success);
            AdminInterface();
        }

        /// <summary>
        /// Updates the name of the category.
        /// </summary>
        public static void UpdateCategory()
        {
            var categoryList = WebShopAPI.GetCategories().ToList();
            var index = Admin.UpdateCategory(categoryList);
            var category = categoryList[index];
            string newCategoryName = Console.ReadLine().Trim();
            var success = new WebShopAPI().UpdateCategory(AdminController.AdminID, category.ID, newCategoryName);
            ExtractedView.SuccessDBCalls(success);
            AdminInterface();
        }

        /// <summary>
        /// Deletes a category from the database if it has 0 books in it.
        /// </summary>
        public static void DeleteCategory()
        {
            var category = Admin.DeleteCategory();
            bool success = new WebShopAPI().DeleteCategory(AdminController.AdminID, category.ID);
            ExtractedView.SuccessDBCalls(success);
            AdminInterface();
        }
               
        /// <summary>
        /// Adds a new user to the database. (Lets administrator register another user).
        /// </summary>
        public static void AddUser()
        {
            var userDetails = Admin.AddUser();
            bool success = new WebShopAPI().AddUser(AdminController.AdminID, userDetails[0], userDetails[1], userDetails[2], userDetails[3]);
            ExtractedView.SuccessDBCalls(success);
            AdminInterface();
        }

        /// <summary>
        /// Displays all the items sold.
        /// </summary>
        public static void SoldItems()
        {
            var soldItems = new WebShopAPI().SoldItems(AdminController.AdminID).ToList();
            Admin.SoldItems(soldItems);
            Console.ReadKey();
            AdminInterface();
        }

        /// <summary>
        /// Displays all the money earned from sales.
        /// </summary>
        public static void MoneyEarned()
        {
            var moneyEarned = new WebShopAPI().MoneyEarned(AdminController.AdminID);
            Admin.MoneyEarned(moneyEarned);
            Console.ReadKey();
            AdminInterface();
        }

        /// <summary>
        /// Displays the customer with most purchases.
        /// </summary>
        public static void BestCustomer()
        {
            var users = new WebShopAPI().BestCustomer(AdminController.AdminID).ToList();
            Admin.BestCustomer(users);
            Console.ReadKey();
            AdminInterface();
        }

        /// <summary>
        /// Promotes user to admin.
        /// </summary>
        /// <param name="userID"></param>
        public static void Promote()
        {
            var users = new WebShopAPI().ListActiveUsers(AdminController.AdminID).ToList();
            var userID = Admin.Promote(users);
            var success = new WebShopAPI().Promote(AdminController.AdminID, userID);
            ExtractedView.SuccessDBCalls(success);
            AdminInterface();
        }

        /// <summary>
        /// Demotes a user from admin.
        /// </summary>
        /// <param name="userID">User ID as int.</param>
        public static void Demote()
        {
            var users = new WebShopAPI().ListActiveUsers(AdminController.AdminID).ToList();
            var userID = Admin.Demote(users);
            var success = new WebShopAPI().Demote(AdminController.AdminID, userID);
            ExtractedView.SuccessDBCalls(success);
            AdminInterface();
        }

        /// <summary>
        /// Activates users account.
        /// </summary>
        public static void ActivateUserAccount()
        {
            var users = new WebShopAPI().ListInactiveUsers(AdminController.AdminID).ToList();
            var userID = Admin.ActivateUser(users);
            var success = new WebShopAPI().ActivateUser(AdminController.AdminID, userID);
            ExtractedView.SuccessDBCalls(success);
            AdminInterface();
        }

        /// <summary>
        /// Inactivates a users account.
        /// </summary>
        public static void InactivateUserAccount()
        {
            var users = new WebShopAPI().ListActiveUsers(AdminController.AdminID).ToList();
            var userID = Admin.InactivateUser(users);
            var success = new WebShopAPI().InactivateUser(AdminController.AdminID, userID);
            ExtractedView.SuccessDBCalls(success);
            AdminInterface();
        }
    }
}
