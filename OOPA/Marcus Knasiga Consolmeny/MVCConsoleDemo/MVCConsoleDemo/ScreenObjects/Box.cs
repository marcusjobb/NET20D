using System;
using System.Collections.Generic;
using System.Linq;
using static MVCConsoleDemo.Helpers.Output;

namespace MVCConsoleDemo.ScreenObjects
{
    public class Box
    {
        public List<Line> Lines = new List<Line>();
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Width { get; set; } = 0;
        public bool IsActive { get; set; } = false;
        public int MenuRow { get; set; } = 0;
        public ConsoleColor BackColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor ForeColor { get; set; } = ConsoleColor.White;

        public void Cls()
        {
            int height = Lines.Count;
            Lines = new List<Line>();
            for (int i = 0; i < Lines.Count; i++)
            {
                Lines.Add(Line.NewLine(""));
            }
            CurrentY = 0;
        }

        public bool NotChoosable { get; set; } = false;
        public string Name { get; set; }
        public int CurrentY { get; set; } = 0;
        public bool Visible { get; set; } = true;

        internal void Print(string text, string key = "")
        {
            Lines[CurrentY].Text = text;
            Lines[CurrentY++].Key = key;
        }

        public void ShowBox()
        {
            if (Visible)
            {
                if (Width == 0)
                {
                    var maxWith = Lines.Max(l => l.Width);
                    Width = maxWith;
                }
                var y = Y;
                ConAtF(X, y++, "╔" + new string('═', Width + 2) + "╗");
                Console.ForegroundColor = ForeColor;
                Console.BackgroundColor = BackColor;
                for (int i = 0; i < Lines.Count; i++)
                {
                    Lines[i].Width = Width;
                    if (IsActive)
                    {
                        if (MenuRow == i - 1)
                        {
                            Console.ForegroundColor = BackColor;
                            Console.BackgroundColor = ForeColor;
                        }
                        else
                        {
                            Console.ForegroundColor = ForeColor;
                            Console.BackgroundColor = BackColor;
                        }
                    }
                    ConAtF(X, y++, Lines[i].GetString());
                    if (IsActive)
                    {
                        Console.ForegroundColor = ForeColor;
                        Console.BackgroundColor = BackColor;
                        ConAtF(X, y - 1, "║");
                        ConAtF(X + Width + 3, y - 1, "║");
                    }
                }
                ConAtF(X, y++, "╚" + new string('═', Width + 2) + "╝");
            }
            Console.CursorTop = 0;
            Console.ResetColor();
        }

        internal bool IsEmpty()
        {
            return NotChoosable || (Lines[2].Text == "" /* fulhack */);
        }

        public void MoveUp()
        {
            MenuRow--;
            while (Lines[MenuRow + 1].Key.Trim() == "")
            {
                MenuRow--;
                if (MenuRow < 0)
                {
                    MenuRow = Lines.Count - 2;
                }
                if (MenuRow < 0) MenuRow = 0;
            }
            ShowBox();
        }

        public void MoveDown()
        {
            MenuRow++;
            while (Lines[MenuRow + 1].Key.Trim() == "")
            {
                MenuRow++;
                if (MenuRow > Lines.Count - 2)
                    MenuRow = 0;
            }
            ShowBox();
        }
    }
}