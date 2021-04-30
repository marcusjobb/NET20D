using System;
using System.Collections.Generic;
using WebshopAPI;
using WebshopMVC.UtilsMVC;
using WebshopMVC.UtilsMVC.Converters;
using WebshopMVC.Views;

namespace WebshopMVC.Controllers
{
    /// <summary>
    /// Controller class for handling Category object data
    /// </summary>
    public class CategoryController
    {
        /// <summary>
        /// Retrieves all Category objects present in database
        /// </summary>
        /// <returns>List of List of base class object</returns>
        public static List<List<object>> ListAllCategories()
        {
            Console.Clear();
            var api = new API();
            var categoryList = api.GetCategories();
            var categoryListData = CategoryConverters.CategoryConverter(categoryList);

            return CategoryView.CategoryListReader(categoryListData);
        }

        /// <summary>
        /// Retrieves all Category objects based on search term matching Category.Name 
        /// </summary>
        /// <returns>List of List of base class object</returns>
        public static List<List<object>> GetCategoriesByKeyword()
        {
            Console.Clear();
            var api = new API();
            Console.Write("Enter search term:");
            var keyword = Console.ReadLine();
            var categoryList = api.GetCategories(keyword);
            var categoryListData = CategoryConverters.CategoryConverter(categoryList);

            return CategoryView.CategoryListReader(categoryListData);
        }

        /// <summary>
        /// Retrieves Category object based on Category.Id
        /// </summary>
        /// <returns>List of List of base class object</returns>
        public static List<List<object>> GetBooksByCategoryId()
        {
            Console.Clear();
            var api = new API();
            Console.Write("Enter category Id:");
            int.TryParse(Console.ReadLine(), out int categoryId);
            var bookList = api.GetCategory(categoryId);
            var categoryListData = BookConverters.BookConverter(bookList);

            return BookView.BookListReader(categoryListData);
        }

        /// <summary>
        /// Retrieves all Book objects based on Category.Id where Book.Amount>0
        /// </summary>
        /// <returns>List of List of base class object</returns>
        public static List<List<object>> GetAvailableBooksByCategoryId()
        {
            Console.Clear();
            var api = new API();
            Console.Write("Enter category Id:");
            int.TryParse(Console.ReadLine(), out int categoryId);
            var bookList = api.GetAvailableBooks(categoryId);
            var categoryListData = BookConverters.BookConverter(bookList);

            return BookView.BookListReader(categoryListData);
        }
    }
}