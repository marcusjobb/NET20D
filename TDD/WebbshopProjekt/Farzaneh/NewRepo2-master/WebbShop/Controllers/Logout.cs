namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;

    /// <summary>
    /// Defines the <see cref="Logout" />.
    /// </summary>
    internal class Logout
    {
        /// <summary>
        /// Defines the MyAPI.
        /// </summary>
        private WebbShopAPIHelper MyAPI = new WebbShopAPIHelper();

        /// <summary>
        /// This method calls Logout from WebbShopAPIHelper to logut user.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool LogoutUser()
        {
            return MyAPI.Logout(Views.LogIn.user.ID);
        }
    }
}
