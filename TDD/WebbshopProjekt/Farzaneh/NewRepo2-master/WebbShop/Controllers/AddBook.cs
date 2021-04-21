namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="AddBook" />.
    /// </summary>
    internal class AddBook
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
        /// then calls AddBook() from WebbShopAPIHelper to add a book
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Add()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.AddBook(Views.LogIn.user.ID, book.Title, book.Author, book.Price, book.Amount);
        }
    }
}
