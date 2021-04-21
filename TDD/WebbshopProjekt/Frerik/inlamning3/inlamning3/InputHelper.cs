using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inlamning3
{
    /// <summary>
    /// Any help to provide for inputs
    /// </summary>
    public static class InputHelper
    {
        /// <summary>
        /// Require the user to supply the software with a string input
        /// </summary>
        /// <param name="msg">What message to write before requesting user to input</param>
        /// <returns>A string from the user (hopefully)</returns>
        public static string TakeObligatoryStringInput(string msg)
        {
            string retval;
            if (!msg.EndsWith(": "))
                msg += ": ";

            do
            {
                Console.Write(msg);
                retval = Console.ReadLine();
            } while (string.IsNullOrEmpty(retval));
            return retval;
        }

        /// <summary>
        /// Require the user to supply the software with a double input
        /// </summary>
        /// <param name="msg">What message to write before requesting user to input</param>
        /// <returns>A string from the user (hopefully)</returns>
        public static double TakeObligatoryDoubleInput(string msg)
        {
            string get = TakeObligatoryStringInput(msg);
            double retval;
            while (!double.TryParse(get, out retval))
            {
                Console.WriteLine("The input was not valid.");
                get = TakeObligatoryStringInput(msg);
            }
            return retval;
        }

        /// <summary>
        /// Require the user to supply the software with an int input
        /// </summary>
        /// <param name="msg">What message to write before requesting user to input</param>
        /// <returns>A string from the user (hopefully)</returns>
        public static int TakeObligatoryIntInput(string msg)
        {
            string get = TakeObligatoryStringInput(msg);
            int retval;
            while (!int.TryParse(get, out retval))
            {
                Console.WriteLine("The input was not valid.");
                get = TakeObligatoryStringInput(msg);
            }
            return retval;
        }

        /// <summary>
        /// Require the user to supply input based on a selection of allowed inputs
        /// </summary>
        /// <param name="allowedOptions">What inputs are allowed</param>
        /// <returns>An integer value (hopefully)</returns>
        public static int GetObligatoryInput(string[] allowedOptions)
        {
            int retval = -1;
            string opt = TakeObligatoryStringInput("\nEnter the digit of the option: ");
            if (InArray(allowedOptions, opt))
            {
                retval = int.Parse(opt);
            }

            while (!InArray(allowedOptions, opt) || retval < 0)
            {
                Console.WriteLine("Failed.");
                opt = TakeObligatoryStringInput("\nEnter the digit of the option: ");
                if (InArray(allowedOptions, opt))
                {
                    retval = int.Parse(opt);
                }
            }
            return retval;
        }

        /// <summary>
        /// Check if the array contains a certain item
        /// </summary>
        /// <param name="haystack">What to search through</param>
        /// <param name="needle">What to find</param>
        /// <returns>Yes or no (true or false)</returns>
        static bool InArray(string[] haystack, string needle)
        {
            return haystack.Any(h => h == needle);
        }
    }
}
