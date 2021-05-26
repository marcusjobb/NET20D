using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarScapeExplained
{
    public class MovingStars
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Xdirection { get; set; } = 1;
        public int Ydirection { get; set; } = 0;
        public int XMax { get; set; } = 110;
        public int YMax { get; set; } = 25;

        public MovingStars(int x, int y, int xdirection, int ydirection, int xmax, int ymax)
        {
            X = x;
            Y = y;
            Xdirection = xdirection;
            Ydirection = ydirection;
            XMax = xmax;
            YMax = ymax;
        }
        public void MoveStar()
        {
            X += Xdirection;
            Y += Ydirection;
            if (X < 0) X = XMax - 1;
            if (X >= XMax) X = 0;
            if (Y < 0) Y = YMax - 1;
            if (Y >= YMax) Y = 0;
        }
    }
}
