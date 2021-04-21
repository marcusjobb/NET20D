using System.ComponentModel.DataAnnotations;

namespace WebbShopInlamningsUppgift.Models
{
    /// <summary>
    /// Represents categories in database
    /// </summary>
    public class BookCategory
    {
        [Key]
        public int ID { get; set; }
        public string Genere { get; set; }
    }
}
