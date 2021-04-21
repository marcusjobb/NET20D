namespace WebbShop_MikaelLarsson.Views
{
    using System;
    using Inlamn2WebbShop_MLarsson;
    using WebbShop_MikaelLarsson.Controllers;

    /// <summary>
    /// KLass för att skriva ut adminmenyerna
    /// </summary>
   internal static class AdminMenuView
    {
        /// <summary>
        /// property för att loopa AdminMainMenu().
        /// </summary>
        public static bool adminMenu;

        /// <summary>
        /// Meny för admins bokdel
        /// </summary>
        internal static void AdminBookMenu(int adminId)
        {
            Console.WriteLine("\nFOR ADMIN ONLY");
            Console.WriteLine("1 - Back to admin main menu\n2 - Add a new book\n3 - Set amount of books\n4 - Update a book" +
                "\n5 - Delete a book\n6 - Add book to category");
            AdminBookController.AdminBookMenu(adminId);
        }

        /// <summary>
        /// Meny för admins kategoridel
        /// </summary>
        internal static void AdminCategoryMenu(int adminId)
        {
            Console.WriteLine("\nFOR ADMIN ONLY");
            Console.WriteLine("1 - Back to admin main menu\n2 - Add a new category\n3 - Update a category\n4 - Delete a category");
            AdminCategoryController.AdminCategoryMenu(adminId);
        }

        /// <summary>
        /// Meny för admins ekonomidel
        /// </summary>
        internal static void AdminEconomyMenu(int adminId)
        {
            Console.WriteLine("\nFOR ADMIN ONLY");
            Console.WriteLine("1 - Back to admin main menu\n2 - See all sold items\n3 - See total money earned\n4 - See best customer");
            AdminEconomyController.AdminEconomyMenu(adminId);
        }

        /// <summary>
        /// Huvudmenyn för admin
        /// </summary>
        internal static void AdminMainMenu(int adminId)
        {
            adminMenu = true;
            while (adminMenu)
            {
                Console.Title = "Administration section";
                Console.Clear();
                Console.WriteLine("FOR ADMIN ONLY");
                Console.WriteLine("1 - Back to main menu\n2 - Handle users\n3 - Handle books\n4 - Handle categories" +
                    "\n5 - Handle economy");
                AdminMenuController.AdminMainMenu(adminId);
            }
        }

        /// <summary>
        /// Meny för admins userdel
        /// </summary>
        internal static void AdminUserMenu(int adminId)
        {
            Console.WriteLine("\nFOR ADMIN ONLY");
            Console.WriteLine("1 - Back to admin main menu\n2 - See all users\n3 - Find users\n4 - Add a new user\n5 - Promote a user" +
                "\n6 - Demote a user\n7 - Activate a user\n8 - Deactivate a user");
            AdminUserController.AdminUserMenu(adminId);
        }
    }
}
