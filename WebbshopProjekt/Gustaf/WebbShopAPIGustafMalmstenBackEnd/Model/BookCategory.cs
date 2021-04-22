using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopAPIGustafMalmsten.Model
{
    /// <summary>
    /// Represents a category/genre of books, e.g. 'Horror', 'Romance'
    /// </summary>
    public class BookCategory
    {
        [Key]
        public int BookCategoryID { get; set; }
        public string BookCategoryName { get; set; }
    }
}
