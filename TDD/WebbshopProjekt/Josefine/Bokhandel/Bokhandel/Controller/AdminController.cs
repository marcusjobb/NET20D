using Bokhandel.Help;
using Bokhandel.View;
using System;
using WebbShopJoR;

namespace Bokhandel.Controller
{
    internal class AdminController
    {
        private AdminView view = new AdminView();

        /// <summary>
        /// Adding new book
        /// </summary>
        /// <param name="adminId"></param>
        public void AddBook(int adminId)
        {
            var sucess = API.AddBook(adminId, 0, Title(), Author(), Price(), Amount());
            if (sucess) { view.Sucess(); }
            else if (!sucess) { view.AdminFail(); }
        }

        /// <summary>
        /// Ask for bookId and categoruId and add book to category
        /// </summary>
        /// <param name="adminId"></param>
        public void AddBookToCategory(int adminId)
        {
            var sucess = API.AddBookToCategory(adminId, BookId(), CategoryId());
            if (sucess) { view.Sucess(); }
            else if (!sucess) { view.AdminFail(); }
        }

        /// <summary>
        /// Add new category
        /// </summary>
        /// <param name="adminId"></param>
        public void AddCategory(int adminId)
        {
            view.EnterCategory();
            var category = Console.ReadLine();
            var sucess = API.AddCategory(adminId, category);
            if (sucess) { view.Sucess(); }
            else if (!sucess) { view.AdminFail(); }
        }

        /// <summary>
        /// Add new user with username and password
        /// </summary>
        /// <param name="adminId"></param>
        public void AddUser(int adminId)
        {
            var sucess = API.AddUser(adminId, UserController.EnterUsername(), UserController.EnterPassword());
            if (sucess) { view.Sucess(); }
            else if (!sucess) { view.AdminFail(); }
        }

        /// <summary>
        /// Controlling first menu
        /// </summary>
        /// <param name="adminId"></param>
        public void AdminMeny(int adminId)
        {
            API.Ping(adminId);
            bool loop = true;
            while (loop)
            {
                AdminView.AdminMenu();
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddBook(adminId);
                        break;

                    case "2":
                        SetAmount(adminId);
                        break;

                    case "3":
                        ListUsers(adminId);
                        break;

                    case "4":
                        FindUsers(adminId);
                        break;

                    case "5":
                        UpdateBook(adminId);
                        break;

                    case "6":
                        DeleteBook(adminId);
                        break;

                    case "7":
                        AddCategory(adminId);
                        break;

                    case "8":
                        AddBookToCategory(adminId);
                        break;

                    case "9":
                        UpdateCategory(adminId);
                        break;

                    case "10":
                        DeleteBook(adminId);
                        break;

                    case "11":
                        AddUser(adminId);
                        break;

                    case "x":
                        loop = false;
                        break;

                    default:
                        BookView.EnterValidNumber();
                        break;
                }
            }
        }
        /// <summary>
        /// Delete book
        /// </summary>
        /// <param name="adminId"></param>
        public void DeleteBook(int adminId)
        {
            var sucess = API.DeleteBook(adminId, BookId());
            if (sucess) { view.Sucess(); }
            else if (!sucess) { view.AdminFail(); }
        }

        /// <summary>
        /// Delete category, but only if empty
        /// </summary>
        /// <param name="adminId"></param>
        public void DeleteCategory(int adminId)
        {
            var sucess = API.DeleteCategory(adminId, CategoryId());
            if (sucess) { view.Sucess(); }
            else if (!sucess)
            {
                view.AdminFail();
                view.FailDeleteCategory();
            }
        }

        /// <summary>
        /// Search user
        /// </summary>
        /// <param name="adminId"></param>
        public void FindUsers(int adminId)
        {
            var users = API.FindUsers(adminId, SearchUserName());
            AdminView.ShowUsers(users);
        }

        /// <summary>
        /// List users
        /// </summary>
        /// <param name="adminId"></param>
        public void ListUsers(int adminId)
        {
            var users = API.ListUsers(adminId);
            AdminView.ShowUsers(users);
        }

        /// <summary>
        /// Ask for bookId, sets amount and then check amount
        /// </summary>
        /// <param name="adminId"></param>
        public void SetAmount(int adminId)
        {
            var bookId = BookId();
            API.SetAmount(adminId, bookId, Amount());
            var book = API.GetBook(bookId);
            if (book.Amount != 0)
            {
                view.Sucess();
                view.NrOfBooks(book.Amount);
            }
            else { view.AdminFail(); }
        }
        /// <summary>
        /// Ask for bookId and what to update and then update
        /// </summary>
        /// <param name="adminId"></param>
        public void UpdateBook(int adminId)
        {
            var bookid = BookId();
            var book = API.GetBook(bookid);
            AdminView.UpdateBookChoice(book);
            AdminView.ChooseUpdate();
            var choice = Help.Input.ConvertInput(Console.ReadLine());
            if (choice == 1) { book.Title = Title(); }
            else if (choice == 2) { book.Author = Author(); }
            else if (choice == 3) { book.Price = Price(); }
            var sucess = API.UpdateBook(adminId, bookid, book.Title, book.Author, book.Price);
            if (sucess) { view.Sucess(); }
            else if (!sucess) { view.AdminFail(); }
        }
        /// <summary>
        /// Ask for categoryId and new name for category and update it
        /// </summary>
        /// <param name="adminId"></param>
        public void UpdateCategory(int adminId)
        {
            view.EnterCategory();
            var category = Console.ReadLine();
            var sucess = API.UpdateCategory(adminId, CategoryId(), category);
            if (sucess) { view.Sucess(); }
            else if (!sucess) { view.AdminFail(); }
        }
        /// <summary>
        /// Ask for amount
        /// </summary>
        /// <returns></returns>
        private int Amount()
        {
            view.EnterAmount();
            return Input.ConvertInput(Console.ReadLine());
        }

        /// <summary>
        /// Ask for author
        /// </summary>
        /// <returns></returns>
        private string Author()
        {
            view.EnterAuthor();
            return Console.ReadLine().Trim();
        }

        /// <summary>
        /// Ask for bookId
        /// </summary>
        /// <returns></returns>
        private int BookId()
        {
            view.EnterBookId();
            return Input.ConvertInput(Console.ReadLine());
        }

        /// <summary>
        /// Ask for categoryId
        /// </summary>
        /// <returns></returns>
        private int CategoryId()
        {
            view.EnterCategoryId();
            return Input.ConvertInput(Console.ReadLine());
        }

        /// <summary>
        /// Ask for price
        /// </summary>
        /// <returns></returns>
        private int Price()
        {
            view.EnterPrice();
            return Input.ConvertInput(Console.ReadLine());
        }

        /// <summary>
        /// Ask for name to searh
        /// </summary>
        /// <returns></returns>
        private string SearchUserName()
        {
            view.FindUser();
            return Console.ReadLine().Trim();
        }

        /// <summary>
        /// Ask for title
        /// </summary>
        /// <returns></returns>
        private string Title()
        {
            view.EnterTitle();
            return Console.ReadLine().Trim();
        }
    }
}