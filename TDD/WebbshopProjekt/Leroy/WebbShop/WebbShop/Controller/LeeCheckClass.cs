using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.Model;

namespace WebbShop.Controller
{
    public static class LeeCheckClass
    {
        /// <summary>
        /// Checks if a string is null or empty
        /// </summary>
        /// <param name="mess"></param>
        /// <returns></returns>
        public static bool IfStringContainsNullOrEmpty(string mess)
        {
            if (mess != null || mess != "")
                return true;
            return false;
        }

        /// <summary>
        /// Checks if a user is active
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IfUserIsActive(User user)
        {
            if (user.IsActive) return true;
            return false;
        }

        /// <summary>
        /// Checks if the input is a digit
        /// </summary>
        /// <param name="choise"></param>
        /// <returns></returns>
        public static bool IsADigit(string choise)
        {
            int a = 0;
            try
            {
                a = int.Parse(choise);
                return true;
            }
            catch
            {

            }
            return false;
        }
    }
}
