namespace WebbShop.Models
{
    public class LoginDetails
    {
        /// <summary>
        /// Klassen är skapad för att smidigare kunna hantera användarens uppgifter till controllern vid inloggning
        /// </summary>
        public string Name { get; set; }
        public string Password { get; set; }

        public LoginDetails(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}