namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;

    /// <summary>
    /// Defines the <see cref="DeleteBook" />.
    /// </summary>
    internal class DeleteBook
    {
        /// <summary>
        /// Defines the MyAPI.
        /// </summary>
        private WebbShopAPIHelper MyAPI = new WebbShopAPIHelper();

        /// <summary>
        /// Gets or sets the BookId.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// This method calls UpdateSessionTimer() from WebbShopAPIHelper to update session timer
        /// then calls DeleteBook() from WebbShopAPIHelper to delete a book
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Delete()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.DeleteBook(Views.LogIn.user.ID, BookId);
        }
    }
}
