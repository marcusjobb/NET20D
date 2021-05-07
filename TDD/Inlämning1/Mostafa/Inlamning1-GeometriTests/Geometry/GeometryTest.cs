using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inlamning1_Geometri.Geometry;
using System;
using System.Collections.Generic;
using System.Text;
using Inlamning1_Geometri.Interface;

namespace Inlamning1_Geometri.Geometry.Tests
{
    [TestClass()]
    public class GeometryTest
    {
        [TestMethod()]
        public void Triangle()
        {
            var triangle = new Triangle(60,60);
            var input1 = triangle.GetArea();
            var expected1 = 1800;
            Assert.AreEqual(input1, expected1);
            var input2 = triangle.GetPerimeter();
            var expected2 = 180;
            Assert.AreEqual(input2, expected2);

        }
        [TestMethod()]
        public void Circle()
        {
            var circle = new Circle(10);
            var input1 = circle.GetArea();
            var expected1 = 131.40001f;
            Assert.AreEqual(input1, expected1);
            var input2 = circle.GetPerimeter();
            var expected2 = 262.80002f;
            Assert.AreEqual(input2, expected2);
        }

        [TestMethod()]
        public void Rectangle()
        {
            var rectangle = new Rectangle(5,5);
            var input1 = rectangle.GetArea();
            var expected1 = 25;
            Assert.AreEqual(input1, expected1);
            var input2 = rectangle.GetPerimeter();
            var expected2 = 20;
            Assert.AreEqual(input2, expected2);
        }
        
        [TestMethod()]
        public void Square()
        {
            var square = new Square(5);
            var input1 = square.GetArea();
            var expected1 = 25;
            Assert.AreEqual(input1, expected1);
            var input2 = square.GetPerimeter();
            var expected2 = 20;
            Assert.AreEqual(input2, expected2);
        }

        [TestMethod()]
        public void GeometryCalculater()
        {
            var geomterything = new GeometriyCalculator();
            var input = geomterything.GetPerimeter(new List<IGeometryThing>());
            var expected = 377.80002f;
            Assert.AreEqual(input, expected);
        }
    }
}