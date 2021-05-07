using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometri;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Geometri.Tests
{
    [TestClass()]
    public class GeometricCalculatorTests
    {
        #region Square
        [TestMethod]
        [DataRow(45.56f, 2075.714f)]
        [DataRow(0, 0)]
        [DataRow(-0.9f, 0)]
        public void Test_Square_Area(float height, float expected)
        {
            // Arrange
            var square = new Square { Height = height };

            // Act
            var actual = square.GetArea();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(45.56f, 182.24f)]
        [DataRow(0, 0)]
        [DataRow(-0.9f, 0)]
        public void Test_Square_Perimeter(float height, float expected)
        {
            // Arrange
            var square = new Square { Height = height };

            // Act
            var actual = square.GetPerimeter();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion
        #region Circle
        [TestMethod]
        [DataRow(7.781f, 190.204f)]
        [DataRow(0, 0)]
        [DataRow(-6.526f, 0)]

        public void Test_Circle_Area(float radius, float expected)
        {
            //Arrange
            var circle = new Circle { Radius = radius };

            //Act
            var actual = circle.GetArea();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [DataRow(7.781f, 48.889f)]
        [DataRow(0, 0)]
        [DataRow(-6.936f, 0)]

        public void Test_Circle_Perimeter(float radius, float expected)
        {
            // Arrange
            var circle = new Circle { Radius = radius };

            // Act
            var actual = circle.GetPerimeter();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion
        #region Rectangle
        [TestMethod]
        [DataRow(7.781f, 48.889f, 380.405f)]
        [DataRow(0, 0, 0)]
        [DataRow(-0.987f, -2.54f, 0)]

        public void Test_Rectangle_Area(float width, float height, float expected)
        {
            // Arrange
            var rectangle = new Rectangle { Width = width, Height = height };

            // Act
            var actual = rectangle.GetArea();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [DataRow(7.781f, 48.889f, 113.34f)]
        [DataRow(0, 0, 0)]
        [DataRow(-0.987f, 0, 0)]

        public void Test_Rectangle_Perimeter(float width, float height, float expected)
        {
            // Arrange
            var rectangle = new Rectangle { Width = width, Height = height };

            // Act
            var actual = rectangle.GetPerimeter();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion
        #region Triangle
        [TestMethod]
        [DataRow(5.9f, 0.8f, 2.36f)]
        [DataRow(0, 0, 0)]
        [DataRow(-0.9f, 0, 0)]

        public void Test_Triangle_Area(float tHeight, float tBase, float expected)
        {
            // Arrange
            var tri = new Triangle { Theight = tHeight, Tbase = tBase };

            // Act
            var actual = tri.GetArea();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [DataRow(0.8f, 5.0003f, 7.008f, 12.808f)]
        [DataRow(0, 0, 0, 0)]
        [DataRow(-0.9f, 0, 0, 0)]

        public void Test_Triangle_Perimeter(float tBase, float sideA, float sideC, float expected)
        {
            // Arrange
            var square = new Triangle { Tbase = tBase, SideA = sideA, SideC = sideC };

            // Act
            var actual = square.GetPerimeter();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion
        #region Multiple Shapes
        [TestMethod]
        public void Test_Multiple_Shapes_Area()
        {
            // Arrange
            float expected = 345.93f;
            var calc = new GeometricCalculator();
            var shapes = new GeometricShapes[]
            {new Triangle (3.98f, 8.97f, 4.76f, 5.78f ),
            null,
             new Square (4.56f),
             null,
             new Circle (9.89f)
             };

            // Act
            var actual = calc.GetArea(shapes);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_Multiple_Shapes_Perimeter()
        {
            // Arrange
            float expected = 32.76f;
            var calc = new GeometricCalculator();
            var shapes = new GeometricShapes[]
            {new Triangle (3.98f, 8.97f, 4.76f, 5.78f),
             null,
             new Square (4.56f)
            };

            // Act
            var actual = calc.GetPerimeter(shapes);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}