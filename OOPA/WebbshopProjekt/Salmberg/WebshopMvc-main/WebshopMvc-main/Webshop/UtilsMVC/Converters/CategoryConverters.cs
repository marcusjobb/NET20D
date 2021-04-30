using System.Collections.Generic;
using WebshopAPI.Models;

namespace WebshopMVC.UtilsMVC.Converters
{
    /// <summary>
    /// Class for converting List of BookCategory objects to List of List of base class objects.
    /// </summary>
    internal class CategoryConverters
    {
        /// <summary>
        /// Converts List of BookCategory objects to List of List of base class objects.
        /// </summary>
        /// <param name="categoryList"></param>
        /// <returns>List of List of base class objects</returns>
        public static List<List<object>> CategoryConverter(List<BookCategory> categoryList)
        {
            List<List<object>> categoryListData = new List<List<object>>();
            foreach (var item in categoryList)
            {
                categoryListData.Add(new List<object> { item.Id, item.Name });
            }
            return categoryListData;
        }
    }
}