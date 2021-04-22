namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;

    /// <summary>
    /// Defines the <see cref="PromoteUser" />.
    /// </summary>
    internal class PromoteUser
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
        /// then calls Promote() from WebbShopAPIHelper to promote a user
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Promote()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.Promote(Views.LogIn.user.ID, UserId);
        }
    }
}
