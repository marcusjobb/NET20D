namespace WebbShop.Controllers
{
    using System.Collections.Generic;
    using WebbShopAPI.APIHelper;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="ShowUsers" />.
    /// </summary>
    internal class ShowUsers
    {
        /// <summary>
        /// Defines the MyAPI.
        /// </summary>
        private WebbShopAPIHelper MyAPI = new WebbShopAPIHelper();

        /// <summary>
        /// This method calls UpdateSessionTimer() from WebbShopAPIHelper to update session timer
        /// then calls ListUsers() from WebbShopAPIHelper to get List of users in database
        /// </summary>
        /// <returns>The <see cref="List{User}"/>.</returns>
        public List<User> ListAllUsers()
        {
            MyAPI.UpdateSessionTimer(Views.LogIn.user.ID);
            return MyAPI.ListUsers(Views.LogIn.user.ID);
        }
    }
}
