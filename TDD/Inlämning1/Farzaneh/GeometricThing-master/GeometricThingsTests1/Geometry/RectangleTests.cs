namespace GeometricThings.Geometry.Tests
{
    using GeometricThings.Geometry;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GeometricThings.Extensions;

    /// <summary>
    /// Defines the <see cref="RectangleTests" />.
    /// </summary>
    [TestClass()]
    public class RectangleTests
    {
        /// <summary>
        /// Tests the GetPerimeter() method by valid and invalid amount
        /// </summary>
        /// <param name="width">The width<see cref="float"/>.</param>
        /// <param name="height">The height<see cref="float"/>.</param>
        /// <param name="expectedValue">The expectedValue<see cref="float"/>.</param>
        [TestMethod()]
        [DataRow(-3, -6, 0)]
        [DataRow(-2, .0000004F, 0)]
        [DataRow(0, 2, 0)]
        [DataRow(1, 2, 6)]
        [DataRow(2.400007F, 3.91101F, 12.6220F)]

        public void GetPerimeterTest(float width, float height, float expectedValue)
        {
            var rect = new Rectangle(width, height);
            var actual = rect.GetPerimeter().NiceRound();
            Assert.AreEqual(actual, expectedValue);
        }

        /// <summary>
        /// Tests the GetArea() method by valid and invalid amount
        /// </summary>
        /// <param name="width">The width<see cref="float"/>.</param>
        /// <param name="height">The height<see cref="float"/>.</param>
        /// <param name="expectedValue">The expectedValue<see cref="float"/>.</param>
        [TestMethod()]
        [DataRow(-3, -6, 0)]
        [DataRow(-2, .0000004F, 0)]
        [DataRow(0, 2, 0)]
        [DataRow(1, 2, 2)]
        [DataRow(2.400007F, 3.91101F, 9.3865F)]

        public void GetAreaTest(float width, float height, float expectedValue)
        {
            var rect = new Rectangle(width, height);
            var actual = rect.GetArea().NiceRound();
            Assert.AreEqual(actual, expectedValue);
        }
    }
}
