using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.Model;
using WebbShop.LeeUtils;
using WebbShop.Controller;
using WebbShopAPI;

namespace WebbShop.Controller
{
    static class ActivatePromoteController
    {


        /// <summary>
        /// Promoting userg
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string PromoteUser(User admin)
        {
            TxtMessClass.Mess(Txt.Name);
            string name = Console.ReadLine();
            List<User> users = WebbShopAPIClass.FindUsers(admin, name);
            if (users.Count() > 0)
            {
                Console.WriteLine($"Promote user {users[0].Name} J/N");
                if (Choise(users[0]))
                {
                    if (WebbShopAPIClass.Promote(admin, users[0]))
                        return Txt.UserPromoted;
                }
            }
            return Txt.UserNotPromoted;
        }


        private static bool Choise(User user)
        {
            string choise = Console.ReadLine();
            switch (choise)
            {
                case "j":
                    return true;
                case "J":
                    return true;
                case "n":
                    return false;
                case "N":
                    return false;
            }
            return false;
        }

        /// <summary>
        /// Demoting user
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string DemoteUser(User admin)
        {
            TxtMessClass.Mess(Txt.Name);
            string name = Console.ReadLine();
            List<User> users = WebbShopAPIClass.FindUsers(admin, name);
            if (users.Count() > 0)
            {
                Console.WriteLine($"Demote user {users[0].Name} J/N");
                if (Choise(users[0]))
                {
                    if (WebbShopAPIClass.Demote(admin, users[0]))
                        return Txt.UserDemoted;
                }
            }
            return Txt.UserNotPromoted;
        }

        /// <summary>
        /// Activating user
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string ActivateUser(User admin)
        {
            TxtMessClass.Mess(Txt.Name);
            string name = Console.ReadLine();
            List<User> users = WebbShopAPIClass.FindUsers(admin, name);
            if (users.Count() > 0)
            {
                Console.WriteLine($"Activate user {users[0].Name} J/N");
                if (Choise(users[0]))
                {
                    if (WebbShopAPIClass.ActivateUser(admin, users[0]))
                        return Txt.UserActivated;
                }
            }
            return Txt.UserNotPromoted;
        }

        /// <summary>
        /// Deactivating user
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string DeactivateUser(User admin)
        {
            TxtMessClass.Mess(Txt.Name);
            string name = Console.ReadLine();
            List<User> users = WebbShopAPIClass.FindUsers(admin, name);
            if (users.Count() > 0)
            {
                Console.WriteLine($"Deactivate user {users[0].Name} J/N");
                if (Choise(users[0]))
                {
                    if (WebbShopAPIClass.InctivateUser(admin, users[0]))
                        return Txt.UserDeActivated;
                }
            }
            return Txt.UserNotPromoted;
        }
    }
}
