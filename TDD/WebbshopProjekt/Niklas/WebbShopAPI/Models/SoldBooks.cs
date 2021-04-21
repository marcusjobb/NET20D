using System;
using System.ComponentModel.DataAnnotations;
using WebbShopAPI.Interfaces;

namespace WebbShopAPI.Models
{
    /// <summary>
    /// Sold books.
    /// Containing: ID, title, author, category, price, bought by, purchase date.
    /// </summary>
    public class SoldBook : ITitle, ILiterature, IBuyLoggable, IModelable
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; } = null;
        public Category Categories { get; set; } = null;
        public int Price { get; set; } = default;
        public User BoughtBy { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
