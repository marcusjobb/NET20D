using Inlämning2.Models;
using System;

namespace Inlämning2.Utils
{
    /// <summary>
    /// Samlingar av hjälpmetoder för att kolla olika saker.
    /// </summary>
    public static class Check
    {
        /// <summary>
        /// Kolla om en användare är administratör.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True om användaren är administratör, annars false</returns>
        public static bool ExistAdmin(User user)
        {
            if (user.IsAdmin)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Det krävs administrativ rättighet här.");
                return false;
            }
        }

        /// <summary>
        /// Kolla om en bok finns.
        /// </summary>
        /// <param name="book"></param>
        /// <returns> True om boken existerar, annars false.</returns>
        public static bool ExistBook(Book book)
        {
            return book != null;
        }

        /// <summary>
        /// Kolla om en kategori finns.
        /// </summary>
        /// <param name="cat"></param>
        /// <returns>True om kategori finns, annars false.</returns>
        public static bool ExistCategory(Category cat)
        {
            return cat != null;
        }

        /// <summary>
        /// Kolla om en användare är registerad.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True om användaren finns, annars false.</returns>
        public static bool ExistUser(User user)
        {
            return user != null;
        }
    }
}
