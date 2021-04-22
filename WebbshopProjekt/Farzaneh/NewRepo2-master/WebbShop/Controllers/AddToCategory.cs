namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;

    /// <summary>
    /// Defines the <see cref="AddToCategory" />.
    /// </summary>
    internal class AddToCategory
    {
        /// <summary>
        /// Defines the MyAPI.
        /// </summary>
        private WebbShopAPIHelper MyAPI = new WebbShopAPIHelper();

        /// <summary>
        /// Gets or sets the CategoryName.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the BookID.
        /// </summary>
        public int BookID { get; set; }

        /// <summary>
        /// This method calls UpdateSessionTimer() from WebbShopAPIHelper to update session timer
        /// then calls AddBookToCategory() from WebbShopAPIHelper to add a book to a category
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool AddToBookToCategory()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.AddBookToCategory(Views.LogIn.user.ID, BookID, CategoryName);
        }
    }
}
