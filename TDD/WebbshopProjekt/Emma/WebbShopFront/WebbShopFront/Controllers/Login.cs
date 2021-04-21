using System;
using WebbShopFrontInlamning.Views;
using WebbShopInlamningsUppgift;

namespace WebbShopFrontInlamning.Controllers
{
    /// <summary>
    /// Controls the login functionality
    /// </summary>
    class Login
    {
        /// <summary>
        /// Runs the login functionality page
        /// </summary>
        /// <returns>integer, user id if successful, 0 if not</returns>
        public int Run()
        {
            AccountViews.LoginPage();
            var userName = Console.ReadLine();
            var userPassword = Console.ReadLine();
            return CheckLoginStatus(userName, userPassword);
        }

        /// <summary>
        /// Checks if login succeeded
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns>integer, user id if successful, 0 if not</returns>
        public int CheckLoginStatus(string userName, string userPassword)
        {
            if (userName != "" && userPassword != "")
            {
                WebbShopAPI api = new WebbShopAPI();
                var user = api.Login(userName, userPassword);
                if (user != 0)
                {
                    AccountViews.LoginSuccess();
                    return user;
                }
            }

            AccountViews.LoginFailed();
            return 0;
        }
    }
}
