using System;

namespace StarScapeExplained
{
    class Program
    {
        static void Main(string[] args)
        {
            var buff = new ScreenBuffer(Console.WindowWidth, Console.WindowHeight, 3);
            buff.PrintAt(50, 10, "+-----------------------------+");
            buff.PrintAt(50, 11, "+ This is a static silly sign +");
            buff.PrintAt(50, 12, "+-----------------------------+");

            var posY = Console.WindowHeight - 6;
            var posX = Console.WindowWidth - 22;
            buff.PrintAt(posX, posY, "╔═════════════════╗");
            buff.PrintAt(posX, posY + 1, "║\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0║");
            buff.PrintAt(posX, posY + 2, "║\0Codic\0Education\0║");
            buff.PrintAt(posX, posY + 3, "║\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0║");
            buff.PrintAt(posX, posY + 4, "╚═════════════════╝");

            buff.AddStars();
            int amountOfStars = 50;
            var stars = new MovingStars[amountOfStars];
            var random = new Random();
            for (int i = 0; i < amountOfStars; i++)
            {
                stars[i] = new MovingStars(
                    random.Next(Console.WindowWidth),
                    random.Next(Console.WindowHeight),
                    random.Next(1, 3), 0,
                    Console.WindowWidth, Console.WindowHeight);
            }
            while (true)
            {
                for (int i = 0; i < amountOfStars; i++)
                {
                    buff.PrintAt(2, stars[i].X, stars[i].Y, ' ');
                    if (random.Next(1000) > 990) stars[i].Y++;
                    stars[i].MoveStar();
                    buff.PrintAt(2, stars[i].X, stars[i].Y, '.');
                }
                buff.PrintBuffer();
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
