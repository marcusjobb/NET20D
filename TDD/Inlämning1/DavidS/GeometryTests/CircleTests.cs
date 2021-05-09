namespace GeometryTests
{
    using Geometry.GeometricThings;
    using NUnit.Framework;

    public class CircleTests
    {
        [TestCase(3, 28.2743f)]
        [TestCase(6.3f, 124.6898f)]
        public void AreaTest_PositiveInput_ReturnsArea(float radius, float expected)
        {
            var circle = new Circle { Radius = radius };
            var actual = circle.Area();
            Assert.That(actual, Is.EqualTo(expected).Within(.05));
        }

        [TestCase(-1, 0)]
        public void AreaTest_NegativeInput_ReturnsZero(float radius, float expected)
        {
            var circle = new Circle { Radius = radius };
            var actual = circle.Area();
            Assert.That(actual, Is.EqualTo(expected).Within(.05));
        }

        [TestCase(3, 18.8496f)]
        [TestCase(6.3f, 39.5841f)]
        public void PerimiterTest_PositiveInput_ReturnsPerimiter(float radius, float expected)
        {
            var circle = new Circle { Radius = radius };
            var actual = circle.Perimiter();
            Assert.That(actual, Is.EqualTo(expected).Within(.05));
        }

        [TestCase(-2.5f, 0)]
        public void PerimiterTest_NegativeInput_ReturnsZero(float radius, float expected)
        {
            var circle = new Circle { Radius = radius };
            var actual = circle.Perimiter();
            Assert.That(actual, Is.EqualTo(expected).Within(.05));
        }
    }
}
