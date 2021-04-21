using System.ComponentModel.DataAnnotations;

namespace WebshopApi.Models
{
    /// <summary>
    /// Klasse som är modell till Category
    /// </summary>
    public class Category
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
    }
}