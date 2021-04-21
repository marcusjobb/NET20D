using System;

namespace FrontEnd.Controllers
{
    public static class User
    {
        public static void Exampel()
        {
            var input = Helper.InputAdmin.AddBookInput();
            WebbShopAPI.WebbShopApi.AddBook(Models.User.UserId, input.title, input.author, input.price, input.quantity);
            Helper.LoginUserAdmin.SetSessionTimer();
            Console.WriteLine($"Title: {input.title} Author: {input.author} Price: {input.price} Qty: {input.quantity}" +
                $"n\nHave been added to Svantes Webbshop");
            Console.ReadLine();
        }

        public static void GetCategories()
        {
            var genres = WebbShopAPI.WebbShopApi.GetCategories();
            foreach (var genre in genres)
            {
                Console.WriteLine($"{genre.GenreId} {genre.Genre}");
            }
        }

        public static void GetCategories(string keyword)
        {
            var genres = WebbShopAPI.WebbShopApi.GetCategories(keyword);
            
            foreach (var genre in genres)
            {
                Console.WriteLine($"{genre.GenreId} {genre.Genre}");
            }
        }

        internal static void GetCategory()
        {
            var genreList = WebbShopAPI.WebbShopApi.GetCategories();
            foreach (var genre in genreList)
            {
                Console.WriteLine($" ID {genre.GenreId} Genre {genre.Genre}");
            }
            var genreInput = Helper.InputUser.GetCategory();
            var books = WebbShopAPI.WebbShopApi.GetCategory(genreInput);
            if (books.Count > 0)
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"ID {book.Id} Title {book.Title} Author {book.Author}");
                }
            }
            else
            {
                Console.WriteLine("Someting went wrong");
            }
        }

        internal static void GetBook()
        {
            var input = Helper.InputUser.GetBook();
            var bookInfo = WebbShopAPI.WebbShopApi.GetBook(input);
            if (bookInfo != null)
            {
                Console.WriteLine($"ID: {bookInfo.Id} Title: {bookInfo.Title}\n" +
                    $"Author: {bookInfo.Author}\n" +
                    $"Gener: {bookInfo.Genres}\n" +
                    $"Price: {bookInfo.Price}\n" +
                    $"Qty: {bookInfo.Quantity}");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }

        internal static void Ping()
        {
            var ping = WebbShopAPI.WebbShopApi.Ping(Models.User.UserId);
            if (ping == "pong")
            {
                Models.User.SessionTimer = DateTime.Now;
            }
            else
            {
                Console.WriteLine("you are logged out");
            }
        }

        internal static void BuyBook()
        {
            var input = Helper.InputUser.BuyBook();
            var buySucces = WebbShopAPI.WebbShopApi.BuyBook(input.userId, input.bookId);
            if (buySucces)
            {
                Console.WriteLine("Order confirmation 54445454");
            }
            else
            {
                Console.WriteLine("something went wrong");
            }
        }

        internal static void GetAuthors()
        {
            Console.WriteLine("[Get Authors]");
            var input = Helper.InputUser.GetCategories();
            var books = WebbShopAPI.WebbShopApi.GetAuthors(input);
            if (books != null)
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title} {book.Author}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        internal static void GetBooks()
        {
            Console.WriteLine("[Get Book]");
            var input = Helper.InputUser.GetCategories();
            var books = WebbShopAPI.WebbShopApi.GetBooks(input);
            if (books != null)
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title} {book.Author}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        internal static void GetAvaliableBooks()
        {
            var input = Helper.InputUser.GetAvaliableBooks();
            var books = WebbShopAPI.WebbShopApi.GetAvailableBooks(input);
            if (books != null)
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title} Qty: {book.Quantity}");
                }
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}