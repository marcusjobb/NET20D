namespace GeometricThings.Geometry.Tests
{
    using GeometricThings.Geometry;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GeometricThings.Extensions;

    /// <summary>
    /// Defines the <see cref="TriangleTests" />.
    /// </summary>
    [TestClass()]
    public class TriangleTests
    {
        /// <summary>
        /// Tests The GetArea() method by valid and invalid amount
        /// </summary>
        /// <param name="side">The side<see cref="float"/>.</param>
        /// <param name="height">The height<see cref="float"/>.</param>
        /// <param name="expectedValue">The expectedValue<see cref="float"/>.</param>
        [TestMethod()]
        [DataRow(-3, -2, 0)]
        [DataRow(0, 3, 0)]
        [DataRow(3, 2, 3)]
        [DataRow(2.0003F, 0.000214F, 0.0002F)]

        public void GetAreaTest(float side, float height, float expectedValue)
        {
            var triangle = new Triangle(side, height);
            var actual = triangle.GetArea().NiceRound();
            Assert.AreEqual(actual, expectedValue);
        }

        /// <summary>
        /// Tests The GetPerimeter() method by valid and invalid amount
        /// </summary>
        /// <param name="side">The side<see cref="float"/>.</param>
        /// <param name="height">The height<see cref="float"/>.</param>
        /// <param name="expectedValue">The expectedValue<see cref="float"/>.</param>
        [TestMethod()]
        [DataRow(-3, -2, 0)]
        [DataRow(0, 3, 0)]
        [DataRow(3, 2, 8)]
        [DataRow(2.0003F, 0.000214F, 4.0008F)]

        public void GetPerimeterTest(float side, float height, float expectedValue)
        {
            var triangle = new Triangle(side, height);
            var actual = triangle.GetPerimeter().NiceRound();
            Assert.AreEqual(actual, expectedValue);
        }
    }
}
