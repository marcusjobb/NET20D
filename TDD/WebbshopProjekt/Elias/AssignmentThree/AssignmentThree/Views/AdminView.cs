using System;

namespace AssignmentThree.Views
{
    public static class AdminView
    {
        public static (int bookId, string bookTitle, string bookAuthor, int bookPrice, int bookAmount) PrintAddBook()
        {
            Console.WriteLine("Enter the id for the book you want to add");
            int.TryParse(Console.ReadLine(), out var bookId);

            Console.WriteLine("Enter the title of the book");
            var bookTitle = Console.ReadLine();

            Console.WriteLine("Enter the author of the book");
            var bookAuthor = Console.ReadLine();

            Console.WriteLine("Enter the price of the book");
            int.TryParse(Console.ReadLine(), out var bookPrice);

            Console.WriteLine("Enter the amount of books you want to add");
            int.TryParse(Console.ReadLine(), out var bookAmount);

            return (bookId, bookTitle, bookAuthor, bookPrice, bookAmount);
        }

        public static (int bookId, int categoryId) PrintAddBookToCategory()
        {
            Console.WriteLine("Enter the id of the book");
            int.TryParse(Console.ReadLine(), out var bookId);

            Console.WriteLine("Enter the id of the category");
            int.TryParse(Console.ReadLine(), out var categoryId);

            return (bookId, categoryId);
        }

        public static void PrintAddCategory()
        {
            Console.WriteLine("Enter the name of the new category to add");
        }

        public static (string username, string password) PrintAddUser()
        {
            Console.WriteLine("Enter the name of the new user");
            var username = Console.ReadLine();

            Console.WriteLine("Enter the password for the new user");
            var password = Console.ReadLine();

            return (username, password);
        }

        public static void PrintAdminMenu()
        {
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Set amount of books");
            Console.WriteLine("3. List of all users");
            Console.WriteLine("4. List of matching users");
            Console.WriteLine("5. Update book information");
            Console.WriteLine("6. Delete a book");
            Console.WriteLine("7. Add a new category");
            Console.WriteLine("8. Add a book to a category");
            Console.WriteLine("9. Update a category");
            Console.WriteLine("10. Delete a category");
            Console.WriteLine("11. Add a user");
            Console.WriteLine("0. Return to main menu");
        }

        public static void PrintAdminMenuError()
        {
            Console.WriteLine("You either forgot to log in, or maybe you shouldn't be lurking around here you non admin?");
        }

        public static void PrintDeleteBook()
        {
            Console.WriteLine("Enter the id of the book you want to delete");
        }

        public static void PrintDeleteCategory()
        {
            Console.WriteLine("Enter the id of the category to delete");
        }

        public static void PrintFindUser()
        {
            Console.WriteLine("Enter the name of the user you want to find");
            var username = Console.ReadLine();

            foreach (var item in Program.API.FindUser(Program.User.Id, username))
            {
                Console.WriteLine($"{item.Id} {item.Name}");
            }
        }

        public static void PrintInvalidInput()
        {
            Console.WriteLine("Invalid input, please try again");
        }

        public static void PrintListUsers()
        {
            foreach (var item in Program.API.ListUsers(Program.User.Id))
            {
                Console.WriteLine($"{item.Id} {item.Name}");
            }
        }

        public static void PrintResult(bool result)
        {
            if (result)
            {
                Console.WriteLine("Action was successful");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public static (int bookId, int bookAmount) PrintSetAmount()
        {
            Console.WriteLine("Enter the id for the book you want to set amount of ");
            int.TryParse(Console.ReadLine(), out var bookId);

            Console.WriteLine("Enter the amount that you want to set to");
            int.TryParse(Console.ReadLine(), out var bookAmount);

            return (bookId, bookAmount);
        }

        public static (int bookId, string bookTitle, string bookAuthor, int bookPrice) PrintUpdateBook()
        {
            Console.WriteLine("Enter the id of the book you want to update");
            int.TryParse(Console.ReadLine(), out var bookId);

            Console.WriteLine("Enter the title of the book");
            var bookTitle = Console.ReadLine();

            Console.WriteLine("Enter the author of the book");
            var bookAuthor = Console.ReadLine();

            Console.WriteLine("Enter the price of the book");
            int.TryParse(Console.ReadLine(), out var bookPrice);

            return (bookId, bookTitle, bookAuthor, bookPrice);
        }

        public static (int categoryId, string categoryName) PrintUpdateCategory()
        {
            Console.WriteLine("Enter the id of the category to update");
            int.TryParse(Console.ReadLine(), out var categoryId);

            Console.WriteLine("Enter the new name for the category");
            var categoryName = Console.ReadLine();

            return (categoryId, categoryName);
        }
    }
}