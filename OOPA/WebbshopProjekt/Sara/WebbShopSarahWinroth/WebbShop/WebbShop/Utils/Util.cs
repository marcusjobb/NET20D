using System.Collections.Generic;
using WebbShop.Views.Shared;

namespace WebbShop.Utils
{
    /// <summary>
    /// En hjälpklass som skriver ut listor av olika typer.
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Loopar igenom en lista och skriver ut objekt av typen Category.
        /// </summary>
        /// <param name="list">Lista av typen Category</param>
        public static void PrintList(List<WebbShopApi.Models.Category> list)
        {
            if (list == null)
            { MessageView.SearchFailed(); }
            else
            {
                foreach (var i in list)
                {
                    if (i != null)
                    {
                        PrintView.CategoryItem(i.ToString());
                    }
                }
            }
        }
        /// <summary>
        /// Loopar igenom en lista och skriver ut objekt av typen Book
        /// </summary>
        /// <param name="list">Lista av typen Book</param>
        public static void PrintList(List<WebbShopApi.Models.Book> list)
        {
            if (list == null)
            { MessageView.SearchFailed(); }
            else
            {
                foreach (var i in list)
                {
                    if (i != null)
                    {
                        PrintView.BookItem(i.ToString());
                    }
                }
            }
        }
        /// <summary>
        /// Loopar igenom en lista och skriver ut objekt av typen SoldBook
        /// </summary>
        /// <param name="list">Lista av typen SoldBook</param>
        public static void PrintList(List<WebbShopApi.Models.SoldBook> list)
        {
            if (list == null)
            { MessageView.SearchFailed(); }
            else
            {
                foreach (var i in list)
                {
                    if (i != null)
                    {
                        PrintView.BookItem(i.ToString());
                    }
                }
            }
        }
        /// <summary>
        /// Loopar igenom en lista och skriver ut objekt av typen User
        /// </summary>
        /// <param name="list">Lista av typen User</param>
        public static void PrintList(List<WebbShopApi.Models.User> list)
        {
            if (list == null)
            { MessageView.SearchFailed(); }
            else
            {
                foreach (var i in list)
                {
                    if (i != null)
                    {
                        PrintView.UserItem(i.ToString());
                    }
                }
            }
        }
    }
}