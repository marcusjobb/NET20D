using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_Inlamning_Lee.GeoItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_Inlamning_Lee.GeoItems;

namespace TDD_Inlamning_Lee.GeoItems.Tests
{
    [TestClass()]
    public class GeometricCalculatorTests
    {
        GeometricCalculator calc = new GeometricCalculator();
        [TestMethod()]
        [DataRow(null, 0)]
        [DataRow(5, 25)]
        [DataRow(2.5f, 6.25f)]
        [DataRow(-1, -1)]
        [DataRow(0, 0)]
        public void GetAreaTest_Square(float input, float result)
        {
            var actual = calc.GetArea(new Square(input));
            var expected = result;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(null, null, 0)]
        [DataRow(5, 20, 100)]
        [DataRow(12.3f, 45.7f, 562.11f)]
        [DataRow(-1, 10, -1)]
        public void GetAreaTest_Rectangle(float width, float height, float result)
        {
            var actual = calc.GetArea(new Rectangle(width, height));
            var expected = result;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(null, 0)]
        [DataRow(5, 78.54f)]
        [DataRow(12.3f, 475.29f)]
        [DataRow(-1, -1)]
        public void GetAreaTest_Circle(float radius, float result)
        {
            var actual = calc.GetArea(new Circle(radius));
            var expected = result;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(null, null, 0)]
        [DataRow(5, 20, 50)]
        [DataRow(12.3f, 45.7f, 281.06f)]
        [DataRow(-1, 10, -1)]
        public void GetAreaTest_Triangle(float width, float height, float result)
        {
            var actual = calc.GetArea(new Triangle(width, height));
            var expected = result;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(null, 0)]
        [DataRow(5, 20)]
        [DataRow(2.5f, 10f)]
        [DataRow(-1, -1)]
        [DataRow(0, 0)]
        public void GetPerimiterTest_Square(float input, float result)
        {
            var actual = calc.GetPerimiter(new Square(input));
            var expected = result;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(null, null, 0)]
        [DataRow(5, 20, 50)]
        [DataRow(12.3f, 45.7f, 116f)]
        [DataRow(-1, 10, -1)]
        public void GetPerimiterTest_Rectangle(float width, float height, float result)
        {
            var actual = calc.GetPerimiter(new Rectangle(width, height));
            var expected = result;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        [DataRow(null, 0)]
        [DataRow(5, 31.42f)]
        [DataRow(12.3f, 77.28f)]
        [DataRow(-1, -1)]
        public void GetPerimiterTest_Circle(float radius, float result)
        {
            var actual = calc.GetPerimiter(new Circle(radius));
            var expected = result;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(null, null, 0)]
        [DataRow(5, 20, 45.31f)]
        [DataRow(12.3f, 45.7f, 104.52f)]
        [DataRow(-1, 10, -1)]
        public void GetPerimiterTest_Triangle(float width, float height, float result)
        {
            var actual = calc.GetPerimiter(new Triangle(width, height));
            var expected = result;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(null, 0)]
        [DataRow(5, 15f)]
        [DataRow(12.3f, 36.9f)]
        [DataRow(-2, -1)]
        public void GetPerimiterTest_Triangle_Equilateral(float side, float result)
        {
            var actual = calc.GetPerimiter(new Triangle(side, true));
            var expected = result;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(null, null, 0)]
        [DataRow(5, 20, 161.73f)]
        [DataRow(12.3f, 45.7f, 383.9f)]
        [DataRow(-2, 10, -1)]
        public void GetPerimiterTest_DifferentShapes(float widthSide, float height, float result)
        {
            var geoThings = new GeometricThings[]
            {
                new Square(widthSide),
                new Rectangle(widthSide, height),
                new Circle(widthSide),
                new Triangle(widthSide, height),
                new Triangle(widthSide, true)
            };

            var actual = calc.GetPerimiter(geoThings);
            var expected = result;

            Assert.AreEqual(expected, actual);
        }
    }
}