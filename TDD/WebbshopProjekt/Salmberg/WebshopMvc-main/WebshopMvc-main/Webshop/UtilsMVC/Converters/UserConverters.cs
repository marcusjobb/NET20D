using System.Collections.Generic;
using WebshopAPI.Models;

namespace WebshopMVC.UtilsMVC.Converters
{
    /// <summary>
    /// Class for converting List of User objects to List of List of base class objects.
    /// </summary>
    internal class UserConverters
    {
        /// <summary>
        /// Converts List of User objects to List of List of base class objects.
        /// </summary>
        /// <param name="userList"></param>
        /// <returns>List of List of base class objects</returns>
        public static List<List<object>> UserConverter(List<User> userList)
        {
            List<List<object>> userListData = new List<List<object>>();
            foreach (var item in userList)
            {
                userListData.Add(new List<object> { item.Id, item.Name, item.Password, item.LastLogin, item.SessionTimer, item.IsActive, item.IsAdmin });
            }
            return userListData;
        }

        /// <summary>
        /// Converts a User object to List of List of base class objects.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>List of List of base class objects</returns>
        public static List<List<object>> UserConverter(User user)
        {
            List<List<object>> userData = new List<List<object>>()
            {new List<object>() { user.Id,user.Name,user.Password,user.LastLogin,user.SessionTimer,user.IsActive,user.IsAdmin } };

            return userData;
        }
    }
}