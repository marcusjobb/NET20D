
namespace WebbshopFrontEnd.Views.Admin
{
    using Inlämning2;
    using Inlämning2.Models;
    using System;
    using System.Collections.Generic;
    using WebbshopFrontEnd.Controllers.AdminControllers;

    public static class AdminUserMenu
    {
        public static WebbShopAPI api = new WebbShopAPI();

        public static void ShowAllUsers(List<User> users)
        {
            foreach (var u in users) { Console.WriteLine(u.ToString()); }
            if (users.Count == 0) { Message.UserNotExisted(); }
        }
        
        /// <summary>
        /// Vyn för hantering av användare.
        /// </summary>
        /// <param name="adminId"></param>
        public static void ShowUserMenu(int adminId)
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("************************");
                Console.WriteLine("*   Adminstratörsmeny  *");
                Console.WriteLine("************************\n");
                Console.WriteLine("Du har följande val");
                Console.WriteLine("[1]  Lista alla användare");
                Console.WriteLine("[2]  Söka efter en användare");
                Console.WriteLine("[3]  Lägga till en användare");
                Console.WriteLine("[4]  Tillbaka till adminstratörmenyn.");
                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 4)
                    {
                        AdminViews.AdminMenu(adminId);
                        loop = false;
                    }
                    else { AdminChoiceController.UserMenuChoice(adminId, choice); }
                }
                catch { Message.ErrorInput(); }
            }

        }
    }
}
