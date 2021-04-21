using System;

namespace FrontEnd.Helper
{
    public static class InputAdmin
    {
        internal static (string title, string author, int price, int quantity) AddBookInput()
        {
            Console.WriteLine("[ADD BOOK]");
            Console.WriteLine("Enter Title");
            Console.Write(">");
            var title = Console.ReadLine();

            Console.WriteLine("Enter Author Fullname");
            Console.Write(">");
            var author = Console.ReadLine();

            Console.WriteLine("Enter Price");
            Console.Write(">");
            var strPrice = Console.ReadLine();
            int price = 0;
            try
            {
                price = Int32.Parse(strPrice);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{strPrice}'");
            }

            Console.WriteLine("Enter Quantity");
            Console.Write(">");
            var strQuantity = Console.ReadLine();
            int quantity = 0;
            try
            {
                quantity = Int32.Parse(strQuantity);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{strQuantity}'");
            }
            return (title, author, price, quantity);
        }

        internal static (int bookId, int quantity) SetQuantity()
        {
            Console.WriteLine("[SET QUANTITY]");
            Console.WriteLine("Enter bookId");
            Console.Write(">");
            var strBookId = Console.ReadLine();
            int bookId = 0;
            try
            {
                bookId = Int32.Parse(strBookId);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{strBookId}'");
            }

            Console.WriteLine("Enter Quantity");
            Console.Write(">");
            var strQuantity = Console.ReadLine();
            int quantity = 0;
            try
            {
                quantity = Int32.Parse(strQuantity);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{strQuantity}'");
            }

            return (bookId, quantity);
        }

        internal static (int userId, int bookId, string title, string author, int price) UpdateBook()
        {
            Console.WriteLine("[UPDATE BOOK]");
            var userId = Models.User.UserId;
            Console.WriteLine("Enter bookId");
            Console.Write(">");
            var strBookId = Console.ReadLine();
            int bookId = 0;
            try
            {
                bookId = Int32.Parse(strBookId);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{strBookId}'");
            }

            Console.WriteLine("Enter Title");
            Console.Write(">");
            var title = Console.ReadLine();

            Console.WriteLine("Enter Author");
            Console.Write(">");
            var author = Console.ReadLine();

            Console.WriteLine("Enter Price");
            var strPrice = Console.ReadLine();
            int price = 0;
            try
            {
                price = Int32.Parse(strPrice);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{strPrice}'");
            }

            return (userId, bookId, title, author, price);
        }

        internal static (int userId, string name, string password) AddUserInput()
        {
            Console.WriteLine("[ADD USER]");
            var userId = Models.User.UserId;
            var name = Console.ReadLine();
            var password = Console.ReadLine();

            return (userId, name, password);
        }

        internal static (int userId, int genreId) DeleteGenre()
        {
            Console.WriteLine("[DELETE GENRE]");
            var userId = Models.User.UserId;
            Console.WriteLine("Enter GenreID");
            var strgenre = Console.ReadLine();
            int genreId = 0;
            try
            {
                genreId = Int32.Parse(strgenre);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{strgenre}'");
            }

            return (userId, genreId);
        }

        internal static (int userId, int genreId, string name) UpdateGenre()
        {
            Console.WriteLine("[UPDATE GENRE]");
            var userId = Models.User.UserId;
            Console.WriteLine("Enter GenreID");
            var strgenre = Console.ReadLine();
            int genreId = 0;
            try
            {
                genreId = Int32.Parse(strgenre);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{strgenre}'");
            }

            Console.WriteLine("Enter new genre name");
            var genreName = Console.ReadLine();

            return (userId, genreId, genreName);
        }

        internal static (int userId, int bookId, int genreId) AddBookToGenre()
        {
            Console.WriteLine("[ADD BOOK TO GENRE]");
            var userId = Models.User.UserId;

            Console.WriteLine("Enter bookId");
            Console.Write(">");
            var strBookId = Console.ReadLine();
            int bookId = 0;
            try
            {
                bookId = Int32.Parse(strBookId);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{strBookId}'");
            }

            var strGenre = Console.ReadLine();
            int genreId = 0;
            try
            {
                genreId = Int32.Parse(strGenre);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{strGenre}'");
            }
            return (userId, bookId, genreId);
        }

        internal static (int userId, string name) AddGenre()
        {
            Console.WriteLine("[ADD GENRE]");
            var userId = Models.User.UserId;
            string name = Console.ReadLine();

            return (userId, name);
        }

        internal static (int userId, int bookId) DeleteBook()
        {
            Console.WriteLine("[DELTE BOOK]");
            var userId = Models.User.UserId;

            Console.WriteLine("Enter bookId");
            Console.Write(">");
            var strBookId = Console.ReadLine();
            int bookId = 0;
            try
            {
                bookId = Int32.Parse(strBookId);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{strBookId}'");
            }
            return (userId, bookId);
        }
    }
}