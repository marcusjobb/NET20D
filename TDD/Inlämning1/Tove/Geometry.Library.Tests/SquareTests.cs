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
    /// Tests that areal/perimeter is correctly calculated with base length as a given parameter.
    /// Both negative and positive values are tested, as well as null.
    /// </summary>
    [TestFixture]
    class SquareTests
    {
        [Test]
        public void GetArea_Square_ShouldWork([Values(4, 5, 6, 7.5, 8.5, 0.5)] double baseLength)
        {
            IGeometricThing square = new Square(baseLength);
            var expected = baseLength * baseLength;
            var actual = square.GetArea();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetArea_Square_HandleNull([Values(null)] double baseLength)
        {
            IGeometricThing square = new Square(baseLength);
            var expected = baseLength * baseLength;
            var actual = square.GetArea();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetArea_Square_Negative_ShouldReturnZero([Values(-4, -4.5, -8)] double baseLength)
        {
            IGeometricThing square = new Square(baseLength);
            var expected = 0;
            var actual = square.GetArea();
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void GetPerimeter_Square_ShouldWork([Values(4, 5, 6, 7.5, 8.5, 0.5)] double baseLength)
        {
            IGeometricThing square = new Square(baseLength);
            var expected = baseLength * 4;
            var actual = square.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPerimeter_Square_HandleNull([Values(null)] double baseLength)
        {
            IGeometricThing square = new Square(baseLength);
            var expected = baseLength * 4;
            var actual = square.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPerimeter_Square_Negative_ShouldReturnZero([Values(-8, -4.5, -16)] double baseLength)
        {
            IGeometricThing square = new Square(baseLength);
            var expected = 0;
            var actual = square.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
     
    }
}
