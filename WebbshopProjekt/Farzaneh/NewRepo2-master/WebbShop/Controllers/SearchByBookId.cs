namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="SearchByBookId" />.
    /// </summary>
    internal class SearchByBookId
    {
        /// <summary>
        /// Defines the MyAPI.
        /// </summary>
        private WebbShopAPIHelper MyAPI = new WebbShopAPIHelper();

        /// <summary>
        /// Gets or sets the BookID.
        /// </summary>
        public int BookID { get; set; }

        /// <summary>
        /// This method calls UpdateSessionTimer() from WebbShopAPIHelper to update session timer
        /// then calls GetBook() from WebbShopAPIHelper to Get information about book
        /// </summary>
        /// <returns>The <see cref="Book"/>.</returns>
        public Book Search()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return WebbShopAPIHelper.GetBook(BookID);
        }
    }
}
