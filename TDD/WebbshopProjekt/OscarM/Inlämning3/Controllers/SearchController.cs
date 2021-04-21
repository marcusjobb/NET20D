using Inlämning2WebbShop;
using Inlämning2WebbShop.Models;
using Inlämning3.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inlämning3.Controllers
{
    internal class SearchController
    {
        private WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// method that calls other methods depending on the choice of the user
        /// </summary>
        public void SearchMenu()
        {
            do
            {
                int choice = Views.User.Search.DisplaySearchMenu();
                switch (choice)
                {
                    case 1:
                        Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                        SearchBooks();
                        break;

                    case 2:
                        Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                        SearchCategories();
                        break;

                    case 3:
                        Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                        GetAllCategories();
                        break;

                    case 4:
                        Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                        Console.Clear();
                        var homeController = new HomeController();
                        homeController.Home();
                        break;

                    default:
                        Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                        Messages.NotValidInput();
                        break;
                }
            } while (true);
        }

        /// <summary>
        /// Gets and prints all books in a category chosed by a user.
        /// </summary>
        private void GetAllCategories()
        {
            var categories = api.GetCategories();
            var choice = Views.User.Search.SeeAllCategories(categories);
            if (choice < 0 || choice > categories.Count)
            {
                SearchMenu();
            }
            else
            {
                var booksInCategory = api.GetAvailableBooks(categories[choice].Id);
                var userController = new UserController();
                userController.PrintBooks(booksInCategory);
            }
        }

        /// <summary>
        /// Gets and prints books based on a searchword on the title and/or the author.
        /// </summary>
        public void SearchBooks()
        {
            var keyword = Views.User.Search.SearchBooks();
            var booksByTitleResult = api.GetBooks(keyword);
            var booksByAuthorResult = api.GetAuthors(keyword);
            var allBooksFoundBySearch = booksByTitleResult.Union(booksByAuthorResult).ToList();
            var userController = new UserController();
            userController.PrintBooks(allBooksFoundBySearch);
        }

        /// <summary>
        /// gets and prints books based on a searchword on a category.
        /// </summary>
        public void SearchCategories()
        {
            var keyword = Views.User.Search.SearchCategories();
            var categoriesFound = api.GetCategories(keyword);
            var booksFoundByCategory = GetBooksByCategoryResult(categoriesFound);
            if (booksFoundByCategory.Count > 0)
            {
                var userController = new UserController();
                userController.PrintBooks(booksFoundByCategory);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No results found!");
            }
        }

        /// <summary>
        /// Loops a list of BookCategories, and gets the books based on that certain categoryId.
        /// returns a list of books
        /// </summary>
        /// <param name="categoriesFound"></param>
        /// <returns></returns>
        private List<Book> GetBooksByCategoryResult(List<BookCategory> categoriesFound)
        {
            var booksInCategory = new List<Book>();
            if (categoriesFound.Count == 1)
            {
                foreach (var category in categoriesFound)
                {
                    booksInCategory = api.GetCategory(category.Id);
                    return booksInCategory;
                }
            }
            else if (categoriesFound.Count > 1)
            {
                foreach (var category in categoriesFound)
                {
                    foreach (var book in api.GetCategory(category.Id))
                    {
                        booksInCategory.Add(book);
                    }
                    return booksInCategory;
                }
            }
            return booksInCategory;
        }
    }
}