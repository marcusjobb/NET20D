using System;
using TDD_Inlamning_Lee.GeoItems;

namespace TDD_Inlamning_Lee
{
    class Program
    {
        static void Main(string[] args)
        {
            var geoThings = new GeometricThings[]
            {
                new Square(5),
                new Rectangle(5, 20),
                new Circle(5),
                new Triangle(5, 20),
                new Triangle(5, true)
            };
            GeometricCalculator calc = new GeometricCalculator();
            calc.GetPerimiter(geoThings);
            Console.WriteLine("Hello World!");
        }
    }
}
