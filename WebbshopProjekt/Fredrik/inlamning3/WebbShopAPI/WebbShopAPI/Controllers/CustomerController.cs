using System.Linq;
using WebbShopAPI.Database;
using WebbShopAPI.Models;

namespace WebbShopAPI.Controllers
{
    public static class CustomerController
    {
        /// <summary>
        /// Allows you to register a new customer.
        /// </summary>
        /// <param name="name">The users name</param>
        /// <param name="password">The users preferred associated password</param>
        /// <param name="passwordVerify">The users preferred associated password. Must match previous parameter password.</param>
        /// <returns>True for success or false if any of the following conditions are not met:
        /// <list type="bullet">
        /// <item>The name provided is null or empty (not set or "")</item>
        /// <item>The password provided in either password or passwordVerify is null or empty (not set or "")</item>
        /// <item>The name is already taken.</item>
        /// </list></returns>
        public static bool Register(string name, string password, string passwordVerify)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordVerify) || password != passwordVerify)
                return false;

            using var db = new WebbShopAPIContext();
            if(db.Customers.FirstOrDefault(c => c.Name.ToLower() == name.ToLower()) == null)
            {
                db.Customers.Add(new Customer()
                {
                    Name = name,
                    Password = password
                });
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Allows you to create a new customer via an object of it.
        /// </summary>
        /// <param name="c">The object of the customer you want to create.</param>
        /// <returns>True for success or false if any of the following conditions are not met:
        /// <list type="bullet">
        /// <item>The name provided is null or empty (not set or "")</item>
        /// <item>The password provided in either password or passwordVerify is null or empty (not set or "")</item>
        /// <item>The name is already taken.</item>
        /// </list></returns>
        public static bool Register(Customer c)
        {
            return Register(c.Name, c.Password, c.Password);
        }
    }
}
