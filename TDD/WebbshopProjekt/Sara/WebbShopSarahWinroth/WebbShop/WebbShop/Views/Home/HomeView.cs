using System;

namespace WebbShop.Views.Home
{
    public static class HomeView
    {
        /// <summary>
        /// Visar användaren Hem-menyn där användaren kan välja mellan att registera sig eller Logga in.
        /// </summary>
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Välkommen till Sarah's e-handel!");
            Console.WriteLine("Registrera dig för att bli kund hos oss eller logga in om du redan har ett konto.");
            Console.WriteLine("1. Registrera");
            Console.WriteLine("2. Logga in");
            Console.Write("> ");
        }
    }
}