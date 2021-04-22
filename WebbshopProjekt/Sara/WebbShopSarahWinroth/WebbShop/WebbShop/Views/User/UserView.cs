using System;
using System.Collections.Generic;
using System.Text;

namespace WebbShop.Views.User
{
    public static class UserView
    {
        /// <summary>
        /// Visar information/rubtik till användaren.
        /// </summary>
        public static void AllCategories()
        {
            Console.WriteLine("[ALLA KATEGORIER]\n");
        }

        /// <summary>
        /// Visar information/feedbakc till användaren.
        /// </summary>
        public static string BuyBook()
        {
            Console.WriteLine("\nTryck [ENTER] för att slutföra köpet eller [Q] för att gå tillbaka.");
            string input = Console.ReadLine();
            return input;
        }

        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är namnet på den kategori som användaren söker tillgängliga böcker ifrån</returns>
        public static string GetAllAvailableBooks()
        {
            Console.WriteLine("[HÄMTA TILLGÄNGLIGA BÖCKER EFTER KATEGORI]\n");
            Console.WriteLine("Sök på kategori nedan:");
            Console.Write("> ");
            string input = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("[ALLA TILLGÄNGLIGA BÖCKER I KATEGORI]\n");
            return input;
        }

        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är titeln på den bok som användaren vill köpa</returns>
        public static string GetBookToBuy()
        {
            Console.WriteLine("[VILKEN BOK VILL DU KÖPA?]\n");
            Console.WriteLine("Ange titeln på boken du vill köpa:");
            Console.Write("> ");
            string title = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("[BOKEN SOM MATCHAR DIN SÖKNING]\n");
            return title;
        }

        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är titeln på den bok som användaren vill se information om</returns>
        public static string GetInfoAboutBook()
        {
            Console.WriteLine("[SÖK EFTER EN BOK]\n");
            Console.WriteLine("Ange titeln på boken du söker:");
            Console.Write("> ");
            string title = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("[BOKEN SOM MATCHAR DIN SÖKNING]\n");
            return title;
        }

        /// <summary>
        /// Skriver ut Bokmenyn och alla valmöljligheter. Tar emot inmatning/valet från användaren.
        /// </summary>
        /// <returns>Returnerar användarens menyval.</returns>
        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine("[MENY]");
            Console.WriteLine("1. Lista alla kategorier");
            Console.WriteLine("2. Sök efter kategori");
            Console.WriteLine("3. Lista böcker från en kategori");
            Console.WriteLine("4. Lista alla tillgängliga böcker");
            Console.WriteLine("5. Hämta information om en bok");
            Console.WriteLine("6. Sök efter böcker");
            Console.WriteLine("7. Sök böcker efter författare");
            Console.WriteLine("8. Köp bok");
            Console.WriteLine("9. Ping - Uppdatera sidan");
            Console.WriteLine("0. Logga ut");
            Console.Write("> ");
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som sökningen av böcker skall utgå ifrån</returns>
        public static string SearchBooks()
        {
            Console.WriteLine("[SÖK EFTER BÖCKER]\n");
            Console.WriteLine("Gör din sökning nedan:");
            Console.Write("> ");
            string input = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("[ALLA BÖCKER MATCHANDE DIN SÖKNING]\n");
            return input;
        }

        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är namnet på författaren av de böcker användaren söker efter</returns>
        public static string SearchBooksByAuthor()
        {
            Console.WriteLine("[SÖK BÖCKER EFTER FÖRFATTARE]\n");
            Console.WriteLine("Gör din sökning nedan:");
            Console.Write("> ");
            string author = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("[ALLA BÖCKER MATCHANDE DIN SÖKNING]\n");
            return author;
        }

        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är namnet på den kategori som användaren söker böcker ifrån</returns>
        public static string SearchBooksByCategory()
        {
            Console.WriteLine("[SÖK BÖCKER EFTER KATEGORI]\n");
            Console.WriteLine("Gör din sökning nedan:");
            Console.Write("> ");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("[ALLA BÖCKER MATCHANDE DIN SÖKNING]\n");
            return name;
        }

        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är namnet på den kategori som användaren söker efter</returns>
        public static string SearchCategory()
        {
            Console.WriteLine("[SÖK KATEGORI]\n");
            Console.WriteLine("Gör din sökning nedan:");
            Console.Write("> ");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("[ALLA KATEGORIER MATCHANDE DIN SÖKNING]\n");
            return name;
        }
    }
}
