
namespace TDDGeometric.GeometricThings.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TDDGeometric.GeometricThings.GeoShapes;

    [TestClass()]
    public class GeometricCalculatorTests
    {
        [TestMethod()]
        public void GetAreaTest_Negative_Zero()
        {
            var geoThings = new GeometricShapes[]
            {
               new Triangle(-3,6),
               new Square(-5),
               new Circle(-6)
            };
            var geoCalc = new GeometricCalculator();
            var actual = geoCalc.GetArea(geoThings);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaTest_Positive_TotalArea()
        {
            var geoThings = new GeometricShapes[]
            {
               new Triangle(3,6),
               new Square(5),
               new Circle(6)
            };
            var geoCalc = new GeometricCalculator();
            var actual = geoCalc.GetArea(geoThings);
            var expected = 147.10f;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTest_Negative_Zero()
        {
            var geoThings = new GeometricShapes[]
            {
               new Triangle(-3,6),
               new Square(-5),
               new Circle(-6)
            };
            var geoCalc = new GeometricCalculator();
            var actual = geoCalc.GetPerimeter(geoThings);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTest_Positive_TotalPerimeter()
        {
            var geoThings = new GeometricShapes[]
            {
               new Triangle(3,6),
               new Square(5),
               new Circle(6)
            };
            var geoCalc = new GeometricCalculator();
            var actual = geoCalc.GetPerimeter(geoThings);
            var expected = 66.70f;
            Assert.AreEqual(expected, actual);
        }
    }
}