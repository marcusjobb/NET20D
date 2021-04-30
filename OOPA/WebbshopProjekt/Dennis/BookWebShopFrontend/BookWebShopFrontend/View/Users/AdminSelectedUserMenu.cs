using System;

namespace BookWebShopFrontend.View.Users
{
    public static class AdminSelectedUserMenu
    {
        /// <summary>
        /// Class of the view of AdminSelectedUserMenu.
        /// </summary>
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Admin Selected User Menu                               |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. Promote user");
            Console.WriteLine("2. Demote user");
            Console.WriteLine("3. Activate user");
            Console.WriteLine("4. Inactivate user");
            Console.WriteLine("0. Back");
        }
    }
}