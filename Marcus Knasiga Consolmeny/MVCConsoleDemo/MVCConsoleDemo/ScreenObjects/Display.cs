using MVCConsoleDemo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCConsoleDemo.ScreenObjects
{
    public class Display
    {
        public List<Box> Boxes = new List<Box>();
        public int Width { get; set; } = 0;

        public void Info(string name, params string[] info)
        {
            var box = Stats.Display.GetBox(name);
            box.Cls();
            foreach (var item in info)
            {
                var key = item.Trim().Substring(2);
                box.Print(item, (item.Trim().StartsWith("*") ? key : ""));
            }
            box.ShowBox();
        }

        public void InfoAdd(string name, params string[] info)
        {
            var box = Stats.Display.GetBox(name);
            foreach (var item in info)
            {
                var key = item.Trim();
                if (key.Length > 2) key = key.Substring(2);
                box.Print(item, (item.Trim().StartsWith("*") ? key : ""));
            }
            box.ShowBox();
        }

        public static Box NewBox(int x, int y, int width, int height, string name = "")
        {
            var box = new Box() { Width = width, X = x, Y = y, Name = name };
            box.Cls();
            return box;
        }

        public Box GetBox(string v)
        {
            return Boxes.FirstOrDefault(b => b.Name == v);
        }

        public void ShowBoxes()
        {
            foreach (var item in Boxes)
            {
                item.ShowBox();
            }
            Console.CursorTop = 0;
        }

        internal Box ActiveBox()
        {
            return Boxes.FirstOrDefault(b => b.IsActive);
        }

        internal void NextBox()
        {
            var chooseNext = false;
            var pos = 0;
            while (true)
            {
                pos++;
                if (pos >= Boxes.Count)
                {
                    chooseNext = true;
                    pos = 1;
                }

                if (chooseNext)
                {
                    if (!Boxes[pos].IsEmpty())
                    {
                        Boxes[pos].IsActive = true;
                        Boxes[pos].ShowBox();
                        Boxes[pos].MenuRow = -1;
                        Boxes[pos].MoveDown();
                        break;
                    }
                }

                if (Boxes[pos].IsActive)
                {
                    chooseNext = true;
                    Boxes[pos].IsActive = false;
                    Boxes[pos].ShowBox();
                }
            }
        }
    }
}