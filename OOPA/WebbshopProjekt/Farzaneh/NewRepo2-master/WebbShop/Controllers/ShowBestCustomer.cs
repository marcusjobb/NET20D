namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="ShowBestCustomer" />.
    /// </summary>
    internal class ShowBestCustomer
    {
        /// <summary>
        /// Defines the MyAPI.
        /// </summary>
        private WebbShopAPIHelper MyAPI = new WebbShopAPIHelper();

        /// <summary>
        /// This method calls UpdateSessionTimer() from WebbShopAPIHelper to update session timer
        /// then calls BestCustomer() from WebbShopAPIHelper to Find best customer by checking amount of orders (soldbooks).
        /// </summary>
        /// <returns>The <see cref="User"/>.</returns>
        public User BestCustomr()
        {
            return MyAPI.BestCustomer(Views.LogIn.user.ID);
        }
    }
}
