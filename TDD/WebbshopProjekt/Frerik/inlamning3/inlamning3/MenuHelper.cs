using System;

namespace inlamning3
{
    /// <summary>
    /// Any help to provide for menus
    /// </summary>
    public static class MenuHelper
    {
        /// <summary>
        /// Output to the console an array of string items
        /// </summary>
        /// <param name="opts">What items to print to the console</param>
        /// <returns></returns>
        public static string[] PrintMenu(string[] opts)
        {
            string[] retval = new string[opts.Length];
            for (int i = 0; i < opts.Length; i++)
            {
                Console.WriteLine($"{i}. {opts[i]}");
                retval[i] = i.ToString();
            }
            return retval;
        }

        /// <summary>
        /// Provide interruption ability for the console to wait on the current position until the user presses a key
        /// </summary>
        public static void Interrupt()
        {
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        /// <summary>
        /// Print in special color if any of a selection of words are occuring in the text.
        /// </summary>
        /// <param name="state">What message to print</param>
        public static void PrintState(string state)
        {
            string[] needles = { "no", "unknown", "bad", "missing", "low", "empty", "failed" };
            string[] words = state.Split(" ");

            foreach (string s in words)
            {
                foreach (string ss in needles)
                {
                    if(s.ToLower() == ss)
                        Console.ForegroundColor = ConsoleColor.Red;
                }
            }
            Console.WriteLine($"{state}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
