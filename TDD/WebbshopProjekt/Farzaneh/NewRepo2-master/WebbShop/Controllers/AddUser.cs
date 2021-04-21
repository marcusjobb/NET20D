namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;

    /// <summary>
    /// Defines the <see cref="AddUser" />.
    /// </summary>
    internal class AddUser
    {
        /// <summary>
        /// Defines the MyAPI.
        /// </summary>
        private WebbShopAPIHelper MyAPI = new WebbShopAPIHelper();

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// This method calls UpdateSessionTimer() from WebbShopAPIHelper to update session timer
        /// then calls AddUser() from WebbShopAPIHelper to add a new user
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool add()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            if (Name == null)
            {
                return false;
            }
            else
            {
                return MyAPI.AddUser(Views.LogIn.user.ID, Name, Password);
            }
        }
    }
}
