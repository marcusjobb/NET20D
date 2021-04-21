using Inlämning3.Helpers;
using System;

namespace Inlämning3.Views.Home
{
    public class MainMenu
    {
        /// <summary>
        /// Display main menu and returns a choice from the user.
        /// </summary>
        /// <returns></returns>
        public static int Display()
        {
            Console.WriteLine(@".___  ___.      ___       __  .__   __.    .___  ___.  _______ .__   __.  __    __  ");
            Console.WriteLine(@"|   \/   |     /   \     |  | |  \ |  |    |   \/   | |   ____||  \ |  | |  |  |  | ");
            Console.WriteLine(@"|  \  /  |    /  ^  \    |  | |   \|  |    |  \  /  | |  |__   |   \|  | |  |  |  | ");
            Console.WriteLine(@"|  |\/|  |   /  /_\  \   |  | |  . `  |    |  |\/|  | |   __|  |  . `  | |  |  |  | ");
            Console.WriteLine(@"|  |  |  |  /  _____  \  |  | |  |\   |    |  |  |  | |  |____ |  |\   | |  `--'  | ");
            Console.WriteLine(@"|__|  |__| /__/     \__\ |__| |__| \__|    |__|  |__| |_______||__| \__|  \______/  ");
            Console.WriteLine();
            Console.WriteLine("Welcome to our Bookshop!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine($"[1] Register");
            Console.WriteLine($"[2] Login");
            Console.WriteLine($"[3] Search");
            Console.WriteLine($"[4] Logout");
            Console.WriteLine($"[5] Exit");
            Console.Write("Enter choice: ");
            return Helper.GetUserChoiceNumber();
        }
    }
}