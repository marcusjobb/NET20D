namespace GeometricThings.Geometry.Tests
{
    using GeometricThings.Extensions;
    using GeometricThings.Geometry;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines the <see cref="SquareTests" />.
    /// </summary>
    [TestClass()]
    public class SquareTests
    {
        /// <summary>
        /// Tests The GetPerimeter() method by valid and invalid amount
        /// </summary>
        /// <param name="side">The side<see cref="float"/>.</param>
        /// <param name="expectedValue">The expectedValue<see cref="float"/>.</param>
        [TestMethod()]
        [DataRow(0, 0)]
        [DataRow(-3, 0)]
        [DataRow(4, 16)]
        [DataRow(1.22404F, 4.8962F)]

        public void GetPerimeterTest(float side, float expectedValue)
        {
            var square = new Square(side);
            var actual = square.GetPerimeter().NiceRound();
            Assert.AreEqual(actual, expectedValue);
        }

        /// <summary>
        /// Tests The GetArea() method by valid and invalid amount
        /// </summary>
        /// <param name="side">The side<see cref="float"/>.</param>
        /// <param name="expectedValue">The expectedValue<see cref="float"/>.</param>
        [TestMethod()]
        [DataRow(0, 0)]
        [DataRow(-3, 0)]
        [DataRow(4, 16)]
        [DataRow(1.22404F, 1.4983F)]

        public void GetAreaTest(float side, float expectedValue)
        {
            var square = new Square(side);
            var actual = square.GetArea().NiceRound();
            Assert.AreEqual(actual, expectedValue);
        }
    }
}
