using System;
using System.Collections.Generic;
using System.Linq;
using WebbShop.Models;
using WebbutikFrontend.Views.Shared;
using static WebbutikFrontend.Utils.Helper;

namespace WebbutikFrontend.Controllers
{
    public class BooksController
    {
        /// <summary>
        /// Shows a special <see cref="Book"/>
        /// menu for the <paramref name="adminId"/>.
        /// </summary>
        /// <param name="userId"></param>
        public void Index(int userId = 0)
        {
            if (API.UserIsAdmin(userId))
            {
                while (true)
                {
                    Message.Ping(userId);
                    Views.BookMenu.Index.View();
                    bool exit;
                    do
                    {
                        exit = true;
                        switch (Get.Choice())
                        {
                            case 1:
                                AddBook(userId);
                                break;

                            case 2:
                                SearchBooks(userId);
                                break;

                            case 3:
                                return;

                            default:
                                Message.Error();
                                exit = false;
                                break;
                        }
                    } while (!exit);
                }
            }
            else
            {
                SearchBooks(userId);
            }
            
        }

        /// <summary>
        /// Lets the <paramref name="adminId"/> input the information
        /// required to add a <see cref="Book"/>. If the book exists the amount
        /// is increased, otherwise a new book is created.
        /// </summary>
        /// <param name="adminId"></param>
        private void AddBook(int adminId)
        {
            Views.BookMenu.AddBook.View();
            string title = Get.Text("title");
            if (title.Length != 0)
            {
                var books = API.GetBooks(title);
                if (books.Count > 0)
                {
                    var ctr = Display.Books(books, "to edit");
                    bool exit;
                    do
                    {
                        exit = true;
                        var choice = Get.Choice();
                        if (choice > 0 && choice < ctr)
                        {
                            var book = books[choice - 1];
                            do
                            {
                                exit = true;
                                Console.WriteLine();
                                var amount = Get.Number("amount");
                                if (amount > 0)
                                {
                                    if (API.AddBook(adminId, book.Id, book.Title, book.Author, book.Price, amount))
                                    {
                                        Message.Success($"{amount} of the book {book.Title} was successfully added!");
                                    }
                                    else
                                    {
                                        Message.Error("Something went wrong.");
                                    }
                                    break;
                                }
                                else
                                {
                                    Message.Error();
                                    exit = false;
                                }
                            } while (!exit);
                        }
                        else if (choice == ctr)
                        {
                            if (Get.DoYouWantTo($"add {title} as a new book"))
                            {
                                AddNewBook(adminId, title);
                            }
                        }
                        else
                        {
                            Message.Error();
                            exit = false;
                        }
                    } while (!exit);
                }
                else
                {
                    AddNewBook(adminId, title);
                }
            }
        }

        /// <summary>
        /// Lets the <paramref name="adminId"/> add the specified
        /// <paramref name="book"/> to a <see cref="BookCategory"/>.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="book"></param>
        private void AddBookToCategory(int adminId, Book book)
        {
            bool exit;
            var categories = API.GetCategories();
            if (categories.Count > 0)
            {
                var ctr = Display.Categories(categories);
                do
                {
                    exit = true;
                    var choice = Get.Choice();
                    if (choice > 0 && choice < ctr)
                    {
                        var category = categories[choice - 1];
                        if (API.AddBookToCategory(adminId, book.Id, category.Id))
                        {
                            Message.Success($"{book.Title} was added to {category.Name}!");
                        }
                        else
                        {
                            Message.Error("Something went wrong.");
                        }
                    }
                    else if (choice != ctr)
                    {
                        Message.Error();
                        exit = false;
                    }
                } while (!exit);
            }
            else
            {
                Message.Error("There are no categories available!");
            }
        }

        /// <summary>
        /// Lets the <paramref name="adminId"/> add a new
        /// <see cref="Book"/> to the database.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="title"></param>
        private void AddNewBook(int adminId, string title)
        {
            var author = Get.Text("author");
            if (author.Length != 0)
            {
                var price = Get.Number("price");
                var amount = Get.Number("amount");
                if (API.AddBook(adminId, 0, title, author, price, amount))
                {
                    Message.Success($"{title} was successfully added!");
                }
                else
                {
                    Message.Error("Something went wrong.");
                }
            }
        }

        /// <summary>
        /// Lets a user buy a specified <see cref="Book"/>
        /// based on the <paramref name="bookId"/>.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        private void BuyBook(int userId, int bookId)
        {
            if (API.BuyBook(userId, bookId))
            {
                var book = API.GetBook(bookId);
                Message.Success($"{book.Title} was successfully purchased.");
            }
            else
            {
                Message.Error("You have to be logged in to buy a book.");
            }
        }

        /// <summary>
        /// Lets the <paramref name="adminId"/> delete
        /// the specified <paramref name="book"/>.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="book"></param>
        private bool DeleteBook(int adminId, Book book)
        {
            if (API.DeleteBook(adminId, book.Id))
            {
                Message.Success($"{book.Title} was successfully deleted!");
                return true;
            }
            else
            {
                Message.Error($"{book.Title} was only reduced by 1.");
                return false;
            }
        }

        /// <summary>
        /// Lets the user search for books that match a keyword.
        /// The search will look for matches in titles, authors,
        /// and categories and then show the books that match.
        /// </summary>
        /// <param name="userId"></param>
        private void FreeSearch(int userId)
        {
            var keyword = Get.Text("keyword", "\n\t");
            var books = new List<Book>();
            foreach (var category in API.GetCategories(keyword))
            {
                foreach (var book in API.GetCategory(category.Id))
                {
                    books.Add(book);
                }
            }

            foreach (var book in API.GetBooks(keyword))
            {
                books.Add(book);
            }

            foreach (var book in API.GetAuthors(keyword))
            {
                books.Add(book);
            }

            books = books.Distinct().ToList();
            ShowBooks(userId, books);
        }

        /// <summary>
        /// Lets the user search for books in different ways.
        /// </summary>
        /// <param name="userId"></param>
        private void SearchBooks(int userId)
        {
            while (true)
            {
                Message.Ping(userId);
                Views.Books.SearchBooks.View();
                bool exit;
                do
                {
                    exit = true;
                    switch (Get.Choice())
                    {
                        case 1:
                            SearchByTitle(userId);
                            break;

                        case 2:
                            SearchByAuthor(userId);
                            break;

                        case 3:
                            SearchByCategory(userId);
                            break;

                        case 4:
                            FreeSearch(userId);
                            break;

                        case 5:
                            return;

                        default:
                            Message.Error();
                            exit = false;
                            break;
                    }
                } while (!exit);
            }
        }

        /// <summary>
        /// Lets the user search for books through authors.
        /// </summary>
        /// <param name="userId"></param>
        private void SearchByAuthor(int userId)
        {
            var author = Get.Text("author", "\n\t");
            var books = API.GetAuthors(author);
            ShowBooks(userId, books);
        }

        /// <summary>
        /// Lets the user search for books through categories.
        /// </summary>
        /// <param name="userId"></param>
        private void SearchByCategory(int userId)
        {
            var categories = API.GetCategories();
            if (categories.Count > 0)
            {
                var ctr = Display.Categories(categories);
                bool exit;
                do
                {
                    exit = true;
                    var choice = Get.Choice();
                    if (choice > 0 && choice < ctr)
                    {
                        var category = categories[choice - 1];
                        var books = API.GetAvailableBooks(category.Id);
                        if (API.UserIsAdmin(userId))
                        {
                            books = API.GetCategory(category.Id);
                        }
                        ShowBooks(userId, books);
                    }
                    else if (choice != ctr)
                    {
                        Message.Error();
                        exit = false;
                    }
                } while (!exit);
            }
            else
            {
                Message.Error("There are no categories available!");
            }
        }

        /// <summary>
        /// Lets the user search for books through titles.
        /// </summary>
        /// <param name="userId"></param>
        private void SearchByTitle(int userId)
        {
            var title = Get.Text("title", "\n\t");
            var books = API.GetBooks(title);
            ShowBooks(userId, books);
        }

        /// <summary>
        /// If the user is admin shows a menu admin
        /// choose different things to do with the specified.
        /// Else asks user to buy book.
        /// <paramref name="book"/>.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="book"></param>
        private void SelectedBook(int userId, Book book)
        {
            if (API.UserIsAdmin(userId))
            {
                bool outerExit = false;
                while (!outerExit)
                {
                    Message.Ping(userId);
                    Views.Books.SelectedBook.View(book);
                    bool innerExit;
                    do
                    {
                        innerExit = true;
                        switch (Get.Choice())
                        {
                            case 1:
                                SetAmount(userId, book);
                                break;

                            case 2:
                                AddBookToCategory(userId, book);
                                break;

                            case 3:
                                UpdateBook(userId, book);
                                break;

                            case 4:
                                outerExit = DeleteBook(userId, book);
                                break;

                            case 5:
                                outerExit = true;
                                break;

                            default:
                                Message.Error();
                                innerExit = false;
                                break;
                        }
                    } while (!innerExit);
                }
            }
            else
            {
                if (Get.DoYouWantTo($"buy {book.Title}"))
                {
                    BuyBook(userId, book.Id);
                }
            }
        }

        /// <summary>
        /// Lets the <paramref name="adminId"/> set the amount
        /// for the specified <paramref name="book"/>.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="book"></param>
        private void SetAmount(int adminId, Book book)
        {
            bool exit;
            do
            {
                exit = true;
                int amount = Get.Number("amount", "\n\t");
                if (amount > 0)
                {
                    API.SetAmount(adminId, book.Id, amount);
                    Message.Success($"The amount for {book.Title} was set to {amount}!");
                }
                else
                {
                    Message.Error();
                    exit = false;
                }
            } while (!exit);
        }

        /// <summary>
        /// Lists all the books in <paramref name="books"/> in a
        /// menu like manner and lets the user choose a book to buy.
        /// If the user is an admin a special menu will open for
        /// the book instead of the book being purchased.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="books"></param>
        private void ShowBooks(int userId, List<Book> books)
        {
            if (!API.UserIsAdmin(userId))
            {
                books = books.Where(b => b.Amount > 0).ToList();
            }

            if (books.Count > 0)
            {
                var ctr = Display.Books(books, API.UserIsAdmin(userId) ? "edit" : "buy");
                bool exit;
                do
                {
                    exit = true;
                    var choice = Get.Choice();
                    if (choice > 0 && choice < ctr)
                    {
                        var book = books[choice - 1];
                        SelectedBook(userId, book);
                    }
                    else if (choice != ctr)
                    {
                        Message.Error();
                        exit = false;
                    }
                } while (!exit);
            }
            else
            {
                Message.Error("There are no books available that match your search.");
            }
        }

        /// <summary>
        /// Shows an update menu for the <paramref name="adminId"/> and lets
        /// him or her make changes to the specified <paramref name="book"/>.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="book"></param>
        private void UpdateBook(int adminId, Book book)
        {
            while (true)
            {
                API.Ping(adminId);
                Views.Books.Update.View(book);
                bool exit;
                do
                {
                    exit = true;
                    switch (Get.Choice())
                    {
                        case 1:
                            Console.WriteLine();
                            book.Title = Get.Text("title");
                            break;

                        case 2:
                            Console.WriteLine();
                            book.Author = Get.Text("author");
                            break;

                        case 3:
                            Console.WriteLine();
                            book.Price = Get.Number("price");
                            break;

                        case 4:
                            return;

                        default:
                            Message.Error();
                            exit = false;
                            break;
                    }
                } while (!exit);

                if (API.UpdateBook(adminId, book.Id, book.Title, book.Author, book.Price))
                {
                    Message.Success($"{book.Title} was successfully updated!");
                }
                else
                {
                    Message.Error("Something went wrong.");
                }
            }
        }
    }
}
