using System;
using WebbShopEmil;
using WebbShopEmil.Models;
using WebbShopFE.Views;

namespace WebbShopFE.Controllers
{
    /// <summary>
    /// Handles the Login, Logout and Register methods.
    /// </summary>
    internal class AuthenticationController
    {
        private static readonly MenuController menu = new();
        private readonly WebbShopAPI api = new();

        /// <summary>
        /// Takes input from user
        /// and uses the WebbShopAPI to Login user.
        /// </summary>
        internal void Login()
        {
            InputView.AskForName();
            var userName = Console.ReadLine();

            InputView.AskForPassword();
            var password = Console.ReadLine();

            var user = api.Login(userName, password);

            api.Ping(user.Id);

            if (user != null && user.IsActive == true)
            {
                if (user.IsAdmin == false)
                {
                    UserView.UserIsLoggedIn(user);
                }
                else if (user.IsAdmin == true)
                {
                    UserView.AdminIsLoggedIn(user);
                }
                Console.ReadKey();
                menu.SubMenuDirection(user);
            }
            else
            {
                MessageView.ErrorMessage();
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Uses the WebbShopAPI to logout user.
        /// </summary>
        /// <param name="id"></param>
        internal void Logout(int id)
        {
            api.Logout(id);
            UserView.LoggingOut();
            menu.MainMenu();
        }

        /// <summary>
        /// Takes input from user
        /// and uses the WebbShopAPI to register new user.
        /// </summary>
        /// <param name="user"></param>
        internal void Register(User user)
        {
            api.Ping(user.Id);

            InputView.AskForName();
            var name = Console.ReadLine();

            InputView.AskForPassword();
            var password = Console.ReadLine();

            InputView.VerifyPassword();
            var verifyPassword = Console.ReadLine();

            var succsesOrNot = api.Register(name, password, verifyPassword);
            if (succsesOrNot == true)
            {
                UserView.IsRegistered(name);
                Console.ReadKey();
                menu.MainMenu();
            }
            else
            {
                MessageView.ErrorMessage();
            }
            Console.ReadKey();
        }
    }
}