using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI;
using WebbShopAPI.Model;
using WebbShop.Controller;
using WebbShop.LeeUtils;
using WebbShopAPI;
using System.Threading;

namespace WebbShop.View
{
    static class LogInController
    {
        /// <summary>
        /// Initializez the login menu
        /// </summary>
        /// <returns></returns>
        public static bool StartMenue()
        {
            bool run = true;
            bool running = true;
            while (run)
            {
                WelcomeScreen();
                LogInView.Show();
                LogInScreen();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Presents the welcome screen
        /// </summary>
        /// <returns></returns>
        public static bool WelcomeScreen()
        {
            TxtMessClass.Mess(Txt.Welcome);
            return false;
        }

        /// <summary>
        /// Presents the login screen
        /// </summary>
        /// <returns></returns>
        public static bool LogInScreen()
        {
            
            TxtMessClass.Mess(Txt.Name);
            string name = Console.ReadLine();
            TxtMessClass.Mess(Txt.Password);
            string password = Console.ReadLine();
            var user = WebbShopAPIClass.LogIn(name, password);
            if (user.Name != null)
            {
                if (LeeCheckClass.IfUserIsActive(user))
                {
                    TxtMessClass.Mess(Txt.WelcomeUser + name);
                    TxtMessClass.Mess(Txt.LogingIn);
                    MenuOneView.Show(user);
                    Thread.Sleep(500);
                }
                else
                {
                    TxtMessClass.Mess(Txt.UserNotActive);
                }

            }
            else
            {
                Console.WriteLine($"Failed to log in {name}");
            }

            return false;
        }

        /// <summary>
        /// Registrates a new user
        /// </summary>
        /// <returns></returns>
        public static bool Registration()
            {
            TxtMessClass.Mess(Txt.Name);
            string name = Console.ReadLine();
            TxtMessClass.Mess(Txt.Password);
            string password = Console.ReadLine();
            TxtMessClass.Mess(Txt.Verify);
            string veriification = Console.ReadLine();
            if (WebbShopAPIClass.Register(name, password, veriification))
            {
                TxtMessClass.Mess(Txt.UserAdded);
                TxtMessClass.Mess(Txt.LogingIn);
                User ad = new User { IsAdmin = true };
                List<User> admin = WebbShopAPIClass.FindUsers(ad, name);
                User user = admin[0];
                if (user.ID != 0)
                {
                    if (user != null)
                    {
                        MenuOneView.Show(user);
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool LogOut(User user)
        {
            if (WebbShopAPIClass.LogOut(user))
                return true;
            return false;
        }
    }
}
