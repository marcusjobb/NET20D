
namespace TDDGeometric.GeometricThings.GeoShapes.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class SquareTests
    {
        [TestMethod()]
        [DataRow(4, 16)]
        [DataRow(0, 0)]
        [DataRow(3.16f, 9.99f)]
        [DataRow(-3.16f, 0)]
        public void GetAreaTest(float side, float expected)
        {
            var square = new Square(side);
            var actual = square.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(4,16)]
        [DataRow(0,0)]
        [DataRow(3.16f, 12.64f)]
        [DataRow(-3.16f, 0)]
        public void GetPerimiterTest(float side, float expected)
        {
            var square = new Square(side);
            var actual = square.GetPerimiter();
            Assert.AreEqual(expected, actual);
        }
    }
}