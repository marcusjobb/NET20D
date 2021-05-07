using System;
using System.Collections.Generic;
using System.Text;

namespace TDDInlämning1
{
    public class Rectangle : GeometricThing
    {
        /// <summary>
        /// rektangelns bredd
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// rektangelns höjd
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// konstruktor som tar emot bredd och höjd. Ifall värdet som skickas in är negativt, ändras det till 0 i konstruktorn
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Rectangle(double width, double height)
        {
            if(width < 0)
            {
                width = 0;
            }
            if (height < 0)
            {
                height = 0;
            }
            Width = width;
            Height = height;
        }
        /// <summary>
        /// räknar ut rektangelns area genom att ta bredden * höjden
        /// </summary>
        /// <returns></returns>
        public override double Area()
        {
            return Width * Height;
        }
        /// <summary>
        /// räknar ut rektangelns omkrets genom att plussa på dess sidor. Ifall någon av bredden eller höjden är 0, så returneras 0.
        /// </summary>
        /// <returns></returns>
        public override double Perimeter()
        {
            if (Width == 0 || Height == 0) return 0;
            return (Width + Height) * 2;
        }
    }
}
