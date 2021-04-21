using BookWebShop;
using BookWebShopFrontend.View.Home;
using System;
using System.Threading;

namespace BookWebShopFrontend.Controller
{
    public class HomeController
    {
        /// <summary>
        /// Class for home menu and controller for admin and customer users.
        /// </summary>

        private WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// Runs at the start of the program.
        /// </summary>
        public void Start()
        {
            bool keepGoing = true;
            do
            {
                Home.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            RegisterUser();
                            break;

                        case 2:
                            Console.Clear();
                            LogginUser();
                            break;

                        case 0:
                            Console.WriteLine("Bye bye");
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        /// <summary>
        /// Method for the home menu for admin user.
        /// </summary>
        /// <param name="adminId"></param>
        private void AdminMenu(int adminId)
        {
            bool keepGoing = true;
            do
            {
                AdminHomeMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            api.Ping(adminId);
                            var book = new BooksController();
                            book.BooksMenuAdmin(adminId);
                            break;

                        case 2:
                            Console.Clear();
                            api.Ping(adminId);
                            var user = new UsersController();
                            user.UsersMenuAdmin(adminId);
                            break;

                        case 3:
                            Console.Clear();
                            api.Ping(adminId);
                            var category = new CategoryController();
                            category.CategoryMenuAdmin(adminId);
                            break;

                        case 4:
                            Console.Clear();
                            api.Ping(adminId);
                            var soldBooks = new SoldBooksController();
                            soldBooks.SoldBooksMenuAdmin(adminId);
                            break;

                        case 0:
                            Console.Clear();
                            api.Logout(adminId);
                            Console.WriteLine("You logged out!");
                            Thread.Sleep(2000);
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        /// <summary>
        /// Method for the home menu for customer user.
        /// </summary>
        /// <param name="userId"></param>
        private void CustomerMenu(int userId)
        {
            bool keepGoing = true;
            do
            {
                CustomerHomeMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            api.Ping(userId);
                            var bookMenu = new BooksController();
                            bookMenu.BookMenuCustomer(userId);
                            break;

                        case 2:
                            Console.Clear();
                            api.Ping(userId);
                            var categoryMenu = new CategoryController();
                            categoryMenu.CategoryMenuCustomer(userId);
                            break;

                        case 0:
                            Console.Clear();
                            api.Logout(userId);
                            Console.WriteLine("You logged out!");
                            Thread.Sleep(2000);
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        /// <summary>
        /// Method for logging in the user both admin and customer.
        /// </summary>
        private void LogginUser()
        {
            int userId;
            bool keepGoing = true;
            do
            {
                Login.View();
                Console.Write("\nEnter Username: ");
                var username = Console.ReadLine();
                Console.Write("Enter Password: ");
                var password = Console.ReadLine();
                if (username.Length != 0 && password.Length != 0)
                {
                    userId = api.Login(username, password);
                    if (userId != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Success! You are logged in!");
                        if (api.IsAdmin(userId))
                        {
                            AdminMenu(userId);
                            keepGoing = false;
                        }
                        else
                        {
                            CustomerMenu(userId);
                            keepGoing = false;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Username or Password was wrong.");
                    }
                }
                else { Console.WriteLine("Check input and try again."); }
            } while (keepGoing);
        }

        /// <summary>
        /// Method for registering a new user.
        /// </summary>
        private void RegisterUser()
        {
            bool keepGoing = true;
            do
            {
                Register.View();
                Console.Write("\nEnter Username: ");
                var username = Console.ReadLine();
                if (username.Length != 0)
                {
                    Console.Write("Enter Password: ");
                    var password = Console.ReadLine();
                    Console.Write("Verify Password: ");
                    var passwordVerify = Console.ReadLine();
                    if (password == passwordVerify)
                    {
                        try
                        {
                            if (api.Register(username, password, passwordVerify))
                            {
                                Console.WriteLine($"{username} has been registerd!");
                                keepGoing = false;
                            }
                            else { Console.WriteLine($"{username} already exist!"); }
                        }
                        catch { Console.WriteLine("Something went wrong."); }
                    }
                    else { Console.WriteLine("Passwords don't match."); }
                }
                else { Console.WriteLine("No input."); }
            } while (keepGoing);
        }
    }
}