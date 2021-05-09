using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry.Controllers;
using Geometry.Interfaces;
using Geometry.Models;

namespace GeometricTest
{
    [TestClass()]
    public class GeometricTest
    {
        GeometricCalculator geo = new GeometricCalculator();
        //private IShape rectangle = new Rectangle(14, 7);
        //private IShape triangle =  new Triangle(14, 7);
        //private IShape square =  new Square(14);
        //private IShape circle =  new Circle(14);

        #region PerimterTests

        [TestMethod()]
        [DataRow(14, 7, 42)]
        public void RectanglePerimeterTest(float height, float shapeBase, float expected)
        {
            //Arrange
            IShape rectangle = new Rectangle(height, shapeBase);
            //Assert

            Assert.AreEqual(expected, Math.Round(geo.GetPerimeter(rectangle), 2));
        }

        [TestMethod()]
        [DataRow(14, 7, 35.43)]
        public void TrianglePerimeterTest(float height, float shapeBase, double expected)
        {
            //Arrange
            IShape triangle = new Triangle(height, shapeBase);

            //Assert
            Assert.AreEqual(expected, Math.Round(geo.GetPerimeter(triangle), 2));
        }

        [TestMethod()]
        [DataRow(14, 56)]
        public void SquarePerimeterTest(float height, float expected)
        {
            //Arrange
            IShape square = new Square(height);

            //Assert
            Assert.AreEqual(expected, Math.Round(geo.GetPerimeter(square), 2));
        }

        [TestMethod()]
        [DataRow(14, 138.17)]
        public void CirclePerimeterTest(float height, double expected)
        {
            //Arrange
            IShape circle = new Circle(height);

            //Assert
            Assert.AreEqual(expected, Math.Round(geo.GetPerimeter(circle), 2));
        }

        #endregion

        #region AreaTest

        [TestMethod()]
        [DataRow(14, 7, 98)]
        public void RectangleAreaTest(float height, float shapeBase, float expected)
        {
            IShape rectangle = new Rectangle(height, shapeBase);
            //Assert

            Assert.AreEqual(expected, Math.Round(geo.GetArea(rectangle), 2));
        }

        [TestMethod()]
        [DataRow(14, 7, 49)]
        public void TriangleAreaTest(float height, float shapeBase, float expected)
        {
            //Arrange
            IShape triangle = new Triangle(height, shapeBase);

            //Assert
            Assert.AreEqual(expected, Math.Round(geo.GetArea(triangle), 2));
        }

        [TestMethod()]
        [DataRow(14, 196)]
        public void SquareAreaTest(float height, float expected)
        {
            //Arrange
            IShape square = new Square(height);

            //Assert
            Assert.AreEqual(expected, Math.Round(geo.GetArea(square), 2));
        }

        [TestMethod()]
        [DataRow(14, 21.99)]
        public void CircleAreaTest(float height, double expected)
        {
            //Arrange
            IShape circle = new Circle(height);

            //Assert
            Assert.AreEqual(expected, Math.Round(geo.GetArea(circle), 2));
        }

        #endregion

        #region PerimeterSumTest

        [TestMethod()]
        public void TotalPerimeterTest()
        {
            //Arrange
            new Rectangle(14, 7);
            new Triangle(14, 7);
            new Square(14);
            new Circle(14);
            var list = new List<IShape>
            {
                new Rectangle(14, 7),
                new Triangle(14, 7),
                new Square(14),
                new Circle(14)
            };
            var expected = 271.61;

            //Assert
            var actual = Math.Round(geo.GetPerimeter(list), 2);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region FailTest

        [TestMethod()]
        public void CalculateWithoutShapeTest()
        {
            try
            {
                IShape shape = null;
                geo.GetPerimeter(shape);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Assert.Fail("No shapes found");
            }
        }

        [TestMethod()]
        [DataRow(-14, 7)]
        public void NegativeValueSideTest(float a, float b)
        {
            IShape rectangle = new Rectangle(a, b);
            Assert.IsFalse(rectangle.Height < 0, "Shape sides cannot have negative values");
        }
        #endregion
    }
}
