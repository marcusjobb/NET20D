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
    /// Admin menu class for handling User object data
    /// </summary>
    public class AdminUserController
    {
        /// <summary>
        /// Retrieves all Users present in database
        /// User object as parameter for handling session timer and ping function
        /// </summary>
        /// <param name="admin"></param>
        public static List<List<object>> ListAllUsers(User admin)
        {
            List<List<object>> userListData = new List<List<object>>();
            bool isUsersListed = false;
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

                var result = api.ListUsers(admin.Id);
                if (result == null)
                {
                    ErrorMessage.ErrorNoAbort("retrieving a list of users", "the database is empty/corrupt");
                    break;
                }
                else
                {
                    userListData = UserConverters.UserConverter(result);

                    UserController.SendPing(admin.Id);
                    isUsersListed = true;
                }
            } while (isUsersListed == false);
            return UserView.UserListReader(userListData);
        }

        /// <summary>
        /// Retrieves all Users matching search term based on User.Name
        /// User object as parameter for handling session timer and ping function
        /// </summary>
        /// <param name="admin"></param>
        public static List<List<object>> FindUser(User admin)
        {
            List<List<object>> userListData = new List<List<object>>();
            bool isUsersFound = false;
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
                Console.Write("Enter search term: ");
                var keyword = Console.ReadLine();
                var result = api.FindUser(admin.Id, keyword);
                if (result.Count < 1)
                {
                    var input = ErrorMessage.ErrorAbort("retrieving users", "the database is corrupt/empty, or your search term gave no matches");
                    if (input != "")
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    userListData = UserConverters.UserConverter(result);

                    UserController.SendPing(admin.Id);
                    isUsersFound = true;
                }
            } while (isUsersFound == false);
            return UserView.UserListReader(userListData);
        }

        /// <summary>
        /// Creates a new User object.
        /// User object as parameter for handling session timer and ping function.
        /// </summary>
        /// <param name="admin"></param>
        public static void AddUser(User admin)
        {
            bool isUserCreated = false;
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
                Console.Write("Enter name: ");
                var name = Console.ReadLine();

                Console.Write("Enter password: ");
                var password = Console.ReadLine();

                var result = api.AddUser(admin.Id, name, password);
                if (result == false)
                {
                    var input = ErrorMessage.ErrorAbort("adding a user", "or a user with that name already exists");
                    if (input != "")
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    SuccessMessage.SuccessWithString("A new user was added with name", $"{name} and password {password}");

                    UserController.SendPing(admin.Id);
                    isUserCreated = true;
                }
            } while (isUserCreated == false);
        }

        /// <summary>
        /// Retrieves User that have purchased most books.
        /// User object as parameter for handling session timer and ping function.
        /// </summary>
        /// <param name="admin"></param>
        public static List<List<object>> BestCostumer(User admin)
        {
            List<List<object>> bestCostumer = new List<List<object>>();
            bool isCostumerListed = false;
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

                var result = api.BestCostumer(admin.Id);
                if (result == null)
                {
                    ErrorMessage.ErrorNoAbort("retrieving best costumer", "the database is empty/corrupted");
                    break;
                }
                else
                {
                    bestCostumer = UserConverters.UserConverter(result);
                    UserController.SendPing(admin.Id);
                    isCostumerListed = true;
                }
            } while (isCostumerListed == false);
            return UserView.UserListReader(bestCostumer);
        }

        /// <summary>
        /// Gives a user administrator privileges.
        /// User object as parameter for handling session timer and ping function.
        /// </summary>
        /// <param name="admin"></param>
        public static void PromoteUser(User admin)
        {
            bool isUserPromoted = false;
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
                Console.Write("Enter user Id: ");
                int.TryParse(Console.ReadLine(), out int userId);
                var result = api.Promote(admin.Id, userId);
                if (result == false)
                {
                    var input = ErrorMessage.ErrorAbort("promoting a user", "you entered incorrect data");
                    if (input != "")
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    SuccessMessage.SuccessWithString("User now has administrator privileges");

                    UserController.SendPing(admin.Id);
                    isUserPromoted = true;
                }
            } while (isUserPromoted == false);
        }

        /// <summary>
        /// Removes a user's administrator privileges.
        /// User object as parameter for handling session timer and ping function.
        /// </summary>
        /// <param name="admin"></param>
        public static void DemoteUser(User admin)
        {
            bool isUserDemoted = false;
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
                Console.Write("Enter user Id: ");
                int.TryParse(Console.ReadLine(), out int userId);
                var result = api.Demote(admin.Id, userId);
                if (result == false)
                {
                    var input = ErrorMessage.ErrorAbort("demoting a user", "you entered incorrect data");
                    if (input != "")
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    SuccessMessage.SuccessWithString("User now has lost administrator privileges");

                    UserController.SendPing(admin.Id);
                    isUserDemoted = true;
                }
            } while (isUserDemoted == false);
        }

        /// <summary>
        /// Activates a user.
        /// User object as parameter for handling session timer and ping function.
        /// </summary>
        /// <param name="admin"></param>
        public static void ActivateUser(User admin)
        {
            bool isUserActivated = false;
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
                Console.Write("Enter user Id: ");
                int.TryParse(Console.ReadLine(), out int userId);
                var result = api.ActivateUser(admin.Id, userId);
                if (result == false)
                {
                    var input = ErrorMessage.ErrorAbort("activating a user", "you entered incorrect data");
                    if (input != "")
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    SuccessMessage.SuccessWithString("User is now activated");

                    UserController.SendPing(admin.Id);
                    isUserActivated = true;
                }
            } while (isUserActivated == false);
        }

        /// <summary>
        /// Deactivates a user.
        /// User object as parameter for handling session timer and ping function.
        /// </summary>
        /// <param name="admin"></param>
        public static void DeactivateUser(User admin)
        {
            bool isUserDeactivated = false;
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
                Console.Write("Enter user Id: ");
                int.TryParse(Console.ReadLine(), out int userId);
                var result = api.InactivateUser(admin.Id, userId);
                if (result == false)
                {
                    var input = ErrorMessage.ErrorAbort("deactivating a user", "you entered incorrect data");
                    if (input != "")
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    SuccessMessage.SuccessWithString("User is now deactivated");

                    UserController.SendPing(admin.Id);
                    isUserDeactivated = true;
                }
            } while (isUserDeactivated == false);
        }
    }
}