using System;

namespace Inlämning3.Views.Admin
{
    internal class AdminMenus
    {
        /// <summary>
        /// prints admin main menu and returns the choice.
        /// </summary>
        /// <returns></returns>
        public static int MainMenu()
        {
            Console.WriteLine(@"     ___       _______  .___  ___.  __  .__   __.    .___  ___.  _______ .__   __.  __    __  ");
            Console.WriteLine(@"    /   \     |       \ |   \/   | |  | |  \ |  |    |   \/   | |   ____||  \ |  | |  |  |  | ");
            Console.WriteLine(@"   /  ^  \    |  .--.  ||  \  /  | |  | |   \|  |    |  \  /  | |  |__   |   \|  | |  |  |  | ");
            Console.WriteLine(@"  /  /_\  \   |  |  |  ||  |\/|  | |  | |  . `  |    |  |\/|  | |   __|  |  . `  | |  |  |  | ");
            Console.WriteLine(@" /  _____  \  |  '--'  ||  |  |  | |  | |  |\   |    |  |  |  | |  |____ |  |\   | |  `--'  | ");
            Console.WriteLine(@"/__/     \__\ |_______/ |__|  |__| |__| |__| \__|    |__|  |__| |_______||__| \__|  \______/  ");
            Console.WriteLine("[1] Manage Users");
            Console.WriteLine("[2] Manage Books");
            Console.WriteLine("[3] Finances");
            Console.WriteLine("[4] Logout");
            Console.WriteLine("[5] Exit");
            Console.Write("Enter choice: ");
            return Helpers.Helper.GetUserChoiceNumber();
        }

        /// <summary>
        /// prints admin book menu and returns the choice.
        /// </summary>
        /// <returns></returns>
        public static int BookMenu()
        {
            Console.WriteLine("[1] Add book");
            Console.WriteLine("[2] Add book to category");
            Console.WriteLine("[3] Set amount on book");
            Console.WriteLine("[4] Update book");
            Console.WriteLine("[5] Delete book");
            Console.WriteLine("[6] Add category");
            Console.WriteLine("[7] Update category");
            Console.WriteLine("[8] Delete category");
            Console.WriteLine("[9] Go back to admin menu");
            Console.WriteLine("[10] Logout");
            Console.Write("Enter choice: ");
            return Helpers.Helper.GetUserChoiceNumber();
        }

        /// <summary>
        /// prints admin user menu and returns the choice.
        /// </summary>
        /// <returns></returns>
        public static int UserMenu()
        {
            Console.WriteLine("[1] List all users");
            Console.WriteLine("[2] Search user");
            Console.WriteLine("[3] Add new user");
            Console.WriteLine("[4] Back to admin menu");
            Console.WriteLine("[5] Logout");
            Console.Write("Enter choice: ");
            return Helpers.Helper.GetUserChoiceNumber();
        }

        /// <summary>
        /// prints specific user menu and returns the choice.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int SpecificUserMeny(Inlämning2WebbShop.Models.User user)
        {
            Console.WriteLine(user);
            Console.WriteLine("Select what you want to do:");
            Console.WriteLine($"[1] Promote {user.Name}");
            Console.WriteLine($"[2] Demote {user.Name}");
            Console.WriteLine($"[3] Activate {user.Name}");
            Console.WriteLine($"[4] Deactivate {user.Name}");
            Console.WriteLine($"[5] Go back to admin menu");
            Console.WriteLine($"[6] Logout");
            Console.Write("Enter your choice: ");
            return Helpers.Helper.GetUserChoiceNumber();
        }

        /// <summary>
        /// prints the finance menu
        /// </summary>
        /// <returns></returns>
        public static int FinanceMenu()
        {
            Console.WriteLine("[1] See money earned");
            Console.WriteLine("[2] See all sold Books");
            Console.WriteLine("[3] See who bought most books");
            Console.WriteLine("[4] Back to Admin menu");
            Console.WriteLine("[5] Logout");
            Console.Write("Enter choice: ");
            return Helpers.Helper.GetUserChoiceNumber();
        }
    }
}