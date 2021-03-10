using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFLinq.Models
{
    public class House
    {

        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public List<Person> Tenants { get; set; } // Äger de boende 
    }
}
