using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometry.Library;

namespace Geometry.Library.Tests
{
    /// <summary>
    /// Tests every declared baseLength in combination with all of the declared heights and makes sure the areal/perimeter is correctly calculated.
    /// Both negative and positive values are tested, as well as null.
    /// </summary>
    [TestFixture]
    class RectangleTests
    {       
        [Test]
        public void GetArea_Rectangle_ShouldWork([Values(4, 5.5)] double baseLength, [Values(3, 4)] double height)
        {
            IGeometricThing rectangle = new Rectangle(baseLength, height);
            var expected = baseLength * height;
            var actual = rectangle.GetArea();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetArea_Rectangle_HandleNull([Values(null)] double baseLength, [Values(null)] double height)
        {
            IGeometricThing rectangle = new Rectangle(baseLength, height);
            var expected = baseLength * height;
            var actual = rectangle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetArea_Rectangle_NegativeBase_ShouldReturnZero([Values(-4)] double baseLength, [Values(2)] double height)
        {
            IGeometricThing rectangle = new Rectangle(baseLength, height);
            var expected = 0;
            var actual = rectangle.GetArea();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetArea_Rectangle_NegativeHeight_ShouldReturnZero([Values(3)] double baseLength, [Values(-2)] double height)
        {
            IGeometricThing rectangle = new Rectangle(baseLength, height);
            var expected = 0;
            var actual = rectangle.GetArea();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetArea_Rectangle_AllNegatives_ShouldReturnZero([Values(-3)] double baseLength, [Values(-2)] double height)
        {
            IGeometricThing rectangle = new Rectangle(baseLength, height);
            var expected = 0;
            var actual = rectangle.GetArea();
            Assert.AreEqual(expected, actual);
        }
    
        [Test]
        public void GetPerimeter_Rectangle_ShouldWork([Values(4, 7.5)] double baseLength, [Values(3, 2)] double height)
        {
            IGeometricThing rectangle = new Rectangle(baseLength, height);
            var expected = (baseLength * 2) + (height * 2);
            var actual = rectangle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPerimeter_Rectangle_HandleNull([Values(null)] double baseLength, [Values(null)] double height)
        {
            IGeometricThing rectangle = new Rectangle(baseLength, height);
            var expected = (baseLength * 2) + (height * 2);
            var actual = rectangle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPerimeter_Rectangle_NegativeBase_ShouldReturnZero([Values(-8)] double baseLength, [Values(3, 2, 6)] double height)
        {
            IGeometricThing rectangle = new Rectangle(baseLength, height);
            var expected = 0;
            var actual = rectangle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetPerimeter_Rectangle_NegativeHeight_ShouldReturnZero([Values(8, 4.5, 16)] double baseLength, [Values(-3)] double height)
        {
            IGeometricThing rectangle = new Rectangle(baseLength, height);
            var expected = 0;
            var actual = rectangle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetPerimeter_Rectangle_AllNegatives_ShouldReturnZero([Values( -16)] double baseLength, [Values(-4, -2, -8)] double height)
        {
            IGeometricThing rectangle = new Rectangle(baseLength, height);
            var expected = 0;
            var actual = rectangle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}
