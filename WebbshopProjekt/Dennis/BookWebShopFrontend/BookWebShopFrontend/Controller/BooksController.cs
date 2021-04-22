using BookWebShop;
using BookWebShopFrontend.View.Books;
using System;
using System.Threading;

namespace BookWebShopFrontend.Controller
{
    public class BooksController
    {
        /// <summary>
        /// Class for books menu and controller for admin and customer users.
        /// </summary>

        private WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// Book menu for customer user.
        /// </summary>
        /// <param name="userId"></param>
        public void BookMenuCustomer(int userId)
        {
            bool keepGoing = true;
            do
            {
                Console.Clear();
                ListBooks(userId);
                CustomerBooksMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            api.Ping(userId);
                            ListBooks(userId);
                            GetBookInfo(userId);
                            Thread.Sleep(2000);
                            break;

                        case 2:
                            Console.Clear();
                            api.Ping(userId);
                            ListBooks(userId);
                            SearchBook(userId);
                            Thread.Sleep(2000);
                            break;

                        case 3:
                            Console.Clear();
                            api.Ping(userId);
                            ListBooks(userId);
                            SearchByAuthor(userId);
                            Thread.Sleep(2000);
                            break;

                        case 4:
                            Console.Clear();
                            api.Ping(userId);
                            ListBooks(userId);
                            BuyBook(userId);
                            Thread.Sleep(2000);
                            break;

                        case 0:
                            Console.Clear();
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        /// <summary>
        /// Book menu for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        public void BooksMenuAdmin(int adminId)
        {
            bool keepGoing = true;
            do
            {
                Console.Clear();
                ListBooks(adminId);
                AdminBooksMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            api.Ping(adminId);
                            ListBooks(adminId);
                            AddBook(adminId);
                            Thread.Sleep(2000);
                            break;

                        case 2:
                            Console.Clear();
                            api.Ping(adminId);
                            ListBooks(adminId);
                            UpdateBook(adminId);
                            Thread.Sleep(2000);
                            break;

                        case 3:
                            Console.Clear();
                            api.Ping(adminId);
                            ListBooks(adminId);
                            DeleteBook(adminId);
                            Thread.Sleep(2000);
                            break;

                        case 4:
                            Console.Clear();
                            api.Ping(adminId);
                            ListBooks(adminId);
                            SetBookAmount(adminId);
                            Thread.Sleep(2000);
                            break;

                        case 0:
                            Console.Clear();
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        /// <summary>
        /// Method for adding a book for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        private void AddBook(int adminId)
        {
            Console.Write("\nEnter title: ");
            string title = Console.ReadLine();
            if (title.Length != 0)
            {
                Console.Write("Enter author: ");
                string author = Console.ReadLine();
                if (author.Length != 0)
                {
                    Console.Write("Enter price: ");
                    if (int.TryParse(Console.ReadLine(), out var price))
                    {
                        Console.Write("Enter amount: ");
                        if (int.TryParse(Console.ReadLine(), out var amount))
                        {
                            try
                            {
                                if (api.AddBook(adminId, title, author, price, amount))
                                {
                                    Console.WriteLine($"Success! {title} was added");
                                }
                                else { Console.WriteLine("Something went wrong."); }
                            }
                            catch { Console.WriteLine("Something went wrong."); }
                        }
                        else { Console.WriteLine("Wrong input."); }
                    }
                    else { Console.WriteLine("Wrong input."); }
                }
                else { Console.WriteLine("No input."); }
            }
            else { Console.WriteLine("No input."); }
        }

        /// <summary>
        /// Method for buying a book for customer user.
        /// </summary>
        /// <param name="userId"></param>
        private void BuyBook(int userId)
        {
            Console.Write("\nEnter Id number of the book you want to Buy: ");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                if (bookId != 0)
                {
                    try
                    {
                        if (api.BuyBook(userId, bookId))
                        {
                            Console.WriteLine("Success!");
                        }
                        else { Console.WriteLine("Something went wrong."); }
                    }
                    catch { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }

        /// <summary>
        /// Method to delete a book for admins user.
        /// </summary>
        /// <param name="adminId"></param>
        private void DeleteBook(int adminId)
        {
            Console.Write("\nEnter book Id number you want to delete: ");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                try
                {
                    if (api.DeleteBook(adminId, bookId))
                    {
                        Console.WriteLine($"Success! Book was deleted.");
                    }
                    else { Console.WriteLine("Something went wrong."); }
                }
                catch { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }

        /// <summary>
        /// Method for getting info about a book for customer user.
        /// </summary>
        /// <param name="userId"></param>
        private void GetBookInfo(int userId)
        {
            Console.Write("\nEnter Id number of the book you want info about: ");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                if (bookId != 0 && bookId > 0)
                {
                    if (api.GetBook(bookId) != null)
                    {
                        try
                        {
                            foreach (var book in api.GetBook(bookId))
                            {
                                Console.WriteLine($"{"Id:",-4}{"Title:",-20}{"CatId:",-7}{"Category:",-15}{"Author:",-20}{"Price:",-7}{"Amount:",-8}\n");
                                Console.WriteLine($"{book.Id + ".",-4}{book.Title,-20}{book.Category.Id,-7}{book.Category.Name,-15}{book.Author,-20}{book.Price,-7}{book.Amount,-8}");
                            }
                        }
                        catch { Console.WriteLine("Something went wrong."); }
                    }
                    else { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }

        /// <summary>
        /// Method for listing all avaliable books for both admin and customer user.
        /// </summary>
        /// <param name="userId"></param>
        private void ListBooks(int userId)
        {
            if (api.GetAvaliableBooks() != null)
            {
                try
                {
                    Console.WriteLine($"{"Id:",-4}{"Title:",-20}{"Author:",-20}{"Price:",-7}{"Amount:",-8}\n");
                    foreach (var book in api.GetAvaliableBooks())
                    {
                        Console.WriteLine($"{book.Id + ".",-4}{book.Title,-20}{book.Author,-20}{book.Price,-7}{book.Amount,-8}");
                    }
                }
                catch { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Something went wrong."); }
        }

        /// <summary>
        /// Method for searching a book by input for customer user.
        /// </summary>
        /// <param name="userId"></param>
        private void SearchBook(int userId)
        {
            Console.Write("\nEnter title name to search for: ");
            string bookBySearch = Console.ReadLine();
            if (bookBySearch != null)
            {
                try
                {
                    Console.WriteLine($"{"Id:",-4}{"Title:",-20}{"Author:",-20}{"Price:",-7}{"Amount:",-8}\n");
                    foreach (var book in api.GetBooks(bookBySearch))
                    {
                        Console.WriteLine($"{book.Id + ".",-4}{book.Title,-20}{book.Author,-20}{book.Price,-7}{book.Amount,-8}");
                    }
                }
                catch { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Something went wrong."); }
        }

        /// <summary>
        /// Method for searching for a book by author for customer user.
        /// </summary>
        /// <param name="userId"></param>
        private void SearchByAuthor(int userId)
        {
            Console.Write("\nEnter author name to search for: ");
            string bookByAuthor = Console.ReadLine();
            if (bookByAuthor != null && api.GetAuthors(bookByAuthor) != null)
            {
                try
                {
                    Console.WriteLine($"{"Id:",-4}{"Title:",-20}{"Author:",-20}{"Price:",-7}{"Amount:",-8}\n");
                    foreach (var book in api.GetAuthors(bookByAuthor))
                    {
                        Console.WriteLine($"{book.Id + ".",-4}{book.Title,-20}{book.Author,-20}{book.Price,-7}{book.Amount,-8}");
                    }
                }
                catch { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Something went wrong."); }
        }

        /// <summary>
        /// Method for setting the book amounts for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        private void SetBookAmount(int adminId)
        {
            Console.Write("\nEnter book Id number: ");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                Console.Write("Enter amount: ");
                if (int.TryParse(Console.ReadLine(), out var bookAmount))
                {
                    if (bookId != 0 && bookId > 0 && bookAmount != 0 && bookAmount > 0)
                    {
                        try
                        {
                            api.SetAmount(adminId, bookId, bookAmount);
                            foreach (var book in api.GetBook(bookId))
                            {
                                Console.WriteLine($"{book.Id}. {book.Title} Amount was increased to: {book.Amount}st");
                            }
                        }
                        catch { Console.WriteLine("Something went wrong."); }
                    }
                    else { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Wrong input!"); }
            }
            else { Console.WriteLine("Wrong input!"); }
        }

        /// <summary>
        /// Method for updating book info for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        private void UpdateBook(int adminId)
        {
            Console.Write("\nEnter Id of book you want to update: ");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                Console.Write("Enter title: ");
                string title = Console.ReadLine();
                if (title.Length != 0)
                {
                    Console.Write("Enter author: ");
                    string author = Console.ReadLine();
                    if (author.Length != 0)
                    {
                        Console.Write("Enter price: ");
                        if (int.TryParse(Console.ReadLine(), out var price))
                        {
                            try
                            {
                                if (api.UpdateBook(adminId, bookId, title, author, price))
                                {
                                    Console.WriteLine("Success! The book was updated.");
                                }
                                else { Console.WriteLine("Something went wrong."); }
                            }
                            catch { Console.WriteLine("Something went wrong."); }
                        }
                        else { Console.WriteLine("Wrong input."); }
                    }
                    else { Console.WriteLine("No input."); }
                }
                else { Console.WriteLine("No input."); }
            }
        }
    }
}