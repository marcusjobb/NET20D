using BookShopFrontEnd.Controllers;
using BookShopFrontEnd.Utility;
using System;

namespace BookShopFrontEnd.Views
{
    public static class StartupMenuView
    {
        /// <summary>
        /// Starting menu.
        /// Menu options: Login, Register, Exit.
        /// </summary>
        public static void Menu()
        {
            Console.Clear();
            Logotypes.Welcome();
            MenuFrames.Frame(new string[] { "Login", "Register", "Exit" });
        }
    }
}
