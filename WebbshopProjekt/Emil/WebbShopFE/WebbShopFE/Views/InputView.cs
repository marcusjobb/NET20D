using System;

namespace WebbShopFE.Views
{
    /// <summary>
    /// Methods that prints out input statments for the user.
    /// </summary>
    public static class InputView
    {
        public static void AskForAmount()
        {
            Console.Write("\nEnter amount: ");
        }

        public static void AskForAuthor()
        {
            Console.Write("\nEnter author: ");
        }

        public static void AskForBookId()
        {
            Console.Write("\nEnter book Id: ");
        }

        public static void AskForChoice()
        {
            Console.Write("\nEnter choice: ");
        }

        public static void AskForKeyword() => Console.Write("\nEnter keyword: ");

        public static void AskForName()
        {
            Console.Write("\nEnter name: ");
        }

        public static void AskForPassword()
        {
            Console.Write("\nEnter password: ");
        }

        public static void AskForPrice()
        {
            Console.Write("\nEnter price: ");
        }

        public static void AskForTitle()
        {
            Console.Write("\nEnter title: ");
        }

        public static void ChooseBookById()
        {
            Console.Write("\nChoose book by id: ");
        }

        public static void SearchForBookByAuthor()
        {
            Console.Write("\nSearch for a book by author: ");
        }

        public static void SearchForBookByTitle()
        {
            Console.Write("\nSearch for a book by title: ");
        }

        public static void SearchForBookToBuy()
        {
            Console.Write("\nSearch for a book you want to buy (press [ENTER] to show all books): ");
        }

        public static void SearchForCategoryByName()
        {
            Console.Write("\nSearch for category by name: ");
        }

        public static void SearchforTitleOrAuthor()
        {
            Console.WriteLine("1. Search book by Title. \n2. Search book by Author.");
        }

        public static void VerifyPassword()
        {
            Console.Write("\nVerify passsword: ");
        }
    }
}