using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopFrontInlamning.Helpers;
using WebbShopFrontInlamning.Views;
using WebbShopInlamningsUppgift;
using WebbShopInlamningsUppgift.Models;

namespace WebbShopFrontInlamning.Controllers
{
    /// <summary>
    /// Controls the book flow
    /// </summary>
    class Book
    {
        /// <summary>
        /// Runs the book functionality page
        /// </summary>
        public void Run()
        {
            bool keepGoing = true;
            while(keepGoing)
            {
                BookViews.BookMeny();
                var input = InputHelper.ParseInput();

                switch(input)
                {
                    case 1:
                        ViewAllCategories();
                        break;
                    case 2:
                        SearchFunctionCategories();
                        break;
                    case 3:
                        SearchBooksByAuthor();
                        break;
                    case 4:
                        SearchBooksByTitle();
                        break;
                    case 5:
                        FindAllAvailableBooks();
                        break;
                    case 6:
                        keepGoing = false;
                        break;
                    default:
                        MessageViews.DisplayNonAvailableMessage();
                        break;
                }
            }
        }

        /// <summary>
        /// Uses all book categories to fetch all books in each category
        /// </summary>
        /// <returns></returns>
        public List<Books> GetAllBooks()
        {
            var listOfBooks = new List<Books>();

            WebbShopAPI api = new WebbShopAPI();
            var listOfCategories = api.GetCategories().ToList();
            if(listOfCategories != null)
            {
                foreach (var category in listOfCategories)
                {
                    listOfBooks.AddRange(api.GetAvailableBooks(category.ID).ToList());
                }
                return listOfBooks;
            }

            return new List<Books>();
        }

        /// <summary>
        /// Allows you to view all book categories
        /// </summary>
        public void ViewAllCategories()
        {
            WebbShopAPI api = new WebbShopAPI();
            var listOfCategories = api.GetCategories().ToList();
            if(listOfCategories != null)
            {
                var sortCategoryList = listOfCategories.OrderBy(c => c.ID).ToList();
                BookViews.DisplayCategoryList(sortCategoryList);
                return;
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows you to search for a specific category
        /// </summary>
        public void SearchFunctionCategories()
        {
            BookViews.SearchPage();
            var keyword = Console.ReadLine();
            if (keyword != "")
            {
                WebbShopAPI api = new WebbShopAPI();
                var listOfCategories = api.GetCategories(keyword).ToList();
                if (listOfCategories != null)
                {
                    BookViews.DisplayCategoryList(listOfCategories);
                    return;
                }
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows you to search for books based on author
        /// </summary>
        public void SearchBooksByAuthor()
        {
            BookViews.SearchPage();
            var keyword = Console.ReadLine();
            if (keyword != "")
            {
                WebbShopAPI api = new WebbShopAPI();
                var listOfBooks = api.GetAuthor(keyword).ToList();
                if (listOfBooks != null)
                {
                    BookViews.DisplayBookList(listOfBooks);
                    return;
                }
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows you to search for books based to title
        /// </summary>
        public void SearchBooksByTitle()
        {
            BookViews.SearchPage();
            var keyword = Console.ReadLine();
            if (keyword != "")
            {
                WebbShopAPI api = new WebbShopAPI();
                var listOfBooks = api.GetBooks(keyword).ToList();
                if (listOfBooks != null)
                {
                    BookViews.DisplayBookList(listOfBooks);
                    return;
                }
            }

            MessageViews.DisplayErrorMessage();
        }

        /// <summary>
        /// Allows you to view all available books
        /// </summary>
        public void FindAllAvailableBooks()
        {
            var listOfBooks = GetAllBooks();
            if(listOfBooks.Count != 0)
            {
                var sortBookList = listOfBooks.OrderBy(b => b.ID).ToList();
                BookViews.DisplayAvailableBooks(sortBookList);
                return;
            }

            MessageViews.DisplayErrorMessage();
        }

        
    }
}
