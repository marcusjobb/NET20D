using System.ComponentModel.DataAnnotations;

namespace WebbShopIvoNazlic.Models
{
    /// <remarks>
    /// Categories table
    /// </remarks>
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"Category: {Name} (id: {Id})";
        }

    }
}
