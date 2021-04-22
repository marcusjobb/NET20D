using Inlämning2WebbShop.Database;
using Inlämning2WebbShop.Models;
using System;
using System.Linq;

namespace Inlämning2WebbShop.Helpers
{
    internal class HelperMethods
    {
        public WebbShopContext db = new WebbShopContext();

        /// <summary>
        /// kollar om en bok existerar baserat på Id
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool DoesBookExists(int bookId, out Book book)
        {
            book = db.Books.FirstOrDefault(b => b.Id == bookId);
            return book != null;
        }

        /// <summary>
        /// kollar om bok existerar baserat på titel
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool DoesBookExists(string title)
        {
            var book = db.Books.FirstOrDefault(b => b.Title == title);
            return book != null;
        }

        /// <summary>
        /// kollar om en speicik kategori existerar baserat på kategori id.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool DoesCategoryExists(int categoryId, out BookCategory category)
        {
            category = db.Categories.FirstOrDefault(c => c.Id == categoryId);
            return category != null;
        }

        /// <summary>
        /// kollar om en specifik kategori existerar baserat på namn.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool DoesCategoryExists(string name)
        {
            var category = db.Categories.FirstOrDefault(c => c.Name == name);
            return category != null;
        }

        /// <summary>
        /// kollar ifall en avändare existerar genom att söka på Id. Returnerar true om användaren finns, false om null.
        /// tar emot userId och out parameter user.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool DoesUserExists(int userId, out User user)
        {
            user = db.Users.FirstOrDefault(u => u.Id == userId);
            return user != null;
        }

        /// <summary>
        /// kollar ifall en avändare existerar genom att söka på namn och lösenord. Returnerar true om användaren finns, false om null.
        /// tar emot ett username och ett password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool DoesUserExists(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            var user = db.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// kollar om en användare är en admin och inloggad.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsAdminAndLoggedIn(int userId)
        {
            var admin = new User();
            if (IsUserLoggedIn(userId, out admin) && admin.IsAdmin)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// kollar om en bok matchar kriterierna för att vara ute till försäljning
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool IsBookAvaliableForSale(int bookId, out Book book)
        {
            if (DoesBookExists(bookId, out book) && book.Amount > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// kollar om en användare matchar kriterierna för att få göra ett bokköp
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsUserAbleToPurchase(int userId, out User user)
        {
            if (IsUserLoggedIn(userId, out user) && user.IsActive)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kollar om en användare kan registrera sig baserat på namn, lösenord och lösenord verifierare.
        /// användaren får inte finnas, och de två inskickade lösenorden måste matcha.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns></returns>
        public bool IsUserAbleToRegister(string name, string password, string passwordVerify)
        {
            if (!DoesUserExists(name, password) && password.Equals(passwordVerify))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// kollar om en användare är inloggad
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsUserLoggedIn(int userId, out User user)
        {
            if (DoesUserExists(userId, out user) && user.SessionTimer > DateTime.Now.AddMinutes(-15) && user.IsActive)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// kollar så att användaren matchar kriterierna för att få vara inloggad. true om så är fallet, annars false
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UserAbleToLogIn(string username, string password, out User user)
        {
            user = db.Users.FirstOrDefault(u => u.Name == username && u.Password == password);

            if (user != null && user.IsActive)
            {
                return true;
            }
            return false;
        }
    }
}