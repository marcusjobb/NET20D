using NUnit.Framework;
using System;
using TDDInlämning1;

namespace GeometricTests
{
    class SquareTests
    {
        /// <summary>
        /// skickar in rätt värden för att testa fyrkantens area metod
        /// </summary>
        [TestCase(4, 16)]
        [TestCase(4.3, 18.49)]
        public void AreaTest_Valid_ReturnsAreaValue(double length, double expected)
        {
            var square = new Square(length);
            var actual = Math.Round(square.Area(), 2);
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// skickar in fel värden för att testa fyrkantens area metod
        /// </summary>
        [TestCase(0, 0)]
        [TestCase(-5, 0)]
        public void AreaTest_Invalid_ReturnsZero(double length, double expected)
        {
            var square = new Square(length);
            var actual = Math.Round(square.Area(), 2);
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// skickar in rätt värden för att testa fyrkantens omkrets metod
        /// </summary>
        [TestCase(6, 24)]
        [TestCase(5.2, 20.8)]
        public void PerimiterTest_Valid_ReturnsPerimiterValue(double length, double expected)
        {
            var square = new Square(length);
            var actual = Math.Round(square.Perimeter(), 2);
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// skickar in fel värden för att testa fyrkantens omkrets metod
        /// </summary>
        [TestCase(0, 0)]
        [TestCase(-4, 0)]
        public void PerimiterTest_Invalid_ReturnsZero(double length, double expected)
        {
            var square = new Square(length);
            var actual = Math.Round(square.Perimeter(), 2);
            Assert.AreEqual(actual, expected);
        }
    }
}
