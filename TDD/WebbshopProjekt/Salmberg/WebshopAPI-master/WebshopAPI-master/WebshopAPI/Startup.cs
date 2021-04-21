using WebshopAPI.Models;
using WebshopAPI.Utils;

namespace WebshopAPI
{
    /// <summary>
    /// Class for handling objects for starting application
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// Used like a session cookie for keeping track of logged in user
        /// </summary>
        public static User sessionCookie = new User();

        /// <summary>
        /// Sets up Seeder for use in Main()
        /// </summary>
        public static void InitialiseSeed()
        {
            Seed.Seeder();
        }

        /// <summary>
        /// Sets up DatabaseCreator for use in Main()
        /// </summary>
        public static void InitialiseDatabase()
        {
            Database.DatabaseCreator.Create();
        }
    }
}