using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.Model;
using WebbShop.LeeUtils;
using WebbShopAPI;

namespace WebbShop.Controller
{
    public static class AdminController
    {

        public static string AddUser(User admin)
        {
            TxtMessClass.Mess(Txt.Name);
            string name = Console.ReadLine();

            TxtMessClass.Mess(Txt.Password);
            string password = Console.ReadLine();

            if (WebbShopAPIClass.AddUser(admin, name, password))
            {
                return Txt.UserAdded;
            }
            return Txt.UserNotAdded;
        }
        /// <summary>
        /// Adds a new book or raises the amout available
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string AddBook(User admin)
        {
            TxtMessClass.Mess(Txt.BookTitle);
            string title = Console.ReadLine();
            TxtMessClass.Mess(Txt.BookAuthor);
            string author = Console.ReadLine();
            TxtMessClass.Mess(Txt.BookPrice);
            string price = Console.ReadLine();
            TxtMessClass.Mess(Txt.BookAmount);
            string amount = Console.ReadLine();
            if (LeeCheckClass.IsADigit(price) && LeeCheckClass.IsADigit(amount))
            {
                int p = int.Parse(price);
                int a = int.Parse(amount);
                if (a > 0 && p > 0)
                {
                    Book book = WebbShopAPIClass.GetBook(title);
                    if (book.ID == 0)
                    {
                        if (WebbShopAPIClass.AddBook(admin, book, title, author, p, a))
                        {
                            return Txt.BookAdded;
                        }
                    }
                    else if (SetAmount(admin, book, a))
                    {
                        return Txt.BookAdded;
                    }
                }
            }
            return Txt.BookNotAdded;
        }

        /// <summary>
        /// Changes the amout of books available
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string ChangeTheAmount(User admin)
        {
            TxtMessClass.Mess(Txt.ChooseBook);
            string book = Console.ReadLine();
            List<Book> books = WebbShopAPIClass.GetBooks(book);
            if (books.Count() > 0)
            {
                Console.WriteLine(books[0].Title + "? J/N");
                string choise = Console.ReadLine();
                switch (choise)
                {
                    case "j":
                        Console.WriteLine("Wich amount");
                        string amount = Console.ReadLine();
                        if (LeeCheckClass.IsADigit(amount))
                        {
                            int a = int.Parse(amount);
                            if (a > 0)
                            {
                                if (SetAmount(admin, books[0], a))
                                    return Txt.AmountAdded;
                            }
                        }
                        break;
                    case "J":
                        Console.WriteLine("Wich amount");
                        amount = Console.ReadLine();
                        if (LeeCheckClass.IsADigit(amount))
                        {
                            int a = int.Parse(amount);
                            if (a > 0)
                            {
                                if (SetAmount(admin, books[0], a))
                                    return Txt.AmountAdded;
                            }
                        }
                        break;
                    case "n":
                        break;
                    case "N":
                        break;
                }
            }
            return Txt.AmountNotAdded;
        }


        private static bool SetAmount(User admin, Book book, int amount)
        {
            if (WebbShopAPIClass.SetAmount(admin, book, amount))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Lists all the users
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string ListUsers(User admin)
        {
            List<User> users = WebbShopAPIClass.ListUsers(admin);
            string list = "";
            int i = 1;
            if (users.Count() > 0)
            {
                foreach (User u in users)
                {
                    list += i + ". " + u.Name + "\n";
                    i++;
                }
                return Txt.ShowList + list;
            }
            return Txt.Nothing;
        }

        /// <summary>
        /// Finds users matching your keyword
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string FindUsers(User admin)
        {
            TxtMessClass.Mess(Txt.Name);
            string name = Console.ReadLine();
            List<User> users = WebbShopAPIClass.FindUsers(admin, name);
            string list = "";
            int i = 1;
            if (users.Count() > 0)
            {
                foreach (User u in users)
                {
                    list += i + ". " + u.Name + "\n";
                    i++;
                }
                return Txt.ShowList + list;
            }
            return Txt.Nothing;
        }

        /// <summary>
        /// Updatse a book
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string UpdateBook(User admin)
        {
            Console.WriteLine("Type wich book");
            string findBook = Console.ReadLine();
            TxtMessClass.Mess(Txt.BookTitle);
            string title = Console.ReadLine();
            TxtMessClass.Mess(Txt.BookAuthor);
            string author = Console.ReadLine();
            TxtMessClass.Mess(Txt.BookPrice);
            string price = Console.ReadLine();
            if (LeeCheckClass.IsADigit(price))
            {
                int p = int.Parse(price);
                if (p > 0)
                {
                    Book book = WebbShopAPIClass.GetBook(findBook);
                    if (book.ID != 0)
                    {
                        if (WebbShopAPIClass.UpdateBook(admin, book, title, author, p))
                        {
                            return Txt.BookUpdated;
                        }
                    }
                }
            }
            return Txt.BookNotUpdated;
        }

        /// <summary>
        /// Deletes a book
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string DeleteBook(User admin)
        {
            TxtMessClass.Mess(Txt.BookTitle);
            string title = Console.ReadLine();
            Book book = WebbShopAPIClass.GetBook(title);
            if (book.ID != 0)
            {
                if (WebbShopAPIClass.DeleteBook(admin, book))
                {
                    return Txt.BookDeleted;
                }
            }

            return Txt.BookNotDeleted;
        }

        /// <summary>
        /// Adds a new category
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string AddCategory(User admin)
        {
            TxtMessClass.Mess(Txt.Name);
            string name = Console.ReadLine();

            if (WebbShopAPIClass.AddCategory(admin, name))
            {
                return Txt.CategoryAdded;
            }
            return Txt.CategoryNotAdded; ;
        }

        /// <summary>
        /// Adds a book to a category
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string AddBookToCategory(User admin)
        {
            TxtMessClass.Mess(Txt.BookTitle);
            string title = Console.ReadLine();
            TxtMessClass.Mess(Txt.Category);
            string category = Console.ReadLine();
            List<Book> books = WebbShopAPIClass.GetBooks(title);
            List<BookCategory> categories = WebbShopAPIClass.GetCategories(category);
            if (books.Count() > 0 && categories.Count > 0)
            {
                if (WebbShopAPIClass.AddBookToCategory(admin, books[0], categories[0]))
                {
                    return Txt.CategoryAdded;
                }
            }
            return Txt.CategoryNotAdded; ;
        }

        /// <summary>
        /// Updates a category
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string UpdateCategory(User admin)
        {
            TxtMessClass.Mess(Txt.Category);
            string category = Console.ReadLine();
            TxtMessClass.Mess(Txt.Name);
            string name = Console.ReadLine();
            List<BookCategory> categories = WebbShopAPIClass.GetCategories(category);
            if (categories.Count > 0)
            {
                if (WebbShopAPIClass.UpdateCategory(admin, categories[0], name))
                {
                    return Txt.CategoryUpdated;
                }
            }
            return Txt.CategoryNotUpdated;
        }

        /// <summary>
        /// Delets a category
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string DeleteCategory(User admin)
        {
            TxtMessClass.Mess(Txt.Category);
            string category = Console.ReadLine();
            List<BookCategory> categories = WebbShopAPIClass.GetCategories(category);
            if (categories.Count > 0)
            {
                if (WebbShopAPIClass.DeleteCategory(admin, categories[0]))
                {
                    return Txt.CategoryDeleted;
                }
            }
            return Txt.CategoryNotDeleted;
        }

        /// <summary>
        /// Lists all books sold
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string ListAllSoldBooks(User admin)
        {
            List<SoldBook> soldBooks = WebbShopAPIClass.SoldItems(admin);
            string list = "";
            int i = 1;
            if (soldBooks.Count > 0)
            {
                foreach (SoldBook b in soldBooks)
                {
                    list += i + ". " + b.Title + "\n";
                    i++;
                }
                return Txt.ShowList + list;
            }
            return Txt.Nothing;
        }

        /// <summary>
        /// Displays the total amout you've earned
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string ShowMoneyEarned(User admin)
        {
            int earnings = WebbShopAPIClass.MoneyEarned(admin);
            return Txt.Earnings + earnings.ToString();
        }

        /// <summary>
        /// Shows your best buyer
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string ShowBestCustomer(User admin)
        {
            User bestCustomer = WebbShopAPIClass.BestCustomer(admin);
            return Txt.BestCustomer + bestCustomer.Name;
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static string DeleteUser(User admin)
        {
            TxtMessClass.Mess(Txt.Name);
            string name = Console.ReadLine();
            List<User> user = WebbShopAPIClass.FindUsers(admin, name);
            if (user.Count() > 0)
            {
                List<User> users = WebbShopAPIClass.FindUsers(admin, user[0].Name);
                if (users.Count() > 0)
                {

                    if (WebbShopAPIClass.DeleteUser(admin, users[0]))
                    {
                        return Txt.UserDeleted;
                    }
                }

            }
            return Txt.UserNotDeleted;
        }
    }
}
