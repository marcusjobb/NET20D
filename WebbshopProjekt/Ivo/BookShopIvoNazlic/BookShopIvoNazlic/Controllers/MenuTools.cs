using System;

namespace BookShopIvoNazlic.Controllers
{
    /// <remarks>
    /// Handles user inpunts
    /// </remarks>
    static class MenuTools
    {

        public static string UserIdInput()
        {
            Console.Write("Enter the user Id: ");
            string userId = Console.ReadLine();
            Console.Clear();
            return userId;
        }

        public static string UsernameInput()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Clear();
            return username;
        }

        public static string PasswordInput()
        {
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Clear();
            return password;
        }

        public static string KeywordInput()
        {
            Console.Write("Enter keyword: ");
            string keyword = Console.ReadLine();
            Console.Clear();
            return keyword;
        }
        
        public static string CategoryIdInput()
        {
            Console.Write("Enter Category Id: ");
            string categoryId = Console.ReadLine();
            Console.Clear();
            return categoryId;
        }

        public static string CategoryNameInput()
        {
            Console.Write("Enter the name for the category: ");
            string categoryName = Console.ReadLine();
            Console.Clear();
            return categoryName;
        }

        public static string BookIdInput()
        {
            Console.Write("Enter book Id: ");
            string bookdId = Console.ReadLine();
            Console.Clear();
            return bookdId;
        }

        public static string BookTitleInput()
        {
            Console.Write("Enter book title: ");
            string bookTitle = Console.ReadLine();
            Console.Clear();
            return bookTitle;
        }

        public static string AuthorInput()
        {
            Console.Write("Enter author name: ");
            string author = Console.ReadLine();
            Console.Clear();
            return author;
        }

        public static string PriceInput()
        {
            Console.Write("Enter the price: ");
            string price = Console.ReadLine();
            Console.Clear();
            return price;
        }

        public static string AmmountInput()
        {
            Console.Write("Enter the ammount: ");
            string ammount = Console.ReadLine();
            Console.Clear();
            return ammount;
        }


    }
}
