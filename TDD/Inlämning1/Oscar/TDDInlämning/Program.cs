using System;

namespace TDDInlämning1
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(2, 0);
            Console.WriteLine($"{triangle.Area()}");
            Console.WriteLine(0 / 3);
        }
    }
}
