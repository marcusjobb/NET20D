using System;
using System.Collections.Generic;
using System.Text;

namespace WebshopFrontend.Helpers
{
    class WrongInput
    {
        /// <summary>
        /// Method that keeps the error message from all wrong inputs
        /// </summary>
        public static void InputErrorMessage()
        {
            Console.Clear();
            CenterText.PrintLinesInCenter(
            "╔══════════════════════════════════════════╗",
            "║      An unexpected value was entered     ║",
            "║       ──────────────╬──────────────      ║",
            "║            Please try  again             ║",
            "╚══════════════════════════════════════════╝");
        }

    }
}
