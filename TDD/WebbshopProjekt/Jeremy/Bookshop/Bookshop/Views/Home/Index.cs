using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Views.Home
{
    public static class Index
    {
        /// <summary>
        /// The menu options when the user is not logged in.
        /// </summary>
        public static List<string> menuOptions = new List<string>() { "Login", "Register", "Books", 
            "Exit"};

        /// <summary>
        /// The menu options when the user is logged in.
        /// </summary>
        public static List<string> menuOptionsLoggedIn = new List<string>() { "Logout", "Books", 
            "Exit" };
    }
}
