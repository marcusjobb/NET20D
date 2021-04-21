namespace WebbShop.Controllers
{
    using System.Collections.Generic;
    using WebbShopAPI.APIHelper;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="SearchByAuthor" />.
    /// </summary>
    internal class SearchByAuthor
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
        /// then calls GetAuthors() from WebbShopAPIHelper to Get List of books that their author matching keyword
        /// </summary>
        /// <returns>The <see cref="List{Book}"/>.</returns>
        public List<Book> Search()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.GetAuthors(Keyword);
        }
    }
}
