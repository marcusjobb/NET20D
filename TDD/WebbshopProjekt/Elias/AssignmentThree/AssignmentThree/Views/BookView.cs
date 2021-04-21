using System;

namespace AssignmentThree.Views
{
    public static class BookView
    {
        public static void PrintAvailableBooks()
        {
            Console.WriteLine("Enter category id to show books available in selected category");
            int.TryParse(Console.ReadLine(), out var userInput);

            foreach (var item in Program.API.GetAvailableBooks(userInput))
            {
                Console.WriteLine($"{item.Title}, {item.Author}");
            }
        }

        public static void PrintBookInfo()
        {
            Console.WriteLine("Enter book id to show additional information about the book");
            int.TryParse(Console.ReadLine(), out var userInput);

            foreach (var item in Program.API.GetBook(userInput))
            {
                Console.WriteLine($"ID: {item.Id}, Title: {item.Title}, Author: {item.Author}, Price: {item.Price}, Amount: {item.Amount}");
            }
        }

        public static void PrintBookMenu()
        {
            Console.WriteLine("1. List of books available");
            Console.WriteLine("2. Information about a specific book");
            Console.WriteLine("3. List of matching books");
            Console.WriteLine("4. List of books by author");
            Console.WriteLine("5. List of books in category");
            Console.WriteLine("0. Return to main menu");
        }

        public static void PrintBooksByAuthor()
        {
            Console.WriteLine("Please enter the keyword to search for books by matching authors");
            var userInput = Console.ReadLine();

            foreach (var item in Program.API.GetAuthors(userInput))
            {
                Console.WriteLine($"{item.Title}, {item.Author}");
            }
        }

        public static void PrintBooksInCategory()
        {
            Console.WriteLine("Enter category id to show all books in selected category");
            int.TryParse(Console.ReadLine(), out var userInput);

            foreach (var item in Program.API.GetCategory(userInput))
            {
                Console.WriteLine($"ID:{item.Id}, {item.Title}, {item.Author}");
            }
        }

        public static void PrintBuyBook()
        {
            Console.WriteLine("Enter the id for the book you want to buy");
        }

        public static void PrintCompleted()
        {
            Console.WriteLine("Book purchase completed. Thank you for supporting us.");
        }

        public static void PrintFailed()
        {
            Console.WriteLine("The purchase failed. Try again.");
        }

        public static void PrintInvalidInput()
        {
            Console.WriteLine("Invalid input, please try again");
        }

        public static void PrintLoginNeeded()
        {
            Console.WriteLine("You need to log in before buying a book");
        }

        public static void PrintMatchingBooks()
        {
            Console.WriteLine("Please enter the keyword to search for books");
            var userInput = Console.ReadLine();

            foreach (var item in Program.API.GetBooks(userInput))
            {
                Console.WriteLine($"ID: {item.Id}, {item.Title}, {item.Author}");
            }
        }
    }
}