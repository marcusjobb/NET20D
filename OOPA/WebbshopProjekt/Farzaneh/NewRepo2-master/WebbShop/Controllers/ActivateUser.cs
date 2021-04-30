namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;

    /// <summary>
    /// Defines the <see cref="ActivateUser" />.
    /// </summary>
    internal class ActivateUser
    {
        /// <summary>
        /// Defines the MyAPI.
        /// </summary>
        private WebbShopAPIHelper MyAPI = new WebbShopAPIHelper();

        /// <summary>
        /// Gets or sets the UserId.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// This method calls UpdateSessionTimer from WebbShopAPIHelper
        /// then calls ActivateUser from WebbShopAPIHelper to activate a user
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Active()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.ActivateUser(Views.LogIn.user.ID, UserId);
        }
    }
}
