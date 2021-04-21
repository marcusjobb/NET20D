namespace WebbShop_MikaelLarsson.Controllers
{
    using System;
    using Inlamn2WebbShop_MLarsson;
    using Inlamn2WebbShop_MLarsson.Models;
    using WebbShop_MikaelLarsson.Views;
    using WebbShop_MikaelLarsson.Views.UserView;

    /// <summary>
    /// Klass för att hantera Adminmenyerna
    /// </summary>
    internal static class AdminMenuController
    {
        /// <summary>
        /// Controller för View.AdminMainMenu()
        /// </summary>
        public static void AdminMainMenu(int adminId)
        {
            int choice = ControlHelper.TryParseReadLine();
            switch (choice)
            {
                case 1:
                    AdminMenuView.adminMenu = false;
                    break;
                case 2:
                    AdminMenuView.AdminUserMenu(adminId);
                    break;
                case 3:
                    AdminMenuView.AdminBookMenu(adminId);
                    break;
                case 4:
                    AdminMenuView.AdminCategoryMenu(adminId);
                    break;
                case 5:
                    AdminMenuView.AdminEconomyMenu(adminId);
                    break;
            }
        }
    }
}
