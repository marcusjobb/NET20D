namespace GeometryTests
{
    using Geometry.GeometricThings;
    using NUnit.Framework;

    public class TriangleTests
    {
        [TestCase(5, 12, 30)]
        [TestCase(2.3f, 1.4f, 1.61f)]
        public void AreaTest_PositiveInput_ReturnsArea(
            float tBase,
            float height,
            float expected)
        {
            var triangle = new Triangle { Base = tBase, Height = height };
            var actual = triangle.Area();
            Assert.That(actual, Is.EqualTo(expected).Within(.05));
        }

        [TestCase(10, -2, 0)]
        [TestCase(-23, 10, 0)]
        public void AreaTest_NegativeInput_ReturnsZero(
            float tBase,
            float height,
            float expected)
        {
            var triangle = new Triangle { Base = tBase, Height = height };
            var actual = triangle.Area();
            Assert.That(actual, Is.EqualTo(expected).Within(.05));
        }

        [TestCase(5, 15)]
        [TestCase(2.3f, 6.9f)]
        public void PerimiterTest_PositiveInput_ReturnsPerimiter(float tBase, float expected)
        {
            var triangle = new Triangle { Base = tBase };
            var actual = triangle.Perimiter();
            Assert.That(actual, Is.EqualTo(expected).Within(.05));
        }

        [TestCase(-14, 0)]
        public void PerimiterTest_NegativeInput_ReturnsZero(float tBase, float expected)
        {
            var triangle = new Triangle { Base = tBase };
            var actual = triangle.Perimiter();
            Assert.That(actual, Is.EqualTo(expected).Within(.05));
        }
    }
}
