using Bookshop.Helpers;
using Bookshop.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Controllers
{
    class AdminBooksController
    {
        Layout layout = new Layout();
        MenuController menuController = new MenuController();

        /// <summary>
        /// Handles the logic for the index page.
        /// </summary>
        public void Index()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            int option = menuController.Menu(Views.AdminBooks.Index.menuOptions, false);
            switch (option)
            {
                case 0: // Add book
                    AddBook();
                    break;
                case 1: // Edit book
                    EditBook();
                    break;
                case 2: // Add category
                    AddCategory();
                    break;
                case 3: // Update category
                    UpdateCategory();
                    break;
                case 4: // Delete category
                    DeleteCategory();
                    break;
                case 5: // Back
                    AdminHomeController adminHomeController = new AdminHomeController();
                    adminHomeController.Index();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the logic for adding a new book.
        /// </summary>
        public void AddBook()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminBooks.AddBook.PrintAddBookPage();

            int option = menuController.Menu(Views.AdminBooks.AddBook.menuOptions, true);
            switch (option)
            {
                case 0: // Edit book
                    EditBook();
                    break;
                case 1: // Add category
                    AddCategory();
                    break;
                case 2: // Update category
                    UpdateCategory();
                    break;
                case 3: // Delete category
                    DeleteCategory();
                    break;
                case 4: // Back
                    Index();
                    break;
                default:
                    break;
            }

            List<(string title, string author, int price, int amount)> userInput = Views.AdminBooks
                .AddBook.UseAddBookPage();
            bool addedBook = GlobalVariables.Api.AddBook(GlobalVariables.User.Id, 
                userInput[0].title, userInput[0].author, userInput[0].price, userInput[0].amount);

            if (addedBook == true)
            {
                Views.AdminBooks.AddBook.Success();
            }
            else
            {
                Views.AdminBooks.AddBook.Failure();
            }

            Index();
        }

        /// <summary>
        /// Handles the logic for editing a book.
        /// </summary>
        public void EditBook()
        {
            BookComparer comparer = new BookComparer();

            layout.ClearMainContent();
            layout.ClearMenu();

            Views.Book.Search.PrintSearchBar();

            int option = menuController.Menu(Views.AdminBooks.EditBook.menuOptions, true);
            switch (option)
            {
                case 0: // Add book
                    AddBook();
                    break;
                case 1: // Back
                    Index();
                    break;
                default:
                    break;
            }

            string userInput = Views.Book.Search.UseSearchBar();

            List<Webbutik.Models.Book> books = GlobalVariables.Api.GetBooks(userInput).Distinct()
                .ToList();
            List<Webbutik.Models.Book> author = GlobalVariables.Api.GetAuthors(userInput).Distinct()
                .ToList();
            List<Webbutik.Models.BookCategory> categoryKeyword = GlobalVariables.Api
                .GetCategories(userInput).Distinct().ToList();

            List<Webbutik.Models.Book> categories = new List<Webbutik.Models.Book>();

            for (int i = 0; i < categoryKeyword.Count; i++)
            {
                categories = categories.Union(GlobalVariables.Api.GetCategory(
                    categoryKeyword[i].Id), comparer).ToList();
            }

            List<Webbutik.Models.Book> filteredSearch = books;
            filteredSearch = filteredSearch.Union(author, comparer).ToList();
            filteredSearch = filteredSearch.Union(categories, comparer).ToList();

            Views.Book.Search.ShowSearchResult(filteredSearch);

            GlobalVariables.BookId = menuController.MainContentMenu(filteredSearch);

            BookInfo();
        }

        /// <summary>
        /// Handles the logic for the information of a book.
        /// </summary>
        public void BookInfo()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminBooks.BookInfo.PrintBookInfo();

            int option = menuController.Menu(Views.AdminBooks.BookInfo.menuOptions, false);
            switch (option)
            {
                case 0: // Change amount
                    ChangeAmount();
                    break;
                case 1: // Update book
                    UpdateBook();
                    break;
                case 2: // Remove book
                    RemoveBook();
                    break;
                case 3: // Change category
                    ChangeCategory();
                    break;
                case 4: // Back
                    EditBook();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the logic for changeing the amount of a specific book.
        /// </summary>
        public void ChangeAmount()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminBooks.ChangeAmount.PrintChangeAmountPage();

            int option = menuController.Menu(Views.AdminBooks.ChangeAmount.menuOptions, true);
            switch (option)
            {
                case 0: // Update book
                    UpdateBook();
                    break;
                case 1: // Remove book
                    RemoveBook();
                    break;
                case 2: // Change category
                    ChangeCategory();
                    break;
                case 3: // Back
                    EditBook();
                    break;
                default:
                    break;
            }

            int userInput = Views.AdminBooks.ChangeAmount.UseChangeAmountPage();
            GlobalVariables.Api.SetAmount(GlobalVariables.User.Id, GlobalVariables.BookId, 
                userInput);

            Index();
        }

        /// <summary>
        /// Handles the logic to update a book.
        /// </summary>
        public void UpdateBook()
        {
            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminBooks.UpdateBook.PrintUpdateBookPage();

            int option = menuController.Menu(Views.AdminBooks.UpdateBook.menuOptions, true);
            switch (option)
            {
                case 0: // Change amount
                    ChangeAmount();
                    break;
                case 1: // Remove book
                    RemoveBook();
                    break;
                case 2: // Change category
                    ChangeCategory();
                    break;
                case 3: // Back
                    EditBook();
                    break;
                default:
                    break;
            }

            var userInput = new List<(string title, string author, int price)>();
            userInput = Views.AdminBooks.UpdateBook.UseUpdateBookPage();
            
            bool isUpdated = GlobalVariables.Api.UpdateBook(GlobalVariables.User.Id, 
                GlobalVariables.BookId, userInput[0].title, userInput[0].author, 
                userInput[0].price);

            if (isUpdated == true)
            {
                Views.AdminBooks.UpdateBook.Success();
            }
            else
            {
                Views.AdminBooks.UpdateBook.Failure();
            }

            Index();
        }

        /// <summary>
        /// Hanldes the logic for removing a book.
        /// </summary>
        public void RemoveBook()
        {
            Menu menu = new Menu();

            if (GlobalVariables.IsUserLoggedIn == true)
            {
                GlobalVariables.Api.Ping(GlobalVariables.User.Id);
            }

            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminBooks.RemoveBook.Confirm();
            menu.PrintMessageBox(1);

            int option = menuController.Menu(Views.AdminBooks.RemoveBook.menuOptions, true);
            switch (option)
            {
                case 0: // Change amount
                    ChangeAmount();
                    break;
                case 1: // Update book
                    UpdateBook();
                    break;
                case 2: // Change category
                    ChangeCategory();
                    break;
                case 3: // Back
                    EditBook();
                    break;
                default:
                    break;
            }

            option = menuController.MessageWindow();
            switch (option)
            {
                case 0:
                    bool isRemoved = GlobalVariables.Api.DeleteBook(GlobalVariables.User.Id, 
                        GlobalVariables.BookId);

                    if (isRemoved == true)
                    {
                        Views.AdminBooks.RemoveBook.Success();
                    }
                    else
                    {
                        Views.AdminBooks.RemoveBook.Failure();
                    }
                    Index();
                    break;
                case 1:
                    Index();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the logic to change the category of a book.
        /// </summary>
        public void ChangeCategory()
        {
            if (GlobalVariables.IsUserLoggedIn == true)
            {
                GlobalVariables.Api.Ping(GlobalVariables.User.Id);
            }

            layout.ClearMainContent();
            layout.ClearMenu();

            List<Webbutik.Models.BookCategory> categories = GlobalVariables.Api.GetCategories();
            Views.Book.ListCategories.ListAllCategories(categories);

            int option = menuController.Menu(Views.AdminBooks.ChangeCategory.menuOptions, true);
            switch (option)
            {
                case 0: // Change amount
                    ChangeAmount();
                    break;
                case 1: // Update book
                    UpdateBook();
                    break;
                case 2: // Remove book
                    RemoveBook();
                    break;
                case 3: // Back
                    EditBook();
                    break;
                default:
                    break;
            }

            option = menuController.MainContentMenu(categories);

            layout.ClearMainContent();
            bool isChanged = GlobalVariables.Api.AddBookToCategory(GlobalVariables.User.Id, 
                GlobalVariables.BookId, option);

            if (isChanged == true)
            {
                Views.AdminBooks.ChangeCategory.Success();
            }
            Index();
        }

        /// <summary>
        /// Handles the logic for adding a new category.
        /// </summary>
        public void AddCategory()
        {
            if (GlobalVariables.IsUserLoggedIn == true)
            {
                GlobalVariables.Api.Ping(GlobalVariables.User.Id);
            }

            layout.ClearMainContent();
            layout.ClearMenu();

            Views.AdminBooks.AddCategory.PrintAddCategoryPage();

            int option = menuController.Menu(Views.AdminBooks.AddCategory.menuOptions, true);
            switch (option)
            {
                case 0: // Add book
                    AddBook();
                    break;
                case 1: // Edit book
                    EditBook();
                    break;
                case 2: // Update category
                    UpdateCategory();
                    break;
                case 3: // Delete category
                    DeleteCategory();
                    break;
                case 4: // Back
                    Index();
                    break;
                default:
                    break;
            }

            string userInput = Views.AdminBooks.AddCategory.UseAddCategoryPage();
            bool isAdded = GlobalVariables.Api.AddCategory(GlobalVariables.User.Id, userInput);

            if (isAdded == true)
            {
                Views.AdminBooks.AddCategory.Success();
            }
            else
            {
                Views.AdminBooks.AddCategory.Failure();
            }

            Index();
        }

        /// <summary>
        /// Handles the logic to update a category.
        /// </summary>
        public void UpdateCategory()
        {
            if (GlobalVariables.IsUserLoggedIn == true)
            {
                GlobalVariables.Api.Ping(GlobalVariables.User.Id);
            }

            layout.ClearMainContent();
            layout.ClearMenu();

            List<Webbutik.Models.BookCategory> categories = GlobalVariables.Api.GetCategories();
            Views.Book.ListCategories.ListAllCategories(categories);

            int option = menuController.Menu(Views.AdminBooks.UpdateCategory.menuOptions, true);
            switch (option)
            {
                case 0: // Add book
                    AddBook();
                    break;
                case 1: // Edit book
                    EditBook();
                    break;
                case 2: // Add category
                    AddCategory();
                    break;
                case 3: // Delete category
                    DeleteCategory();
                    break;
                case 4: // Back
                    Index();
                    break;
                default:
                    break;
            }

            option = menuController.MainContentMenu(categories);

            layout.ClearMainContent();
            string userInput = Views.AdminBooks.UpdateCategory.UseUpdateCategoryPage();
            bool isUpdated = GlobalVariables.Api.UpdateCategory(GlobalVariables.User.Id, 
                option, userInput);
            if (isUpdated == true)
            {
                Views.AdminBooks.UpdateCategory.Success();
            }

            Index();
        }

        /// <summary>
        /// Handles the logic to delete a category if the category is not in use.
        /// </summary>
        public void DeleteCategory()
        {
            if (GlobalVariables.IsUserLoggedIn == true)
            {
                GlobalVariables.Api.Ping(GlobalVariables.User.Id);
            }

            layout.ClearMainContent();
            layout.ClearMenu();

            List<Webbutik.Models.BookCategory> categories = GlobalVariables.Api.GetCategories();
            Views.Book.ListCategories.ListAllCategories(categories);

            int option = menuController.Menu(Views.AdminBooks.DeleteCategory.menuOptions, true);
            switch (option)
            {
                case 0: // Add book
                    AddBook();
                    break;
                case 1: // Edit book
                    EditBook();
                    break;
                case 2: // Add category
                    AddCategory();
                    break;
                case 3: // Update category
                    UpdateCategory();
                    break;
                case 4: // Back
                    Index();
                    break;
                default:
                    break;
            }

            int categoryId = menuController.MainContentMenu(categories);

            layout.ClearMainContent();
            Views.AdminBooks.DeleteCategory.Confirm();
            option = menuController.MessageWindow();
            switch (option)
            {
                case 0:
                    bool isDeleted = GlobalVariables.Api.DeleteCategory(
                        GlobalVariables.User.Id, categoryId);

                    if (isDeleted == true)
                    {
                        Views.AdminBooks.DeleteCategory.Success();
                    }
                    else
                    {
                        Views.AdminBooks.DeleteCategory.Failure();
                    }
                    Index();
                    break;
                case 1:
                    Index();
                    break;
                default:
                    break;
            }
        }
    }
}
