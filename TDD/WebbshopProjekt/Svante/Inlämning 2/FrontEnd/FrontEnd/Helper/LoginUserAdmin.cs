using System;

namespace FrontEnd.Helper
{
    public static class LoginUserAdmin
    {
        public static int Login()
        {
            var nameAndPassword = Helper.Inputs.InputLogin();
            var userId = WebbShopAPI.WebbShopApi.Login(nameAndPassword.userName, nameAndPassword.password);
            Models.User.SessionTimer = DateTime.Now;
            return userId;
        }

        internal static void SetSessionTimer()
        {
            Models.User.SessionTimer = DateTime.Now;
        }
    }
}