using LinusNestorson_WebbShopFrontEnd.Controller;
using System;

namespace LinusNestorson_WebbShopFrontEnd.Views
{
    class StartView
    {
        private static StartController userController = new StartController();
        /// <summary>
        /// Method for displaying login menu.
        /// </summary>
        public static void Startup()
        {
            while (true)
            {
                Console.WriteLine("Welcome to Linus Bookstore");
                Console.WriteLine("If you are a new user. Press [1]");
                Console.WriteLine("If you already have an account. Press [2]");
                Console.Write("If you want to exit Linus Bookshop. Press [3]\n>");
                int choice;
                bool input = int.TryParse(Console.ReadLine(), out choice);
                if (input)
                {
                    switch (choice)
                    {
                        case 1:
                            Register();
                            break;

                        case 2:
                            Login();
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Something went wrong. Try again");
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input. Try Again");
                    continue;
                }
            }
        }
        /// <summary>
        /// Present the Login view for user.
        /// </summary>
        public static void Login()
        {
            while (true)
            {
                Console.WriteLine("\nHello! Please login to the site to get access");
                Console.Write("Username: ");
                var username = Console.ReadLine();
                Console.Write("Password: ");
                var password = Console.ReadLine();
                var user = userController.UserLogin(username, password);
                if (user != null)
                {
                    if (user.IsAdmin)
                    {
                        Console.Clear();
                        AdminFirstView.AdminMenu(user);
                        break;
                    }
                    else if (!user.IsAdmin)
                    {
                        Console.Clear();
                        UserMenuView.UserMenu(user);
                        break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Something went wrong. Make sure the login credentials are valid");
                }
            }
        }
        /// <summary>
        /// Register new user.
        /// </summary>
        public static void Register()
        {
            Console.WriteLine("Please enter necessary information below:");
            while (true)
            {
                Console.Write("Username: ");
                var username = Console.ReadLine();
                Console.Write("Password: ");
                var password = Console.ReadLine();
                Console.Write("Verify Password: ");
                var verPassword = Console.ReadLine();
                if (username.Contains(" ") || password.Contains(" ") || verPassword.Contains(" "))
                {
                    Console.WriteLine("Please enter your username and password without spaces");
                    continue;
                }
                var successOrFail = userController.UserRegistration(username, password, verPassword);
                if (successOrFail)
                {
                    Console.Clear();
                    Console.WriteLine("Account created\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Failed to create account. Make sure that password is the same as verified password and that user does not exist");
                    continue;
                }
            }
        }
    }
}
