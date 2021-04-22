using System.Collections.Generic;
using WebshopAPI.Models;

namespace WebshopMVC.UtilsMVC.Converters
{
    /// <summary>
    /// Class for converting List of SoldBook objects to List of List of base class objects.
    /// </summary>
    public class SoldBooksConverters
    {
        /// <summary>
        /// Converts List of SoldBook objects to List of List of base class objects.
        /// </summary>
        /// <param name="soldBooksList"></param>
        /// <returns>List of List of base class objects</returns>
        public static List<List<object>> SoldBooksConverter(List<SoldBook> soldBooksList)
        {
            List<List<object>> soldBooksListData = new List<List<object>>();
            foreach (var item in soldBooksList)
            {
                soldBooksListData.Add(new List<object> { item.Id, item.Title, item.Author, item.Price, item.CategoryId });
            }
            return soldBooksListData;
        }
    }
}