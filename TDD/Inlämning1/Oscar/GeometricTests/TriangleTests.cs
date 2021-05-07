using NUnit.Framework;
using System;
using TDDInl�mning1;

namespace GeometricTests
{
    public class TriangleTests
    {
        /// <summary>
        /// skickar in r�tt v�rden f�r att testa triangelns area metod
        /// </summary>
        /// <param name="tBase"></param>
        /// <param name="height"></param>
        /// <param name="expected"></param>
        [TestCase(4,2,4)]
        [TestCase(4.3,2.4,5.16)]
        public void AreaTest_Valid_ReturnsAreaValue(double tBase, double height, double expected)
        {
            var triangle = new Triangle(tBase, height);
            var actual = Math.Round(triangle.Area(), 2);
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// skickar in fel v�rden f�r att testa triangelns area metod
        /// </summary>
        /// <param name="tBase"></param>
        /// <param name="height"></param>
        /// <param name="expected"></param>
        [TestCase(0, 4, 0)]
        [TestCase(4, 0, 0)]
        [TestCase(-4, 2, 0)]
        [TestCase(4, -2, 0)]
        public void AreaTest_Invalid_ReturnsZero(double tBase, double height, double expected)
        {
            var triangle = new Triangle(tBase, height);
            var actual = Math.Round(triangle.Area(), 2);
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// skickar in korrekta v�rden f�r att testa triangelns omkrets metod
        /// </summary>
        /// <param name="tBase"></param>
        /// <param name="expected"></param>
        [TestCase(4, 12)]
        [TestCase(4.3, 12.9)]
        public void PerimiterTest_Valid_ReturnsPerimiterValue(double tBase, double expected)
        {
            var triangle = new Triangle(tBase);
            var actual = Math.Round(triangle.Perimeter(), 2);
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// skickar in fel v�rden f�r att testa triangelns omkrets metod
        /// </summary>
        /// <param name="tBase"></param>
        /// <param name="expected"></param>
        [TestCase(0, 0)]
        [TestCase(-4, 0)]
        public void PerimiterTest_Invalid_ReturnsZero(double tBase, double expected)
        {
            var triangle = new Triangle(tBase);
            var actual = Math.Round(triangle.Perimeter(), 2);
            Assert.AreEqual(actual, expected);
        }

    }
}