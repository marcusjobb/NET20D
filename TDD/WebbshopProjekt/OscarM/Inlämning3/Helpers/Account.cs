using Inlämning3.Controllers;

namespace Inlämning3.Helpers
{
    /// <summary>
    /// Account to keep track of the logged in account.
    /// </summary>
    public static class Account
    {
        public static int UserId { get; set; }
        public static bool IsLoggedIn { get; set; }
        public static bool IsAdmin { get; set; }

        /// <summary>
        /// method that kicks a user out from the Admin views if the admin is not longer logged in or not longer admin.
        /// </summary>
        public static void KickOutIfNotLoggedInAdmin()
        {
            if (!IsAdmin || !IsLoggedIn)
            {
                HomeController home = new HomeController();
                home.Home();
            }
        }
    }
}