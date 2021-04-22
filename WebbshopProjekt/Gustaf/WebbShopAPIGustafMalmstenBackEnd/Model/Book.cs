using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopAPIGustafMalmsten.Model
{
    /// <summary>
    /// Represents a book object in the online bookshop
    /// </summary>
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

        public int BookCategoryID { get; set; }
        public BookCategory BookCategory { get; set; }
    }
}
