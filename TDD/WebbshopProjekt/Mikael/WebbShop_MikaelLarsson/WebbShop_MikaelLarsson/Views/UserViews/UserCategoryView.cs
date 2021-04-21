namespace WebbShop_MikaelLarsson.Views.UserView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Inlamn2WebbShop_MLarsson;
    using Inlamn2WebbShop_MLarsson.Models;
    /// <summary>
    /// Klass för att skriva ut category-relaterad text.
    /// </summary>
    internal static class UserCategoryView
    {
        /// <summary>
        /// Listar alla kategorier i en kategorilista
        /// </summary>
        /// <param name="categories"></param>
        public static void ListCategories(List<Category> categories)
        {
            try
            {
                if (categories != null)
                {
                    Console.WriteLine("\nCATEGORIES: ");
                    foreach (var cat in categories.OrderBy(o => o.Id))
                    {
                        Console.WriteLine($"{cat.Id} - {cat.Name}");
                    }
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
            Console.WriteLine();
        }

        /// <summary>
        /// Listar alla böcker i en kategori.
        /// </summary>
        /// <param name="books"></param>
        public static void ListCategory(List<Book> books)
        {
            try
            {
                if (books != null)
                {
                    Console.WriteLine("\nBOOKS IN CATEGORY: ");
                    foreach (var book in books.OrderBy(o => o.Id))
                    {
                        Console.WriteLine($"{book.Id} - {book.Title}");
                    }
                    UserBookView.KnowMore(books);
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
        /// Input för att söka efter en kategori.
        /// </summary>
        /// <returns>input från användare</returns>
        public static string SearchCategory()
        {
            Console.Write("Enter one or many letters to find a matching category:  ");
            return Console.ReadLine();
        }
        /// <summary>
        /// Hämtar alla kategorier och ber användaren att välja en av dem.
        /// </summary>
        /// <returns>categoryId</returns>
        internal static int GetCategoryId()
        {
            UserCategoryView.ListCategories(WebbShopAPI.GetCategories());
            Console.WriteLine("Enter number to see all books in category");
            int.TryParse(Console.ReadLine(), out int choice);
            return choice;
        }
    }
}
