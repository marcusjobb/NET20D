using LinusNestorson_WebbShop.Models;
using LinusNestorson_WebbShopFrontEnd.Controller;
using System;

namespace LinusNestorson_WebbShopFrontEnd.Views
{
    class UserMenuView
    {
        private static UserController userCon = new UserController();

        /// <summary>
        /// Menu for presenting options for normal user.
        /// </summary>
        /// <param name="user">Variable containing user information</param>
        public static void UserMenu(User user)
        {
            Console.WriteLine("Welcome to Linus Bookstore");
            while (true)
            {
                Console.WriteLine("\nWhat do you want to do? Confirm your choice by pressing [Enter]");
                Console.WriteLine("1. Get All Categories\n2. Get categories based on keyword\n3. Get books based on category");
                Console.WriteLine("4. List available books in category\n5. Read information about specific book\n6. Get Books based on keyword");
                Console.WriteLine("7. Get books by Author\n8. Buy Book");
                if (!user.IsAdmin)
                {
                    Console.WriteLine("9. Logout");
                }
                else
                {
                    Console.WriteLine("9. Go back one step");
                }
                int choice;
                bool input = int.TryParse(Console.ReadLine(), out choice);
                if (input)
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            UserOptions.GetAllCategories(user.Id);
                            continue;
                        case 2:
                            Console.Clear();
                            UserOptions.GetCategoriesByKeyword(user.Id);
                            continue;
                        case 3:
                            Console.Clear();
                            UserOptions.GetBooksByCategory(user.Id);
                            continue;
                        case 4:
                            Console.Clear();
                            UserOptions.AvailableBooks(user.Id);
                            continue;
                        case 5:
                            Console.Clear();
                            UserOptions.GetBook(user.Id);
                            continue;
                        case 6:
                            Console.Clear();
                            UserOptions.GetBooks(user.Id);
                            continue;
                        case 7:
                            Console.Clear();
                            UserOptions.GetBooksByAuthors(user.Id);
                            continue;
                        case 8:
                            Console.Clear();
                            UserOptions.BuyBook(user.Id);
                            continue;
                        case 9:
                            if (!user.IsAdmin)
                            {
                                Console.Clear();
                                userCon.Logout(user.Id);
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                break;
                            }
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