using System;
using WebbShop.Models;
using WebbutikFrontend.Views.Shared;

namespace WebbutikFrontend.Views.Users
{
    public static class SelectedUser
    {
        /// <summary>
        /// The index view for the selected user.
        /// </summary>
        public static void View(User user)
        {
            Console.ForegroundColor = Layout.BannerInputColor;
            Console.WriteLine(
                "\n\t  __  __" +
                "\n\t / / / /__ ___ ____" +
                "\n\t/ /_/ (_-</ -_) __/" +
                "\n\t\\____/___/\\__/_/");
            Console.ForegroundColor = Layout.OriginalForegroundColor;
            Display.UserDetails(user, "\n\t");
            Console.WriteLine(
                "\n\tWhat do you want to do?" +
                "\n\t1. Promote user" +
                "\n\t2. Demote user" +
                "\n\t3. Activate user" +
                "\n\t4. Inactivate user" +
                "\n\t5. Go back");
        }
    }
}