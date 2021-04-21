using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.Model;
using WebbShopAPI;

namespace WebbShop.Controller
{
    static class CategoryController
    {
        /// <summary>
        /// Displays all categories
        /// </summary>
        /// <returns></returns>
        public static string ShowAllCategories()
        {
            List<BookCategory> categories = WebbShopAPIClass.GetCategories();
            string list = "";
            foreach (BookCategory b in categories)
            {
                list += b.Name + "\n";
            }
            if (list.Length > 0)
                return LeeUtils.Txt.ShowList + list;
            return LeeUtils.Txt.Nothing;
        }

        /// <summary>
        /// Searches for a category by keyword
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string FindCategory(string name)
        {
            List<BookCategory> categories = WebbShopAPIClass.GetCategories(name);
            string list = "";
            foreach (BookCategory b in categories)
            {
                list += b.Name + "\n";
            }
            if (list.Length > 0)
                return LeeUtils.Txt.ShowList + list;
            return LeeUtils.Txt.Nothing;
        }
    }
}
