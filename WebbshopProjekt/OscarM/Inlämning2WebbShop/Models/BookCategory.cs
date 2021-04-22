using System.ComponentModel.DataAnnotations;

namespace Inlämning2WebbShop.Models
{
    public class BookCategory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// skriver ut kategori namnet.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}