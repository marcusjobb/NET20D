using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleApp3.Shapes.Tests
{
    [TestClass()]
    public class RectangelTests
    {
        [TestMethod()]
        [DataRow(1f, 1f, 1f)]
        [DataRow(2f, 2f, 4f)]
        [DataRow(4f, 4f, 16f)]
        public void Area_CalculatesWidthHeight_ReturnsArea(float width, float length, float expected)
        {
            var rectangel = new Rectangel(width, length);
            var actual = rectangel.Area();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(1f, 1f, 4f)]
        [DataRow(2f, 5f, 14f)]
        [DataRow(6f, 9f, 30f)]
        public void Perimeter_CalculateWidthHeight_ReturnArea(float width, float length, float expected)
        {
            var rectangel = new Rectangel(width, length);
            var actual = rectangel.Perimeter();

            Assert.AreEqual(MathF.Round(expected, 2, MidpointRounding.ToEven), MathF.Round(actual, 2, MidpointRounding.ToEven));
        }
    }
}