using System;
using System.Linq;
using WebbShopEmil;
using WebbShopEmil.Models;
using WebbShopFE.Helper;
using WebbShopFE.Views;

namespace WebbShopFE.Controllers
{
    /// <summary>
    /// All the methods that are used in the shop.
    /// </summary>
    public class ShopController
    {
        private readonly WebbShopAPI api = new();

        /// <summary>
        /// Takes input from user
        /// and uses the WebbShopAPI to buy book.
        /// </summary>
        /// <param name="user"></param>
        internal void BuyBook(User user)
        {
            api.Ping(user.Id);

            var listBooks = api.GetAllAvailableBooks();
            BookView.ShowBooks(listBooks);

            InputView.ChooseBookById();
            int.TryParse(Console.ReadLine(), out int input);

            var result = api.BuyBook(user.Id, input);
            HelpMethods.SuccessOrNot(result);
        }

        /// <summary>
        /// Takes input from user
        /// and uses the WebbShopAPI to search for book by author name.
        /// </summary>
        internal void SearchForBookByAuthor()
        {
            InputView.SearchForBookByAuthor();
            var keyword = Console.ReadLine();
            var list = api.GetAuthors(keyword);
            if (list.Any())
            {
                BookView.ShowBooks(list);
            }
            else
            {
                MessageView.ItemNotFound();
            }
        }

        /// <summary>
        /// Takes input from user
        /// and uses the WebbShopAPI to search for book by title name.
        /// </summary>
        internal void SearchForBookByTitle()
        {
            InputView.SearchForBookByTitle();
            var keyword = Console.ReadLine();
            var list = api.GetBooks(keyword);
            if (list.Any())
            {
                BookView.ShowBooks(list);
            }
            else
            {
                MessageView.ItemNotFound();
            }
        }

        /// <summary>
        /// Uses WebbShopAPI to show avaliable books in category.
        /// </summary>
        internal void ShowAvaliableBooks()
        {
            var categoryList = api.GetCategories();
            CategoryView.ShowCategory(categoryList);

            int.TryParse(Console.ReadLine(), out int input);
            var list = api.GetAvailableBooks(input);
            if (list.Any())
            {
                BookView.ShowBooks(list);
            }
            else
            {
                MessageView.ItemNotFound();
            }
        }

        /// <summary>
        /// Takes input from user
        /// and uses the WebbShopAPI to show categories that matches with the keyword.
        /// </summary>
        internal void ShowCategoriesByKeyword()
        {
            InputView.SearchForCategoryByName();
            var keyword = Console.ReadLine();
            var list = api.GetCategories(keyword);
            if (list.Any())
            {
                CategoryView.ShowCategory(list);
            }
            else
            {
                MessageView.ItemNotFound();
            }
        }
    }
}