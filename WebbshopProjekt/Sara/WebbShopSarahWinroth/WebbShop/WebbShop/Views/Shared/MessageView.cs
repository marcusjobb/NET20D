using System;

namespace WebbShop.Views.Shared
{
    public static class MessageView
    {
        /// <summary>
        /// Visar information/feedback till användaren att användaren inte är aktiverad.
        /// </summary>
        public static void ActivateUserFailed()
        {
            Console.WriteLine("Något gick fel och användaren är INTE aktiverad!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att användaren är aktiverad.
        /// </summary>
        public static void ActivateUserSucceeded()
        {
            Console.WriteLine("Användaren är aktiverad!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att boken inte är tillagd.
        /// </summary>
        public static void AddBookFailed()
        {
            Console.WriteLine("Något gick fel och boken är INTE tillagd!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att boken är tillagd.
        /// </summary>
        public static void AddBookSucceeded()
        {
            Console.WriteLine("Boken är tillagd!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att kategorin inte är tillagd.
        /// </summary>
        public static void AddCategoryFailed()
        {
            Console.WriteLine("Något gick fel och kategorin är INTE tillagd!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att kategorin är tillagd.
        /// </summary>
        public static void AddCategorySucceeded()
        {
            Console.WriteLine("Kategorin är tillagd!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att användaren inte är tillagd.
        /// </summary>
        public static void AddUserFailed()
        {
            Console.WriteLine("Något gick fel och användaren är INTE tillagd!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att användarene är tillagd.
        /// </summary>
        public static void AddUserSucceeded()
        {
            Console.WriteLine("Användaren är tillagd!");
        }
        /// <summary>
        /// Visar information/feedback till användaren om att trycka enter för att återgå till menyn.
        /// </summary>
        public static void BackToMenu()
        {
            Console.WriteLine("\nTryck [ENTER] för att gå tillbaka till menyn");
            Console.ReadLine();
        }
        /// <summary>
        /// Visar information/feedback till användaren att boken inte är borttagen.
        /// </summary>
        public static void BookDeleteFailed()
        {
            Console.WriteLine("Något gick fel och boken är INTE borttagen!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att boken är borttagen.
        /// </summary>
        public static void BookDeleteSucceeded()
        {
            Console.WriteLine("Boken är borttagen!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att boken eller kategorin inte finns.
        /// </summary>
        public static void BookOrCategoryDontExist()
        {
            Console.WriteLine("Kategorin eller boken finns inte.");
        }
        /// <summary>
        /// Visar information/feedback till användaren att ingen bok finns som matchar sökkriterierna.
        /// </summary>
        public static void BookSearchFailed()
        {
            Console.WriteLine("Ingen bok matchade din sökning..");
        }
        /// <summary>
        /// Visar information/feedback till användaren att boken inte är uppdaterad.
        /// </summary>
        public static void BookUpdateFailed()
        {
            Console.WriteLine("Något gick fel och boken kunde INTE redigeras.");
        }
        /// <summary>
        /// Visar information/feedback till användaren att boken är uppdaterad.
        /// </summary>
        public static void BookUpdateSucceeded()
        {
            Console.WriteLine("Boken är redigerad och sparad!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att kategorin inte är borttagen.
        /// </summary>
        public static void CategoryDeleteFailed()
        {
            Console.WriteLine("Något gick fel och kategorin är INTE borttagen!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att boken är borttagen.
        /// </summary>
        public static void CategoryDeleteSucceeded()
        {
            Console.WriteLine("Kategorin är borttagen!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att ingen kategori finns som matchar sökkriterierna.
        /// </summary>
        public static void CategorySearchFailed()
        {
            Console.WriteLine("Ingen kategori matchade din sökning..");
        }
        /// <summary>
        /// Visar information/feedback till användaren att kategorin inte är uppdaterad.
        /// </summary>
        public static void CategoryUpdateFailed()
        {
            Console.WriteLine("Något gick fel och kategorin kunde INTE redigeras.");
        }
        /// <summary>
        /// Visar information/feedback till användaren att kategorin är uppdaterad.
        /// </summary>
        public static void CategoryUpdateSucceeded()
        {
            Console.WriteLine("Kategorin är redigerad och sparad!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att anslutningen (sessionTimer) har uppdaterats.
        /// </summary>
        public static void ConnectionReset(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine("Du är fortfarande ansluten och sidan har uppdaterats.");
        }
        /// <summary>
        /// Visar information/feedback till användaren att användaren inte är nedgraderad.
        /// </summary>
        public static void DemoteUserFailed()
        {
            Console.WriteLine("Något gick fel och användaren är INTE nedgraderad!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att användaren är nedgraderad.
        /// </summary>
        public static void DemoteUserSucceeded()
        {
            Console.WriteLine("Användaren är nedgraderad!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att ingen information har hittats eller något gått fel.
        /// </summary>
        public static void GetBestCustomerFailed()
        {
            Console.WriteLine("Det finns ingen som köpt böcker eller så har något gått fel.. ");
        }
        /// <summary>
        /// Visar information/feedback till användaren att ingen sålda böcker har hittats eller något gått fel.
        /// </summary>
        public static void GetMoneyEarnedFailed()
        {
            Console.WriteLine("Något gick fel, alternativt det finns inga sålda böcker.");
        }
        /// <summary>
        /// Visar information/feedback till användaren att användaren inte är inaktiverad.
        /// </summary>
        public static void InactivateUserFailed()
        {
            Console.WriteLine("Något gick fel och användaren är INTE inaktiverad!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att användaren är inaktiverad.
        /// </summary>
        public static void InactivateUserSucceeded()
        {
            Console.WriteLine("Användaren är inaktiverad!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att användaren inte är uppgraderad.
        /// </summary>
        public static void PromoteUserFailed()
        {
            Console.WriteLine("Något gick fel och användaren är INTE uppgraderad!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att användaren är uppgraderad.
        /// </summary>
        public static void PromoteUserSucceeded()
        {
            Console.WriteLine("Användaren är uppgraderad!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att köpet inte är genomfört.
        /// </summary>
        public static void PurchaseFailed()
        {
            Console.WriteLine("Köpet INTE genomfört!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att köpet är genomfört.
        /// </summary>
        public static void PurchaseSucceeded()
        {
            Console.WriteLine("Köpet genomfört!");
        }
        /// <summary>
        /// Visar information/feedback till användaren att sökningen misslyckats.
        /// </summary>
        public static void SearchFailed()
        {
            Console.WriteLine("Sökningen misslyckades, inga kriterier matchade din sökning..");
        }
        /// <summary>
        /// Visar information/feedback till användaren att användaren varit inaktiv i mer än 15 min och därmed utloggad.
        /// </summary>
        public static void TimedOut()
        {
            Console.WriteLine("Du har varit inaktiv i mer än 15 min och har blivit utloggad.");
            Console.WriteLine("\nTryck [ENTER] för att logga in igen.");
            Console.ReadLine();
        }
        /// <summary>
        /// Visar information/feedback till användaren att användaren gjort fel inmatning.
        /// </summary>
        public static void WrongInput()
        {
            Console.WriteLine("Fel inmatning, vänligen försök igen.");
            Console.WriteLine("\nTryck [ENTER] för att fortsätta");
            Console.ReadLine();
        }
    }
}