namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;

    /// <summary>
    /// Defines the <see cref="DeleteCategory" />.
    /// </summary>
    internal class DeleteCategory
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
        /// This method calls UpdateSessionTimer() from WebbShopAPIHelper to update session timer
        /// then calls DeleteCategory() from WebbShopAPIHelper to delete a category
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Delete()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.DeleteCategory(Views.LogIn.user.ID, CategoryId);
        }
    }
}
