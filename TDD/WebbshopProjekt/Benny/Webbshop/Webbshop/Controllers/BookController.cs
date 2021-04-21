using System;
using System.Collections.Generic;
using Webbshop.Views;
using webshopAPI;
using webshopAPI.Models;

namespace Webbshop.Controllers
{
    internal class BookController
    {
        private static WebShopApi api = new WebShopApi();

        /// <summary>
        /// Method for getting input and searching for a book
        /// </summary>
        /// <returns>A specific book</returns>
        public static Book SearchForBook()
        {
            WebShopApi api = new WebShopApi();
            Console.Clear();
            BookView.SearchForBook();
            var searchKeyword = SharedController.GetSearchInput();
            if (searchKeyword.ToLower() == "x")
            {
                return null;
            }
            var listWithMatchingBooks = api.GetBooks(searchKeyword);

            if (listWithMatchingBooks.Count > 0)
            {
                Console.Clear();
                BookView.ListAllBooks(listWithMatchingBooks);
                var input = SharedController.GetAndValidateInput();
                if (input.validatedInput != 0
                    && input.validatedInput <= listWithMatchingBooks.Count)
                {
                    return api.GetBook(listWithMatchingBooks[input.validatedInput - 1].Id);
                }
                else
                {
                    SharedError.PrintWrongInput();
                    return null;
                }
            }
            else
            {
                SharedError.NothingFound();
                return null;
            }
        }

        /// <summary>
        /// Method for buying a book
        /// </summary>
        /// <param name="user">Takes a user to be connected with the purchase</param>
        /// <param name="book">Takes a book to be bought</param>
        internal static void BuyBook(User user, Book book)
        {
            if (api.BuyBook(user.Id, book.Id))
            {
                SharedError.Success();
            }
            else
            {
                SharedError.Failed();
            }
        }

        /// <summary>
        /// Search and buy a book by category listing
        /// </summary>
        /// <param name="user">Takes a user to be connected with the purchase</param>
        internal static void BuyByChooseByCategory(User user)
        {
            var categories = FindAndListCategories();
            var chosenCategory = ChooseCategoryToView(categories);
            var books = api.GetBooksInCategory(chosenCategory.Id);
            if (books.Count == 0)
            {
                SharedError.NothingFound();
            }
            else
            {
                var book = ListAndChooseBook(books);
                if (book != null)
                {
                    ShowInfoAboutBook(user, book);
                }
            }
        }

        /// <summary>
        /// Search and buy book thru Author listing
        /// </summary>
        /// <param name="user">Takes a user to be connected with the purchase</param>
        internal static void BuyBySearchByAuthor(User user)
        {
            var tuple = BookController.SearchBooksFromAuthor();
            if (tuple.message == "Avbrutet")
            {
            }
            else
            {
                var book = BookController.ListAndChooseBook(tuple.listWithBooks);
                if (book != null)
                {
                    BookController.ShowInfoAboutBook(user, book);
                }
            }
        }

        /// <summary>
        /// Search and buy book by book search
        /// </summary>
        /// <param name="user">User to be connected with the purchase</param>
        internal static void BuyBySearchByBook(User user)
        {
            var book = BookController.SearchForBook();
            if (book != null)
            {
                BookController.ShowInfoAboutBook(user, book);
            }
        }

        /// <summary>
        /// Search and buy book thru category search
        /// </summary>
        /// <param name="user">Takes a user to be connected to the purchase</param>
        internal static void BuyBySearchByCategory(User user)
        {
            var categories = SearchAndListCategories();
            var chosenCategory = ChooseCategoryToView(categories);
            var books = api.GetBooksInCategory(chosenCategory.Id);
            if (books.Count == 0)
            {
                SharedError.NothingFound();
            }
            else
            {
                var book = ListAndChooseBook(books);
                if (book != null)
                {
                    ShowInfoAboutBook(user, book);
                }
            }
        }

        /// <summary>
        /// List all books and choose one to return
        /// </summary>
        /// <param name="listWithMatchingBooks">Takes a list of books</param>
        /// <returns>returns a book</returns>
        internal static Book ListAndChooseBook(List<Book> listWithMatchingBooks)
        {
            if (listWithMatchingBooks.Count > 0)
            {
                Console.Clear();
                BookView.ListAllBooks(listWithMatchingBooks);
                var input = SharedController.GetAndValidateInput();
                if (input.validatedInput != 0
                    && input.validatedInput <= listWithMatchingBooks.Count)
                {
                    return api.GetBook(listWithMatchingBooks[input.validatedInput - 1].Id);
                }
                else
                {
                    SharedError.PrintWrongInput();
                    return null;
                }
            }
            else
            {
                SharedError.NothingFound();
                return null;
            }
        }

        /// <summary>
        /// Search book from specific author
        /// </summary>
        /// <returns>Returns a abort message if aborted during search. 
        /// Always returns a list with books, empty or not.</returns>
        internal static (string message, List<Book> listWithBooks) SearchBooksFromAuthor()
        {
            List<Book> listOfBooksFromAuthor = new List<Book>();
            WebShopApi api = new WebShopApi();
            Console.Clear();
            BookView.SearchBooksFromAuthor();
            var searchKeyword = SharedController.GetSearchInput();
            if (searchKeyword.ToLower() == "x")
            {
                return ("Avbrutet", listOfBooksFromAuthor);
            }
            listOfBooksFromAuthor = api.GetBooksByAuthor(searchKeyword);
            return ("Sökresultat", listOfBooksFromAuthor);
        }

        /// <summary>
        /// Shows info about book and gives the user the options to buy or abort.
        /// </summary>
        /// <param name="user">Takes a user to be connected to purchase</param>
        /// <param name="book">Takes a book for obtaining the info shown.</param>
        internal static void ShowInfoAboutBook(User user, Book book)
        {
            var continueLoop = true;
            do
            {
                BookView.ShowInfoAboutBook(book);
                var input = SharedController.GetSearchInput();
                switch (input.ToLower())
                {
                    case "j":
                        BuyBook(user, book);
                        continueLoop = false;
                        break;

                    case "n":
                        continueLoop = false;
                        break;

                    default:
                        SharedError.PrintWrongInput();
                        continueLoop = true;
                        break;
                }
            } while (continueLoop);
        }
        /// <summary>
        /// Listing categories to be chosen from. Returns one single category
        /// </summary>
        /// <param name="categories">Takes a  list of categories</param>
        /// <returns>Returns one single category</returns>
        private static BookCategory ChooseCategoryToView(List<BookCategory> categories)
        {
            var continueLoop = true;
            Tuple<string, int> input;
            do
            {
                input = SharedController.GetAndValidateInput().ToTuple();

                if (input.Item2 > 0
                   && input.Item2 <= categories.Count)
                {
                    continueLoop = false;
                }
                else
                {
                    SharedError.PrintWrongInput();
                    continueLoop = true;
                }
            } while (continueLoop);

            return categories[input.Item2 - 1];
        }

        /// <summary>
        /// Find all categories in the database
        /// </summary>
        /// <returns>returns a list of all categories in database</returns>
        private static List<BookCategory> FindAndListCategories()
        {
            List<BookCategory> categories = new List<BookCategory>();
            categories = api.GetCategories();
            Console.Clear();
            if (categories.Count > 0)
            {
                SharedView.ListCategories(categories);
            }

            return categories;
        }

        /// <summary>
        /// Method for searching with keyword and getting a list of matching categories
        /// </summary>
        /// <returns>returns a list of matching categories for the search keyword</returns>
        private static List<BookCategory> SearchAndListCategories()
        {
            List<BookCategory> categories = new List<BookCategory>();
            BookView.SearchForCategory();
            var input = SharedController.GetSearchInput();
            categories = api.GetCategories(input);
            Console.Clear();
            if (categories.Count > 0)
            {
                SharedView.ListCategories(categories);
            }

            return categories;
        }
    }
}