using Inlämning2WebbShop;
using Inlämning2WebbShop.Models;
using Inlämning3.Helpers;
using System;

namespace Inlämning3.Controllers
{
    internal class AdminUsersController
    {
        private WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// Method that gets a choice and then call other methods depending on the user choice
        /// </summary>
        public void ManageUsers()
        {
            Account.KickOutIfNotLoggedInAdmin();
            var choice = Views.Admin.AdminMenus.UserMenu();
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    var userList = api.ListUsers(Account.UserId);
                    var chosenUser = Views.Admin.ManageUser.PrintUsers(userList);
                    if (chosenUser > userList.Count || chosenUser < 0)
                    {
                        Messages.ErrorMessage();
                    }
                    else
                    {
                        Console.Clear();
                        ManageSpecificUser(userList[chosenUser]);
                    }
                    break;

                case 2:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    var keyword = Views.Admin.ManageUser.SearchUsers();
                    userList = api.FindUsers(Account.UserId, keyword);
                    chosenUser = Views.Admin.ManageUser.PrintUsers(userList);
                    if (chosenUser > userList.Count || chosenUser < 0)
                    {
                        Messages.ErrorMessage();
                    }
                    else
                    {
                        Console.Clear();
                        ManageSpecificUser(userList[chosenUser]);
                    }
                    break;

                case 3:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    AddUser();
                    break;

                case 4:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    Console.Clear();
                    var adminController = new AdminController();
                    adminController.AdminMenu();
                    break;

                default:
                    Messages.NotValidInput();
                    break;
            }
        }

        /// <summary>
        /// gets input and Calls Api method to addUser.
        /// </summary>
        private void AddUser()
        {
            Console.Clear();
            Account.KickOutIfNotLoggedInAdmin();
            Views.Admin.ManageUser.AddUser(out string username, out string password);
            bool success;
            if (password == string.Empty)
            {
                success = api.AddUser(Account.UserId, username);
            }
            else
            {
                success = api.AddUser(Account.UserId, username, password);
            }
            if (success)
            {
                Messages.SuccessMessage();
            }
            else
            {
                Messages.ErrorMessage();
            }
        }

        /// <summary>
        /// Method that gets a choice and then call other methods depending on the user choice
        /// </summary>
        /// <param name="user"></param>
        private void ManageSpecificUser(User user)
        {
            Console.Clear();
            Account.KickOutIfNotLoggedInAdmin();
            int choice = Views.Admin.AdminMenus.SpecificUserMeny(user);
            switch (choice)
            {
                case 1:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    PromoteUser(user);
                    break;

                case 2:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    DemoteUser(user);
                    break;

                case 3:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    ActivateUser(user);
                    break;

                case 4:
                    Helpers.Helper.CheckPing(api.Ping(Account.UserId));
                    DeactivateUser(user);
                    break;

                default:
                    Messages.NotValidInput();
                    break;
            }
        }

        /// <summary>
        /// Calls the Api method to Inactivate a user.
        /// </summary>
        /// <param name="user"></param>
        private void DeactivateUser(User user)
        {
            Console.Clear();
            Account.KickOutIfNotLoggedInAdmin();
            var choice = Views.Admin.ManageUser.DeactivateUser(user);
            if (choice == "Y")
            {
                if (api.InactivateUser(Account.UserId, user.Id))
                {
                    Console.Clear();
                    Messages.SuccessMessage();
                }
            }
            else
            {
                Console.Clear();
                Messages.ErrorMessage();
            }
        }

        /// <summary>
        /// Calls the Api method to activate a user.
        /// </summary>
        /// <param name="user"></param>
        private void ActivateUser(User user)
        {
            Account.KickOutIfNotLoggedInAdmin();
            var choice = Views.Admin.ManageUser.ActivateUser(user);
            if (choice == "Y")
            {
                if (api.ActivateUser(Account.UserId, user.Id))
                {
                    Console.Clear();
                    Messages.SuccessMessage();
                }
            }
            else
            {
                Console.Clear();
                Messages.ErrorMessage();
            }
        }

        /// <summary>
        /// calls Api method to Demote user.
        /// </summary>
        /// <param name="user"></param>
        private void DemoteUser(User user)
        {
            Account.KickOutIfNotLoggedInAdmin();
            var choice = Views.Admin.ManageUser.DemoteUser(user);
            if (choice == "Y")
            {
                if (api.Demote(Account.UserId, user.Id))
                {
                    Console.Clear();
                    Messages.SuccessMessage();
                }
            }
            else
            {
                Console.Clear();
                Messages.ErrorMessage();
            }
        }

        /// <summary>
        /// Calls API method to Promote user.
        /// </summary>
        /// <param name="user"></param>
        private void PromoteUser(User user)
        {
            Account.KickOutIfNotLoggedInAdmin();
            var choice = Views.Admin.ManageUser.PromoteUser(user);
            if (choice == "Y")
            {
                if (api.Promote(Account.UserId, user.Id))
                {
                    Console.Clear();
                    Messages.SuccessMessage();
                }
            }
            else
            {
                Console.Clear();
                Messages.ErrorMessage();
            }
        }
    }
}