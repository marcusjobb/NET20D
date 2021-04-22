using System;
using WebbShopFrontInlamning.Views;
using WebbShopInlamningsUppgift;

namespace WebbShopFrontInlamning.Controllers
{
    /// <summary>
    /// Controls the user flow
    /// </summary>
    class User
    {
        /// <summary>
        /// Allows you to register a new account
        /// </summary>
        public void RegisterAccount()
        {
            ManageAccountViews.RegisterAccount();
            var userName = Console.ReadLine();
            var userPassword = Console.ReadLine();
            var verifyPassword = Console.ReadLine();

            bool result = CheckRegistrationStatus(userName, userPassword, verifyPassword);
            if (result)
            {
                ManageAccountViews.RegisterSuccess();
                return;
            }

            ManageAccountViews.RegisterFailed();
        }

        /// <summary>
        /// Checks the status of the registration
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <param name="verifyPassword"></param>
        /// <returns>boolean, true if success, false if not</returns>
        private bool CheckRegistrationStatus(string userName, string userPassword, string verifyPassword)
        {
            if(userName != "" && userPassword != "" && verifyPassword != "")
            {
                WebbShopAPI api = new WebbShopAPI();
                return api.Register(userName, userPassword, verifyPassword);
            }

            return false;
        }
    }
}
