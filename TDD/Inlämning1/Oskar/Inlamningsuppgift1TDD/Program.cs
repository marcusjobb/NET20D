namespace Inlamningsuppgift1TDD
{
    using System;
    using Inlamningsuppgift1TDD.Geometric;
    internal class Program
    {
        private static void Main()
        {
            GeometricCalculator calc = new GeometricCalculator();

            Console.WriteLine(calc.GetPerimeter(new Circle(20)));
        }
    }
}
