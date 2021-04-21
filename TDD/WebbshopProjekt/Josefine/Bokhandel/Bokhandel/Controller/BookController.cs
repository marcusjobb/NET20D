using Bokhandel.Help;
using Bokhandel.View;
using System;
using System.Collections.Generic;
using WebbShopAPI.Models;
using WebbShopJoR;

namespace Bokhandel.Controller
{
    internal class BookController
    {
        /// <summary>
        /// Buy book
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        public static void BuyBook(int userId, int bookId)
        {
            var sucess = API.BuyBook(userId, bookId);
            var view = new AdminView();
            if (sucess) { view.Sucess(); }
            else if (!sucess) { view.UserFail(); }
        }

        /// <summary>
        /// Choose book to se more about
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="books"></param>
        public static bool ChooseBook(int userId, List<Book> books)
        {
            BookView.SeeMore();
            var choice = Console.ReadLine().Trim().ToLower();
            if (choice == "x")
            {
                return false;
            }
            else
            {
                var number = Input.ConvertInput(choice);
                if (0 < number && number < books.Count + 1)
                {
                    var bookId = books[number - 1].Id;
                    SeeMoreAboutBook(userId, bookId);
                    return true;
                }
                else
                {
                    BookView.EnterValidNumber();
                    return true;
                }
            }
        }

        /// <summary>
        /// Choose category to see books in it
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="categories"></param>
        public static bool ChooseCategory(int userId, List<BookCategory> categories)
        {
            BookView.SeeMore();
            var choice = Console.ReadLine().Trim().ToLower();
            if (choice == "x")
            {
                return false;
            }
            else
            {
                var number = Input.ConvertInput(choice);
                if (0 < number && number < categories.Count + 1)
                {
                    MenuController.AllOrOnlyAvailableBooks(userId, categories[number - 1].Id);
                    return true;
                }
                else
                {
                    BookView.EnterValidNumber();
                    return true;
                }
            }
        }

        /// <summary>
        /// List only available book
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="categoryId"></param>
        public static void ListAvailableBooksInCategory(int userId, int categoryId)
        {
            bool loop = true;
            while (loop)
            {
                var books = API.GetAvailableBooks(categoryId);
                BookView.ShowBooks(books);
                loop = ChooseBook(userId, books);
            }
        }

        /// <summary>
        /// List books in category
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="categoryId"></param>
        public static void ListBooksInCategory(int userId, int categoryId)
        {
            bool loop = true;
            while (loop)
            {
                var books = API.GetBooksInCategory(categoryId);
                BookView.ShowBooks(books);
                loop = ChooseBook(userId, books);
            }
        }

        /// <summary>
        /// Search author with searchword
        /// </summary>
        /// <param name="userId"></param>
        public static void SearchAuthor(int userId)
        {
            bool loop = true;
            while (loop)
            {
                BookView.EnterSearch();
                var searchedAuthors = API.GetAuthors(Input.StringInput());
                BookView.ShowBooks(searchedAuthors);
                loop = ChooseBook(userId, searchedAuthors);
            }
        }

        /// <summary>
        /// Search book with search word
        /// </summary>
        /// <param name="userId"></param>
        public static void SearchBook(int userId)
        {
            bool loop = true;

            while (loop)
            {
                BookView.EnterSearch();
                var searchedBooks = API.GetBooks(Input.StringInput());
                BookView.ShowBooks(searchedBooks);
                loop = ChooseBook(userId, searchedBooks);
            }
        }

        /// <summary>
        /// Search category with search word
        /// </summary>
        /// <param name="userId"></param>
        public static void SearchCategory(int userId)
        {
            bool loop = true;
            while (loop)
            {
                BookView.EnterSearch();
                var searchedCategories = API.GetCategories(Input.StringInput());
                BookView.ShowCathegorys(searchedCategories);
                loop = ChooseCategory(userId, searchedCategories);
            }
        }

        /// <summary>
        /// Show all categories
        /// </summary>
        /// <param name="userId"></param>
        public static void SeeCategories(int userId)
        {
            bool loop = true;
            while (loop)
            {
                var allCategories = API.GetCategories();
                BookView.ShowCathegorys(allCategories);
                loop = ChooseCategory(userId, allCategories);
            }
        }

        /// <summary>
        /// Show details about book
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        public static void SeeMoreAboutBook(int userId, int bookId)
        {
            BookView.ShowBook(API.GetBook(bookId));
            WantToBuyBook(userId, bookId);
        }

        /// <summary>
        /// Ask if user want to buy book
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        public static void WantToBuyBook(int userId, int bookId)
        {
            bool loop = true;
            while (loop)
            {
                UserView.BuyBook();
                var choice = Console.ReadLine().Trim().ToLower();
                if (choice == "x") { loop = false; }
                var number = Input.ConvertInput(choice);
                if (number == 1) { BuyBook(userId, bookId); }
                else { BookView.EnterValidNumber(); }
            }
        }
    }
}