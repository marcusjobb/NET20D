using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Webbutik.Models
{
    public class BookCategory
    {
        /// <summary>
        /// The id of the category.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of the category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The books with the category.
        /// </summary>
        public List<Book> Books { get; set; }

        /// <summary>
        /// The sold books with the category.
        /// </summary>
        public List<SoldBook> SoldBooks { get; set; }
    }
}
