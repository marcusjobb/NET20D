using System.ComponentModel.DataAnnotations;

namespace EFLinq.Models
{
    public class Pet
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Typ { get; set; }
    }
}
