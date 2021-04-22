namespace WebbShop.Controllers
{
    using System.Collections.Generic;
    using WebbShopAPI.APIHelper;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="ShowBooksInCategory" />.
    /// </summary>
    internal class ShowBooksInCategory
    {
        /// <summary>
        /// Defines the MyAPI.
        /// </summary>
        public WebbShopAPIHelper MyAPI = new WebbShopAPIHelper();

        /// <summary>
        /// Gets or sets the CategoryName.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// This method calls UpdateSessionTimer() from WebbShopAPIHelper to update session timer
        /// then calls GetCategory() from WebbShopAPIHelper to get list of books in the category
        /// </summary>
        /// <returns>The <see cref="List{Book}"/>.</returns>
        public List<Book> Display()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.GetCategory(CategoryName);
        }

        /// <summary>
        /// This method calls UpdateSessionTimer() from WebbShopAPIHelper to update session timer
        /// then calls GetAvailableBooks() from WebbShopAPIHelper to get list of books with amount>0 in the category.
        /// </summary>
        /// <returns>The <see cref="List{Book}"/>.</returns>
        public List<Book> DisplayAvailableBooks()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.GetAvailableBooks(CategoryName);
        }
    }
}
