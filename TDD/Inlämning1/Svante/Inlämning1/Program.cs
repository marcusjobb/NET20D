using Inlämning1.Calculator;
using Inlämning1.Shapes;

namespace Inlämning1
{
    static class Program
    {
        static void Main(string[] args)
        {

            var geoThings = new GeometricThing[]
            {
               new Rectangle(height:10, widht:10),//100
               new Rectangle(height:10, widht:10),//50
               new Triangle(height:10, tbase:12),//60
               new Circle(radius:7) // 43,982297150257105338477007365913 
            };
            var fyrkant = new Rectangle(height:15, widht:20);            
            var area = GeometricCalculator.GetArea(new GeometricThing[] { fyrkant });

            var areaArray = GeometricCalculator.GetArea(geoThings);
        }
    }
}
