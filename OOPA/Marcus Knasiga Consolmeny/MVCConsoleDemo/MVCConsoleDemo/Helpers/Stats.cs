using MVCConsoleDemo.GameObjects;
using MVCConsoleDemo.ScreenObjects;
using System.Collections.Generic;

namespace MVCConsoleDemo.Helpers
{
    public static class Stats
    {
        public static int Room = 0;
        public static bool GameOver = false;
        public static List<Item> Items = new List<Item>();
        public static int CurrentY { get; set; } = 0;
        public static int MainX { get; set; } = 0;
        public static int MainY { get; set; } = 0;
        public static Display Display { get; set; }
        public static List<Item> Directions { get; set; } = new List<Item>();
    }
}