namespace WebbShop_MikaelLarsson.Controllers
{
    using System;
    using System.IO;
    using Inlamn2WebbShop_MLarsson;
    using Inlamn2WebbShop_MLarsson.Models;
    using WebbShop_MikaelLarsson.Views;
    using WebbShop_MikaelLarsson.Views.UserView;

    /// <summary>
    /// Klass för att hantera Huvudmenyn.
    /// </summary>
    internal static class MenuController
    {
        /// <summary>
        /// Skapar nytt Userobjekt för att kunna logga in.
        /// </summary>
        public static User user = new User();

        /// <summary>
        /// Controller för huvudmenyn
        /// </summary>
        public static void MainMenu()
        {
            int choice = ControlHelper.TryParseReadLine();
            switch (choice)
            {
                case 1:
                    MenuView.mainMenu = false;
                    break;
                case 2:
                    var login = UserUserView.LoginView();
                    user = WebbShopAPI.LogInUser(login.Item1, login.Item2);
                    MessageView.PressEnter();
                    break;
                case 3:
                    WebbShopAPI.LogOutUser(user.Id);
                    user = null;
                    MessageView.PressEnter();
                    break;
                case 4:
                    var register = UserUserView.Register();
                    WebbShopAPI.Register(register[0], register[1], register[2]);
                    MessageView.PressEnter();
                    break;
                case 5:
                    ControlHelper.PingHelper(user.Id);
                    MenuView.CategoryMenu();
                    break;
                case 6:
                    ControlHelper.PingHelper(user.Id);
                    MenuView.BookMenu();
                    break;
                case 7:
                    ControlHelper.CheckIfAdmin(user);
                    break;
            }
        }
    }
}
