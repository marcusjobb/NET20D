namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="BuyBook" />.
    /// </summary>
    internal class BuyBook
    {
        /// <summary>
        /// Defines the MyAPI.
        /// </summary>
        private WebbShopAPIHelper MyAPI = new WebbShopAPIHelper();

        /// <summary>
        /// Gets or sets the BookTitle.
        /// </summary>
        public string BookTitle { get; set; }

        /// <summary>
        /// This method calls buy() from WebbShopAPIHelper to buy a book
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool buy()
        {
            Book book = WebbShopAPIHelper.GetBook(BookTitle);
            return MyAPI.BuyBook(Views.LogIn.user.ID, book.Id);
        }
    }
}
