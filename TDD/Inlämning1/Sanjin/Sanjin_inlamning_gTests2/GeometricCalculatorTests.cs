using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sanjin_inlamning_g;
using Sanjin_inlamning_g.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanjin_inlamning_g.Tests
{
    [TestClass()]
    public class GeometricCalculatorTests
    {
        [TestMethod()]
        public void GetPerimeterTestRectangle()
        {
            var rectangel = new Rectangle(5, 4);
            var expected = 18;
            var actual = rectangel.GetPerimeter();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetAreaTestRectangle()
        {
            var rectangel = new Rectangle(5, 4);
            var expected = 20;
            var actual = rectangel.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTestSquare()
        {
            var square = new Square(4);
            var expected = 16;
            var actual = square.GetPerimeter();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetAreaTestSquare()
        {
            var square = new Square(4);
            var expected = 16;
            var actual = square.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTestTriangle()
        {
            var triangle = new Triangle(1, 3);
            var expected = 3;
            var actual = triangle.GetPerimeter();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetAreaTestTriangle()
        {
            var triangle = new Triangle(2, 5);
            var expected = 5;
            var actual = triangle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTestCircle()
        {
            var circle = new Circle(2);
            var expected = 12.566371f;
            var actual = circle.GetPerimeter();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetAreaTestCircle()
        {
            var circle = new Circle(4);
            var expected = 50.265484f;
            var actual = circle.GetArea();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetPerimeterTest()
        {
            var objectArray = new GeometricThing[]
            {
                new Circle(12),
                new Triangle(2,2),
                new Square(5)

            };

            var geomatricCalculator = new GeometricCalculator();
            Assert.AreEqual(101, MathF.Round(geomatricCalculator.GetPerimeter(objectArray)));
        }
    }
}