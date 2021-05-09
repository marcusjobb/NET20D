namespace GeometryTests
{
    using Geometry;
    using Geometry.Abstracts;
    using Geometry.GeometricThings;
    using NUnit.Framework;
    using System;

    public class GeometricCalculatorTests
    {
        private GeometryCalculator calculator;
        private GeometricThing[] nullThings;
        private GeometricThing[] noThings;
        private GeometricThing[] positiveThings;
        private GeometricThing[] negativeThings;

        [SetUp]
        public void Setup()
        {
            calculator = new GeometryCalculator();
            nullThings = null;
            noThings = Array.Empty<GeometricThing>();
            positiveThings = new GeometricThing[]
            {
                new Square { Side = 5 },
                new Rectangle { Height = 2.5f, Width = 4.2f },
                new Circle { Radius = 3 },
                new Triangle { Base = 2.3f, Height = 5.2f }
            };

            negativeThings = new GeometricThing[]
            {
                new Square { Side = -5 },
                new Rectangle { Height = -2.5f, Width = 4.2f },
                new Circle { Radius = -3f },
                new Triangle { Base = -2.3f, Height = -5.2f }
            };
        }

        [TearDown]
        public void TearDown()
        {
            calculator = null;
            nullThings = null;
            noThings = null;
            positiveThings = null;
            negativeThings = null;
        }

        [Test]
        public void GetPerimitersTest_PositiveArray_ReturnsSumOfPerimiters()
        {
            const float Expected = 59.1496f;
            var actual = calculator.GetPerimiters(positiveThings);
            Assert.That(actual, Is.EqualTo(Expected).Within(.05));
        }

        [Test]
        public void GetPerimitersTest_NegativeArray_ReturnsZero()
        {
            const float Expected = 0.0f;
            var actual = calculator.GetPerimiters(negativeThings);
            Assert.That(actual, Is.EqualTo(Expected).Within(.05));
        }

        [Test]
        public void GetPerimitersTest_NullArray_ReturnsZero()
        {
            const float Expected = 0.0f;
            var actual = calculator.GetPerimiters(nullThings);
            Assert.That(actual, Is.EqualTo(Expected).Within(.05));
        }

        [Test]
        public void GetPerimitersTest_EmptyArray_ReturnsZero()
        {
            const float Expected = 0.0f;
            var actual = calculator.GetPerimiters(noThings);
            Assert.That(actual, Is.EqualTo(Expected).Within(.05));
        }

        [Test]
        public void GetAreasTest_PositiveArray_ReturnsSumOfAreas()
        {
            const float Expected = 69.7543f;
            var actual = calculator.GetAreas(positiveThings);
            Assert.That(actual, Is.EqualTo(Expected).Within(.05));
        }

        [Test]
        public void GetAreasTest_NegativeArray_ReturnsZero()
        {
            const float Expected = 0.0f;
            var actual = calculator.GetAreas(negativeThings);
            Assert.That(actual, Is.EqualTo(Expected).Within(.05));
        }

        [Test]
        public void GetAreasTest_NullArray_ReturnsZero()
        {
            const float Expected = 0.0f;
            var actual = calculator.GetAreas(nullThings);
            Assert.That(actual, Is.EqualTo(Expected).Within(.05));
        }

        [Test]
        public void GetAreasTest_EmptyArray_ReturnsZero()
        {
            const float Expected = 0.0f;
            var actual = calculator.GetAreas(noThings);
            Assert.That(actual, Is.EqualTo(Expected).Within(.05));
        }
    }
}