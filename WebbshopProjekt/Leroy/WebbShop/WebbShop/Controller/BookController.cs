using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.Model;
using WebbShopAPI;
using WebbShop.LeeUtils;

namespace WebbShop.Controller
{
    class BookController
    {    
        /// <summary>
        /// Displays all books in a given category
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ShowAllBooksInCategory(string name)
        {
            List<BookCategory> categories = WebbShopAPIClass.GetCategories(name);
            if (categories.Count() == 0) return LeeUtils.Txt.Nothing;
            List<Book> books = WebbShopAPIClass.GetCategory(categories[0]);
            string list = "";
            foreach (Book b in books)
            {
                list += b.Title + "\n";
            }
            if (list.Length > 0)
                return Txt.ShowList + list;
            return Txt.Nothing;
        }

        /// <summary>
        /// Displays the available books in a given category
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetAvailableBooksFromCategory(string name)
        {
            List<BookCategory> categories = WebbShopAPIClass.GetCategories(name);
            if (categories.Count() == 0) return LeeUtils.Txt.Nothing;
            List<Book> books = WebbShopAPIClass.GetAvailableBooks(categories[0]);
            string list = "";
            int i = 1;
            foreach (Book b in books)
            {
                list += i + ". " + b.Title + "\n";
                i++;
            }
            if (list.Length > 0)
                return Txt.ShowList + list;
            return Txt.Nothing;
        }

        /// <summary>
        /// Shows information about a book
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ShowInformation(string name)
        {
            List<BookCategory> categories = WebbShopAPIClass.GetCategories(name);
            if (categories.Count() == 0) return LeeUtils.Txt.Nothing;
            List<Book> books = WebbShopAPIClass.GetAvailableBooks(categories[0]);
            string list = "";
            foreach (Book b in books)
            {
                list += b.Title + "\n";
            }
            if (list.Length > 0)
                return GetInformation(books);
            return Txt.Nothing;
        }

        private static string GetInformation(List<Book> books)
        {
            TxtMessClass.Mess(Txt.ChooseBook);
            string choise = Console.ReadLine();
            string bookInformation = "";
            if (LeeCheckClass.IsADigit(choise))
            {
                int a = int.Parse(choise);
                if (a > 0 && books.Count() >= a)
                {
                    bookInformation = WebbShopAPIClass.GetInformationAboutBook(books[a - 1]);
                }
            }
            if (bookInformation.Length > 0)
                return bookInformation;
            return Txt.Nothing;
        }

        /// <summary>
        /// Allows you to buy a book through a chosen category
        /// </summary>
        /// <param name="name"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string BuyBook(string name, User user)
        {
            List<BookCategory> categories = WebbShopAPIClass.GetCategories(name);
            if (categories.Count() == 0) return LeeUtils.Txt.NoBookPurchased;
            List<Book> books = WebbShopAPIClass.GetAvailableBooks(categories[0]);
            string list = "";
            foreach (Book b in books)
            {
                list += b.Title + "\n";
            }
            if (list.Length > 0)
                return ConfirmPurchase(books, user);
            return Txt.NoBookPurchased;
        }

        private static string ConfirmPurchase(List<Book> books, User user)
        {
            TxtMessClass.Mess(Txt.ChooseBook);
            string choise = Console.ReadLine();
            if (LeeCheckClass.IsADigit(choise))
            {
                int a = int.Parse(choise);
                if (a > 0 && books.Count() >= a)
                {
                    if (WebbShopAPIClass.BuyBook(user, books[a - 1]))
                    {
                        return Txt.BookPurchased;
                    }
                }
            }
            return Txt.NoBookPurchased;
        }

        /// <summary>
        /// Finds a list of books by a keyword
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetBooksByKeyword(string name)
        {

            List<Book> books = WebbShopAPIClass.GetBooks(name);
            if (books.Count() == 0) return LeeUtils.Txt.Nothing;
            string list = "";
            int i = 1;
            foreach (Book b in books)
            {
                list += i + ". " + b.Title + "\n";
                i++;
            }
            if (list.Length > 0)
                return list;
            return Txt.Nothing;
        }

        /// <summary>
        /// Finds list of books by author
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetBooksByAuthor(string name)
        {

            List<Book> books = WebbShopAPIClass.GetAuthor(name);
            if (books.Count() == 0) return LeeUtils.Txt.Nothing;
            string list = books[0].Author + "\n";
            int i = 1;
            foreach (Book b in books)
            {
                list += i + ". " + b.Title + "\n";
                i++;
            }
            if (list.Length > 0)
                return list;
            return Txt.Nothing;
        }

        /// <summary>
        /// Shows information by book through keyword of a book
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isBook"></param>
        /// <returns></returns>
        public static string ShowInformationByBook(string name, bool isBook)
        {
            List<Book> books = new List<Book>();
            if (isBook)
            {
                books = WebbShopAPIClass.GetBooks(name);
                if (books.Count() != 0)
                    return GetInformation(books);
            }
            else
            {
                books = WebbShopAPIClass.GetAuthor(name);
                if (books.Count() != 0)
                    return GetInformation(books);
            }
            return Txt.Nothing;
        }

        /// <summary>
        /// Buy a book by name or through author
        /// </summary>
        /// <param name="name"></param>
        /// <param name="user"></param>
        /// <param name="isBook"></param>
        /// <returns></returns>
        public static string BuyBookByName(string name, User user, bool isBook)
        {
            List<Book> books = new List<Book>();
            if (isBook)
            {
                books = WebbShopAPIClass.GetBooks(name);
                if (books.Count() != 0)
                    return ConfirmPurchase(books, user);
            }
            else
            {
                books = WebbShopAPIClass.GetAuthor(name);
                if (books.Count() != 0)
                    return ConfirmPurchase(books, user);
            }
            return Txt.Nothing;
        }

    }
}
