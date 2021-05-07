using Geometri.Interface;
using Geometri.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometri.GeometricCalculator.Tests
{
    [TestClass()]
    public class GeometricCalculatorTests
    {
        [TestMethod()]
        public void GetAreaTest01()
        {
            var geoCalc = new GeometricCalculator();

            var shape = new IGeometricThing[]
            {
                new Triangle(1f),
                new Rectangle(1f, 1f),
                new Circle(1f),
                new Square(1f)
            };
            var actual = geoCalc.GetArea(shape);
            var expected = 5.57f;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaTests02_ArrayIsNull_ReturnsZero()
        {
            var geoCalc = new GeometricCalculator();
            var actual = geoCalc.GetArea(null);
            var expected = 0;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void GetPerimeterTest01()
        {
            var geoCalc = new GeometricCalculator();

            var shape = new IGeometricThing[]
            {
                new Triangle(1f),
                new Rectangle(1f, 1f),
                new Circle(1f),
                new Square(1f)
            };
            var actual = geoCalc.GetPerimeter(shape);
            var expected = 17.28f;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTests_ArrayIsNull_ReturnsZero02()
        {
            var geoCalc = new GeometricCalculator();
            var actual = geoCalc.GetPerimeter(null);
            var expected = 0;
            Assert.AreEqual(actual, expected);
        }
    }
}