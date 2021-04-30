using System;
using System.Collections.Generic;
using System.Text;

namespace WebbShop.Models
{
    public class RegistrationDetails
    {
        /// <summary>
        /// Klassen är skapad för att smidigare kunna hantera användarens uppgifter till controllern vid regitrering
        /// </summary>
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordVerify { get; set; }

        public RegistrationDetails(string name, string password, string passwordVerify)
        {
            Name = name;
            Password = password;
            PasswordVerify = passwordVerify;
        }
    }
}
