namespace TDDInlamning1_MLarsson.GeometricThings.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TDDInlamning1_MLarsson.Tests;

    [TestClass()]
    public class SquareTests
    {
        [TestMethod()]
        [DataRow(0f, 0f)]
        [DataRow(-4f, 0f)]
        [DataRow(null, 0f)]
        public void GetArea_SquareTest_NegativeResult(float side, float expected)
        {
            GeometricThing square = new Square(side);
            var actual = square.GetArea();
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod()]
        [DataRow(4f, 16f)]
        [DataRow(4.123456789f, 17.0029f)]
        public void GetArea_SquareTest_PositiveResult(float side, float expected)
        {
            GeometricThing square = new Square(side);
            var actual = square.GetArea();
            Assert.AreEqual(expected, actual, 0.0001);
        }
        [TestMethod()]
        [DataRow(0f, 0f)]
        [DataRow(-4f, 0f)]
        [DataRow(null, 0f)]
        public void GetPerimeter_SquareTest_NegativeResult(float side, float expected)
        {
            GeometricThing square = new Square(side);
            var actual = square.GetPerimeter();
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod()]
        [DataRow(10f, 40f)]
        [DataRow(4.123456789f, 16.4938f)]
        public void GetPerimeter_SquareTest_PositiveResult(float side, float expected)
        {
            GeometricThing square = new Square(side);
            var actual = square.GetPerimeter();
            Assert.AreEqual(expected, actual, 0.0001);
        }
    }
}