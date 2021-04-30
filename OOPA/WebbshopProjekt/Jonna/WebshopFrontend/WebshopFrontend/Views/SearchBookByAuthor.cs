using System;
using System.Collections.Generic;
using System.Text;
using WebshopFrontend.Controller;

namespace WebshopFrontend.Views
{
    class SearchBookByAuthor
    {
        /// <summary>
        /// View of the Search Book by Author Method
        /// </summary>
        public static void DisplayResultBook()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║        Search for books by Author          ║");
            Console.WriteLine("║  ─────────────────╬──────────────────────  ║");
            Console.WriteLine("║       Example, searching for 'king'.       ║");
            Console.WriteLine("║    Would display books by 'Stephen king'   ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            SearchBookByAuthorController.DisplayResultBookLogic();
            Console.ReadKey();
        }
    }
}
