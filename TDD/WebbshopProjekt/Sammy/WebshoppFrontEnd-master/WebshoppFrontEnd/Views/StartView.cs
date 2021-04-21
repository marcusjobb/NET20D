
namespace WebbshopFrontEnd.Views
{
    using System;

    public static class StartView
    {
        /// <summary>
        /// Vyn för startsidan.
        /// </summary>        
        public static void StartMenu()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("*   Välkommen till vår webbshop  *");
            Console.WriteLine("**********************************\n");
            Console.WriteLine("För att utnyttja vår webbshop, måste du vara inloggad.");
            Console.WriteLine("Tryck enter för att fortsätta.");
            Console.ReadKey();
        }
    }
}
