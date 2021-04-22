using System;

namespace WebbShopFrontInlamning.Helpers
{
    /// <summary>
    /// InputHelper main purpose is to check user input
    /// </summary>
    public class InputHelper
    {
        /// <summary>
        /// Parsing input, if the input isn't an integer the user will be asked to try again
        /// </summary>
        /// <returns>boolean, true if success, false if not</returns>
        public static int ParseInput()
        {
            int value;
            while (true)
            {
                try
                {
                    value = int.Parse(Console.ReadLine());
                    return value;
                }
                catch (Exception)
                {
                    Console.WriteLine("Only numbers please! Try again");
                }
            }
        }
    }
}
