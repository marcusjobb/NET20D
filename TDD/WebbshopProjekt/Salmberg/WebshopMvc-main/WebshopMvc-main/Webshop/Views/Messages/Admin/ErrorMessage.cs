using System;

namespace WebshopMVC.Views.Messages
{
    /// <summary>
    /// Class for handling error messages.
    /// </summary>
    internal class ErrorMessage
    {
        /// <summary>
        /// Prints generalized error message for use when user is prompted with try again/abort.
        /// Parameters for specifying error message.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns>string</returns>
        public static string ErrorAbort(string input1 = "", string input2 = "")
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong when {input1}! Either your session timed out and you have to log in again, \n" +
                $"or {input2}");
            return Prompts.Abort();
        }

        /// <summary>
        /// Prints generalized error message.
        /// Parameters for specifying error message.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        public static void ErrorNoAbort(string input1 = "", string input2 = "")
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong when {input1}! Either your session timed out and you have to log in again, \n" +
                $"or {input2}");
            Prompts.ClearAndContinue();
        }
    }
}