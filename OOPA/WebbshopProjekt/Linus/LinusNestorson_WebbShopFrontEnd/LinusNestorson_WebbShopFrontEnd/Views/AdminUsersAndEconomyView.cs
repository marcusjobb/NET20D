using System;

namespace LinusNestorson_WebbShopFrontEnd.Views
{
    class AdminUsersAndEconomyView
    {
        /// <summary>
        /// Presents the alternatives for user alternativs and economic overview.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void AdminUserAndEconomy(int adminId)
        {
            Console.WriteLine("Welcome to Linus Bookstore");
            while (true)
            {
                Console.WriteLine("\nWhat do you want to do? Confirm your choice by pressing [Enter]");
                Console.WriteLine("1. List users\n2. Add user\n3. Find user\n4. Activate user\n5. Inavtivate user\n6. Promote user");
                Console.Write("7. Demote user\n8. Best customer\n9. Money earned\n10. Sold items\n11. Go back to Main menu\n>");
                int choice;
                bool input = int.TryParse(Console.ReadLine(), out choice);
                if (input)
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            AdminOptions.ListUsers(adminId);
                            continue;

                        case 2:
                            Console.Clear();
                            AdminOptions.AddUser(adminId);
                            continue;
                        case 3:
                            Console.Clear();
                            AdminOptions.FindUser(adminId);
                            continue;

                        case 4:
                            Console.Clear();
                            AdminOptions.ActivateUser(adminId);
                            continue;

                        case 5:
                            Console.Clear();
                            AdminOptions.InactivateUser(adminId);
                            continue;

                        case 6:
                            Console.Clear();
                            AdminOptions.Promote(adminId);
                            continue;
                        case 7:
                            Console.Clear();
                            AdminOptions.Demote(adminId);
                            continue;
                        case 8:
                            Console.Clear();
                            AdminOptions.BestCustomer(adminId);
                            continue;
                        case 9:
                            Console.Clear();
                            AdminOptions.MoneyEarned(adminId);
                            continue;
                        case 10:
                            Console.Clear();
                            AdminOptions.SoldItems(adminId);
                            continue;
                        case 11:
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
