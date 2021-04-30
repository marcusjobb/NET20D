using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFLinq.Models
{
    public class Person
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pet> Pets { get; set; } // Äger djur
        public List<House> Home { get; set; } // Äger hus
    }
}
