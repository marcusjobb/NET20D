using Bookshop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbutik;
using Webbutik.Models;

namespace Bookshop.Helpers
{
    /// <summary>
    /// Global variables for the program.
    /// </summary>
    public static class GlobalVariables
    {
        public static WebbShopAPI Api = new WebbShopAPI();
        public static User User = new User();
        public static bool IsUserLoggedIn = false;
        public static int BookId = 0;
    }
}
