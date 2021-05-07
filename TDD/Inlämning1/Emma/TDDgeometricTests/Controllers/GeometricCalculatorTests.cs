using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDgeometric.Models;

namespace TDDgeometric.Controllers.Tests
{
    [TestClass()]
    public class GeometricCalculatorTests
    {
        //Tests GetTotalArea method with null object, should return zero
        [TestMethod()]
        public void GetTotalArea_Null_ShouldReturnZero()
        {
            var calc = new GeometricCalculator();
            var actual = calc.GetTotalArea(null);
            Assert.AreEqual(0, actual);
        }

        //Tests GetTotalArea method with an empty array, should return zero
        [TestMethod()]
        public void GetTotalArea_EmptyArray_ShouldReturnZero()
        {
            var calc = new GeometricCalculator();
            var shapes = new GeometricShapes[0];

            var actual = calc.GetTotalArea(shapes);
            Assert.AreEqual(0, actual);
        }

        //Tests GetTotalArea method with negative parameters for objects, should return zero
        [TestMethod()]
        public void GetTotalArea_Negative_ShouldReturnZero()
        {
            var calc = new GeometricCalculator();
            var shapes = new GeometricShapes[]
            {
                new Circle(-5),
                new Square(0),
                new Rectangle(float.MaxValue, float.MaxValue),
                new IsocelesTriangle(-0.4f)
            };

            var actual = calc.GetTotalArea(shapes);
            Assert.AreEqual(0, actual);
        }

        //Tests GetTotalArea method with positive parameter for objects, should return sum of total area
        [TestMethod()]
        public void GetTotalArea_Positive_ShouldReturnTotalArea()
        {
            var calc = new GeometricCalculator();
            var shapes = new GeometricShapes[]
            {
                new Circle(5),
                new Square(4),
                new Rectangle(4, 5),
                new IsocelesTriangle(5)
            };

            var actual = calc.GetTotalArea(shapes);
            Assert.AreEqual(125.37f, actual);
        }

        //Tests GetTotalPerimiter method with null object, should return zero
        [TestMethod()]
        public void GetTotalPerimiter_Null_ShouldReturnZero()
        {
            var calc = new GeometricCalculator();
            var actual = calc.GetTotalPerimiter(null);
            Assert.AreEqual(0, actual);
        }

        //Tests GetTotalPerimiter method with an empty array, should return zero
        [TestMethod()]
        public void GetTotalPerimiter_EmptyArray_ShouldReturnZero()
        {
            var calc = new GeometricCalculator();
            var shapes = new GeometricShapes[0];

            var actual = calc.GetTotalPerimiter(shapes);
            Assert.AreEqual(0, actual);
        }

        //Tests GetTotalPerimiter method with negative parameter for objects, should return zero
        [TestMethod()]
        public void GetTotalPerimiter_Negative_ShouldReturnZero()
        {
            var calc = new GeometricCalculator();
            var shapes = new GeometricShapes[]
            {
                new Circle(-5),
                new Square(0),
                new Rectangle(float.MaxValue, float.MaxValue),
                new IsocelesTriangle(-0.4f)
            };

            var actual = calc.GetTotalPerimiter(shapes);
            Assert.AreEqual(0, actual);
        }

        //Tests GetTotalPerimiter method with positive parameter for objects, should return sum of perimiter
        [TestMethod()]
        public void GetTotalPerimiter_Positive_ShouldReturnTotalPerimiter()
        {
            var calc = new GeometricCalculator();
            var shapes = new GeometricShapes[]
            {
                new Circle(5),
                new Square(5),
                new Rectangle(4, 4),
                new IsocelesTriangle(5)
            };

            var actual = calc.GetTotalPerimiter(shapes);
            Assert.AreEqual(82.42f, actual);
        }
    }
}