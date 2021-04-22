namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;

    /// <summary>
    /// Defines the <see cref="UpdateCategory" />.
    /// </summary>
    internal class UpdateCategory
    {
        /// <summary>
        /// Defines the MyAPI.
        /// </summary>
        private WebbShopAPIHelper MyAPI = new WebbShopAPIHelper();

        /// <summary>
        /// Gets or sets the CategoryId.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the NewName.
        /// </summary>
        public string NewName { get; set; }

        /// <summary>
        /// This method calls UpdateSessionTimer() from WebbShopAPIHelper to update session timer
        /// then calls UpdateBook() from WebbShopAPIHelper to update information of a category
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Update()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.UpdateCategory(Views.LogIn.user.ID, CategoryId, NewName);
        }
    }
}
