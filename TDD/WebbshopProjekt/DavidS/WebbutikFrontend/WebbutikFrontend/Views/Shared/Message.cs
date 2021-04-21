using System;
using System.Threading;
using static WebbutikFrontend.Views.Shared.Layout;
using static WebbutikFrontend.Utils.Helper;

namespace WebbutikFrontend.Views.Shared
{
    public static class Message
    {
        /// <summary>
        /// Shows a colored error <paramref name="message"/> on
        /// the screen, then removes the message and also the
        /// user input that was incorrect.
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message = "Invalid choice! Try again.")
        {
            Console.ForegroundColor = ErrorColor;
            Console.WriteLine("\t" + message);
            Thread.Sleep(SleepTime);
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', ScreenWidth));
            }

            Console.SetCursorPosition(0, Console.CursorTop);
            Console.ForegroundColor = OriginalForegroundColor;
        }

        /// <summary>
        /// Pings the user and writes Pong in dark grey to the screen
        /// if the user still was logged in when pinged.
        /// </summary>
        /// <param name="userId"></param>
        public static void Ping(int userId)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(API.Ping(userId));
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Shows a colored success <paramref name="message"/> on the screen.
        /// </summary>
        /// <param name="message"></param>
        public static void Success(string message)
        {
            Console.ForegroundColor = SuccessColor;
            Console.WriteLine("\t" + message);
            Thread.Sleep(SleepTime);
            Console.ForegroundColor = OriginalForegroundColor;
            Console.Clear();
        }

        /// <summary>
        /// Shows a colored error <paramref name="message"/> on the
        /// screen and asks the user if he or she wants to try again.
        /// </summary>
        /// <param name="message"></param>
        /// <returns><see langword="true"/> if the user wants to try again,
        /// otherwise <see langword="false"/>.</returns>
        public static bool TryAgain(string message)
        {
            SmallError(message);
            return Get.DoYouWantTo("try again");
        }

        /// <summary>
        /// Shows a colored error <paramref name="message"/>
        /// on the screen and then removes it.
        /// </summary>
        /// <param name="message"></param>
        private static void SmallError(string message = "Invalid choice! Try again.")
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\t" + message);
            Thread.Sleep(SleepTime);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', ScreenWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.ForegroundColor = OriginalForegroundColor;
        }
    }
}
