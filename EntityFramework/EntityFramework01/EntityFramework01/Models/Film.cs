// ----------------------------------------------------------------------
// Awesome code by Marcus Medina (for educational purposes)
// © 2021, Codic Education, http://codic.se
// ----------------------------------------------------------------------
namespace EntityFramework01.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>Definition of <see cref="Film" />.</summary>
    internal class Film
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string TitelEng { get; set; }
        public string TitelSwe { get; set; }
        public int Betyg { get; set; }

        public override string ToString()
        {
            return $"Film:{TitelEng} ({Betyg})";
        }
    }
}
