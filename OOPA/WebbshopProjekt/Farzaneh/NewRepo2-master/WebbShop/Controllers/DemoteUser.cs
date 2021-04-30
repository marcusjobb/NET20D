namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;

    /// <summary>
    /// Defines the <see cref="DemoteUser" />.
    /// </summary>
    internal class DemoteUser
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
        /// then calls Demote() from WebbShopAPIHelper to Demote a user
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Demote()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.Demote(Views.LogIn.user.ID, UserId);
        }
    }
}
