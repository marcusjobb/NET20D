using ConsoleApp3.GeoCalculator;
using ConsoleApp3.Interfaces;
using ConsoleApp3.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp3Tests1.Shapes
{
    [TestClass()]
    public class GeometricCalculatorTests
    {
        [TestMethod()]
        [DataRow(141.4159274f)]
        public void Area_CalculatesPerimitersOfObjects_ReturnsTotalPerimeter(float expected)
        {
            var calculator = new GeometricCalculator();
            // Act
            var geoThings = new IGeometricThing[]
            {
                new Triangle(height:10f, width:10f),  // 10 * 3 = 30
                new Square(side:10f),                 // 10 * 4 = 40
                new Rectangel(width:10f, length:10f), // 10 * 2 + 10 * 2 = 40
                new Circle(radius:5f)                 // 3.14159274 * 2 * 5 = 31.4159274
            };
            // Arrange
            var actual = calculator.GetPerimeter(geoThings);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}