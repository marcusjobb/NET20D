using System;

namespace Inlm3.Helpers
{
    /// <summary>
    /// Helper-Klass för detta projekt.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Rensar Consolen efter input från användaren.
        /// </summary>
        public static void NextStep()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}