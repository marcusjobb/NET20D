using System;
using tdd_inlamning_1.Models;

namespace tdd_inlamning_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var geoThings = new GeometricThing[]
            {
                new Triangle(4, 3, 0),
                new Circle(3),
                new Rectangle(10, 2),
                new Square(3)
            };
        }
    }
}
