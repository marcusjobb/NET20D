using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebbShopApi.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Skriver ut namnet på kategorin. 
        /// </summary>
        /// <returns>Returnerar en sträng med namnet på kategorin</returns>
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
