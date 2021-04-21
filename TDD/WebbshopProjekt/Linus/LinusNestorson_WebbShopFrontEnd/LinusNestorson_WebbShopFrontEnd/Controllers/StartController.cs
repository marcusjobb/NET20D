using LinusNestorson_WebbShop;
using LinusNestorson_WebbShop.Models;

namespace LinusNestorson_WebbShopFrontEnd.Controller
{
    class StartController
    {
        private WebbShopAPI userApi = new WebbShopAPI();
        /// <summary>
        /// Controller method for logging in user.
        /// </summary>
        /// <param name="username">Username of user</param>
        /// <param name="password">Password of user</param>
        /// <returns>Returns the user matching username and password from database</returns>
        public User UserLogin(string username, string password)
        {
            var user = userApi.Login(username, password);
            return user;
        }
        /// <summary>
        /// Performs registration and inserting information into database from user.
        /// </summary>
        /// <param name="username">Username of user</param>
        /// <param name="password">Password of user</param>
        /// <param name="verPassword">Varified password of user</param>
        /// <returns>Returns true or false based on success of registration</returns>
        public bool UserRegistration(string username, string password, string verPassword)
        {
            return userApi.Register(username, password, verPassword);
        }
    }
}
