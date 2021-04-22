using System;

namespace Inlämning2.Views
{
    public static class Error
    {
        /// <summary>
        /// Utskrift av felmeddelande om okänt fel.
        /// </summary>
        public static void ErrorUnknown()
        {
            Console.WriteLine("Nåt gick galet!");
        }

        /// <summary>
        /// Felmeddelandet om man inte är administratör.
        /// </summary>
        public static void NotAdmin()
        {
            Console.WriteLine("Du saknar administrativ rättighet.");
        }
    }
}
