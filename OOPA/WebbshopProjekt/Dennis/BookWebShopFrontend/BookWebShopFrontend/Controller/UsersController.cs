using BookWebShop;
using BookWebShop.Models;
using BookWebShopFrontend.View.Users;
using System;
using System.Threading;

namespace BookWebShopFrontend.Controller
{
    public class UsersController
    {
        /// <summary>
        /// Class for user info and controller for admin user.
        /// </summary>

        private WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// Method for the user menu for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        public void UsersMenuAdmin(int adminId)
        {
            bool keepGoing = true;
            do
            {
                Console.Clear();
                ListUsers(adminId);
                AdminUsersMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            api.Ping(adminId);
                            ListUsers(adminId);
                            SearchUser(adminId);
                            Thread.Sleep(2000);
                            break;

                        case 2:
                            Console.Clear();
                            api.Ping(adminId);
                            ListUsers(adminId);
                            AddUser(adminId);
                            Thread.Sleep(2000);
                            break;

                        case 3:
                            Console.Clear();
                            api.Ping(adminId);
                            ListUsers(adminId);
                            SelectUserMenu(adminId, SelectUser(adminId));
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
        /// Method for adding a new user for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        private void AddUser(int adminId)
        {
            Console.Write("\nEnter new User Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter new User Password: ");
            string password = Console.ReadLine();

            if (username.Length != 0 && password.Length != 0)
            {
                try
                {
                    api.AddUser(adminId, username, password);
                }
                catch { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Something went wrong!"); }
        }

        /// <summary>
        /// Method for listing all users for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        private void ListUsers(int adminId)
        {
            if (api.ListUsers(adminId) != null)
            {
                Console.WriteLine($"{"Id:",-4}{"Name:",-20}\n");
                foreach (var user in api.ListUsers(adminId))
                {
                    Console.WriteLine($"{user.Id + ".",-4}{user.Name,-20}");
                }
            }
            else { Console.WriteLine("Something went wrong."); }
        }

        /// <summary>
        /// Method for searching for a user for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        private void SearchUser(int adminId)
        {
            Console.Write("\nSearch User By Name: ");
            string username = Console.ReadLine();

            if (username.Length != 0)
            {
                if (api.FindUser(adminId, username) != null)
                {
                    try
                    {
                        foreach (var user in api.FindUser(adminId, username))
                        {
                            Console.WriteLine($"{user.Id}. { user.Name}");
                        }
                    }
                    catch { Console.WriteLine("Something went wrong."); }
                }
            }
            else { Console.WriteLine("No input."); }
        }

        /// <summary>
        /// Method for selecting a user for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        private User SelectUser(int adminId)
        {
            Console.Write("\nEnter Id of user you want to select: ");
            if (int.TryParse(Console.ReadLine(), out var selectedUserId))
            {
                if (api.ListUsers(adminId) != null)
                {
                    try
                    {
                        foreach (var user in api.ListUsers(adminId))
                        {
                            if (user.Id == selectedUserId)
                            {
                                return user;
                            }
                        }
                    }
                    catch { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }
            return new User();
        }

        /// <summary>
        /// Method for the selected user menu for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="user"></param>
        private void SelectUserMenu(int adminId, User user)
        {
            bool keepGoing = true;
            do
            {
                AdminSelectedUserMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            api.Ping(adminId);
                            UserPromote(adminId, user);
                            keepGoing = false;
                            break;

                        case 2:
                            Console.Clear();
                            api.Ping(adminId);
                            UserDemote(adminId, user);
                            keepGoing = false;
                            break;

                        case 3:
                            Console.Clear();
                            api.Ping(adminId);
                            UserActivate(adminId, user);
                            keepGoing = false;
                            break;

                        case 4:
                            Console.Clear();
                            api.Ping(adminId);
                            UserInactivate(adminId, user);
                            keepGoing = false;
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
        /// Method for activating a user for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="user"></param>
        private void UserActivate(int adminId, User user)
        {
            try
            {
                if (api.ActivateUser(adminId, user.Id))
                {
                    Console.WriteLine($"Success! {user.Name} was Activated.");
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            catch
            {
                Console.WriteLine("Something went wrong.");
            }
        }

        /// <summary>
        /// Method for demoting a user for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="user"></param>
        private void UserDemote(int adminId, User user)
        {
            try
            {
                if (api.Demote(adminId, user.Id))
                {
                    Console.WriteLine($"Success! {user.Name} was Demoted.");
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            catch
            {
                Console.WriteLine("Something went wrong.");
            }
        }

        /// <summary>
        /// Method for inactivating a user for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="user"></param>
        private void UserInactivate(int adminId, User user)
        {
            try
            {
                if (api.InactivateUser(adminId, user.Id))
                {
                    Console.WriteLine($"Success! {user.Name} was Inactivated.");
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            catch
            {
                Console.WriteLine("Something went wrong.");
            }
        }

        /// <summary>
        /// Method for promoting a user for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="user"></param>
        private void UserPromote(int adminId, User user)
        {
            try
            {
                if (api.Promote(adminId, user.Id))
                {
                    Console.WriteLine($"Success! {user.Name} was Promoted.");
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            catch
            {
                Console.WriteLine("Something went wrong.");
            }
        }
    }
}