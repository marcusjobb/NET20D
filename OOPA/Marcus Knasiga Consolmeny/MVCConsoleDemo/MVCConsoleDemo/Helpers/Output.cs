namespace MVCConsoleDemo.Helpers
{
    using System;

    public static class Output
    {
        public static void ConClear()
        {
            Console.Clear();
            Stats.CurrentY = 0;
        }

        public static void ConBox(int x, int y, int width, int height, string title = "")
        {
            Console.Clear();
            var originalY = Stats.MainY + y;
            ConAt(x, y++, "  " + new string(' ', width) + " ║");
            ConAt(x, y++, "  ╔" + new string('═', width) + "╬══");
            for (var i = 0; i < height; i++)
            {
                ConAt(x, y++, "  ║" + new string(' ', width) + "║");
            }
            ConAt(x, y++, "══╬" + new string('═', width) + "╝");
            ConAt(x, y++, "  ║");
            ConAt(x, y++, "  ║");
            if (title != "") Centertext(x, originalY, title, width);
        }

        public static void ConMiniBox(int x, int y, int width, int height, string title = "")
        {
            var originalY = y;
            ConAt(x, y++, "╔" + new string('═', width) + "╗");
            for (var i = 0; i < height; i++)
            {
                ConAt(x, y++, "║" + new string(' ', width) + "║");
            }
            ConAt(x, y++, "╚" + new string('═', width) + "╝");
            if (title != "")
            {
                Centertext(x, originalY + 1, title, width);
                ConAt(x, originalY + 2, "╠" + new string('═', width) + "╣");
            }
        }

        public static void Centertext(int y, string text)
        {
            Centertext(0, y, text, -1);
        }

        public static void Centertext(int x, int y, string text, int width = -1)
        {
            if (width == -1) width = Console.WindowWidth;
            var pos = x + (width / 2) - (text.Length / 2);
            if (pos < 0) pos = 0;
            Console.CursorTop = y;
            Console.CursorLeft = pos;
            Console.Write(text);
        }

        public static void Print(string text)
        {
            ConAt(0, Stats.CurrentY, text);
        }

        public static void Print(string[] text)
        {
            ConAt(0, Stats.CurrentY, text);
        }

        public static void ConAt(int x, int y, string text)
        {
            Console.CursorTop = Stats.MainY + y;
            Console.CursorLeft = Stats.MainX + x;
            Console.Write(text);
            Stats.CurrentY = y + 1;
        }

        public static void ConAtF(int x, int y, string text)
        {
            Console.CursorTop = y;
            Console.CursorLeft = x;
            Console.Write(text);
            Stats.CurrentY = y + 1;
        }

        public static void ConAt(int x, int y, params string[] text)
        {
            y += Stats.MainY;
            foreach (var item in text)
            {
                Console.CursorTop = y++;
                Console.CursorLeft = x;
                Console.Write(item);
            }
        }
    }
}