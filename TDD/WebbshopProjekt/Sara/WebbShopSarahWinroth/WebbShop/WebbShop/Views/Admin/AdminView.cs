using System;

namespace WebbShop.Views.Admin
{
    public static class AdminView
    {
        /// <summary>
        /// Visar information till användaren och tar emot inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är namnet på den användare som skall aktiveras</returns>
        public static string ActivateUser()
        {
            Console.WriteLine("[AKTIVERA ANVÄNDARE]\n");
            Console.WriteLine("Vilken användare vill du aktivera?");
            Console.Write("Användarnamn: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nTryck [ENTER] för att aktivera användaren.");
            Console.ReadLine();
            return name;
        }
        /// <summary>
        /// Visar information till användaren och tar emot inmatning från användaren som sparas i variabler. Ett Book-objekt skapas och värdena i variablarna ges till tillhörande klassmedlem för enklare hantering.
        /// </summary>
        /// <returns>Returnerar ett Book-objekt</returns>
        public static WebbShopApi.Models.Book AddBook()
        {
            Console.WriteLine("[LÄGG TILL EN BOK]\n");
            Console.Write("Titel: ");
            string title = Console.ReadLine();
            Console.Write("Författare: ");
            string author = Console.ReadLine();
            Console.Write("Pris: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Antalet böcker som läggs till: ");
            int amount = Convert.ToInt32(Console.ReadLine());
            var book = new WebbShopApi.Models.Book();
            book.Title = title;
            book.Author = author;
            book.Price = price;
            book.Amount = amount;
            Console.WriteLine("\nTryck [ENTER] för att lägga till boken.");
            Console.ReadLine();
            return book;
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är namnet på den kategori som skall läggas till</returns>
        public static string AddCategory()
        {
            Console.WriteLine("[LÄGG TILL EN KATEGORI]\n");
            Console.Write("Namn: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nTryck [ENTER] för att lägga till kategorin.");
            Console.ReadLine();
            return name;
        }
        /// <summary>
        /// Visar information till användaren och tar emot inmatning från användaren som sparas i variabler. Ett User-objekt skapas och värdena i variablarna ges till tillhörande klassmedlem för enklare hantering.
        /// </summary>
        /// <returns>Returnerar ett User-objekt</returns>
        public static WebbShopApi.Models.User AddUser()
        {
            Console.WriteLine("[LÄGG TILL EN ANVÄNDARE]\n");
            Console.Write("Användarnamn: ");
            string name = Console.ReadLine();
            Console.Write("Lösenord: ");
            string password = Console.ReadLine();
            var user = new WebbShopApi.Models.User();
            user.Name = name;
            user.Password = password;
            Console.WriteLine("\nTryck [ENTER] för att lägga till användaren.");
            Console.ReadLine();
            return user;
        }
        /// <summary>
        /// Visar information till användaren om vilken anändare som köpt flest böcker.
        /// </summary>
        /// /// <param name="user">Namnet på användaren</param>
        public static void BestCostumer(string user)
        {
            Console.WriteLine($"{user} har köpt flest böcker");
        }
        /// <summary>
        /// Skriver ut Bokmenyn och alla valmöljligheter. Tar emot inmatning/valet från användaren.
        /// </summary>
        /// <returns>Returnerar användarens menyval.</returns>
        public static int BookMenu()
        {
            Console.Clear();
            Console.WriteLine("[HANTERA BÖCKER]");
            Console.WriteLine("1. Hämta information om en bok");
            Console.WriteLine("2. Sök efter böcker");
            Console.WriteLine("3. Sök böcker efter författare");
            Console.WriteLine("4. Lista alla tillgängliga böcker");
            Console.WriteLine("5. Lista böcker från en kategori");
            Console.WriteLine("6. Lägg till en bok");
            Console.WriteLine("7. Uppdatera en bok");
            Console.WriteLine("8. Radera en bok");
            Console.WriteLine("9. Ge en bok en kategori");
            Console.WriteLine("10. Lägg till antalet av en bok");
            Console.WriteLine("11. Sålda böcker");
            Console.WriteLine("12. Vinst av försäljning");
            Console.WriteLine("0. Tillbaka till huvudmenyn");
            Console.Write("> ");
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }
        /// <summary>
        /// Skriver ut Kategorimenyn och alla valmöljligheter. Tar emot inmatning/valet från användaren.
        /// </summary>
        /// <returns>Returnerar användarens menyval.</returns>
        public static int CategoryMenu()
        {
            Console.Clear();
            Console.WriteLine("[HANTERA KATEGORIER]");
            Console.WriteLine("1. Sök efter kategori");
            Console.WriteLine("2. Lista alla kategorier");
            Console.WriteLine("3. Lägg till en kategori");
            Console.WriteLine("4. Uppdatera kategori");
            Console.WriteLine("5. Radera kategori");
            Console.WriteLine("0. Tillbaka till huvudmenyn");
            Console.Write("> ");
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är titeln på den bok som skall tas bort</returns>
        public static string DeleteBook()
        {
            Console.WriteLine("\nTryck [ENTER] för att RADERA boken eller [Q] för att gå tillbaka.");
            string title = Console.ReadLine();
            return title;
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är namnet på den kategori som skall tas bort</returns>
        public static string DeleteCategory()
        {
            Console.WriteLine("\nTryck [ENTER] för att RADERA kategorin eller [Q] för att gå tillbaka.");
            string name = Console.ReadLine();
            return name;
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är namnet på den användare som skall nedgraderas</returns>
        public static string DemoteUser()
        {
            Console.WriteLine("[NEDGRADERA ANVÄNDARE]\n");
            Console.WriteLine("Vilken användare vill du ta bort administratörsåtkomst?");
            Console.Write("Användarnamn: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nTryck [ENTER] för att nedgradera användaren.");
            Console.ReadLine();
            return name;
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som sökningen utgår ifrån</returns>
        public static string FindUser()
        {
            Console.WriteLine("[SÖK EFTER ANVÄNDARE]\n");
            Console.WriteLine("Sök på användare nedan:");
            Console.Write("> ");
            string user = Console.ReadLine();
            Console.WriteLine();
            return user;
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är titeln på den bok som skall tilldelas en kategori</returns>
        public static string GetBookToAddCategory()
        {
            Console.WriteLine("[GE EN BOK EN KATEGORI]\n");
            Console.Write("Titel på boken: ");
            string title = Console.ReadLine();
            return title;
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är titeln på den bok som skall tas bort</returns>
        public static string GetBookToDelete()
        {
            Console.WriteLine("[RADERA EN BOK]\n");
            Console.WriteLine("Ange titeln på boken du vill radera:");
            Console.Write("> ");
            string title = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("[BOKEN SOM MATCHAR DIN SÖKNING]\n");
            return title;
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är titeln på den bok som skall tilldelas mer antal av</returns>
        public static string GetBookToSetAmount()
        {
            Console.WriteLine("[ANGE VILKET ANTAL SOM FINNS AV EN BOK]\n");
            Console.WriteLine("Ange titeln på boken du vill ange antalet för:");
            Console.Write("> ");
            string title = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("[BOKEN SOM MATCHAR DIN SÖKNING]\n");
            return title;
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är titeln på den bok som skall uppdateras</returns>
        public static string GetBookToUpdate()
        {
            Console.WriteLine("[REDIGERA EN BOK]\n");
            Console.Write("Skriv in titeln på boken du vill redigera: ");
            string title = Console.ReadLine();
            return title;
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är namnet på den kategori som skall tilldelas en bok</returns>
        public static string GetCategoryToAddToBook()
        {
            Console.Write("Kategorin som ska läggas till: ");
            string category = Console.ReadLine();
            Console.WriteLine("\nTryck [ENTER] för att lägga till kategorin.");
            Console.ReadLine();
            return category;
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är namnet på den kategori som skall tas bort</returns>
        public static string GetCategoryToDelete()
        {
            Console.WriteLine("[RADERA EN KATEGORI]\n");
            Console.WriteLine("Ange namnet på kategorin du vill radera:");
            Console.Write("> ");
            string input = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("[KATEGORIN SOM MATCHAR DIN SÖKNING]\n");
            return input;
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är namnet på den kategori som skall uppdateras</returns>
        public static string GetCategoryToUpdate()
        {
            Console.WriteLine("[REDIGERA EN KATEGORI]\n");
            Console.Write("Namn på kategorin: ");
            string name = Console.ReadLine();
            return name;
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är namnet på den användare som skall inaktiveras (sätter IsActive = false)</returns>
        public static string InactivateUser()
        {
            Console.WriteLine("[INAKTIVERA ANVÄNDARE ]\n");
            Console.WriteLine("Vilken användare vill du inaktivera?");
            Console.Write("Användarnamn: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nTryck [ENTER] för att inaktivera användaren.");
            Console.ReadLine();
            return name;
        }
        /// <summary>
        /// Visar information/rubrik till användaren.
        /// </summary>
        public static void ListAllSoldBooks()
        {
            Console.WriteLine("[LISTA ALLA SÅLDA BÖCKER]\n");
        }
        /// <summary>
        /// Visar information/rubrik till användaren.
        /// </summary>
        public static void ListAllUsers()
        {
            Console.WriteLine("[LISTA ALLA ANVÄNDARE]\n");
        }
        /// <summary>
        /// Skriver ut Huvudmenyn och alla valmöljligheter. Tar emot inmatning/valet från användaren.
        /// </summary>
        /// <returns>Returnerar användarens menyval.</returns>
        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine("[ADMIN MENY]");
            Console.WriteLine("Välj vad du vill hantera..");
            Console.WriteLine("1. Användare");
            Console.WriteLine("2. Böcker");
            Console.WriteLine("3. Kategorier");
            Console.WriteLine("4. Ping - Uppdatera sidan");
            Console.WriteLine("0. Logga ut");
            Console.Write("> ");
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }
        /// <summary>
        /// Visar information till användaren, vinsten av allasålda böcker.
        /// </summary>
        /// <param name="moneyEarned">Vinsten av alla sålda böcker</param>
        public static void MoneyEarned(int moneyEarned)
        {
            Console.WriteLine($"Intjänade pengar: {moneyEarned}kr");
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är namnet på den användare som skall uppgraderas (sätter IsAdmin = true)</returns>
        public static string PromoteUser()
        {
            Console.WriteLine("[UPPGRADERA ANVÄNDARE]\n");
            Console.WriteLine("Vem vill du uppgradera till administratör?");
            Console.Write("Användarnamn: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nTryck [ENTER] för att uppgradera användaren.");
            Console.ReadLine();
            return name;
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är det antal som skall tilldelas en boks Amount</returns>
        public static int SetAmountOfBook()
        {
            Console.WriteLine("\nAnge antalet böcker som finns tillgängliga av denna bok:");
            Console.Write("> ");
            int newAmount = Convert.ToInt32(Console.ReadLine());
            return newAmount;
        }
        /// <summary>
        /// Visar information/rubrik till användaren.
        /// </summary>
        public static void ShowBestCostumer()
        {
            Console.Clear();
            Console.WriteLine("[ANVÄNDARE SOM KÖPT FLEST BÖCKER]\n");
        }
        /// <summary>
        /// Visar information/rubrik till användaren.
        /// </summary>
        public static void ShowMoneyEarned()
        {
            Console.Clear();
            Console.WriteLine("[VINST EFTER FÖRSÄLJNING]");
        }
        /// <summary>
        /// Visar information till användaren och tar emot inmatning från användaren som sparas i variabler. Ett Book-objekt skapas och värdena i variablarna ges till tillhörande klassmedlem för enklare hantering.
        /// </summary>
        /// <returns>Returnerar ett Book-objekt</returns>
        public static WebbShopApi.Models.Book UpdateBook()
        {
            Console.WriteLine("\nFyll i nedan de uppgifter som nu stämmer med boken:\n");
            Console.Write("Titel: ");
            string title = Console.ReadLine();
            Console.Write("Författare: ");
            string author = Console.ReadLine();
            Console.Write("Pris: ");
            int price = Convert.ToInt32(Console.ReadLine());
            var book = new WebbShopApi.Models.Book();
            book.Title = title;
            book.Author = author;
            book.Price = price;
            return book;
        }
        /// <summary>
        /// Visar information till användaren och tar emot en inmatning från användaren.
        /// </summary>
        /// <returns>Returnerar användarens inmatning som är det nya namnet på den kategori som uppdateras</returns>
        public static string UpdateCategory()
        {
            Console.Write("\nNya namnet på kategorin: ");
            string newName = Console.ReadLine();
            return newName;
        }
        /// <summary>
        /// Skriver ut Användaremenyn och alla valmöljligheter. Tar emot inmatning/valet från användaren.
        /// </summary>
        /// <returns>Returnerar användarens menyval.</returns>
        public static int UserMenu()
        {
            Console.Clear();
            Console.WriteLine("[HANTERA ANVÄNDARE]");
            Console.WriteLine("1. Lista alla användare");
            Console.WriteLine("2. Sök efter användare");
            Console.WriteLine("3. Lägg till användare");
            Console.WriteLine("4. Uppgradera användare");
            Console.WriteLine("5. Nedgradera användare");
            Console.WriteLine("6. Aktivera användare");
            Console.WriteLine("7. Inaktivera användare");
            Console.WriteLine("8. Hämta användaren som köpt flest böcker");
            Console.WriteLine("0. Tillbaka till huvudmenyn");
            Console.Write("> ");
            int input = Convert.ToInt32(Console.ReadLine());
            return input;
        }
    }
}