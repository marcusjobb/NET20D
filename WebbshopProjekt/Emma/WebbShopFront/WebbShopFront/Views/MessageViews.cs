using System;

namespace WebbShopFrontInlamning.Views
{
    /// <summary>
    /// Displays general messages
    /// </summary>
    class MessageViews
    {
        /// <summary>
        /// Displays an error message upon failure
        /// </summary>
        public static void DisplayErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Oops, something went wrong!");
        }

        /// <summary>
        /// Displays information needed to select an option
        /// </summary>
        public static void DisplaySelectMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the above: ");
        }

        /// <summary>
        /// Displays information needed to return to previous page
        /// </summary>
        public static void DisplayReturnMessage()
        {
            Console.WriteLine("(Press [0] to return to previous page)");
        }

        /// <summary>
        /// Displays an success message
        /// </summary>
        public static void DisplaySuccessMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Success!");
        }

        /// <summary>
        /// Displays an out of range message if option does not exist
        /// </summary>
        public static void DisplayNonAvailableMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Option is non available");
        }
    }
}
