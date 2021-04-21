using System;
using System.Collections.Generic;
using System.Linq;
using WebshopApi;
using WebshopApi.Models;

namespace Inlm3.Controllers
{
    /// <summary>
    /// Controller för api:n: WebbShopAPI
    /// </summary>

    internal class Controller
    {
        private WebbShopAPI api = new WebbShopAPI();

        /// <summary>
        /// Loggar in en användare genom api:n.
        /// </summary>
        /// <param name="account">Användarens username och lösenord i databasen </param>
        /// <returns> användarens Id, noll om lösenord och användarnamn är fel (int)</returns>
        public int Login((string, string) account)
        {
            int userID = api.Login(account.Item1, account.Item2);
            if (userID != 0)
            {
                return userID;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Loggar ut en användare genom api:n
        /// </summary>
        /// <param name="userID">Användarens userID</param>
        /// <returns> true om användaren loggades ut, annars false (bool)</returns>
        public bool Logout(int userID)
        {
            if (userID != 0)
            {
                api.Logout(userID);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Retunerar en IEnumerable med alla kategorier
        /// </summary>
        /// <returns> Retunerar en IEnumerable med alla kategorier (IEnumerable)</returns>
        public IEnumerable<Category> GetCategories()
        {
            return api.GetCategories();
        }

        /// <summary>
        /// Retunerar en IEnumerable med alla kategorier utifrån en sökning
        /// </summary>
        /// <returns> Retunerar en IEnumerable med alla kategorier utifrån sökning (IEnumerable)</returns>
        public IEnumerable<Category> GetCategoriesSearch()
        {
            string keyword;
            keyword = Console.ReadLine();
            return api.GetCategories(keyword);
        }

        /// <summary>
        /// Retunerar en IEnumerable med alla kategorier utifrån en sökning
        /// </summary>
        /// <returns> Retunerar en IEnumerable med alla kategorier utifrån sökning (IEnumerable)</returns>
        public IEnumerable<Book> GetCategory()
        {
            string textID = Console.ReadLine();

            if (Int32.TryParse(textID, out int categoryID))
            {
                return api.GetCategory(categoryID);
            }
            else
            {
                return Enumerable.Empty<Book>();
            }
        }

        /// <summary>
        /// Retunerar en IEnumerable med alla alla böcker som har amount > 0.
        /// </summary>
        /// <returns> Retunerar en IEnumerable med alla böcker(IEnumerable)</returns>
        public IEnumerable<Book> GetAvailableBooks()
        {
            return api.GetAvailableBooks();
        }

        /// <summary>
        /// Retunerar en IEnumerable med en bok som matchar dess bookID
        /// </summary>
        /// <returns> Retunerar en IEnumerable med en bok som matchar bookID(IEnumerable)</returns>
        public IEnumerable<Book> GetBook()
        {
            string textID = Console.ReadLine();

            if (Int32.TryParse(textID, out int bookID))
            {
                return api.GetBook(bookID);
            }
            else
            {
                return Enumerable.Empty<Book>();
            }
        }

        /// <summary>
        /// Retunerar en IEnumerable med böcker som matchar nyckelord i titel
        /// </summary>
        /// <returns> Retunerar en IEnumerable med böcker(IEnumerable)</returns>
        public IEnumerable<Book> GetBooks()
        {
            string keyword = Console.ReadLine();

            return api.GetBooks(keyword);
        }

        /// <summary>
        /// Retunerar en IEnumerable med böcker som matchar nyckelord i författare
        /// </summary>
        /// <returns> Retunerar en IEnumerable med böcker(IEnumerable)</returns>
        public IEnumerable<Book> GetAuthors()
        {
            string keyword = Console.ReadLine();

            return api.GetAuthors(keyword);
        }

        /// <summary>
        /// Låter användaren köpa en bok.
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> true om allt går som det ska, annars false (bool)</returns>
        public bool BuyBook(int userID)
        {
            string bookIDText = Console.ReadLine();

            if (Int32.TryParse(bookIDText, out int bookID))
            {
                return api.BuyBook(userID, bookID);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Lägger till en bok.
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> true om allt går som det ska, annars false (bool)</returns>
        public bool AddBook(int userID)
        {
            string title, author, price, amount;
            int priceInt, amountInt;

            Console.Write("Book title: ");
            title = Console.ReadLine();
            Console.Write("Book author: ");
            author = Console.ReadLine();
            Console.Write("Book price: ");
            price = Console.ReadLine();
            Console.Write("Book amount: ");
            amount = Console.ReadLine();

            if (Int32.TryParse(price, out priceInt)
                && Int32.TryParse(amount, out amountInt))
            {
                return api.AddBook(userID, title, author, priceInt, amountInt);
            }

            return false;
        }

        /// <summary>
        /// Ändrar en boks amount
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> true om allt går som det ska, annars false (bool)</returns>
        public bool SetAmount(int userID)
        {
            string bookID, amount;
            int bookIDInt, amountInt;

            Console.Write("Book ID: ");
            bookID = Console.ReadLine();
            Console.Write("Book Amount: ");
            amount = Console.ReadLine();

            if (Int32.TryParse(bookID, out bookIDInt)
                && Int32.TryParse(amount, out amountInt))
            {
                return api.SetAmount(userID, bookIDInt, amountInt);
            }
            return false;
        }

        /// <summary>
        /// Uppdaterar Titel, Författare och Pris på en bok
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> true om allt går som det ska, annars false (bool)</returns>
        public bool UpdateBook(int userID)
        {
            string title, author, price, bookID;
            int bookIDInt, priceInt;

            Console.Write("Book title: ");
            title = Console.ReadLine();
            Console.Write("Book author: ");
            author = Console.ReadLine();
            Console.Write("Book price: ");
            price = Console.ReadLine();
            Console.Write("Book ID: ");
            bookID = Console.ReadLine();

            if (Int32.TryParse(price, out bookIDInt)
                && Int32.TryParse(bookID, out priceInt))
            {
                return api.UpdateBook(userID, bookIDInt, title, author, priceInt);
            }

            return false;
        }

        /// <summary>
        /// Raderar en bok baserat på bookID
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> true om allt går som det ska, annars false (bool)</returns>
        public bool DeleteBook(int userID)
        {
            string bookID;
            int bookIDInt;
            Console.Write("BookID: ");
            bookID = Console.ReadLine();

            if (Int32.TryParse(bookID, out bookIDInt))
            {
                return api.DeleteBook(userID, bookIDInt);
            }

            return false;
        }

        /// <summary>
        /// Lägger till en kategori
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> true om allt går som det ska, annars false (bool)</returns>
        public bool AddCategory(int userID)
        {
            string categoryName;
            Console.Write("Category name");
            categoryName = Console.ReadLine();

            return api.AddCategory(userID, categoryName);
        }

        /// <summary>
        /// Lägger till en bok till en kategori
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> true om allt går som det ska, annars false (bool)</returns>
        public bool AddBookToCategory(int userID)
        {
            string categoryID, bookID;
            int categoryIDInt, bookIDInt;

            Console.Write("CategoryID: ");
            categoryID = Console.ReadLine();
            Console.Write("BookID: ");
            bookID = Console.ReadLine();

            if (Int32.TryParse(bookID, out bookIDInt)
                && Int32.TryParse(categoryID, out categoryIDInt))
            {
                return api.AddBookToCategory(userID, bookIDInt, categoryIDInt);
            }

            return false;
        }

        /// <summary>
        /// Uppdaterar namnet på en redan existerande kategori
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> true om allt går som det ska, annars false (bool)</returns>
        public bool UpdateCategory(int userID)
        {
            string categoryID, name;
            int categoryIDInt;

            Console.Write("Category ID: ");
            categoryID = Console.ReadLine();
            Console.Write("New name: ");
            name = Console.ReadLine();

            if (Int32.TryParse(categoryID, out categoryIDInt))
            {
                api.UpdateCategory(userID, categoryIDInt, name);
            }
            return false;
        }

        /// <summary>
        /// Uppdaterar namnet på en redan existerande kategori
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> true om allt går som det ska, annars false (bool)</returns>
        public bool DeleteCategory(int userID)
        {
            string categoryID;
            int categoryIDInt;

            Console.Write("CategoryID: ");
            categoryID = Console.ReadLine();

            if (Int32.TryParse(categoryID, out categoryIDInt))
            {
                return api.DeleteCategory(userID, categoryIDInt);
            }

            return false;
        }

        /// <summary>
        /// IEnumerable med alla användare
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> listar  alla användare, tom IEnumerable om userID != adminID </returns>
        public IEnumerable<User> ListUsers(int userID)
        {
            return api.ListUsers(userID);
        }

        /// <summary>
        /// IEnumerable med alla användare utifrån sökning på nyckelord
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> listar  alla användare, tom IEnumerable om userID != adminID eller om sökningen inte ger resultat </returns>
        public IEnumerable<User> FindUser(int userID)
        {
            string keyword;
            Console.Write("Your keyword: ");
            keyword = Console.ReadLine();

            return api.FindUser(userID, keyword);
        }

        /// <summary>
        /// Lägger till en användare
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> true om allt går som det ska, annars false </returns>
        public bool AddUser(int userID)
        {
            string name, password;
            Console.Write("Name: ");
            name = Console.ReadLine();

            Console.Write("Password: ");
            password = Console.ReadLine();

            return api.AddUser(userID, name, password);
        }

        /// <summary>
        /// Listar alla sålda böcker
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> IEnumerable med såla böcker, tom IEnumerable om userID != adminID </returns>
        public IEnumerable<SoldBook> SoldItems(int userID)
        {
            return api.SoldItems(userID);
        }

        /// <summary>
        /// Visar antalet pengar på sålda böcker
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> int av summan av sålda böcker 0 om userID != adminID </returns>
        public int MoneyEarned(int userID)
        {
            return api.MoneyEarned(userID);
        }

        /// <summary>
        /// Visar userID på bestCustomer
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> userID på bestcustomer, 0 om userID != adminID </returns>
        public int BestCustomer(int userID)
        {
            return api.BestCustomer(userID);
        }

        /// <summary>
        /// Gör en användare till admin
        /// <param name="adminID">Användarens userID</param>
        /// </summary>
        /// <returns> true om allt går som det ska, annars false </returns>
        public bool Promote(int adminID)
        {
            string userID;
            int userIDInt;

            Console.Write("ID of the user you want to promote: ");
            userID = Console.ReadLine();

            if (Int32.TryParse(userID, out userIDInt))
            {
                return api.Promote(adminID, userIDInt);
            }

            return false;
        }

        /// <summary>
        /// Degraderar en användare till vanlig user
        /// <param name="adminID">Användarens userID</param>
        /// </summary>
        /// <returns> true om allt går som det ska, annars false </returns>
        public bool Demote(int adminID)
        {
            string userID;
            int userIDInt;

            Console.Write("ID of the user you want to demote: ");
            userID = Console.ReadLine();

            if (Int32.TryParse(userID, out userIDInt))
            {
                return api.Demote(adminID, userIDInt);
            }

            return false;
        }

        /// <summary>
        /// Gör en användare aktiv
        /// <param name="adminID">Användarens userID</param>
        /// </summary>
        /// <returns> true om allt går som det ska, annars false </returns>
        public bool ActivateUser(int adminID)
        {
            string userID;
            int userIDInt;

            Console.Write("ID of the user you want to activate: ");
            userID = Console.ReadLine();

            if (Int32.TryParse(userID, out userIDInt))
            {
                return api.ActivateUser(adminID, userIDInt);
            }

            return false;
        }

        /// <summary>
        /// Inaktiverar en användare
        /// <param name="adminID">Användarens userID</param>
        /// </summary>
        /// <returns> true om allt går som det ska, annars false </returns>
        public bool InactivateUser(int adminID)
        {
            string userID;
            int userIDInt;

            Console.Write("ID of the user you want to inactivate: ");
            userID = Console.ReadLine();

            if (Int32.TryParse(userID, out userIDInt))
            {
                return api.ActivateUser(adminID, userIDInt);
            }

            return false;
        }

        /// <summary>
        /// Pingar om användarens sessionTimer inte gått ut
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> string "pong" om användarens timer är aktiv </returns>
        public string Ping(int userID)
        {
            return api.Ping(userID);
        }

        /// <summary>
        /// Registerar en ny användare
        /// <param name="userID">Användarens userID</param>
        /// </summary>
        /// <returns> true om allt går som det ska, annars false </returns>
        public bool Register(int userID)
        {
            string name, password, passwordVer;

            Console.Write("Please enter the name: ");
            name = Console.ReadLine();

            Console.Write("Please enter the password: ");
            password = Console.ReadLine();

            Console.Write("Please verify the password: ");
            passwordVer = Console.ReadLine();

            return api.Register(name, password, passwordVer);
        }
    }
}