using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inlamningsuppgift2WebbShopAPI.Models
{
    /// <summary>
    /// Model of the Book object.
    /// This is a model of an object used within entity framework to mirror rows of books in the Books table.
    /// </summary>
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public BookCategory Category { get; set; }
    }
}
