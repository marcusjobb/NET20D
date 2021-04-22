using System.Collections.Generic;

namespace WebbShopAPI.Models
{
    /// <summary>
    /// Class for managing categories/genres
    /// </summary>
    public class BookCategory : Common
    {
        /// <summary>
        /// The name of the category/genre
        /// </summary>
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Name}";
        }
    }
}
