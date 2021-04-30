using System;

namespace MVCConsoleDemo.Helpers
{
    public static class Input
    {
        public static void Pause()
        {
            Console.ReadLine();
        }

        public static ConsoleKey GetKey(ConsoleKey[] allowed = null)
        {
            if (allowed == allowed || allowed.Length == 0)
            {
                allowed = new ConsoleKey[]{
        ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.Enter,
            ConsoleKey.Escape, ConsoleKey.Spacebar, ConsoleKey.Tab };
            }

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var k = Console.ReadKey(true).Key;
                    if (Array.IndexOf(allowed, k) >= 0) return k;
                }
            }
        }
    }
}