namespace GeometryTests
{
    using Geometry.GeometricThings;
    using NUnit.Framework;

    public class RectangleTests
    {
        [TestCase(5, 3, 15)]
        [TestCase(4.2f, 8.6f, 36.12f)]
        public void AreaTest_PositiveInput_ReturnsArea(
            float height,
            float width,
            float expected)
        {
            var rectangle = new Rectangle { Height = height, Width = width };
            var actual = rectangle.Area();
            Assert.That(actual, Is.EqualTo(expected).Within(.05));
        }

        [TestCase(-4, 8, 0)]
        [TestCase(4, -8, 0)]
        public void AreaTest_NegativeInput_ReturnsZero(
            float height,
            float width,
            float expected)
        {
            var rectangle = new Rectangle { Height = height, Width = width };
            var actual = rectangle.Area();
            Assert.That(actual, Is.EqualTo(expected).Within(.05));
        }

        [TestCase(5, 3, 16)]
        [TestCase(2.5f, 4.2f, 13.4f)]
        public void PerimiterTest_PositiveInput_ReturnsPerimiter(float height, float width, float expected)
        {
            var rectangle = new Rectangle { Height = height, Width = width };
            var actual = rectangle.Perimiter();
            Assert.That(actual, Is.EqualTo(expected).Within(.05));
        }

        [TestCase(-4, 8, 0)]
        [TestCase(4, -8, 0)]
        public void PerimiterTest_NegativeInput_ReturnsZero(float height, float width, float expected)
        {
            var rectangle = new Rectangle { Height = height, Width = width };
            var actual = rectangle.Perimiter();
            Assert.That(actual, Is.EqualTo(expected).Within(.05));
        }
    }
}
