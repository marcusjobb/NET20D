using System;
using System.Collections.Generic;
using System.Text;

namespace WebbShopFront.Controllers
{
    class UserMethods
    {
        /// <summary>
        /// Dessa två strängar har jag skapat för att göra det smidigare med att designa menyerna.
        /// </summary>
        public string spacing = "                                            ";
        public string spacing2 = "           ";

        /// <summary>
        /// Denna metod loggar ut användaren.
        /// </summary>
        public void Logout()
        {
            var menu = new WebbShopFront.Menu();
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "ID: ");
            string userInput = Console.ReadLine();

            int userID = Convert.ToInt32(userInput);

            var logout = API.Logout(userID);

            if (logout == true)
            {
                Console.WriteLine(spacing + "Logged out, you will return to main menu.");
                menu.Intro();
            }
            else if (logout == false)
            {
                Console.WriteLine(spacing + "Wrong ID.");
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Denna metod listar upp alla bokkategorier.
        /// </summary>
        public void ListCategories()
        {
            var API = new WebbShopAPI.WebbShopAPI();
            var categories = API.GetCategories();
            
            foreach (var category in categories)
            {
                Console.WriteLine(spacing + category.Name);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Denna metod söker efter en kategori med hjälp av en sökordsparameter.
        /// </summary>
        public void ListCategoryKeyword()
        {
            Console.Write(spacing + "Name: ");
            string input = Console.ReadLine();
            var API = new WebbShopAPI.WebbShopAPI();
            var categories = API.GetCategories(input);

            foreach (var category in categories)
            {
                Console.WriteLine(spacing + category.Name);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Denna metoden söker efter en kategori med hjälp av ID.
        /// </summary>
        public void ListCategoryID()
        {
            Console.Write(spacing + "ID: ");
            string inputID = Console.ReadLine();
            int ID = Convert.ToInt32(inputID);
            var API = new WebbShopAPI.WebbShopAPI();
            var categories = API.GetCategory(ID);

            foreach (var category in categories)
            {
                Console.WriteLine(spacing + category.Title);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Denna metoden kollar hur många böcker det finns kvar i systemet.
        /// </summary>
        public void GetAvaibleBooks()
        {
            Console.Write(spacing + "Book ID: ");
            string inputID = Console.ReadLine();
            int ID = Convert.ToInt32(inputID);
            var API = new WebbShopAPI.WebbShopAPI();
            var books = API.GetCategory(ID);
            int counter = 0;

            foreach (var book in books)
            {
                counter++;
            }
            Console.WriteLine(spacing + $"There is {counter} amount of books left.");
            Console.ReadLine();
        }

        /// <summary>
        /// Denna metoden hämtar en bok med hjälp av ID.
        /// </summary>
        public void GetBook()
        {
            Console.Write(spacing + "ID: ");
            string inputID = Console.ReadLine();
            int ID = Convert.ToInt32(inputID);
            var API = new WebbShopAPI.WebbShopAPI();

            var book = API.GetBook(ID);

            Console.WriteLine(spacing +  book.Title);
            Console.ReadLine();
        }

        /// <summary>
        /// Denna metoden hämtar alla böcker som matchar med sökordsparametern.
        /// </summary>
        public void GetBooks()
        {
            Console.Write(spacing + "Name: ");
            string input = Console.ReadLine();
            var API = new WebbShopAPI.WebbShopAPI();

            var bookList = API.GetBooks(input);

            foreach (var book in bookList)
            {
                Console.WriteLine(spacing + book.Title);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Denna metod hämtar alla författare som matchar med sökordsparametern.
        /// </summary>
        public void GetAuthors()
        {
            Console.Write(spacing + "Name: ");
            string input = Console.ReadLine();
            var API = new WebbShopAPI.WebbShopAPI();

            var authorList = API.GetBooks(input);

            foreach (var book in authorList)
            {
                Console.WriteLine(spacing + book.Author);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Denna metoden används för att köpa en bok.
        /// </summary>
        public void BuyBook()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "User ID: ");
            string userID = Console.ReadLine();
            Console.Write(spacing + "Book ID: ");
            string bookID = Console.ReadLine();
            int user = Convert.ToInt32(userID);
            int book = Convert.ToInt32(bookID);

            var buyBook = API.BuyBook(user, book);

            if (buyBook == true)
            {
                Console.WriteLine(spacing + "Bought book.");
            }
            else if (buyBook == false)
            {
                Console.WriteLine(spacing + "Failed to buy book.");
            }
            Console.ReadLine();
        }

    }
}
