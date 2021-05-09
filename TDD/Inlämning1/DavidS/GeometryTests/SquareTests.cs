namespace GeometryTests
{
    using Geometry.GeometricThings;
    using NUnit.Framework;

    public class SquareTests
    {
        [TestCase(0.2f, 0.04f)]
        [TestCase(4, 16)]
        public void AreaTest_PositiveInput_ReturnsArea(float side, float expected)
        {
            var square = new Square { Side = side };
            var actual = square.Area();
            Assert.That(actual, Is.EqualTo(expected).Within(.05));
        }

        [TestCase(-5, 0)]
        public void AreaTest_NegativeInput_ReturnsZero(float side, float expected)
        {
            var square = new Square { Side = side };
            var actual = square.Area();
            Assert.That(actual, Is.EqualTo(expected).Within(.05));
        }

        [TestCase(5, 20)]
        [TestCase(2.5f, 10)]
        public void PerimiterTest_PositiveInput_ReturnsPerimiter(float side, float expected)
        {
            var square = new Square { Side = side };
            var actual = square.Perimiter();
            Assert.That(actual, Is.EqualTo(expected).Within(.05));
        }

        [TestCase(-2, 0)]
        public void PerimiterTest_NegativeInput_ReturnsZero(float side, float expected)
        {
            var square = new Square { Side = side };
            var actual = square.Perimiter();
            Assert.That(actual, Is.EqualTo(expected).Within(.05));
        }
    }
}
