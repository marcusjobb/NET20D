using System.ComponentModel.DataAnnotations;
using WebbShopAPI.Interfaces;

namespace WebbShopAPI.Models
{
    /// <summary>
    /// Book class.
    /// Containing: ID, title, author, category, price, stock.
    /// </summary>
    public class Book : ITitle, ILiterature, IBuyable, IModelable
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; } = null;
        public Category Categories { get; set; } = null;
        public int Price { get; set; } = default;
        public int Stock { get; set; } = default;
    }
}
