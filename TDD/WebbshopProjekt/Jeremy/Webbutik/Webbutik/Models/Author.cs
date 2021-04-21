using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Webbutik.Models
{
    public class Author
    {
        /// <summary>
        /// The id of the author.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of the author.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The books of the author.
        /// </summary>
        public List<Book> Books { get; set; }

        /// <summary>
        /// The sold books of the author.
        /// </summary>
        public List<SoldBook> SoldBooks { get; set; }
    }
}
