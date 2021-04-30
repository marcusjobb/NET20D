using System;
using LinusNestorson_WebbShop.Models;
using LinusNestorson_WebbShopFrontEnd.Controller;

namespace LinusNestorson_WebbShopFrontEnd.Views
{
    class AdminFirstView
    {
        private static UserController userCon = new UserController();
        /// <summary>
        /// Menu for presenting options for biggers menues for admin user.
        /// </summary>
        /// <param name="user">Variable containing user information</param>
        public static void AdminMenu(User user)
        {
            Console.WriteLine("Welcome to Linus Bookstore");
            while (true)
            {
                Console.WriteLine("\nWhat do you want to do? Confirm your choice by pressing [Enter]");
                Console.Write("1. Normal User Options\n2. Item Options (Admin)\n3. Users & Economy (Admin)\n4. Logout\n> ");
                int choice;
                bool input = int.TryParse(Console.ReadLine(), out choice);
                if (input)
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            UserMenuView.UserMenu(user);
                            continue;
                        case 2:
                            Console.Clear();
                            AdminItemsView.AdminSecondMenu(user.Id);
                            continue;
                        case 3:
                            Console.Clear();
                            AdminUsersAndEconomyView.AdminUserAndEconomy(user.Id);
                            continue;
                        case 4:
                            Console.Clear();
                            userCon.Logout(user.Id);
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Please enter a valid number");
                            continue;
                    }
                    break;
                }
                else if (!input)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter valid input");
                }
            }
        }
    }
}
