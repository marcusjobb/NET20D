namespace WebbShop.Controllers
{
    using WebbShopAPI.APIHelper;
    using WebbShopAPI.Database;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="LoginUser" />.
    /// </summary>
    internal class LoginUser
    {
        /// <summary>
        /// Defines the MyAPI.
        /// </summary>
        private WebbShopAPIHelper MyAPI = new WebbShopAPIHelper();

        /// <summary>
        /// This method calls Seeder.Seed() to initial first data 
        /// then calls Login() from WebbShopAPIHelper to inactivate a user
        /// if user is admin then shows admin's menu else shows customer's menu
        /// </summary>
        /// <param name="user">The user<see cref="User"/>.</param>
        /// <returns>The <see cref="User"/>.</returns>
        public User login(User user)
        {
            Seeder.Seed();
            user.ID = MyAPI.Login(user.Name, user.Password);
            if (MyAPI.IsAdmin(user.ID))
            {
                user.IsAdmin = true;
            }
            return user;
        }
    }
}
