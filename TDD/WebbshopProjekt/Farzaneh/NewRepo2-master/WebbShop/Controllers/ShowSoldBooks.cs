namespace WebbShop.Controllers
{
    using System.Collections.Generic;
    using WebbShopAPI.APIHelper;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="ShowSoldBooks" />.
    /// </summary>
    internal class ShowSoldBooks
    {
        /// <summary>
        /// Defines the MyAPI.
        /// </summary>
        private WebbShopAPIHelper MyAPI = new WebbShopAPIHelper();

        /// <summary>
        /// This method calls UpdateSessionTimer() from WebbShopAPIHelper to update session timer
        /// then calls SoldItems() from WebbShopAPIHelper to gets list of soldbooks.
        /// </summary>
        /// <returns>The <see cref="List{SoldBook}"/>.</returns>
        public List<SoldBook> ListBooks()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.SoldItems(Views.LogIn.user.ID);
        }
    }
}
