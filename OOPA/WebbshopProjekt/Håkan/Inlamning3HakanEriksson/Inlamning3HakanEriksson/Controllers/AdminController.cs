using Inlamning2TrialRunHE;
using Inlamning2TrialRunHE.Models;
using Inlamning3HakanEriksson.Views;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Inlamning3HakanEriksson.Controllers
{
    public class AdminController
    {
        private WebbShopAPI api = new WebbShopAPI();
        /// <summary>
        /// This is the switch case for a logged in admin´s menu.
        /// </summary>
        /// <param name="user"></param>
        public void LoggedInAdmin(User user)
        {
            var view = new ViewMenues();
            var loginData = new List<string>();
            bool keepGoing = true;
            Console.Clear();
            do
            {
                Console.Clear();
                ViewMenues.AdminMenu(user);
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook(user);
                        api.Ping(user.Id);
                        break;

                    case "2":
                        SetAmount(user);
                        api.Ping(user.Id);
                        break;

                    case "3":
                        ListUsers(user);
                        api.Ping(user.Id);
                        break;

                    case "4":
                        FindUsers(user);
                        api.Ping(user.Id);
                        break;

                    case "5":
                        UpdateBook(user);
                        api.Ping(user.Id);
                        break;

                    case "6":
                        DeleteBook(user);
                        api.Ping(user.Id);
                        break;

                    case "7":
                        AddCategory(user);
                        api.Ping(user.Id);
                        break;

                    case "8":
                        AddBookToCategory(user);
                        api.Ping(user.Id);
                        break;

                    case "9":
                        UpdateCategory(user);
                        api.Ping(user.Id);
                        break;

                    case "10":
                        DeleteCategory(user);
                        api.Ping(user.Id);
                        break;

                    case "11":
                        AddUser(user);
                        api.Ping(user.Id);
                        break;

                    case "12":
                        ViewMessages.Exitmessage();
                        Thread.Sleep(2000);
                        api.Logout(user.Id);
                        Environment.Exit(0);
                        break;

                    default:
                        ViewMessages.SomethingWentWrongView();
                        break;
                }
            } while (keepGoing == true);
        }
        /// <summary>
        /// Sends the admin user to viewmessages and the method addbook.
        /// The admins book details is stored in a list with strings named
        /// bookInfo. The detailes are then stored in variables and then sent
        /// to the API to be addded.
        /// </summary>
        /// <param name="user"></param>
        private void AddBook(User user)
        {
            var bookInfo = ViewMessages.AddBook();
            var title = bookInfo[0];
            var author = bookInfo[1];
            int.TryParse(bookInfo[2], out int price);
            int.TryParse(bookInfo[3], out int amount);
            var ok = api.Addbook(user.Id, 0, title, author, price, amount);
            if (ok)
            {
                ViewMessages.BookUpdated(title);
            }
            else
            {
                ViewMessages.SomethingWentWrongView();
            }
        }
        /// <summary>
        /// Let´s the admin add a new book to a category.
        /// </summary>
        /// <param name="user"></param>
        private void AddBookToCategory(User user)   // David ström hjälpte mig med denna metoden.
        {
            var keyword = ViewMessages.Keyword();
            var books = api.GetBooks(keyword);
            var choice = ViewMessages.ListBooks(books);
            var book = new Book();
            if (choice > 0 && choice <= books.Count)
            {
                book = books[choice - 1];
            }

            keyword = ViewMessages.Keyword("category");
            var categories = api.GetCategories(keyword);
            choice = ViewMessages.ListBookCategories(categories);
            var category = new BookCategory();
            if (choice > 0 && choice <= categories.Count)
            {
                category = categories[choice - 1];
            }

            var ok = api.AddBookToCategory(user.Id, book.Id, category.Id);
            if (ok)
            {
                ViewMessages.AddBookToCategory(book.Title, category.Name);
            }
            else
            {
                ViewMessages.SomethingWentWrongView();
            }
        }
        /// <summary>
        /// Lets a admin user add a category in the database.
        /// </summary>
        /// <param name="user"></param>
        private void AddCategory(User user)
        {
            var name = ViewMessages.SetCategoryName();
            var ok = api.AddCategory(user.Id, name);
            if (ok)
            {
                ViewMessages.Success();
            }
            else
            {
                ViewMessages.SomethingWentWrongView();
            }
        }
        /// <summary>
        /// Lets a admin user add a new user to the database.
        /// </summary>
        /// <param name="admin"></param>
        private void AddUser(User admin)
        {
            (string name, string password) user = ViewMessages.SetUserInfo();
            var ok = api.AddUser(admin.Id, user.name, user.password);
            if (ok)
            {
                ViewMessages.Success();
            }
            else
            {
                ViewMessages.SomethingWentWrongView();
            }
        }
        /// <summary>
        /// Lets a user admin delete a book from the database.
        /// </summary>
        /// <param name="user"></param>
        private void DeleteBook(User user)
        {
            var books = api.GetAllBooks();
            var choice = ViewMessages.ListBooks(books);
            if (choice > 0 && choice <= books.Count)
            {
                var book = books[choice - 1];
                var ok = api.DeleteBook(user.Id, book.Id);
                if (ok)
                {
                    ViewMessages.Success();
                }
                else
                {
                    ViewMessages.SomethingWentWrongView();
                }
            }
        }
        /// <summary>
        /// Lets the loged in administrator see the list of categories
        /// by searching with a keyword. Admin is then asked what category 
        /// to delete. if the choice -1 is bigger then 0 and less or equal to 
        /// categories.count. The answer is then sent to the api method
        /// with the same name along with the user id.
        /// If the category is dleted ok becomes true and a success 
        /// message is written to confirm to the admin that it worked.
        /// If no category is deleted a error message is written instead.
        /// 
        /// This long comment is because David Ström helped me understand
        /// how to think about the methods containing the CategoryId and
        /// this way I can show I now understand it :)
        /// </summary>
        /// <param name="user"></param>
        private void DeleteCategory(User admin) // David ström hjälpte mig med denna metoden.
        {
            var keyword = ViewMessages.Keyword();
            var categories = api.GetCategories(keyword);
            var choice = ViewMessages.ListBookCategories(categories);
            if (choice > 0 && choice <= categories.Count)
            {
                var category = categories[choice - 1];
                var ok = api.DeleteCategory(admin.Id, category.Id);

                if (ok)
                {
                    ViewMessages.Success();
                }
                else
                {
                    ViewMessages.SomethingWentWrongView();
                }
            }
        }
        /// <summary>
        /// Lets the administrator search for users using a keyword.
        /// </summary>
        /// <param name="user"></param>
        private void FindUsers(User user)
        {
            string keyword = ViewMessages.Keyword("user");
            var list = api.FindUser(user.Id, keyword);
            ViewMessages.ListUsers(list);
            ViewMessages.PressAnyKeyMessage();
        }
        /// <summary>
        /// Lets the administrator see a list of every user in the database.
        /// </summary>
        /// <param name="user"></param>
        private void ListUsers(User user)
        {
            var list = api.ListUsers(user.Id);
            ViewMessages.ListUsers(list);
            ViewMessages.PressAnyKeyMessage();
        }
        /// <summary>
        /// Lets the administrator set a new amount for a choosen book.
        /// </summary>
        /// <param name="user"></param>
        private void SetAmount(User user)
        {
            var books = api.GetAllBooks();
            var choice = ViewMessages.ListBooks(books);
            if (choice > 0 && choice <= books.Count)
            {
                var book = books[choice - 1];
                int amount = ViewMessages.SetAmountOfBooks();
                api.SetAmount(user.Id, book.Id, amount);
                ViewMessages.CurrentAmount(amount);
            }
        }
        /// <summary>
        /// Lets the administrator user update a books details. 
        /// </summary>
        /// <param name="user"></param>
        private void UpdateBook(User user)
        {
            var books = api.GetAllBooks();
            var choice = ViewMessages.ListBooks(books);
            if (choice > 0 && choice <= books.Count)
            {
                var book = books[choice - 1];
                var bookinfo = ViewMessages.AskUserForInput();
                var title = bookinfo[1];
                var author = bookinfo[2];
                int.TryParse(bookinfo[3], out int price);
                var ok = api.UpdateBook(user.Id, book.Id, title, author, price);
                if (ok)
                {
                    ViewMessages.BookUpdated(title);
                    ViewMessages.PressAnyKeyMessage();
                }
                else
                {
                    ViewMessages.SomethingWentWrongView();
                }
            }
        }
        /// <summary>
        /// Lets the administrator update a categorys name.
        /// </summary>
        /// <param name="user"></param>
        private void UpdateCategory(User user) // David ström hjälpte mig med denna metoden.
        {
            var keyword = ViewMessages.Keyword("category");
            var categories = api.GetCategories(keyword);
            var choice = ViewMessages.ListBookCategories(categories);
            if (choice > 0 && choice <= categories.Count)
            {
                var category = categories[choice - 1];
                var oldName = category.Name;
                var newName = ViewMessages.SetCategoryName("new name");
                var ok = api.UpdateCategory(user.Id, category.Id, newName);
                if (ok)
                {
                    ViewMessages.UpdatedCategory(oldName, newName);
                }
                else
                {
                    ViewMessages.SomethingWentWrongView();
                }
            }
        }
    }
}