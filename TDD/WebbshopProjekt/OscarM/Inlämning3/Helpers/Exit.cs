using Inlämning3.Controllers;
using System;

namespace Inlämning3.Helpers
{
    public static class Exit
    {
        /// <summary>
        /// log out user and exits the program.
        /// </summary>
        public static void LogOutAndExit()
        {
            var logoutController = new LogoutController();
            logoutController.LogOutAndExit();
            Console.Clear();
            Console.WriteLine("See you next time!");
            Environment.Exit(0);
        }
    }
}