using System;
using WebbShop.Models;

namespace WebbShop.Views.Home
{
    public static class UserAccessView
    {
        /// <summary>
        /// Visar information/feedback till användaren.
        /// </summary>
        public static void AccountCreated()
        {
            Console.WriteLine("\nHurra! Du har nu skapat ett konto hos oss.");
            Console.WriteLine("Tryck [ENTER] för att logga in");
            Console.ReadLine();
        }
        /// <summary>
        /// Visar information/feedback till användaren.
        /// </summary>
        public static void AccountRegistrationFailed()
        {
            Console.WriteLine("\nDet gick inte att skapa ett konto hos oss. \nDu kanske redan har ett konto hos oss eller missat att ange någon utav registreringsuppgifterna.");
            Console.WriteLine("Tryck [ENTER] för att gå tillbaka.");
            Console.ReadLine();
        }
        /// <summary>
        /// Visar information/feedback till användaren.
        /// </summary>
        public static void Logout()
        {
            Console.WriteLine("\nDu är nu utloggad!");
            Console.WriteLine("Tack för besöket och välkommen åter.");
            Console.ReadLine();
        }
        /// <summary>
        /// Visar information till användaren och tar emot inmatning från användaren som sparas i variabler. Ett RegistrationDetails-objekt skapas och värdena i variablarna ges till tillhörande klassmedlem för enklare hantering.
        /// </summary>
        /// <returns>Returnerar ett RegistrationDetails-objekt</returns>
        public static RegistrationDetails UserRegistration()
        {
            Console.Clear();
            Console.WriteLine("[REGISTRERA KONTO]");
            Console.WriteLine("Vänligen fyll i följande information:");
            Console.WriteLine("(Alla uppgifter måste fyllas i)");
            Console.Write("Ditt namn: ");
            string name = Console.ReadLine();
            Console.Write("Lösenord: ");
            string password = Console.ReadLine();
            Console.Write("Verifiera lösenordet: ");
            string passwordVerify = Console.ReadLine();
            var registrationDetails = new RegistrationDetails(name, password, passwordVerify);
            return registrationDetails;
        }
        /// <summary>
        /// Visar information till användaren och tar emot inmatning från användaren som sparas i variabler. Ett LoginDetails-objekt skapas och värdena i variablarna ges till tillhörande klassmedlem för enklare hantering.
        /// </summary>
        /// <returns>Returnerar ett LoginDetails-objekt</returns>
        public static LoginDetails VerifyUser()
        {
            Console.Clear();
            Console.WriteLine("[LOGGA IN]");
            Console.WriteLine("Vänligen fyll i följande information:");
            Console.Write("Användarnamn: ");
            string name = Console.ReadLine();
            Console.Write("Lösenord: ");
            string password = Console.ReadLine();
            var loginDetails = new LoginDetails(name, password);
            return loginDetails;
        }
        /// <summary>
        /// Visar information/feedback till användaren.
        /// </summary>
        public static void VerifyUserFailed()
        {
            Console.WriteLine("\nInloggning misslyckad!");
            Console.WriteLine("För att Registerar konto hos oss vänligen tryck [R].");
            Console.WriteLine("Tryck [ENTER] för att gå tillbaka och testa logga in igen.");
        }
    }
}