using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopFront.Helpers
{
    class Rensaren
    {
        public static void RensaRader()
        {
            Console.SetCursorPosition(0, 6);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(new string(' ', 200));
            }
            Console.SetCursorPosition(0, 6);
        }    
    }
}
