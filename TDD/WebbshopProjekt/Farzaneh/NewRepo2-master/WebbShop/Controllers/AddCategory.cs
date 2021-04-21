namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;

    /// <summary>
    /// Defines the <see cref="AddCategory" />.
    /// </summary>
    internal class AddCategory
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
        /// This method calls UpdateSessionTimer() from WebbShopAPIHelper to update session timer
        /// then calls AddCategory() from WebbShopAPIHelper to add a category
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Add()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.AddCategory(Views.LogIn.user.ID, CategoryName);
        }
    }
}
