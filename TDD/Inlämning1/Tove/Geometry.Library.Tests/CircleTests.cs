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
    /// Tests that areal/perimeter is correctly calculated with radius as a given parameter.
    /// Both negative and positive values are tested, as well as null.
    /// </summary>
    [TestFixture]  
    class CircleTests
    {
        [Test]
        public void GetArea_Circle_ShouldWork([Values(4, 5, 6, 7.5, 8.5, 0.1)] double radius)
        {
            IGeometricThing circle = new Circle(radius);
            var expected = radius * radius * Math.PI;
            var actual = circle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetArea_Circle_HandleNull([Values(null)] double radius)
        {
            IGeometricThing circle = new Circle(radius);
            var expected = radius * radius * Math.PI;
            var actual = circle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetArea_Circle_Negative_ShouldReturnZero([Values(-4, -4.5, -8)] double radius)
        {
            IGeometricThing circle = new Circle(radius);
            var expected = 0;
            var actual = circle.GetArea();
            Assert.AreEqual(expected, actual);
        }
     
        [Test]
        public void GetPerimeter_Circle_ShouldWork([Values(4, 5, 6, 7.5, 8.5, 0.1)] double radius)
        {
            IGeometricThing circle = new Circle(radius);
            var expected = (radius + radius) * Math.PI;
            var actual = circle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPerimeter_Circle_HandleNull([Values(null)] double radius)
        {
            IGeometricThing circle = new Circle(radius);
            var expected = (radius + radius) * Math.PI;
            var actual = circle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPerimeter_Circle_Negative_ShouldReturnZero([Values(-4, -4.5, -8)] double radius)
        {
            IGeometricThing circle = new Circle(radius);
            var expected = 0;
            var actual = circle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}
