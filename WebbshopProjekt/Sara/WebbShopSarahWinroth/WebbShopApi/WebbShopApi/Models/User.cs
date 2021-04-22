using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebbShopApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime SessionTimer { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        /// <summary>
        /// Skriver ut information om användaren. 
        /// </summary>
        /// <returns>Returnerar en sträng med information om användaren</returns>
        public override string ToString()
        {
            return $" Namn: {Name}\n Senast inloggad: {LastLogin}\n Är admin: {CheckIfAdmin(IsAdmin)}";
        }
        /// <summary>
        /// Kollar om objektets IsAdmin är true (om användaren är admin). 
        /// </summary>
        /// <returns>Returnerar en sträng, "Ja" eller "Nej"</returns>
        public string CheckIfAdmin(bool isAdmin)
        {
            if (isAdmin)
            {
                return "Ja";
            }
            return "Nej";
        }
    }
}
