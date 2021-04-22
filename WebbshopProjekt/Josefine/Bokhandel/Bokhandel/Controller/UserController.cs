using Bokhandel.View;
using System;
using WebbShopJoR;

namespace Bokhandel.Controller
{
    class UserController
    {
        /// <summary>
        /// Ask for username and password and login
        /// </summary>
        /// <returns></returns>
        public static int Login()
        {
            var view = new AdminView();
            var userId = API.Login(EnterUsername(), EnterPassword());
            if (userId == 0) { view.Fail(); }
            else { view.CouldLogin(); }
            return userId;
        }
        /// <summary>
        /// Ask for username
        /// </summary>
        /// <returns></returns>
        public static string EnterUsername()
        {
            var view = new AdminView();
            view.EnterUsername();
            return Console.ReadLine();
        }
        /// <summary>
        /// Ask for password
        /// </summary>
        /// <returns></returns>
        public static string EnterPassword()
        {
            var view = new AdminView();
            view.EnterPassword();
            return Console.ReadLine();
        }

        /// <summary>
        /// Logging out
        /// </summary>
        /// <param name="userId"></param>
        public static void Logout(int userId)
        {
            API.Logout(userId);
        }
        /// <summary>
        /// Ask for username and for password two times, and register new person
        /// </summary>
        public static void Register()
        {
            var registerSucess = API.Register(EnterUsername(), EnterPassword(), EnterPassword());
            var view = new AdminView();
            if (registerSucess) { view.Sucess(); }
            if (!registerSucess) { view.Fail(); }
        }
    }
}
