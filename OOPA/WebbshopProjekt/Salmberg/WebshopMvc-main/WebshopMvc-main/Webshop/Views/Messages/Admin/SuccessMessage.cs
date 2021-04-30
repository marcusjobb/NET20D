using System;

namespace WebshopMVC.Views.Messages
{
    /// <summary>
    /// Class for handling success messages.
    /// </summary>
    internal class SuccessMessage
    {
        /// <summary>
        /// Prints generalized success message.
        /// Parameters for specifying error message. input2 optional int parameter
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        public static void SuccessWithInt(string input1, int input2 = 0)
        {
            Console.Clear();
            Console.WriteLine($"{input1} {input2}!");
            Prompts.ClearAndContinue();
        }

        /// <summary>
        /// Prints generalized success message.
        /// Parameters for specifying error message. input2 optional string parameter
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        public static void SuccessWithString(string input1, string input2 = "")
        {
            Console.Clear();
            Console.WriteLine($"{input1} {input2}!");
            Prompts.ClearAndContinue();
        }
    }
}