using System;
using Controllers;

namespace ConsoleMVC
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initializes the program
            CoreController coreLogic = new CoreController();
            coreLogic.Start();
        }
    }
}
