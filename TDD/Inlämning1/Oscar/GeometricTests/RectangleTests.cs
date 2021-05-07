using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TDDInlämning1;

namespace GeometricTests
{
    class RectangleTests
    {
        /// <summary>
        /// skickar in rätt värden för att testa rektangelns area metod
        /// </summary>
        [TestCase(4, 3, 12)]
        [TestCase(4.9, 2.7, 13.23)]
        public void AreaTest_Valid_ReturnsAreaValue(double length, double height, double expected)
        {
            var rectangle = new Rectangle(length, height);
            var actual = Math.Round(rectangle.Area(), 2);
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// skickar in fel värden för att testa triangelns area metod
        /// </summary>
        [TestCase(0, 2, 0)]
        [TestCase(2, 0, 0)]
        [TestCase(-4, 3, 0)]
        [TestCase(3, -4, 0)]
        public void AreaTest_Invalid_ReturnsZero(double length, double height, double expected)
        {
            var rectangle = new Rectangle(length, height);
            var actual = Math.Round(rectangle.Area(), 2);
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// skickar in rätt värden för att testa rektangelns omkrets metod
        /// </summary>
        [TestCase(3, 7, 20)]
        [TestCase(5.2, 13.9, 38.2)]
        public void PerimiterTest_Valid_ReturnsPerimiterValue(double length, double height, double expected)
        {
            var rectangle = new Rectangle(length, height);
            var actual = Math.Round(rectangle.Perimeter(), 2);
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// skickar in fel värden för att testa rektangelns omkrets metod
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        /// <param name="expected"></param>
        [TestCase(0, 2, 0)]
        [TestCase(2, 0, 0)]
        [TestCase(-4, 2, 0)]
        [TestCase(2, -4, 0)]
        public void PerimiterTest_Invalid_ReturnsZero(double length, double height, double expected)
        {
            var rectangle = new Rectangle(length, height);
            var actual = Math.Round(rectangle.Perimeter(), 2);
            Assert.AreEqual(actual, expected);
        }
    }
}
