using System;
using System.Collections.Generic;
using WebshopAPI;
using WebshopAPI.Models;
using WebshopAPI.Utils;
using WebshopMVC.Controllers;
using WebshopMVC.UtilsMVC.Converters;
using WebshopMVC.Views;
using WebshopMVC.Views.Messages;
using WebshopMVC.Views.Messages.Admin;

namespace WebshopMVC.ControllersAdmin
{
    /// <summary>
    /// Admin menu class for handling Book object data
    /// </summary>
    internal class AdminBookController
    {
        /// <summary>
        /// Adds a new book to database
        /// User object as parameter for handling session timer and ping function
        /// </summary>
        /// <param name="admin"></param>
        public static void AddBookToInventory(User admin)
        {
            bool isBookAdded = false;
            do
            {
                if (SessionTimer.CheckSessionTimer(admin.SessionTimer) == true || admin.SessionTimer == DateTime.MinValue)
                {
                    Console.Clear();
                    GeneralMessage.AdminNotLoggedIn();
                    break;
                }

                Console.Clear();
                var api = new API();
                Console.Write("Enter title:");
                var title = Console.ReadLine();

                Console.Write("Enter author:");
                var author = Console.ReadLine();

                Console.Write("Enter price:");
                int.TryParse(Console.ReadLine(), out var price);

                Console.Write("Enter amount:");
                int.TryParse(Console.ReadLine(), out var amount);

                var result = api.AddBook(admin.Id, title, author, price, amount);
                if (result == false)
                {
                    var input = ErrorMessage.ErrorAbort("adding a new book", "you entered incorrect data");
                    if (input != "")
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    SuccessMessage.SuccessWithString("Book added to inventory");
                    isBookAdded = true;
                    UserController.SendPing(admin.Id);
                }
            } while (isBookAdded == false);
        }

        /// <summary>
        /// Sets Book objects Amount
        /// User object as parameter for handling session timer and ping function
        /// </summary>
        /// <param name="admin"></param>
        public static void SetAmount(User admin)
        {
            bool isAmountSet = false;
            do
            {
                if (SessionTimer.CheckSessionTimer(admin.SessionTimer) == true || admin.SessionTimer == DateTime.MinValue)
                {
                    Console.Clear();
                    GeneralMessage.AdminNotLoggedIn();
                    break;
                }

                Console.Clear();
                var api = new API();
                Console.Write("Enter book Id:");
                int.TryParse(Console.ReadLine(), out var bookId);

                Console.Write("Enter amount:");
                int.TryParse(Console.ReadLine(), out var amount);

                var result = api.SetAmount(admin.Id, bookId, amount);
                if (result.isAmountSet == false)
                {
                    var input = ErrorMessage.ErrorAbort("setting the amount", "you entered incorrect data");
                    if (input != "")
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    SuccessMessage.SuccessWithInt("Amount set to", result.amount);
                    isAmountSet = true;
                    UserController.SendPing(admin.Id);
                }
            } while (isAmountSet == false);
        }

        /// <summary>
        /// Updates a Book objects properties
        /// User object as parameter for handling session timer and ping function
        /// </summary>
        /// <param name="admin"></param>
        public static void UpdateBook(User admin)
        {
            bool isBookUpdated = false;
            do
            {
                if (SessionTimer.CheckSessionTimer(admin.SessionTimer) == true || admin.SessionTimer == DateTime.MinValue)
                {
                    Console.Clear();
                    GeneralMessage.AdminNotLoggedIn();
                    break;
                }

                Console.Clear();
                var api = new API();
                Console.Write("Enter book Id: ");
                int.TryParse(Console.ReadLine(), out var bookId);

                Console.Write("Enter title: ");
                var title = Console.ReadLine();

                Console.Write("Enter author: ");
                var author = Console.ReadLine();

                Console.Write("Enter price: ");
                int.TryParse(Console.ReadLine(), out var price);

                var result = api.UpdateBook(admin.Id, bookId, title, author, price);
                if (result == false)
                {
                    var input = ErrorMessage.ErrorAbort("updating the book", "you entered incorrect data");
                    if (input != "")
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    SuccessMessage.SuccessWithString("Book updated");
                    isBookUpdated = true;
                    UserController.SendPing(admin.Id);
                }
            } while (isBookUpdated == false);
        }

        /// <summary>
        /// Deletes one(1) Book object from database
        /// User object as parameter for handling session timer and ping function
        /// </summary>
        /// <param name="admin"></param>
        public static void DeleteBook(User admin)
        {
            bool isBookDeleted = false;
            do
            {
                if (SessionTimer.CheckSessionTimer(admin.SessionTimer) == true || admin.SessionTimer == DateTime.MinValue)
                {
                    Console.Clear();
                    GeneralMessage.AdminNotLoggedIn();
                    break;
                }

                Console.Clear();
                var api = new API();
                Console.Write("Enter book Id: ");
                int.TryParse(Console.ReadLine(), out var bookId);

                var result = api.DeleteBook(admin.Id, bookId);
                if (result == false)
                {
                    var input = ErrorMessage.ErrorAbort("deleting the book", "you entered incorrect data");
                    if (input != "")
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    SuccessMessage.SuccessWithString("Book deleted");
                    isBookDeleted = true;
                    UserController.SendPing(admin.Id);
                }
            } while (isBookDeleted == false);
        }

        /// <summary>
        /// Retrieves list of all SoldBook objects present in database
        /// User object as parameter for handling session timer and ping function
        /// </summary>
        /// <param name="admin"></param>
        public static List<List<object>> ListAllSoldBooks(User admin)
        {
            List<List<object>> soldBooksListData = new List<List<object>>();
            bool isListed = false;
            do
            {
                if (SessionTimer.CheckSessionTimer(admin.SessionTimer) == true || admin.SessionTimer == DateTime.MinValue)
                {
                    Console.Clear();
                    GeneralMessage.AdminNotLoggedIn();
                    break;
                }

                Console.Clear();
                var api = new API();

                var result = api.SoldItems(admin.Id);
                if (result == null)
                {
                    ErrorMessage.ErrorNoAbort("retrieving the list of sold books", "the database is corrupt/empty");
                }
                else
                {
                    soldBooksListData = SoldBooksConverters.SoldBooksConverter(result);
                    UserController.SendPing(admin.Id);
                    isListed = true;
                }
            } while (isListed == false);
            return SoldBooksView.SoldBooksListReader(soldBooksListData);
        }

        /// <summary>
        /// Calculates sum of all SoldBook objects based on SoldBook.Price
        /// User object as parameter for handling session timer and ping function
        /// </summary>
        /// <param name="admin"></param>
        public static void SumOfSoldBooks(User admin)
        {
            bool isSumCalculated = false;
            do
            {
                if (SessionTimer.CheckSessionTimer(admin.SessionTimer) == true || admin.SessionTimer == DateTime.MinValue)
                {
                    Console.Clear();
                    GeneralMessage.AdminNotLoggedIn();
                    break;
                }

                Console.Clear();
                var api = new API();

                var result = api.MoneyEarned(admin.Id);
                if (result == null)
                {
                    ErrorMessage.ErrorNoAbort("calculating the sum of all purchases", "the database is corrupt/empty");
                }
                else
                {
                    SuccessMessage.SuccessWithInt("The sum of all purchases is", result.Value);
                    UserController.SendPing(admin.Id);
                    isSumCalculated = true;
                }
            } while (isSumCalculated == false);
        }
    }
}