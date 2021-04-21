using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WebShopFrontend.View
{
    public class Messages
    {
        public void ErrorMessage()
        {

        }

        public static void WrongInput()
        {
            Console.WriteLine("Fel input, försök igen");
            Console.WriteLine("Du skickas tillbaka till menyn.");
            Thread.Sleep(2000);
        }

        public static void DoesNotExist()
        {
            Console.WriteLine("Det du söker efter finns inte");
            Console.WriteLine("Du skickas tillbaka till menyn.");
            Thread.Sleep(2000);
        }
    }
}
