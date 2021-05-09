using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_inl_1.Interfaces;

namespace TDD_inl_1.Geometry.Tests
{
    [TestClass()]
    public class GeometricCalculatorTests
    {
        [TestMethod()]
        public void GetPerimeterTest()
        {
            var geoCal = new GeometricCalculator();
            var geoThings = new IGeometric[] 
            {
                new Triangle(3, 4, 5),
                new Square(10),
                new Circle(3) 
            };

            var actual = geoCal.GetPerimeter(geoThings);
            var expected = 12 + 40 + 18.85;
            
            Assert.AreEqual(expected, actual, 0.01);
        }
    }
}