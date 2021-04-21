using System.ComponentModel.DataAnnotations;

namespace WebbShopAPI.Models
{
    /// <summary>
    /// Contains Id and name of a category for books
    /// </summary>
    public class BookCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
