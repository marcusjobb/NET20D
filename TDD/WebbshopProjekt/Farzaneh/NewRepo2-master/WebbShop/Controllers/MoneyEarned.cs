namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;

    /// <summary>
    /// Defines the <see cref="MoneyEarned" />.
    /// </summary>
    internal class MoneyEarned
    {
        /// <summary>
        /// Defines the MyAPI.
        /// </summary>
        private WebbShopAPIHelper MyAPI = new WebbShopAPIHelper();

        /// <summary>
        /// This method calls UpdateSessionTimer() from WebbShopAPIHelper to update session timer
        /// then calls MoneyEarned() from WebbShopAPIHelper to show amount of Money Earned
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        public int Show()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.MoneyEarned(Views.LogIn.user.ID);
        }
    }
}
