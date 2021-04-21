using System;
using System.Collections.Generic;
using System.Text;
using Inlamn2WebbShop_MLarsson.Database;
using Inlamn2WebbShop_MLarsson.Models;

namespace Inlamn2WebbShop_MLarsson
{
    public static class Helper
    {
        /// <summary>
        /// Hjälpmetod för att se om en användare är administratör.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True om användare är admininstratör, annars false.</returns>
        public static bool CheckIfAdmin(User user)
        {
            Console.WriteLine();
            if (user?.IsAdmin == true)
            {
                return true;
            }
            else
            {
                Console.WriteLine("You are not an administrator.");
                return false;
            }
        }

        /// <summary>
        /// Hjälpmetod för att se om en bok finns.
        /// </summary>
        /// <param name="book"></param>
        /// <returns>True om bok finns, annars false.</returns>
        public static bool DoesBookExist(Book book)
        {
            return book != null;
        }

        /// <summary>
        /// Hjälpmetod för att se om en kategori finns.
        /// </summary>
        /// <param name="cat"></param>
        /// <returns>True om kategorin finns, annars false.</returns>
        public static bool DoesCategoryExist(Category cat)
        {
            return cat != null;
        }

        /// <summary>
        /// Hjälpmetod för att se om en användare finns.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True om användare finns, annars false.</returns>
        public static bool DoesUserExist(User user)
        {
            return user != null;
        }
    }
}
