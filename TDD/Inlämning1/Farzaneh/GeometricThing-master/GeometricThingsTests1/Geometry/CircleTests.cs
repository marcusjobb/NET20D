namespace GeometricThings.Geometry.Tests
{
    using GeometricThings.Extensions;
    using GeometricThings.Geometry;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines the <see cref="CircleTests" />.
    /// </summary>
    [TestClass()]
    public class CircleTests
    {
        /// <summary>
        /// Tests the GetArea() method by valid and invalid amount
        /// </summary>
        /// <param name="radius">The radius<see cref="float"/>.</param>
        /// <param name="expectedValue">The expectedValue<see cref="float"/>.</param>
        [TestMethod()]
        [DataRow(0, 0)]
        [DataRow(-4, 0)]
        [DataRow(4, 50.2655F)]

        public void GetAreaTest(float radius, float expectedValue)
        {
            var circle = new Circle(radius);
            var actual = circle.GetArea().NiceRound();
            Assert.AreEqual(actual, expectedValue);
        }

        /// <summary>
        /// Tests The GetPerimeter() method by valid and invalid amount
        /// </summary>
        /// <param name="radius">The radius<see cref="float"/>.</param>
        /// <param name="expectedValue">The expectedValue<see cref="float"/>.</param>
        [TestMethod()]
        [DataRow(0, 0)]
        [DataRow(-4, 0)]
        [DataRow(4, 25.1327F)]

        public void GetPerimeterTest(float radius, float expectedValue)
        {
            var circle = new Circle(radius);
            var actual = circle.GetPerimeter().NiceRound();
            Assert.AreEqual(actual, expectedValue);
        }
    }
}
