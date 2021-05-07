using Inlämning1.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inlämning1.Calculator.Tests
{
    /// <summary>
    /// Testar samtliga shapes
    /// </summary>

    [TestClass()]
    public class GeometricCalculatorTests
    {
        private GeometricThing circle;
        private GeometricThing triangle;
        private GeometricThing square;
        private GeometricThing[] geoThings;

        [TestCleanup]
        public void TestClean()
        {
            circle = null;
            triangle = null;
            square = null;
            geoThings = null;
        }

        [TestInitialize]
        public void Vars()
        {
            circle = new Circle(radius:10);
            triangle = new Triangle(height:5, tbase:5);
            square = new Rectangle(height: 10, widht: 10);
            geoThings = new GeometricThing[]
            {
               new Rectangle(height:10, widht:10),//100
               new Rectangle(height:10, widht:10),//100
               new Triangle(height:10, tbase:12),//60
               new Circle(radius:7) // riktig uträkning 43,982297150257105338477007365913 sammanlagt för alla 303.9823
            };
        }

        /// <summary>
        /// Testar enkla uträkningar på samtliga geometriska former
        /// </summary>
        [TestMethod()]
        public void GetAreaTest_SingelShape_value()
        {
            //arrange
            var expected = 100;
            //Act
            var actual = GeometricCalculator.GetArea(square);
            //Assert
            Assert.AreEqual(expected, actual, 05);
        }

        [TestMethod()]
        public void GetAreaTest_ArrayShape_value()
        {
            //arrange
            const double expected = 303.9823;
            //Act
            var actual = GeometricCalculator.GetArea(geoThings);
            //Assert
            Assert.AreEqual(expected, actual, 0.05);
        }
        [TestMethod()]
        public void GetPerimeterTest_SingleShape_value()
        {
            var expected = 40;
            var actual = GeometricCalculator.GetPerimeter(square);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetPerimeterTest_ArrayShape_Value()
        {
            float expected = 126;
            var actual = GeometricCalculator.GetPerimeter(geoThings);
            Assert.AreEqual(expected, actual, 0.05);
        }
    }
}