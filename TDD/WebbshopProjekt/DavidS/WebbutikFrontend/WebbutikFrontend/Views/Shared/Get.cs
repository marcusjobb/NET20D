using System;
using static WebbutikFrontend.Views.Shared.Layout;

namespace WebbutikFrontend.Views.Shared
{
    public static class Get
    {
        /// <summary>
        /// Gets an input from the user and tries to
        /// parse it into an <see langword="int"/>.
        /// </summary>
        /// <returns>The parsed <see langword="int"/> or
        /// 0 if the parse failed.</returns>
        public static int Choice()
        {
            Console.Write("\t> ");
            int.TryParse(ReadLine(), out var choice);
            return choice;
        }

        /// <summary>
        /// Asks the user a <paramref name="question"/>
        /// and gets the users answer.
        /// </summary>
        /// <param name="question"></param>
        /// <returns><see langword="true"/> if the user answers y,
        /// otherwise <see langword="false"/>.</returns>
        public static bool DoYouWantTo(string question)
        {
            Console.Write($"\n\tDo you want to {question}? (y/n): ");
            return string.Equals(ReadLine(), "y",
                StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Gets a number from the user.
        /// </summary>
        /// <param name="type"></param>
        /// <returns>The number.</returns>
        public static int Number(string type, string prefix = "\t")
        {
            bool exit;
            int number;
            do
            {
                exit = true;
                Console.Write($"{prefix}Enter {type}: ");
                if (!int.TryParse(ReadLine(), out number))
                {
                    Message.Error();
                    exit = false;
                }
                else if (number < 1)
                {
                    Message.Error("You have to enter a number greater than 0.");
                    exit = false;
                }
            } while (!exit);

            return number;
        }

        /// <summary>
        /// Gets a text input from the user.
        /// </summary>
        /// <param name="type"></param>
        /// <returns>The text input.</returns>
        public static string Text(string type, string prefix = "\t")
        {
            Console.Write($"{prefix}Enter {type}: ");
            return ReadLine();
        }

        /// <summary>
        /// Reads input from the user in color.
        /// </summary>
        /// <returns>The user input.</returns>
        private static string ReadLine()
        {
            Console.ForegroundColor = BannerInputColor;
            var input = Console.ReadLine();
            Console.ForegroundColor = OriginalForegroundColor;
            return input;
        }
    }
}
