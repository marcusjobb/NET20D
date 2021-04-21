using System;
using System.Linq;
using Webbshop.Helpers;
using Webbshop.Views;
using WebbshopProject;
using WebbshopProject.Database;

namespace Webbshop.Controllers
{
    class UsersControllers
    {
        public static WebbshopAPI api = new WebbshopAPI();
        /// <summary>
        /// A menu for the admins only, 
        /// that contains all choices about users.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void UserChoicesAdmin(int userId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                Ping(userId);
                Console.Clear();
                var input = "x";
                while (input != "e")
                {
                    UsersView.UserChoices(userId);
                    Console.Write("Enter choice: ");
                    input = Console.ReadLine().ToLower();

                    if (int.TryParse(input, out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                UsersControllers.ListAllUsers(userId);
                                break;
                            case 2:
                                UsersControllers.FindSpecificUser(userId);
                                break;
                            case 3:
                                UsersControllers.AddNewUser(userId);
                                break;
                            case 4:
                                UsersControllers.PromoteUser(userId);
                                break;
                            case 5:
                                UsersControllers.DemoteUser(userId);
                                break;
                            case 6:
                                UsersControllers.ActivateUser(userId);
                                break;
                            case 7:
                                UsersControllers.InactivateUser(userId);
                                break;
                            case 8:
                                UsersControllers.GetBestCustomer(userId);
                                break;
                            default:
                                Messages.ErrorMessage("Invalid choice. try again!");
                                break;
                        }
                    }

                    else if (input == "e")
                    {
                        StartupControllers.Menu(userId);
                    }

                    else
                    {
                        Messages.ErrorMessage("Invalid choice. try again!");
                    }
                }
            }
        }

        /// <summary>
        /// Lists all the users in the database.
        /// Only for admins.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void ListAllUsers(int userId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                Ping(userId);
                Console.Clear();
                var listOfUsers = api.ListUsers(userId);
                if (listOfUsers != null)
                {
                    UsersView.PrintUsers(listOfUsers);
                }

                else
                {
                    Messages.ErrorMessage("No users in database.");
                }
            }

            else
            {
                Messages.ErrorMessage("You are not authorized.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Lets the user search for a sertain person in the
        /// database. And if user is active and admin. Only for admins.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void FindSpecificUser(int userId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                Ping(userId);
                Console.Clear();
                Console.WriteLine("Who do you want to search for?");
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                var listOfUsers = api.FindUser(userId, name);

                if (listOfUsers.Count() != 0)
                {
                    UsersView.PrintUserStats(listOfUsers);
                }

                else
                {
                    Messages.ErrorMessage("No match found.");
                }
            }

            else
            {
                Messages.ErrorMessage("You are not authorized.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Lets admin add a user to the database.
        /// Only for admins.
        /// </summary>
        /// <param name="userId">The id of the user of the program</param>
        public static void AddNewUser(int userId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(userId))
            {
                Ping(userId);
                var userCredentials = UsersView.CreateAccountAskUserForInput();
                bool answer = api.AddUser(
                    userId,
                    userCredentials.username,
                    userCredentials.password);
                if (answer) 
                {
                    Messages.SuccessMessage("User created.");
                }

                else
                {
                    Messages.ErrorMessage("Something went wrong");
                }
            }

            else
            {
                Messages.ErrorMessage("You are not authorized.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Prints out the person who has bought the most books.
        /// Only for admins.
        /// </summary>
        /// <param name="adminId">The id of the user of the program</param>
        public static void GetBestCustomer(int adminId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(adminId))
            {
                Ping(adminId);
                Console.Clear();
                var bestcustomer = api.BestCustomer(adminId);
                if (bestcustomer.name != null)
                {
                    UsersView.PrintBestCustomer(bestcustomer.name, bestcustomer.books);
                }

                else
                {
                    Messages.ErrorMessage("No customers have bought anything yet.");
                }

                Console.ReadKey();
            }
        }

        /// <summary>
        /// Lets the admin promote a user to admin.
        /// Only for admins.
        /// </summary>
        /// <param name="adminId">The id of the user of the program</param>
        public static void PromoteUser(int adminId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(adminId))
            {
                Ping(adminId);
                Console.Clear();
                var user = HelperMethods.ChooseUser(adminId);
                if (user != 0)
                {
                    var answer = api.Promote(adminId, user);
                    if (answer)
                    {
                        Messages.SuccessMessage($"The promote was successfull.");
                    }

                    else
                    {
                        Messages.ErrorMessage("Something went wrong. Try again!");
                    }
                }

                else
                {
                    Messages.ErrorMessage("Something went wrong. Try again!");
                }
            }

            else
            {
                Messages.ErrorMessage("You need to login first");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Lets the admin demote a user from beeing a admin.
        /// Only for admins.
        /// </summary>
        /// <param name="adminId">The id of the user of the program</param>
        public static void DemoteUser(int adminId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(adminId))
            {
                Ping(adminId);
                Console.Clear();
                var user = HelperMethods.ChooseUser(adminId);
                if (user != 0)
                {
                    var answer = api.Demote(adminId, user);
                    if (answer)
                    {
                        Messages.SuccessMessage($"The demote was successfull.");
                    }

                    else
                    {
                        Messages.ErrorMessage("Something went wrong. Try again!");
                    }
                }

                else
                {
                    Messages.ErrorMessage("Something went wrong. Try again!");
                }
            }

            else
            {
                Messages.ErrorMessage("You need to login first");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Lets the admin activate a user.
        /// </summary>
        /// <param name="adminId">The id of the user of the program</param>
        public static void ActivateUser(int adminId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(adminId))
            {
                Ping(adminId);
                Console.Clear();
                var user = HelperMethods.ChooseUser(adminId);
                if (user != 0)
                {
                    var answer = api.ActivateUser(adminId, user);
                    if (answer)
                    {
                        Messages.SuccessMessage($"The activate was successfull.");
                    }

                    else
                    {
                        Messages.ErrorMessage("Something went wrong. Try again!");
                    }
                }

                else
                {
                    Messages.ErrorMessage("Something went wrong. Try again!");
                }
            }

            else
            {
                Messages.ErrorMessage("You need to login first");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Lets the admin inactivate a user.
        /// </summary>
        /// <param name="adminId">The id of the user of the program</param>
        public static void InactivateUser(int adminId)
        {
            if (HelperMethods.IsUserAdminAndLoggedIn(adminId))
            {

                Console.Clear();
                var user = HelperMethods.ChooseUser(adminId);
                if (user != 0)
                {
                    var answer = api.InactivateUser(adminId, user);
                    if (answer)
                    {
                        Messages.SuccessMessage($"The deactivate was successfull.");
                    }

                    else
                    {
                        Messages.ErrorMessage("Something went wrong. Try again!");
                    }
                }

                else
                {
                    Messages.ErrorMessage("Something went wrong. Try again!");
                }

            }

            else
            {
                Messages.ErrorMessage("You need to login first");
            }

            Console.ReadKey();
        }

        public static void Ping(int userId)
        {
            var answer = api.Ping(userId);
            if (answer)
            {
                UsersView.PrintIfPinged();
            }
            else
            {
                Messages.ErrorMessage("You have been logged out.");
            }
        }

    }
}
