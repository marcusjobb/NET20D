using System.ComponentModel.DataAnnotations;

namespace WebbShopAPI.Models
{
    /// <summary>
    /// Denna klassen jobbar mot dbo.Books tabellen i databasen.
    /// </summary>
    public class Book
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int CategoryID { get; set; }
    }
}