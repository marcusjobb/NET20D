using Geometri.GeometricObjects;
using NUnit.Framework;
using System.Collections.Generic;

namespace Geometri
{
    /// <summary>
    /// Class for testing all Geometric objects
    /// </summary>
    [TestFixture]
    public class TDDSuite
    {
        const float MaxFloatSquareRoot = 1.844674225981379e+19f - 1.0f;
        /// <summary>
        /// Tests to create geometric objects with many kinds of input.
        /// Tests if Circumference and Area are greater than 0.0f,
        /// since distances (the side or radius of an object) must be greater than 0.0f.
        /// Tests with NaN, float.MaxValue, float.MinValue, 1.0f, -1.0f, 0.0f
        /// </summary>
        [Test]
        [TestCase(1.0f, 1.0f)]
        [TestCase(1.0f, -1.0f)]
        [TestCase(-1.0f, 1.0f)]
        [TestCase(-1.0f, -1.0f)]
        [TestCase(0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f)]
        [TestCase(0.0f, 0.0f)]
        [TestCase(float.NaN, 1.0f)]
        [TestCase(1.0f, float.NaN)]
        [TestCase(float.NaN, float.NaN)]
        [TestCase(float.MaxValue, 1.0f)]
        [TestCase(1.0f, float.MaxValue)]
        [TestCase(float.MaxValue, -1.0f)]
        [TestCase(-1.0f, float.MaxValue)]
        [TestCase(float.MaxValue, float.MaxValue)]
        [TestCase(float.MaxValue, float.MinValue)]
        [TestCase(float.MinValue, float.MaxValue)]
        [TestCase(float.MinValue, float.MinValue)]
        [TestCase(MaxFloatSquareRoot, MaxFloatSquareRoot)]
        public void TestInput(float r1 = 1.0f, float r2 = 1.0f)
        {
            var geoThingsList = new List<GeometricThing>()
            {
                new Circle(r1),
                new Ellipse(r1, r2),
                new Rectangle(r1, r2),
                new Square(r1),
                new Triangle(r1, r2)
            };

            var geoThingsArray = new GeometricThing[]
            {
                new Circle(r1),
                new Ellipse(r1, r2),
                new Rectangle(r1, r2),
                new Square(r1),
                new Triangle(r1, r2)
            };

            Assert.IsNotNull(geoThingsArray);
            Assert.IsNotNull(geoThingsList);

            foreach (var item in geoThingsList)
            {
                Assert.IsNotNull(item);
                Assert.IsTrue(GeometricCalculator.GetCircumference(item).CompareTo(0.0f) == 1);
                Assert.IsTrue(GeometricCalculator.GetArea(item).CompareTo(0.0f) == 1);
            }

            for (int i = 0; i < geoThingsArray.Length; i++)
            {
                Assert.IsNotNull(geoThingsArray[i]);
                Assert.IsTrue(GeometricCalculator.GetCircumference(geoThingsArray[i]).CompareTo(0.0f) == 1);
                Assert.IsTrue(GeometricCalculator.GetArea(geoThingsArray[i]).CompareTo(0.0f) == 1);
            }

            Assert.IsNotNull(GeometricCalculator.GetArea(geoThingsList));
            Assert.IsTrue(GeometricCalculator.GetArea(geoThingsList).CompareTo(0.0f) == 1);
            Assert.IsNotNull(GeometricCalculator.GetCircumference(geoThingsList));
            Assert.IsTrue(GeometricCalculator.GetCircumference(geoThingsList).CompareTo(0.0f) == 1);
            Assert.IsNotNull(GeometricCalculator.GetArea(geoThingsArray));
            Assert.IsTrue(GeometricCalculator.GetArea(geoThingsArray).CompareTo(0.0f) == 1);
            Assert.IsNotNull(GeometricCalculator.GetCircumference(geoThingsArray));
            Assert.IsTrue(GeometricCalculator.GetCircumference(geoThingsArray).CompareTo(0.0f) == 1);
        }
    }
}
