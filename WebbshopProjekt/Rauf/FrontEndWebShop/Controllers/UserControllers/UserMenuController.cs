using MyBackend;
using System;


namespace FrontEndWebShop.Controllers.UserControllers
{
    class UserMenuController
    {
        public static void ShowUserMenu()
        {
            switch (Program.choise)
            {
                case "1":
                    {
                        var cat = WebbShopAPI.GetCategories();
                        foreach (var c in cat)
                        {
                            Console.WriteLine($"{c.Id}. {c.Name}");
                        }
                        break;
                    }
                case "2":
                    {
                        Console.Write("Search: ");
                        string keyword = Console.ReadLine();
                        var cat = WebbShopAPI.SearchCategory(keyword);
                        foreach (var c in cat)
                        {
                            Console.WriteLine($"{c.Id}. {c.Name}");
                        }
                        break;
                    }
                case "3":
                    {
                        var cat = WebbShopAPI.GetCategories();
                        foreach (var c in cat)
                        {
                            Console.WriteLine($"{c.Id}. {c.Name}");
                        }
                        Console.Write("Choise a category (id): ");
                        int catId = Convert.ToInt32(Console.ReadLine());
                        var books = WebbShopAPI.ShowBooksByCategory(catId);
                        foreach (var book in books)
                        {
                            Console.WriteLine($"{book.Id}. {book.Title} by {book.Author}. Price: {book.Price} sek");
                        }
                        break;
                    }
                case "4":
                    {
                        var cat = WebbShopAPI.GetCategories();
                        foreach (var c in cat)
                        {
                            Console.WriteLine($"{c.Id}. {c.Name}");
                        }
                        Console.Write("Choise a category (id): ");
                        int catId = Convert.ToInt32(Console.ReadLine());
                        var books = WebbShopAPI.ShowAvailableBooksByCategory(catId);
                        foreach (var book in books)
                        {
                            Console.WriteLine($"{book.Id}. {book.Title} by {book.Author}. Price: {book.Price} sek");
                        }
                        break;
                    }
                case "5":
                    {
                        var books = WebbShopAPI.GetAllBooks();
                        foreach (var b in books)
                        {
                            Console.WriteLine($"{b.Id}.{b.Title}");
                        }
                        Console.Write("Choise a book (id): ");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        var book = WebbShopAPI.GetBookById(bookId);
                        Console.WriteLine($"{book.Id}. {book.Title} by {book.Author}. Price {book.Price} sek. Available amount: {book.Amount}");
                        break;
                    }
                case "6":
                    {
                        Console.Write("Search: ");
                        string keyword = Console.ReadLine();
                        var books = WebbShopAPI.FindBookByName(keyword);
                        foreach (var b in books)
                        {
                            Console.WriteLine($"{b.Id}.{b.Title}");
                        }
                        break;
                    }
                case "7":
                    {
                        Console.Write("Search by author: ");
                        string keyword = Console.ReadLine();
                        var books = WebbShopAPI.GetAuthors(keyword);
                        foreach (var b in books)
                        {
                            Console.WriteLine($"{b.Id}.{b.Title}");
                        }
                        break;
                    }
                case "8":
                    {
                        var books = WebbShopAPI.GetAllBooks();
                        foreach (var b in books)
                        {
                            Console.WriteLine($"{b.Id}.{b.Title}");
                        }
                        Console.Write("Choise a book (id): ");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        WebbShopAPI.BuyABook(Program.userId, bookId);
                        break;
                    }
                case "q":
                    {
                        break;
                    }
            }
        }
    }
}
