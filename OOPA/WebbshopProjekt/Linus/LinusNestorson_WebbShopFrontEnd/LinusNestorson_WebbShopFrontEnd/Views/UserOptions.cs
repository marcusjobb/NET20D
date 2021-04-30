using LinusNestorson_WebbShopFrontEnd.Controller;
using System;

namespace LinusNestorson_WebbShopFrontEnd.Views
{
    class UserOptions
    {
        private static UserController userCon = new UserController();

        /// <summary>
        /// Get available books based on category.
        /// </summary>
        /// <param name="userId">Id of user</param>
        public static void AvailableBooks(int userId)
        {
            Console.WriteLine($"{userCon.Ping(userId)}\n");
            Console.WriteLine("Type in the Id of the category you are interested in");
            int categoryId;
            bool input = int.TryParse(Console.ReadLine(), out categoryId);
            Console.WriteLine("These are the books with a stock of one or more in chosen category:\n");
            if (input)
            {
                if (userCon.GetAvailableBooks(categoryId).Count != 0)
                {
                    foreach (var book in userCon.GetAvailableBooks(categoryId))
                    {
                        Console.WriteLine(book.Title);
                    }
                }
                else
                {
                    Console.WriteLine("There are no available books in this category.");
                }

            }
            else if (!input)
            {
                Console.WriteLine("Please enter a valid number");
            }
        }

        /// <summary>
        /// Method for buying books.
        /// </summary>
        /// <param name="userId">Id of user</param>
        public static void BuyBook(int userId)
        {
            Console.WriteLine("Type Id of the book you want to buy.");
            Console.Write("BookId: ");
            int bookId;
            bool input = int.TryParse(Console.ReadLine(), out bookId);
            if (input)
            {
                if (userCon.BuyBook(userId, bookId))
                {
                    Console.WriteLine("Book bought!");
                }
                else Console.WriteLine("Purchase failed");
            }
            else if (!input)
            {
                Console.WriteLine("Please enter a valid input");
            }
        }

        /// <summary>
        /// List all available categories.
        /// </summary>
        /// <param name="userId">Id of user</param>
        public static void GetAllCategories(int userId)
        {
            Console.WriteLine($"{userCon.Ping(userId)}\n");
            Console.WriteLine("These are all categories:");
            foreach (var category in userCon.GetCategories())
            {
                Console.WriteLine(category.Name);
            }
        }

        /// <summary>
        /// Get information about book.
        /// </summary>
        /// <param name="userId">Id of user</param>
        public static void GetBook(int userId)
        {
            Console.WriteLine($"{userCon.Ping(userId)}\n");
            Console.WriteLine("Type Id of book you want to get information about.");
            Console.Write("BookId: ");
            int bookId;
            bool input = int.TryParse(Console.ReadLine(), out bookId);
            if (input)
            {
                Console.WriteLine("\nInfo:");
                Console.WriteLine(userCon.GetBook(bookId));
            }
            else if (!input)
            {
                Console.WriteLine("Please enter a valid bookId");
            }
        }

        /// <summary>
        /// Get books based on keyword.
        /// </summary>
        /// <param name="userId">Id of user</param>
        public static void GetBooks(int userId)
        {
            Console.WriteLine($"{userCon.Ping(userId)}\n");
            Console.WriteLine("Type in the keyword you want to search for.");
            Console.Write("Keyword: ");
            var keyword = Console.ReadLine();
            Console.WriteLine("These are the books with matching keyword:");
            if (userCon.GetBooks(keyword).Count != 0)
            {
                foreach (var book in userCon.GetBooks(keyword))
                {
                    Console.WriteLine(book.Title);
                }
            }
            else
            {
                Console.WriteLine("There is no books matching the keyword.");
            }
        }

        /// <summary>
        /// Get books based on author.
        /// </summary>
        /// <param name="userId">Id of user</param>
        public static void GetBooksByAuthors(int userId)
        {
            Console.WriteLine($"{userCon.Ping(userId)}\n");
            Console.WriteLine("Type in author that you want to get books by.");
            Console.Write("Author: ");
            var keyword = Console.ReadLine();
            Console.WriteLine("\nThese are the books from this author:\n");
            if (userCon.GetBooksByAuthor(keyword).Count != 0)
            {
                foreach (var book in userCon.GetBooksByAuthor(keyword))
                {
                    Console.WriteLine(book.Title);
                }
            }
            else
            {
                Console.WriteLine("There is no books by this Author or the Author can't be found.");
            }

        }

        /// <summary>
        /// List all books in chosen category.
        /// </summary>
        /// <param name="userId">Id of user</param>
        public static void GetBooksByCategory(int userId)
        {
            Console.WriteLine($"{userCon.Ping(userId)}\n");
            Console.WriteLine("Type in the Id of the category you are interested in");
            Console.Write("CategoryId: ");
            int categoryId;
            bool input = int.TryParse(Console.ReadLine(), out categoryId);
            Console.WriteLine("\nThese are the books in chosen category:\n");
            if (input)
            {
                if (userCon.GetCategory(categoryId).Count != 0)
                {
                    foreach (var book in userCon.GetCategory(categoryId))
                    {
                        Console.WriteLine(book.Title);
                    }
                }
                else
                {
                    Console.WriteLine("There are no books in this category.");
                }

            }
            else if (!input)
            {
                Console.WriteLine("Please enter a valid number");
            }
        }

        /// <summary>
        /// List all categories based on keyword.
        /// </summary>
        /// <param name="userId">Id of user</param>
        public static void GetCategoriesByKeyword(int userId)
        {
            Console.WriteLine($"{userCon.Ping(userId)}\n");
            Console.WriteLine("What word do you want to search for among categories?");
            Console.Write("Keyword: ");
            var keyword = Console.ReadLine();
            Console.WriteLine("\nThese are the categories based on your keyword:\n");
            if (userCon.GetCategories(keyword).Count != 0)
            {
                foreach (var category in userCon.GetCategories(keyword))
                {
                    Console.WriteLine(category.Name);
                }
            }
            else
            {
                Console.WriteLine("There are no categories matching your keyword.");
            }
        }
    }
}