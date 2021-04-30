using System.ComponentModel.DataAnnotations;

namespace WebbShopAPI.Models
{
    public class BookCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
