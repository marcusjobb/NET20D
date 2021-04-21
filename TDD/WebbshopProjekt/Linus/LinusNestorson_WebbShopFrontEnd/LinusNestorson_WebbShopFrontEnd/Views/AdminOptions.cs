using LinusNestorson_WebbShopFrontEnd.Controller;
using System;

namespace LinusNestorson_WebbShopFrontEnd.Views
{
    class AdminOptions
    {
        private static AdminController adminCon = new AdminController();
        private static UserController userCon = new UserController();
        /// <summary>
        /// Allows admin to activate user.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void ActivateUser(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            Console.WriteLine("Please enter the Id of the user to activate");
            Console.Write("Id: ");
            int userId;
            bool input = int.TryParse(Console.ReadLine(), out userId);
            MenuHelper.CheckUserInput(input, adminCon.ActivateUser(adminId, userId));
        }
        /// <summary>
        /// Allows admin to add new books.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void AddBook(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            Console.WriteLine("What book do you want to add?");
            Console.Write("Title:");
            var title = Console.ReadLine();
            Console.Write("Author:");
            var author = Console.ReadLine();
            Console.Write("Price:");
            int price;
            bool input = int.TryParse(Console.ReadLine(), out price);
            if (input)
            {
                Console.Write("Amount of books in store: ");
                int amount;
                input = int.TryParse(Console.ReadLine(), out amount);
                MenuHelper.CheckUserInput(input, adminCon.AddBook(adminId, title, author, price, amount));
            }
            else if (!input)
            {
                Console.WriteLine("Try again and enter price with numbers only");
            }
        }
        /// <summary>
        /// Allows admin to add book to category.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void AddBookToCategory(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            Console.Write("Id of book: ");
            int bookId;
            bool input = int.TryParse(Console.ReadLine(), out bookId);
            if (input)
            {
                Console.Write("Id of category: ");
                int categoryId;
                input = int.TryParse(Console.ReadLine(), out categoryId);
                MenuHelper.CheckUserInput(input, adminCon.AddBookToCategory(adminId, bookId, categoryId));
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
            }
        }
        /// <summary>
        /// Allows admin to add new category.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void AddCategory(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            Console.Write("Name of category to be added: ");
            var catName = Console.ReadLine();
            if (adminCon.AddCategory(adminId, catName))
            {
                Console.WriteLine("Category added");
            }
            else
            {
                Console.WriteLine("Something went wrong. Try again");
            }
        }
        /// <summary>
        /// Allows admin to add new users.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void AddUser(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            Console.Write("Name of user: ");
            var name = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            if (adminCon.AddUser(adminId, name, password))
            {
                Console.WriteLine("User added");
            }
            else
            {
                Console.WriteLine("Something went wrong. Try again");
            }
        }
        /// <summary>
        /// Allows admin to see who bought the most books.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void BestCustomer(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            var bestCustomer = adminCon.BestCustomer(adminId);
            Console.WriteLine($"The best customer is user with Id {bestCustomer}");
        }
        /// <summary>
        /// Allows admin to delete books.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void DeleteBook(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            Console.Write("Id of book to be deleted: ");
            int bookId;
            bool input = int.TryParse(Console.ReadLine(), out bookId);
            MenuHelper.CheckUserInput(input, adminCon.DeleteBook(adminId, bookId));
        }
        /// <summary>
        /// Allows admin to delete a category.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void DeleteCategory(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            Console.WriteLine("Note: If a book is still linked to the category, it won't work");
            Console.Write("Id of category to be deleted: ");
            int categoryId;
            bool input = int.TryParse(Console.ReadLine(), out categoryId);
            MenuHelper.CheckUserInput(input, adminCon.DeleteCategory(adminId, categoryId));
        }
        /// <summary>
        /// Allows admin to demote a user.
        /// </summary>
        /// <param name="adminId">Id of user</param>
        public static void Demote(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            Console.WriteLine("Who do you want to demote to normal user? Type that users Id");
            Console.Write("Id: ");
            int userId;
            bool input = int.TryParse(Console.ReadLine(), out userId);
            MenuHelper.CheckUserInput(input, adminCon.Demote(adminId, userId));
        }
        /// <summary>
        /// Allows admin to find a user by keyword.
        /// </summary>
        /// <param name="adminId">Id of user</param>
        public static void FindUser(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            Console.WriteLine("Type in keyword that you want matching the users.");
            Console.Write("Keyword: ");
            var keyword = Console.ReadLine();
            Console.WriteLine("Theses are all users matching your keyword:");
            if (adminCon.FindUser(adminId, keyword).Count != 0)
            {
                foreach (var user in adminCon.FindUser(adminId, keyword))
                {
                    Console.WriteLine(user.Name);
                }
            }
            else
            {
                Console.WriteLine("No users were found with your keyword.");
            }
        }
        /// <summary>
        /// Allows admin to inactivate a user.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void InactivateUser(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            Console.WriteLine("Please enter the Id of the user to inactivate");
            Console.Write("Id: ");
            int userId;
            bool input = int.TryParse(Console.ReadLine(), out userId);
            MenuHelper.CheckUserInput(input, adminCon.InactivateUser(adminId, userId));
        }
        /// <summary>
        /// Displays a list of all users in database.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void ListUsers(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            Console.WriteLine("These are all users in database:");
            foreach (var user in adminCon.ListUsers(adminId))
            {
                Console.WriteLine(user.Name);
            }
        }
        /// <summary>
        /// Displays the total amount of cash earned from selling books.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void MoneyEarned(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            var sum = adminCon.MoneyEarned(adminId);
            Console.WriteLine($"You have earned {sum} kr from selling books");
        }
        /// <summary>
        /// Allows admin to promote a user.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void Promote(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            Console.WriteLine("Who do you want to promote to admin? Type that users Id");
            Console.Write("Id: ");
            int userId;
            bool input = int.TryParse(Console.ReadLine(), out userId);
            MenuHelper.CheckUserInput(input, adminCon.Promote(adminId, userId));
        }
        /// <summary>
        /// Allows admin to set the stock of a book in the database.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void SetAmount(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            Console.WriteLine("Whats the Id of the book you want to set amount to?");
            int bookId;
            bool input = int.TryParse(Console.ReadLine(), out bookId);
            MenuHelper.CheckBookAmountInput(adminId, bookId, input);
        }
        /// <summary>
        /// Displays a list of all books that have been sold.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void SoldItems(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            Console.WriteLine("\nThese are the sold books listed in database: ");
            foreach (var soldBook in adminCon.SoldItems(adminId))
            {
                Console.WriteLine(soldBook.Title);
            }
        }
        /// <summary>
        /// Allows admin to update a specific book.
        /// </summary>
        /// <param name="adminId">Id of admin</param>
        public static void UpdateBook(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            Console.Write("Id of book to be updated: ");
            int bookId;
            bool input = int.TryParse(Console.ReadLine(), out bookId);
            if (input)
            {
                Console.WriteLine("Update following data:");
                Console.Write("Title: ");
                var title = Console.ReadLine();
                Console.Write("Author: ");
                var author = Console.ReadLine();
                Console.Write("Price: ");
                int price;
                bool priceInput = int.TryParse(Console.ReadLine(), out price);
                if (priceInput)
                {
                    adminCon.UpdateBook(adminId, bookId, title, author, price);
                    Console.WriteLine("Book is updated");
                }
                else
                {
                    Console.WriteLine("Please enter price with numbers");
                }
            }
            else if (!input)
            {
                Console.WriteLine("Please enter a valid bookId");
            }
        }
        /// <summary>
        /// Allows admin to update a category with new name.
        /// </summary>
        /// <param name="adminId">Id óf admin</param>
        public static void UpdateCategory(int adminId)
        {
            Console.WriteLine($"{userCon.Ping(adminId)}\n");
            Console.Write("Id of category to be updated: ");
            int categoryId;
            bool input = int.TryParse(Console.ReadLine(), out categoryId);
            Console.Write("New name of category: ");
            var catName = Console.ReadLine();
            MenuHelper.CheckUserInput(input, adminCon.UpdateCategory(adminId, categoryId, catName));
        }
    }
}