namespace WebbShop_MikaelLarsson.Views
{
    using System;

    /// <summary>
    /// Klass för att hantera enklare utskrifter.
    /// </summary>
  internal static class MessageView
    {
        /// <summary>
        /// Text när ett object är null
        /// </summary>
        public static void Error()
        {
            Console.Write("No item was found...");
        }

        /// <summary>
        /// Console.ReadLine() för att skapa liten paus i menyerna.
        /// </summary>
        internal static void PressEnter()
        {
            Console.WriteLine();
            Console.WriteLine("[Please press enter]");
            Console.ReadLine();
        }

        /// <summary>
        /// Try/Catch-meddelande
        /// </summary>
        internal static void SomethingWentWrong()
        {
            Console.WriteLine("Something went wrong, please try again.");
        }
        /// <summary>
        /// Text då inloggad ej är admin.
        /// </summary>
        internal static void NotAdmin()
        {
            Console.WriteLine("You are not an administrator.\nPlease login with an administrator account.");
        }
    }
}
