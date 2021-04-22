namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="UpdateBook" />.
    /// </summary>
    internal class UpdateBook
    {
        /// <summary>
        /// Defines the MyAPI.
        /// </summary>
        private WebbShopAPIHelper MyAPI = new WebbShopAPIHelper();

        /// <summary>
        /// Gets or sets the book.
        /// </summary>
        public Book book { get; set; } = new Book();

        /// <summary>
        /// This method calls UpdateSessionTimer() from WebbShopAPIHelper to update session timer
        /// then calls UpdateBook() from WebbShopAPIHelper to update information of a book
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Update()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.UpdateBook(Views.LogIn.user.ID, book.Id, book.Title, book.Author, book.Price);
        }
    }
}
