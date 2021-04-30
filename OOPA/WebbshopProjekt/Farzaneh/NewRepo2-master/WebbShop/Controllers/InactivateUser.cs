namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;

    /// <summary>
    /// Defines the <see cref="InactivateUser" />.
    /// </summary>
    internal class InactivateUser
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
        /// This method calls UpdateSessionTimer() from WebbShopAPIHelper to update session timer
        /// then calls InactivateUser() from WebbShopAPIHelper to inactivate a user
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Inactive()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.InactivateUser(Views.LogIn.user.ID, UserId);
        }
    }
}
