using System;

namespace BookWebShopFrontend.View.Users
{
    public static class AdminUsersMenu
    {
        /// <summary>
        /// Class of the view of AdminUsersMenu.
        /// </summary>
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Admin User Menu                                        |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. Search User");
            Console.WriteLine("2. Add User");
            Console.WriteLine("3. Select User");
            Console.WriteLine("0. Back");
        }
    }
}