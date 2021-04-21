using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopUI.Views
{
    class Messages
    {
        public void FailMessage()
        {
            Console.WriteLine("Something went wrong, please try again!");
            Console.ReadKey();
        }

        public void SuccessMessage()
        {
            Console.WriteLine("Success!");
            Console.ReadKey();
        }

        public void ReturnMessage()
        {
            Console.WriteLine("Returning to home menu.");
            Console.ReadKey();
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

    }
}
