namespace WebbShop_MikaelLarsson.Views.UserView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Inlamn2WebbShop_MLarsson;
    using Inlamn2WebbShop_MLarsson.Models;
    using WebbShop_MikaelLarsson.Controllers;
    /// <summary>
    /// Klass för att skriva ut book-relaterad text.
    /// </summary>
    internal static class UserBookView
    {
        /// <summary>
        /// Presenterar en vald bok och dess kategori.
        /// </summary>
        /// <param name="book"></param>
        public static void ListBooks(Book book)
        {
            Console.WriteLine();
            try
            {
                if (book != null)
                {
                    if (book.Categories != null)
                    {
                        foreach (var cat in book.Categories)
                        {
                            Console.Write("Category: ");
                            Console.WriteLine($"{cat.Name} ");
                        }
                    }
                    Console.WriteLine(book);
                    BuyBook(book.Id);
                }
                else
                {
                    MessageView.Error();
                }
            }
            catch (Exception)
            {
                MessageView.SomethingWentWrong();
            }
        }

        /// <summary>
        /// Listar alla böcker i en boklista
        /// </summary>
        /// <param name="bookList"></param>
        public static void ListBooks(List<Book> books)
        {
            try
            {
                if (books != null)
                {
                    foreach (var book in books.OrderBy(o => o.Id))
                    {
                        Console.WriteLine();
                        if (book.Categories != null)
                        {
                            foreach (var cat in book.Categories)
                            {
                                Console.Write("Category: ");
                                Console.WriteLine($"{cat.Name} ");
                            }
                        }
                        Console.WriteLine($"{book.Id} - {book.Title} - {book.Author}");
                    }
                    if (books.Count > 0) KnowMore(books);
                }
                if (books == null || books.Count == 0)
                {
                    MessageView.Error();
                }
            }
            catch (Exception)
            {
                MessageView.SomethingWentWrong();
            }
        }

        /// <summary>
        /// input för att eventuellt köpa en bok.
        /// </summary>
        /// <param name="bookId"></param>
        internal static void BuyBook(int bookId)
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to buy this book?\nPress [y] to buy this book or [enter] to not buy it.");
            string choice = Console.ReadLine();
            if (choice == "y".ToLower().Trim())
            {
                WebbShopAPI.BuyBook(MenuController.user.Id, bookId);
            }
        }

        /// <summary>
        /// Metod för att välja bok att visa mer om.
        /// </summary>
        /// <param name="books"></param>
        internal static void KnowMore(List<Book> books)
        {
            if (books?.Count > 0)
            {
                Console.WriteLine();
                Console.Write("Would you like to know more about a book? \nEnter book number of choice, or leave empty: ");
                int.TryParse(Console.ReadLine(), out int choice);
                ListBooks(WebbShopAPI.GetBook(choice));
            }
        }

        /// <summary>
        /// input för att söka efter författare
        /// </summary>
        /// <returns>input</returns>
        internal static string SearchAuthor()
        {
            Console.Write("Enter one or many letters to find a matching author:  ");
            return Console.ReadLine();
        }

        /// <summary>
        /// input för att söka efter boktitel
        /// </summary>
        /// <returns>input</returns>
        internal static string SearchBook()
        {
            Console.Write("Enter one or many letters to find a matching book title:  ");
            return Console.ReadLine();
        }
    }
}
