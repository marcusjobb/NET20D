using System;

namespace Inlämning3.Helpers
{
    public static class Messages
    {
        /// <summary>
        /// "Prints success"
        /// </summary>
        public static void SuccessMessage()
        {
            Console.WriteLine("Success!");
        }

        /// <summary>
        /// prints "something went wrong"
        /// </summary>
        public static void ErrorMessage()
        {
            Console.WriteLine("Something went wrong!");
        }

        /// <summary>
        /// prints "not valid input"
        /// </summary>
        public static void NotValidInput()
        {
            Console.WriteLine("Not valid input!");
        }
    }
}