using BookShopFrontEnd.Utility;
using BookShopFrontEnd.Views;
using WebbShopAPI;
using WebbShopAPI.Models;

namespace BookShopFrontEnd.Controllers
{
    /// <summary>
    /// Make calls for the Register/Login/Logout part of the application
    /// Also contains the currently active user.
    /// </summary>
    public class UserController
    {
        public static User LoggedUser { get; set; }
        public static int LoggedUserID { get; set; }

        /// <summary>
        /// Logs in the user.
        /// Retrieves a model.User and its ID.
        /// </summary>
        public static void UserLogin()
        {
            var credentials = Login.User();
            var userID = WebShopAPI.Login(credentials[0], credentials[1]);
            if (userID == 0)
            {
                StartupMenuView.Menu();
                Helper.ErrorMessage();
            }
            else
            {
                var user = new WebShopAPI().GetUserByID(userID);
                LoggedUser = user;
                LoggedUserID = userID;
                new WebShopAPI().Ping(userID);
            }
        }

        /// <summary>
        /// Registers the user into the database.
        /// Credentials[0] = username, [1]= password [2]= first name [3] = surname.
        /// </summary>
        internal static void UserRegister()
        {
            var credentials = Register.User();
            var success = new WebShopAPI().Register(credentials[0], credentials[1], credentials[2], credentials[3]);
            if (success)
            {
                MenuController.StartUpMenu();
            }
            else
            {
                Helper.ErrorMessage();
                UserRegister();
            }
        }

        /// <summary>
        /// Logs out the user.
        /// </summary>
        public static void UserLogout()
        {
            Logout.User(UserController.LoggedUser.Username);
            new WebShopAPI().LogOut(LoggedUserID);
            MenuController.StartUpMenu();
        }
    }
}
