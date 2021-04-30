using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class SearchBookByTitle
    {
        /// <summary>
        /// View of the Search Book by Title Method
        /// </summary>
        public static void DisplayResultBook()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║     Search for books by Title     ║");
            Console.WriteLine("║ ─────────────────╬─────────────── ║");
            Console.WriteLine("║    Example, searching for 'bot'   ║");
            Console.WriteLine("║    Would display book 'I Robot'   ║");
            Console.WriteLine("╚═══════════════════════════════════╝");
            SearchBookByTitleController.DisplayResultBookLogic();
            Console.ReadKey();
        }

    }
}
