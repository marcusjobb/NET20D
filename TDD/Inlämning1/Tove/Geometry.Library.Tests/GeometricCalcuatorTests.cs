using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometry.Library;

namespace Geometry.Library.Tests
{
    /// <summary>
    /// Tests that total perimeter of all shapes in an array is correctly calculated.
    /// </summary>
    [TestFixture]  
    public class GeometricCalculatorTest
    {                        
        [Test]
        public void GetPerimeterForAllShapesInArray()
        {
            var circle = new Circle(0.8);
            var triangle = new Triangle(2);
            var rectangle = new Rectangle(6, 3.5);
            var square = new Square(4);
            IGeometricThing[] DifferentShapesToCalculate = new IGeometricThing[] {circle,
            triangle, rectangle,square};
            var perimeterCircle = circle.GetPerimeter();
            var perimeterTriangle = triangle.GetPerimeter();
            var perimeterRectangle = rectangle.GetPerimeter();
            var perimeterSquare = square.GetPerimeter();
            var expected = perimeterCircle + perimeterTriangle + perimeterRectangle + perimeterSquare;
            var actual = GeometricCalculator.GetPerimeter(DifferentShapesToCalculate);
            Assert.AreEqual(expected, actual);
        }
    }
}
