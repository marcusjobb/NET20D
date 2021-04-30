using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI;

namespace WebshopApiFrontend.Utility
{
    public static class MainMenu
    {
        public static int loggedInUser = Models.CurrentUser.LoggedInUser;
        /// <summary>
        /// Main program menu, allows all users to search through books and buy books
        /// A user with admin status gets access to an Admin menu option
        /// </summary>
        /// <param name="loggedInUser"></param>
        public static void ProgramMenu(int loggedInUser)
        {
            bool activeSeassion = true;
            do
            {
                Console.WriteLine("\n**************************************\n");
                Console.WriteLine("* 1. Search menu\n");
                Console.WriteLine("* 2. Buy books\n");
                if (WebbshopAPI.IsAdmin(loggedInUser))
                {
                    Console.WriteLine("* 4. Admin menu\n");
                }
                Console.WriteLine("* 0. Return\n");
                Console.WriteLine("**************************************\n");
                Console.Write(">> ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string menuChoice = Console.ReadLine();
                Console.ResetColor();

                switch (menuChoice)
                {
                    case "1":
                        SearchMenu.ListAndSearch();
                        break;
                    case "2":
                        Shop.PurchaceBooks(loggedInUser);
                        break;
                    case "4":
                        if (WebbshopAPI.IsAdmin(loggedInUser))
                        {
                            AdminMenu.AdminPanel();
                        }
                        break;
                    case "0":
                        WebbshopAPI.Logout(loggedInUser);
                        activeSeassion = false;
                        break;
                }
            } while (activeSeassion);
        }
    }
}
