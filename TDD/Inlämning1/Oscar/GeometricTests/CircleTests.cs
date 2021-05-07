using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TDDInlämning1;

namespace GeometricTests
{
    class CircleTests
    {
        /// <summary>
        /// skickar in rätt värden för att testa cirkelns area metod
        /// </summary>
        [TestCase(8, 201.06)]
        [TestCase(5.4, 91.56)]
        public void AreaTest_Valid_ReturnsAreaValue(double radius, double expected)
        {
            var circle = new Circle(radius);
            var actual = circle.Area();
            Assert.That(actual, Is.EqualTo(expected).Within(0.05));
        }
        /// <summary>
        /// skickar in fel värden för att testa cirkelns area metod
        /// </summary>
        [TestCase(0, 0)]
        [TestCase(-5, 0)]
        public void AreaTest_Invalid_ReturnsZero(double radius, double expected)
        {
            var circle = new Circle(radius);
            var actual = circle.Area();
            Assert.That(actual, Is.EqualTo(expected).Within(0.05));
        }
        /// <summary>
        /// skickar in rätt värden för att testa cirkelns omkrets metod
        /// </summary>
        [TestCase(8, 50.24)]
        [TestCase(3.7, 23.24)]
        public void PerimiterTest_Valid_ReturnsPerimiterValue(double radius, double expected)
        {
            var circle = new Circle(radius);
            var actual = circle.Perimeter();
            Assert.That(actual, Is.EqualTo(expected).Within(0.05));
        }
        /// <summary>
        /// skickar in fel värden för att testa cirkelns omkrets metod
        /// </summary>
        [TestCase(0, 0)]
        [TestCase(-4, 0)]
        public void PerimiterTest_Invalid_ReturnsZero(double radius, double expected)
        {
            var circle = new Circle(radius);
            var actual = circle.Perimeter();
            Assert.That(actual, Is.EqualTo(expected).Within(0.05));
        }
    }
}