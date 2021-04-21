namespace WebbShop_MikaelLarsson.Controllers
{
    using System;
    using Inlamn2WebbShop_MLarsson;
    using WebbShop_MikaelLarsson.Views;
    using WebbShop_MikaelLarsson.Views.Admin;

    /// <summary>
    /// Klass för hantering av admins user-meny
    /// </summary>
    internal static class AdminUserController
    {
        /// <summary>
        /// Controller för hantering av View.AdminUserMenu()
        /// </summary>
        internal static void AdminUserMenu(int adminId)
        {
            int choice = ControlHelper.TryParseReadLine();
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    AdminUserView.ListUsers(WebbShopAPI.ListUsers(adminId));
                    MessageView.PressEnter();
                    break;
                case 3:
                    AdminUserView.SearchUser();
                    string search = Console.ReadLine();
                    AdminUserView.ListUsers(WebbShopAPI.FindUser(adminId, search));
                    MessageView.PressEnter();
                    break;
                case 4:
                    var add = AdminUserView.AddUser();
                    WebbShopAPI.AddUser(adminId, add.Item1, add.Item2);
                    MessageView.PressEnter();
                    break;
                case 5:
                    AdminUserView.UserDoWhat("promote");
                    var id = ControlHelper.TryParseReadLine();
                    VGWebbShopAPI.Promote(adminId, id);
                    MessageView.PressEnter();
                    break;
                case 6:
                    AdminUserView.UserDoWhat("demote");
                    var demoteId = ControlHelper.TryParseReadLine();
                    VGWebbShopAPI.Demote(adminId, demoteId);
                    MessageView.PressEnter();
                    break;
                case 7:
                    var actId = AdminUserView.UserDoWhat("activate");
                    VGWebbShopAPI.ActivateUser(adminId, actId);
                    MessageView.PressEnter();
                    break;
                case 8:
                    var inactId = AdminUserView.UserDoWhat("inactivate");
                    VGWebbShopAPI.InactivateUser(adminId, inactId);
                    MessageView.PressEnter();
                    break;
            }
        }
    }
}

