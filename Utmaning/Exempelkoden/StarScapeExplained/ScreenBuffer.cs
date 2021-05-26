//----------------------------------------------------------------------------------------------------
// <copyright file="ScreenBuffer.cs" company="Codic Education">
// By Marcus Medina, Width21- https://codic-education.azurewebsites.net/ 
// This file is subject to the terms and stated in MIT License, 
// </copyright>
// ---------------------------------------------------------------------------------------------------

namespace StarScapeExplained
{
    using System;

    public class ScreenBuffer
    {
        private char[][][] Buffer;
        private char[][] Output;

        private int Width { get; set; } = 110;

        private int Height { get; set; } = 25;

        private int Depth { get; set; } = 2;

        public ScreenBuffer(int width, int height, int depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
            GenerateMap();
        }

        public ScreenBuffer()
        {
            GenerateMap();
        }

        private void GenerateMap()
        {
            Buffer = new char[Depth][][];
            Output = new char[Height][];
            for (int z = 0; z < Depth; z++)
            {
                Buffer[z] = new char[Height][];
                for (int y = 0; y < Height; y++)
                {
                    Buffer[z][y] = new char[Width];
                    Output[y] = new char[Width];
                }
            }
        }

        public void PrintBuffer()
        {
            for (int y = 0; y < Height; y++)
            {
                Console.SetCursorPosition(0, y);
                var str = new string(Output[y]).Replace('\0', ' ');
                Console.Write(str);
            }
        }

        public void PrintAt(int x, int y, string text) => PrintAt(0, x, y, text);
        public void PrintAt(int z, int x, int y, string text)
        {
            for (int pos = 0; pos < text.Length; pos++)
            {
                if (pos + x >= Width) break;
                PrintAt(z, pos + x, y, text[pos]);
            }
        }

        public void PrintAt(int z, int x, int y, char ch)
        {
            Buffer[z][y][x] = ch;
            if (z > 0)
            {
                for (int d = 0; d < Depth; d++)
                {
                    ch = Buffer[d][y][x];
                    if (ch != '\0') break;
                }
            }

            Output[y][x] = ch;
        }

        public void AddStars()
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                PrintAt(1, random.Next(Width), random.Next(Height), '.');
            }
        }

        public void Clear(int depth)
        {
            Buffer[depth] = new char[Height][];
            for (int y = 0; y < Height; y++)
            {
                Buffer[depth][y] = new char[Width];
            }
            RefreshBuffer();
        }

        public void RefreshBuffer()
        {
            Output = new char[Height][];
            for (int y = 0; y < Height; y++)
            {
                Output[y] = new char[Width];
                for (int x = 0; x < Width; x++)
                {
                    Output[y][x] = Buffer[0][y][x];
                    for (int d = 0; d < Depth; d++)
                    {
                        var ch = Buffer[d][y][x];
                        if (ch != '\0')
                        {
                            Output[y][x] = ch;
                            break;
                        }
                    }
                }
            }
        }
    }
}
