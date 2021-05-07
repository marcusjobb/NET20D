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
    class TriangleTests
    {
        [Test]
        public void GetArea_Triangle_ShouldWork([Values(6, 8, 10, 11.5, 13.5, 0.5)] double baseLength)
        {
            IGeometricThing triangle = new Triangle(baseLength);
            var expected = (baseLength * baseLength) / 2;
            var actual = triangle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetArea_Triangle_HandleNull([Values(null)] double baseLength)
        {
            IGeometricThing triangle = new Triangle(baseLength);
            var expected = (baseLength * baseLength) / 2;
            var actual = triangle.GetArea();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetArea_Triangle_Negative_ShouldReturnZero([Values(-4, -4.5, -8)] double baseLength)
        {
            IGeometricThing triangle = new Triangle(baseLength);
            var expected = 0;
            var actual = triangle.GetArea();
            Assert.AreEqual(expected, actual);
        }       
       
        [Test]
        public void GetPerimeter_Triangle_ShouldWork([Values(6, 8, 10, 11.5, 13.5, 0.5)] double baseLength)
        {
            IGeometricThing triangle = new Triangle(baseLength);
            var expected = baseLength * 3;
            var actual = triangle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetPerimeter_Triangle_HandleNull([Values(null)] double baseLength)
        {
            IGeometricThing triangle = new Triangle(baseLength);
            var expected = baseLength * 3;
            var actual = triangle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPerimeter_Triangle_NegativeBase_ShouldReturnZero([Values(-8, -4.5, -16)] double baseLength)
        {
            IGeometricThing triangle = new Triangle(baseLength);
            var expected = 0;
            var actual = triangle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}
