using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebbShopAPI.Interfaces;

namespace WebbShopAPI.Models
{
    /// <summary>
    /// Category for books.
    /// Containing: ID, category name(title), books in category.
    /// </summary>
    public class Category : ITitle, IModelable
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public List<Book> BooksInCategory { get; set; }
    }
}
