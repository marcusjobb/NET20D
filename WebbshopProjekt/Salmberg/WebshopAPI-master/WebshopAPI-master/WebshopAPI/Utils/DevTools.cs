using System;
using System.Collections.Generic;
using WebshopAPI.Models;

namespace WebshopAPI.Utils
{
    /// <summary>
    /// Class used by developer to test functionality
    /// </summary>
    public static class DevTools
    {
        #region MENU

        /// <summary>
        /// WebshopAPI object for use in menu switch
        /// </summary>
        private static API api = new API();

        /// <summary>
        /// Prints menu to console, switch for choosing menu alternative.
        /// Only for developer use
        /// </summary>
        public static void Menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("CUSTOMER FUNCTIONS\n\n");
                Console.WriteLine("[1] List categories");
                Console.WriteLine("[2] Search categories");
                Console.WriteLine("[3] List books in category");
                Console.WriteLine("[4] Get available books in category");
                Console.WriteLine("[5] Info about book");
                Console.WriteLine("[6] Search for book");
                Console.WriteLine("[7] Search for author");
                Console.WriteLine("[8] Login");
                Console.WriteLine("[9] Logout");
                Console.WriteLine("[10] Buy book (LOGIN REQUIRED)");
                Console.WriteLine("[11] Register\n\n");

                Console.WriteLine("ADMIN FUNCTIONS\n\n");
                Console.WriteLine("[12] Add book");
                Console.WriteLine("[13] Set amount of books");
                Console.WriteLine("[14] List users");
                Console.WriteLine("[15] Find user");
                Console.WriteLine("[16] Update book");
                Console.WriteLine("[17] Delete book");
                Console.WriteLine("[18] Add category");
                Console.WriteLine("[19] Add book to category");
                Console.WriteLine("[20] Update category");
                Console.WriteLine("[21] Delete category");
                Console.WriteLine("[22] Add user");
                Console.WriteLine("[23] List sold books");
                Console.WriteLine("[24] Money earned");
                Console.WriteLine("[25] Best customer");
                Console.WriteLine("[26] Promote");
                Console.WriteLine("[27] Demote");
                Console.WriteLine("[28] Activate user");
                Console.WriteLine("[29] Inactivate user");

                int.TryParse(Console.ReadLine(), out var menuChoice);

                switch (menuChoice)
                {
                    case 1:
                        ListReader(api.GetCategories());

                        break;

                    case 2:
                        Console.Write("Keyword:");
                        var categoryKeyword = Console.ReadLine();

                        ListReader(api.GetCategories(categoryKeyword));
                        break;

                    case 3:
                        Console.Write("Category id:");
                        int.TryParse(Console.ReadLine(), out var categorychoice);
                        ListReader(api.GetCategory(categorychoice));
                        break;

                    case 4:
                        Console.Write("Category id:");
                        int.TryParse(Console.ReadLine(), out var categoryChoice2);
                        ListReader(api.GetAvailableBooks(categoryChoice2));
                        break;

                    case 5:
                        Console.Write("Book id:");
                        int.TryParse(Console.ReadLine(), out var bookId);
                        BookReader(api.GetBook(bookId));
                        break;

                    case 6:
                        Console.Write("Keyword:");
                        var bookKeyword = Console.ReadLine();
                        BookReader(api.GetBooks(bookKeyword));
                        break;

                    case 7:
                        Console.Write("Keyword:");
                        var authorKeyword = Console.ReadLine();
                        BookReader(api.GetAuthors(authorKeyword));
                        break;

                    case 8:
                        Console.Write("Username:");
                        var username = Console.ReadLine();
                        Console.Write("Password:");
                        var password = Console.ReadLine();

                        LoginCheck(api.Login(username, password));
                        break;

                    case 9:
                        Console.Write("User Id:");
                        int.TryParse(Console.ReadLine(), out var userLogout);

                        api.Logout(userLogout);
                        break;

                    case 10:
                        Console.Write("User Id:");
                        int.TryParse(Console.ReadLine(), out var userBuy);
                        Console.Write("Book Id:");
                        int.TryParse(Console.ReadLine(), out var BookBuy);

                        BoolCheck(api.BuyBook(userBuy, BookBuy));
                        break;

                    case 11:
                        Console.Write("User name:");
                        var userReg = Console.ReadLine();
                        Console.Write("Password:");
                        var passReg = Console.ReadLine();
                        Console.Write("Verify password:");
                        var passVer = Console.ReadLine();

                        BoolCheck(api.Register(userReg, passReg, passVer));
                        break;

                    case 12:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminAddBook);
                        Console.Write("Title:");
                        var titleAddBook = Console.ReadLine();
                        Console.Write("Author:");
                        var authorAddBook = Console.ReadLine();
                        Console.Write("Price:");
                        int.TryParse(Console.ReadLine(), out var priceAddBook);
                        Console.Write("Amount:");
                        int.TryParse(Console.ReadLine(), out var amountAddBook);

                        BoolCheck(api.AddBook(adminAddBook, titleAddBook, authorAddBook, priceAddBook, amountAddBook));
                        break;

                    case 13:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminSetAmount);
                        Console.Write("Book Id:");
                        int.TryParse(Console.ReadLine(), out var bookSetAmount);
                        Console.Write("Amount:");
                        var amountSetAmount = Convert.ToInt32(Console.ReadLine());

                        var result = (api.SetAmount(adminSetAmount, bookSetAmount, amountSetAmount));
                        BoolCheck(result.isAmountSet);
                        break;

                    case 14:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminIdListUsers);

                        ListReader(api.ListUsers(adminIdListUsers));
                        break;

                    case 15:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminIdFindUser);
                        Console.Write("Keyword:");
                        var keywordFindUser = Console.ReadLine();

                        ListReader(api.FindUser(adminIdFindUser, keywordFindUser));
                        break;

                    case 16:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminIdUpdateBook);
                        Console.Write("Book Id:");
                        int.TryParse(Console.ReadLine(), out var bookIdUpdateBook);
                        Console.Write("Title:");
                        var titleUpdateBook = Console.ReadLine();
                        Console.Write("Author:");
                        var authorUpdateBook = Console.ReadLine();
                        Console.Write("Price:");
                        int.TryParse(Console.ReadLine(), out var priceUpdateBook);

                        BoolCheck(api.UpdateBook(adminIdUpdateBook, bookIdUpdateBook, titleUpdateBook, authorUpdateBook, priceUpdateBook));
                        break;

                    case 17:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminIdDeleteBook);
                        Console.Write("Book Id:");
                        int.TryParse(Console.ReadLine(), out var bookIdDeleteBook);
                        Console.Write("Amount:");
                        int.TryParse(Console.ReadLine(), out var amountToDelete);

                        BoolCheck(api.DeleteBook(adminIdDeleteBook, bookIdDeleteBook, amountToDelete));
                        break;

                    case 18:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminIdAddCategory);
                        Console.Write("Category name:");
                        var categoryAddCategegory = Console.ReadLine();

                        BoolCheck(api.AddCategory(adminIdAddCategory, categoryAddCategegory));
                        break;

                    case 19:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminIdAddBookToCat);
                        Console.Write("Book Id:");
                        int.TryParse(Console.ReadLine(), out var bookIdAddBookToCat);
                        Console.Write("Category Id:");
                        int.TryParse(Console.ReadLine(), out var catIdAddBookToCat);

                        BoolCheck(api.AddBookToCategory(adminIdAddBookToCat, bookIdAddBookToCat, catIdAddBookToCat));
                        break;

                    case 20:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminIdUpdateCat);
                        Console.Write("Category Id:");
                        int.TryParse(Console.ReadLine(), out var catIdUpdateCat);
                        Console.Write("Name:");
                        var nameUpdateCat = Console.ReadLine();

                        BoolCheck(api.UpdateCategory(adminIdUpdateCat, catIdUpdateCat, nameUpdateCat));
                        break;

                    case 21:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminIdDeleteCat);
                        Console.Write("Category Id:");
                        int.TryParse(Console.ReadLine(), out var catIdDeleteCat);

                        BoolCheck(api.DeleteCategory(adminIdDeleteCat, catIdDeleteCat));
                        break;

                    case 22:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminIdAddUser);
                        Console.Write("User name:");
                        var nameAddUser = Console.ReadLine();
                        Console.Write("Password:");
                        var passAddUser = Console.ReadLine();

                        BoolCheck(api.AddUser(adminIdAddUser, nameAddUser, passAddUser));
                        break;

                    case 23:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminIdSoldItems);

                        ListReader(api.SoldItems(adminIdSoldItems));
                        break;

                    case 24:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminIdMoneyEarned);

                        Reader(api.MoneyEarned(adminIdMoneyEarned));
                        break;

                    case 25:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminIdBestCostumer);

                        UserReader(api.BestCostumer(adminIdBestCostumer));
                        break;

                    case 26:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminIdPromote);
                        Console.Write("User Id:");
                        int.TryParse(Console.ReadLine(), out var userIdPromote);

                        BoolCheck(api.Promote(adminIdPromote, userIdPromote));
                        break;

                    case 27:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminIdDemote);
                        Console.Write("User Id:");
                        int.TryParse(Console.ReadLine(), out var userIdDemote);

                        BoolCheck(api.Demote(adminIdDemote, userIdDemote));
                        break;

                    case 28:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminIdActUser);
                        Console.Write("User Id:");
                        int.TryParse(Console.ReadLine(), out var userIdActUser);

                        BoolCheck(api.ActivateUser(adminIdActUser, userIdActUser));
                        break;

                    case 29:
                        Console.Write("Admin Id:");
                        int.TryParse(Console.ReadLine(), out var adminIdInactUser);
                        Console.Write("User Id:");
                        int.TryParse(Console.ReadLine(), out var userIdInactUser);

                        BoolCheck(api.InactivateUser(adminIdInactUser, userIdInactUser));
                        break;
                }
            }
        }

        #endregion MENU

        #region READER

        /// <summary>
        /// Prints property values of Book object
        /// </summary>
        /// <param name="book"></param>
        private static void BookReader(Book book)
        {
            if (book != null)
            {
                Console.WriteLine(book.Title);
                Console.WriteLine(book.Author);
                Console.WriteLine(book.Price);
                Console.WriteLine(book.CategoryId);
            }
        }

        /// <summary>
        /// Prints Name property value of User object
        /// </summary>
        /// <param name="user"></param>
        private static void UserReader(User user)
        {
            Console.WriteLine(user.Name);
        }

        /// <summary>
        /// Prints value of bool for test purposes
        /// </summary>
        /// <param name="boolcheck"></param>
        private static void BoolCheck(bool boolcheck)
        {
            if (boolcheck == true)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        /// <summary>
        /// Prints userId, nullable
        /// </summary>
        /// <param name="userId"></param>
        private static void LoginCheck(int? userId)
        {
            Console.WriteLine(userId);
        }

        /// <summary>
        /// Prints content of List of type BookCategory
        /// </summary>
        /// <param name="list"></param>
        private static void ListReader(List<BookCategory> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
        }

        /// <summary>
        /// Prints content of List of type SoldBook
        /// </summary>
        /// <param name="list"></param>
        private static void ListReader(List<SoldBook> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.Title);
            }
        }

        /// <summary>
        /// Prints content of List of type User
        /// </summary>
        /// <param name="list"></param>
        private static void ListReader(List<User> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
        }

        /// <summary>
        /// Prints content of List of type Book
        /// </summary>
        /// <param name="list"></param>
        private static void ListReader(List<Book> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.Title);
            }
        }

        /// <summary>
        /// Prints property values of object type Book in List of type Book
        /// </summary>
        /// <param name="book"></param>
        private static void BookReader(List<Book> book)
        {
            foreach (var item in book)
            {
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Author: {item.Author}");
                Console.WriteLine($"Price: {item.Price}");
                Console.WriteLine($"Amount: {item.Amount}");
                Console.WriteLine($"Category: {item.CategoryId}");
                //TODO: Fix Category issue
            }
        }

        /// <summary>
        /// Prints int value, nullable
        /// </summary>
        /// <param name="value"></param>
        private static void Reader(int? value)
        {
            Console.WriteLine(value);
        }

        #endregion READER
    }
}