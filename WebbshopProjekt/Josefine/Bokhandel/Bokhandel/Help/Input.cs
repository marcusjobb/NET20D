using System;

namespace Bokhandel.Help
{
    /// <summary>
    /// Give fault message
    /// </summary>
    public class Input
    {
        /// <summary>
        /// Convert input to int
        /// </summary>
        /// <returns></returns>
        public static int ConvertInput(string choice)
        {
            try
            {
                var number = Convert.ToInt32(choice);
                return number;
            }
            catch
            {
                Console.WriteLine("Are you sure you entered a number?");
            }
            return 0;
        }


        /// <summary>
        /// Trim stringinput
        /// </summary>
        /// <returns></returns>
        public static string StringInput()
        {
            var searchInput = Console.ReadLine().Trim();
            return searchInput;
        }
    }
}