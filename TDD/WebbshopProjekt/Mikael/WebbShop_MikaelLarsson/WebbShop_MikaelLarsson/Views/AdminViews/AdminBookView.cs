namespace WebbShop_MikaelLarsson.Views.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Inlamn2WebbShop_MLarsson.Models;
    /// <summary>
    /// Klass för att skriva ut book-relaterad text från adminmenyn
    /// </summary>
    internal static class AdminBookView
    {
        /// <summary>
        /// Input för att lägga till ny bok.
        /// </summary>
        /// <returns>string[]</returns>
        internal static string[] AddBook()
        {
            Console.WriteLine("\nADD NEW BOOK");
            Console.Write("Enter title: ");
            string title = ControlHelper.AdjustName();
            Console.Write("Enter author: ");
            string author = ControlHelper.AdjustName();
            Console.Write("Enter selling price: ");
            string price = Console.ReadLine();
            Console.Write("Enter amount of books: ");
            string amount = Console.ReadLine();
            return new string[] { title, author, price, amount };
        }

        /// <summary>
        /// Text för SetAmount().
        /// </summary>
        internal static void GetAmount()
        {
            Console.Write("Enter amount of books to add: ");
        }

        /// <summary>
        /// Adminmetod för att lista alla böcker och välja ett Id.
        /// </summary>
        /// <param name="bookList"></param>
        /// <returns>bookId</returns>
        internal static int ListBooks(List<Book> bookList)
        {
            Console.WriteLine();
            try
            {
                if (bookList != null)
                {
                    foreach (var book in bookList.OrderBy(o => o.Id))
                    {
                        Console.WriteLine($"ID-{book.Id} - {book.Title}");
                        if (book.Categories != null)
                        {
                            foreach (var cat in book.Categories)
                            {
                                Console.Write("Category: ");
                                Console.WriteLine($"{cat.Name} ");
                            }
                        }
                        Console.WriteLine();
                    }
                    if (bookList.Count > 0)
                    {
                        Console.Write("Enter ID number of book of choice:  ");
                        int.TryParse(Console.ReadLine(), out int bookId);
                        return bookId;
                    }
                }
                else
                {
                    MessageView.Error();
                }
                return 0;
            }
            catch (Exception)
            {
                MessageView.SomethingWentWrong();
                return 0;
            }
        }
        /// <summary>
        /// Input för att uppdatera bok.
        /// </summary>
        /// <returns>string[]</returns>
        internal static string[] UpdateBook()
        {
            Console.WriteLine("\nUPDATE BOOK");
            Console.WriteLine("(Leave blanc to keep same value)");
            Console.Write("Enter title: ");
            string title = ControlHelper.AdjustName();
            Console.Write("Enter author: ");
            string author = ControlHelper.AdjustName();
            Console.Write("Enter selling price: ");
            string price = Console.ReadLine();
            return new string[] { title, author, price };
        }
    }
}
