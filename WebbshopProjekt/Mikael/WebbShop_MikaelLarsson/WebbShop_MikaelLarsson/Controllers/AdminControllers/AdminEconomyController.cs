namespace WebbShop_MikaelLarsson.Controllers
{
    using System;
    using Inlamn2WebbShop_MLarsson;
    using WebbShop_MikaelLarsson.Views;
    using WebbShop_MikaelLarsson.Views.Admin;

    /// <summary>
    /// Klass för hantering av admins economy-meny
    /// </summary>
    internal static class AdminEconomyController
    {
        /// <summary>
        /// Controller för View.AdminEconomyMenu()
        /// </summary>
        internal static void AdminEconomyMenu(int adminId)
        {
            int choice = ControlHelper.TryParseReadLine();
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    VGWebbShopAPI.SoldItems(adminId);
                    MessageView.PressEnter();
                    break;
                case 3:
                    VGWebbShopAPI.MoneyEarned(adminId);
                    MessageView.PressEnter();
                    break;
                case 4:
                    AdminUserView.ListUser(VGWebbShopAPI.BestCustomer(adminId));
                    MessageView.PressEnter();
                    break;
            }
        }
    }
}
