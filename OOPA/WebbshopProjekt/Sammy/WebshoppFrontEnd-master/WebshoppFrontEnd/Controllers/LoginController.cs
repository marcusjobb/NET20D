
namespace WebbshopFrontEnd.Controllers
{
    using Inlämning2;
    using WebbshopFrontEnd.Views;

    public static class LoginController
    {
        public static WebbShopAPI api = new WebbShopAPI();

        public static void SignIn()
        {
            StartView.StartMenu();
            (string username, string password) = LoginMenu.ShowLogInMenu();
            var logInSuccess = api.LogIn(username, password);
            if (logInSuccess == 0)
            {
                UserView.RegisterUser(username, password);
            }
            else if (logInSuccess == 1)
            {
                AdminViews.AdminMenu(logInSuccess);
            }
            else
            {
                UserView.UserMenu(logInSuccess);
            }
        }
    }
}
