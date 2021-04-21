using System.ComponentModel.DataAnnotations;


namespace Inlamning2TrialRunHE.Models
{
    public class BookCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
