using System;

namespace MVCConsoleDemo.ScreenObjects
{
    public class Line
    {
        public bool Center = false;
        public ConsoleColor BackColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor ForeColor { get; set; } = ConsoleColor.White;
        public string Text { get; set; } = "";
        public int Width { get; set; } = 0;
        public string Key { get; set; } = "";

        public static Line NewLine(string text, int width = 0, bool center = false)
        {
            if (width == 0) width = text.Length + 2;
            return new Line { Text = text, Width = width, Center = center };
        }

        public static Line NewLine(string text, bool center)
        {
            return new Line { Text = text, Width = text.Length + 2, Center = center };
        }

        public static Line NewLine(string text)
        {
            return new Line { Text = text, Width = text.Length + 2, Center = false };
        }

        public string GetString()
        {
            if (Width == 0) Width = Text.Length + 2;
            if (Center)
            {
                var pos = Width / 2 - Text.Length / 2;
                if (pos < 0) pos = 0;
                return @"║ " + PrepString(new string(' ', pos) + Text.PadRight(Width), Width) + " ║";
            }
            return "║ " + PrepString(Text.PadRight(Width), Width) + " ║";
        }

        private static string PrepString(string text, int width)
        {
            if (text.Length > width) text = text.Substring(0, width);
            return text;
        }
    }
}