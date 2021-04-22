namespace WebbShop.Controllers
{
    using System.Collections.Generic;
    using WebbShopAPI.APIHelper;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="SearchCategory" />.
    /// </summary>
    internal class SearchCategory
    {
        /// <summary>
        /// Defines the MyAPI.
        /// </summary>
        private WebbShopAPIHelper MyAPI = new WebbShopAPIHelper();

        /// <summary>
        /// Gets or sets the Keyword.
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// This method calls UpdateSessionTimer() from WebbShopAPIHelper to update session timer
        /// then calls GetCategories() from WebbShopAPIHelper to Get list of all categories that exists in databse
        /// </summary>
        /// <returns>The <see cref="List{BookCategory}"/>.</returns>
        public List<BookCategory> Search()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return WebbShopAPIHelper.GetCategories(Keyword);
        }
    }
}
