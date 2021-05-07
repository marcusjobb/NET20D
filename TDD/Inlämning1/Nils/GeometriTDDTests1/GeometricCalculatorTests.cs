using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometriTDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeometriTDD.Tests
{
    /// <summary>
    /// I denna klassen så kör jag alla metoder för tester. Se bifogad PDF i den komprimerade mappen för att se dokumentation.
    /// </summary>
    [TestClass()]
    public class GeometricCalculatorTests
    {
        [TestMethod()]
        public void GetAreaTest()
        {
            var calc = new GeometricCalculator();
            float expected = 428.53983f; // 100 + 78.53983 + 200 + 50 = 428.53983
            var actual = calc.GetArea(new GeometricThing[]
            {
                new Geometry.Square(10),
                new Geometry.Circle(5),
                new Geometry.Rectangle(10, 20),
                new Geometry.Triangle(10)
            });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaTestOneShape()
        {
            var calc = new GeometricCalculator();
            float expected = 100f;
            var square = new Geometry.Square(10);
            var actual = calc.GetArea(square);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaTestOneShapeNegative()
        {
            var calc = new GeometricCalculator();
            float expected = 0f;
            var square = new Geometry.Square(-10);
            var actual = calc.GetArea(square);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaTestOneShapeNull()
        {
            var calc = new GeometricCalculator();
            float expected = 0f;
            var square = new Geometry.Square(0);
            var actual = calc.GetArea(square);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaTestWeirdValues()
        {
            var calc = new GeometricCalculator();
            float expected = 150f; // 100 + 0 + 0 + 50 = 150
            var actual = calc.GetArea(new GeometricThing[]
            {
                new Geometry.Square(10),
                new Geometry.Circle(0),
                new Geometry.Rectangle(10, -20),
                new Geometry.Triangle(10)
            });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaTestOnlyNegatives()
        {
            var calc = new GeometricCalculator();
            float expected = 0f;
            var actual = calc.GetArea(new GeometricThing[]
            {
                new Geometry.Square(-630),
                new Geometry.Circle(-13.52314f),
                new Geometry.Rectangle(-20, -500),
                new Geometry.Triangle(-3000)
            });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTest()
        {
            var calc = new GeometricCalculator();
            float expected = 161.41592f; // 40 + 31.41592 + 60 + 30 = 161.41592
            var actual = calc.GetPerimeter(new GeometricThing[]
            {
                new Geometry.Square(10),
                new Geometry.Circle(5),
                new Geometry.Rectangle(10, 20),
                new Geometry.Triangle(10)
            });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTestWeirdValues()
        {
            var calc = new GeometricCalculator();
            float expected = 70f; // 40 + 0 + 0 + 30 = 70
            var actual = calc.GetPerimeter(new GeometricThing[]
            {
                new Geometry.Square(10),
                new Geometry.Circle(0),
                new Geometry.Rectangle(10, -20),
                new Geometry.Triangle(10)
            });
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTestOneShape()
        {
            var calc = new GeometricCalculator();
            float expected = 40f;
            var square = new Geometry.Square(10);
            var actual = calc.GetPerimeter(square);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTestOneShapeNegative()
        {
            var calc = new GeometricCalculator();
            float expected = 0f;
            var square = new Geometry.Square(-10);
            var actual = calc.GetPerimeter(square);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTestOneShapeNull()
        {
            var calc = new GeometricCalculator();
            float expected = 0f;
            var square = new Geometry.Square(0);
            var actual = calc.GetPerimeter(square);
            Assert.AreEqual(expected, actual);
        }


    }
}