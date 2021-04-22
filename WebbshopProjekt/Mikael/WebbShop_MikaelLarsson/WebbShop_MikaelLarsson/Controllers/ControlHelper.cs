using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Inlamn2WebbShop_MLarsson;
using Inlamn2WebbShop_MLarsson.Models;
using WebbShop_MikaelLarsson.Views;

namespace WebbShop_MikaelLarsson
{
    /// <summary>
    /// Hjälpklass för hantering av enklare logik.
    /// </summary>
    internal static class ControlHelper
    {
        /// <summary>
        /// Justerar ett namninput till snyggt format.
        /// </summary>
        /// <returns>string</returns>
        internal static string AdjustName()
        {
            string input = Console.ReadLine();
            if (input.Length > 0)
            {
                input = input.Trim();
                input = input.Substring(0, 1).ToUpper() + input.Substring(1).ToLower();
                return input;
            }
            else { return String.Empty; }
        }

        /// <summary>
        /// Hjälpmetod för att se om en användare är administratör.
        /// </summary>
        /// <param name="user"></param>
        internal static void CheckIfAdmin(User user)
        {
            Console.WriteLine();
            if (user?.IsAdmin == true)
            {
                AdminMenuView.AdminMainMenu(user.Id);
            }
            else
            {
                MessageView.NotAdmin();
                MessageView.PressEnter();
            }
        }

        /// <summary>
        /// Hanterar ping-anrop till WebbSHopAPI.
        /// </summary>
        /// <param name="userId"></param>
        internal static void PingHelper(int userId)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.CursorLeft = Console.BufferWidth - 5;
            Console.Write(WebbShopAPI.Ping(userId));
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Maskerar lösenordet för "tjuvkikare".
        /// </summary>
        internal static void SetPasswordColor()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        /// <summary>
        /// Helpermetod för att göra en sträng till en int.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>int</returns>
        internal static int TryParse(string value)
        {
            int.TryParse(value, out int parsedValue);
            return parsedValue;
        }

        /// <summary>
        /// Hjälpmetod för att göra int av ett user-input.
        /// </summary>
        /// <returns>int</returns>
        internal static int TryParseReadLine()
        {
            int.TryParse(Console.ReadLine(), out int parsedValue);
            return parsedValue;
        }
    }
}
