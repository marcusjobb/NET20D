using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebbShopApi.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int CategoryId { get; set; }
        /// <summary>
        /// Skriver ut information om objektet/boken. 
        /// </summary>
        /// <returns>Returnerar en sträng med information om boken</returns>
        public override string ToString()
        {
            return $" Titel: {Title}\n Författare: {Author}\n Pris: {Price}\n Kvar i lager: {Amount}";
        }
    }
}
