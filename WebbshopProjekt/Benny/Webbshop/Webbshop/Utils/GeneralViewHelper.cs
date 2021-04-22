using System;
using System.Threading;

namespace Webbshop.Utils
{
    internal class GeneralViewHelper
    {
        /// <summary>
        /// Waits 2 sec and then clears screen
        /// </summary>
        internal static void WaitAndClearScreen()
        {
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
}