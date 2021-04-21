using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Inlamn2WebbShop_MLarsson.Database;
using Microsoft.EntityFrameworkCore;

namespace Inlamn2WebbShop_MLarsson.Models
{
    /// <summary>
    /// Klassen representerar tabellen Book i databasen.
    /// </summary>
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public List<Category> Categories { get; set; }

        public override string ToString()
        {
           
           return $"ID: {Id}\nTitle: {Title}\nAuthor: {Author}\nPrice: {Price}\nBooks in stock: {Amount}\n";
           
        }
    }
}
