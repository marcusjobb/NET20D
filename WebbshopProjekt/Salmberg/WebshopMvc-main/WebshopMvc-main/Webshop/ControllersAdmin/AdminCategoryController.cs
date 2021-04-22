using System;
using WebshopAPI;
using WebshopAPI.Models;
using WebshopAPI.Utils;
using WebshopMVC.Controllers;
using WebshopMVC.Views.Messages;
using WebshopMVC.Views.Messages.Admin;

namespace WebshopMVC.ControllersAdmin
{
    /// <summary>
    /// Admin menu class for handling Category object data
    /// </summary>
    internal class AdminCategoryController
    {
        /// <summary>
        /// Adds a new category to database
        /// User object as parameter for handling session timer and ping function
        /// </summary>
        /// <param name="admin"></param>
        public static void AddCategory(User admin)
        {
            bool isCategoryCreated = false;
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

                Console.Write("Enter name:");
                var categoryName = Console.ReadLine();

                var result = api.AddCategory(admin.Id, categoryName);
                if (result == false)
                {
                    var input = ErrorMessage.ErrorAbort("creating a new category", "there already is a category with that name");
                    if (input != "")
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    SuccessMessage.SuccessWithString("A new category was created with the name", $"{categoryName}");
                    isCategoryCreated = true;
                    UserController.SendPing(admin.Id);
                }
            } while (isCategoryCreated == false);
        }

        /// <summary>
        /// Adds book to category
        /// User object as parameter for handling session timer and ping function
        /// </summary>
        /// <param name="admin"></param>
        public static void AddBookToCategory(User admin)
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

                Console.Write("Enter book Id:");
                int.TryParse(Console.ReadLine(), out int bookId);

                Console.Write("Enter category Id:");
                int.TryParse(Console.ReadLine(), out int categoryId);

                var result = api.AddBookToCategory(admin.Id, bookId, categoryId);
                if (result == false)
                {
                    var input = ErrorMessage.ErrorAbort("adding a book to a category", "you entered incorrect data");
                    if (input != "")
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    SuccessMessage.SuccessWithString("Book assigned to category");
                    isBookAdded = true;
                    UserController.SendPing(admin.Id);
                }
            } while (isBookAdded == false);
        }

        /// <summary>
        /// Updates a Category object's properties
        /// User object as parameter for handling session timer and ping function
        /// </summary>
        /// <param name="admin"></param>
        public static void UpdateCategory(User admin)
        {
            bool isCategoryUpdated = false;
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

                Console.Write("Enter category Id:");
                int.TryParse(Console.ReadLine(), out int categoryId);

                Console.Write("Enter new name:");
                var name = Console.ReadLine();

                var result = api.UpdateCategory(admin.Id, categoryId, name);
                if (result == false)
                {
                    var input = ErrorMessage.ErrorAbort("updating a category", "you entered incorrect data");
                    if (input != "")
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    SuccessMessage.SuccessWithString("Category updated");
                    isCategoryUpdated = true;
                    UserController.SendPing(admin.Id);
                }
            } while (isCategoryUpdated == false);
        }

        /// <summary>
        /// Deletes a category from database
        /// User object as parameter for handling session timer and ping function
        /// </summary>
        /// <param name="admin"></param>
        public static void DeleteCategory(User admin)
        {
            bool isCategoryDeleted = false;
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

                Console.Write("Enter category Id:");
                int.TryParse(Console.ReadLine(), out int categoryId);

                var result = api.DeleteCategory(admin.Id, categoryId);
                if (result == false)
                {
                    var input = ErrorMessage.ErrorAbort("deleting the category", "you entered incorrect data");
                    if (input != "")
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    SuccessMessage.SuccessWithString("Category deleted");
                    isCategoryDeleted = true;
                    UserController.SendPing(admin.Id);
                }
            } while (isCategoryDeleted == false);
        }
    }
}