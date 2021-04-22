using Inlämning2WebbShop;
using Inlämning2WebbShop.Models;
using Inlämning3.Helpers;
using System;

namespace Inlämning3.Controllers
{
    internal class AdminBooksController
    {
        private WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// Method that takes a choice and calls method depending on choice.
        /// </summary>
        public void ManageBooks()
        {
            Account.KickOutIfNotLoggedInAdmin();
            int choice = Views.Admin.AdminMenus.BookMenu();
            switch (choice)
            {
                case 1:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    AddNewBook();
                    break;

                case 2:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    AddBookToCategory();
                    break;

                case 3:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    SetAmount();
                    break;

                case 4:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    UpdateBook();
                    break;

                case 5:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    DeleteBook();
                    break;

                case 6:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    AddCategory();
                    break;

                case 7:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    UpdateCategory();
                    break;

                case 8:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    DeleteCategory();
                    break;

                case 9:
                    Console.Clear();
                    var adminController = new AdminController();
                    adminController.AdminMenu();
                    break;

                case 10:
                    var logout = new LogoutController();
                    logout.LogoutAndGoToMainMenu();
                    break;

                default:
                    Console.Clear();
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    Messages.NotValidInput();
                    break;
            }
        }

        /// <summary>
        /// Gets the book and the amount as input and then calls API Set amount method
        /// </summary>
        private void SetAmount()
        {
            Account.KickOutIfNotLoggedInAdmin();
            Console.Clear();
            Views.Admin.ManageBooks.SetAmount(out string bookName, out int amount);
            Console.Clear();
            var book = api.GetBooks(bookName);
            if (book.Count == 1)
            {
                api.SetAmount(Account.UserId, book[0].Id, amount);
                Console.Clear();
                Messages.SuccessMessage();
            }
            else
            {
                Console.Clear();
                Messages.ErrorMessage();
            }
        }

        /// <summary>
        /// Gets the input and calls The API to Delete category.
        /// </summary>
        private void DeleteCategory()
        {
            Account.KickOutIfNotLoggedInAdmin();
            Console.Clear();
            var categories = api.GetCategories();
            Views.Admin.ManageBooks.DeleteCategory(categories, out BookCategory bookCategory);
            Console.Clear();
            if (bookCategory != null)
            {
                if (api.DeleteCategory(Account.UserId, bookCategory.Id))
                {
                    Console.Clear();
                    Messages.SuccessMessage();
                }
                else
                {
                    Console.Clear();
                    Messages.ErrorMessage();
                }
            }
        }

        /// <summary>
        /// Gets the input and calls The API to Update Category.
        /// </summary>
        private void UpdateCategory()
        {
            Account.KickOutIfNotLoggedInAdmin();
            Console.Clear();
            var categories = api.GetCategories();
            Views.Admin.ManageBooks.UpdateCategory(categories, out BookCategory categoryToChange, out string newCategoryName);
            Console.Clear();
            if (categoryToChange != null)
            {
                if (api.UpdateCategory(Account.UserId, categoryToChange.Id, newCategoryName))
                {
                    Console.Clear();
                    Messages.SuccessMessage();
                }
                else
                {
                    Console.Clear();
                    Messages.ErrorMessage();
                }
            }
            else
            {
                Messages.ErrorMessage();
            }
        }

        /// <summary>
        /// Gets category name as input from view method, then calls the API to add Category.
        /// </summary>
        private void AddCategory()
        {
            Account.KickOutIfNotLoggedInAdmin();
            Console.Clear();
            var categoryName = Views.Admin.ManageBooks.AddCategory();
            Console.Clear();
            var statement = api.AddCategory(Account.UserId, categoryName);
            if (statement)
            {
                Console.Clear();
                Messages.SuccessMessage();
            }
            else
            {
                Console.Clear();
                Messages.ErrorMessage();
            }
        }

        /// <summary>
        /// Gets book name as input from view method, then gets the book. Finally calls the Api to delete that book.
        /// </summary>
        private void DeleteBook()
        {
            Account.KickOutIfNotLoggedInAdmin();
            Console.Clear();
            var bookName = Views.Admin.ManageBooks.DeleteBook();
            Console.Clear();
            var book = api.GetBooks(bookName);
            if (book.Count < 1)
            {
                Console.Clear();
                Messages.ErrorMessage();
            }
            else
            {
                api.DeleteBook(Account.UserId, book[0].Id);
                Messages.SuccessMessage();
            }
        }

        /// <summary>
        ///  Gets book name and new information to update as input from view method, then gets the book. Finally calls the Api to update book.
        /// </summary>
        private void UpdateBook()
        {
            Account.KickOutIfNotLoggedInAdmin();
            Console.Clear();
            Views.Admin.ManageBooks.UpdateBook(out string bookName, out string title, out string author, out int price);
            Console.Clear();
            var bookToUpdate = api.GetBooks(bookName);
            if (bookToUpdate.Count < 1)
            {
                Console.Clear();
                Messages.ErrorMessage();
            }
            else
            {
                api.UpdateBook(Account.UserId, bookToUpdate[0].Id, title, author, price);
                Console.Clear();
                Messages.SuccessMessage();
            }
        }

        /// <summary>
        /// Gets which book to add a category to, and which category to add to the book. Then calls the API to add category to the book.
        /// </summary>
        private void AddBookToCategory()
        {
            Account.KickOutIfNotLoggedInAdmin();
            Console.Clear();
            Views.Admin.ManageBooks.AddBookToCategory(out string bookName, out string categoryName);
            Console.Clear();
            var books = api.GetBooks(bookName);
            var category = api.GetCategories(categoryName);
            if (books.Count < 1 || category.Count < 1)
            {
                Console.Clear();
                Messages.ErrorMessage();
            }
            else
            {
                if (api.AddBookToCategory(Account.UserId, books[0].Id, category[0].Id))
                {
                    Console.Clear();
                    Messages.SuccessMessage();
                }
                else
                {
                    Console.Clear();
                    Messages.ErrorMessage();
                }
            }
        }

        /// <summary>
        /// Gets book information from view, then calls Api to add book using the information gathered from the view.
        /// </summary>
        private void AddNewBook()
        {
            Account.KickOutIfNotLoggedInAdmin();
            Console.Clear();
            Views.Admin.ManageBooks.AddNewBook(out string title, out string author, out int price, out int amount);
            Console.Clear();

            var books = api.GetBooks(title);
            if (books.Count == 1)
            {
                api.AddBook(Account.UserId, books[0].Id, title, author, price, amount);
                Console.Clear();
                Messages.SuccessMessage();
            }
            else if (books.Count == 0)
            {
                api.AddBook(Account.UserId, 0, title, author, price, amount);
                Console.Clear();
                Messages.SuccessMessage();
            }
            else
            {
                Console.Clear();
                Messages.ErrorMessage();
            }
        }
    }
}