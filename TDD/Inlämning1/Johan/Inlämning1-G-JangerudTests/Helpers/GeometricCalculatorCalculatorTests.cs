using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inlämning1_G_Jangerud.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inlämning1_G_Jangerud.Shapes;

namespace Inlämning1_G_Jangerud.Helpers.Tests
{
    /// <summary>
    /// Testclass for all the different calculations.
    /// </summary>
    [TestClass()]
    public class GeometricCalculatorCalculatorTests
    {

        /// <summary>
        /// Testmethod for the calculation of the area of a square.
        /// </summary>
        [TestMethod()]
        public void GetAreaTest_Square_3_9()
        {
            //Arrange
            var calc = new GeometricCalculator();
            var square = new Square (3);
            var expected = 9;
            //Act
            var actual = calc.GetArea(square);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testmethod for the calculation of the area of a square using a negative value.
        /// </summary>
        [TestMethod()]
        public void GetAreaTest_Square_Negative1_0()
        {
            //Arrange
            var calc = new GeometricCalculator();
            var square = new Square(-1);
            var expected = 0;
            //Act
            var actual = calc.GetArea(square);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testmethod for the calculation of the area of a triangle.
        /// </summary>
        [TestMethod()]
        public void GetAreaTest_Triangle_3_5_75()
        {
            //Arrange
            var calc = new GeometricCalculator();
            var triangle = new Triangle(3, 5);
            var expected = 7.5;
            //Act
            var actual = calc.GetArea(triangle);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testmethod for the calculation of the area of a triangle using a negative value.
        /// </summary>
        [TestMethod()]
        public void GetAreaTest_Triangle_Negative3_5_0()
        {
            //Arrange
            var calc = new GeometricCalculator();
            var triangle = new Triangle(-3, 5);
            var expected = 0;
            //Act
            var actual = calc.GetArea(triangle);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testmethod for the calculation of the area of a rectangle.
        /// </summary>
        [TestMethod()]
        public void GetAreaTest_Rectangle_8_4_36()
        {
            //Arrange
            var calc = new GeometricCalculator();
            var rectangle = new Rectangle(8, 4);
            var expected = 32;
            //Act
            var actual = calc.GetArea(rectangle);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testmethod for the calculation of the area of a rectangle using a negative value.
        /// </summary>
        [TestMethod()]
        public void GetAreaTest_Rectangle_Negative5_10_0()
        {
            //Arrange
            var calc = new GeometricCalculator();
            var rectangle = new Rectangle(-5, 10);
            var expected = 0;
            //Act
            var actual = calc.GetArea(rectangle);
            //Assert
            Assert.AreEqual(expected, actual);
        }

       
        /// <summary>
        /// Testmethod for the calculation of the area of a circle.
        /// </summary>
        [TestMethod()]
        public void GetAreaTest_Circle_8_201()
        {
            //Arrange
            var calc = new GeometricCalculator();
            var circle = new Circle(8);
            var expected = (float)201.06;
            //Act
            var actual = calc.GetArea(circle);
            actual = MathF.Round((float)actual, 2);
            //Assert
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Testmethod for the calculation of the area of a circle using a negative value.
        /// </summary>
        [TestMethod()]
        public void GetAreaTest_Circle_Negative8_0()
        {
            //Arrange
            var calc = new GeometricCalculator();
            var circle = new Circle(-8);
            var expected = (float)0.00;
            //Act
            var actual = calc.GetArea(circle);
            actual = MathF.Round((float)actual, 2);
            //Assert
            Assert.AreEqual(expected, actual);
        }





        /// <summary>
        /// Method that calculates the perimeter of several shapes combined.
        /// Can also be used to calculate the perimeter of one shape as well.
        /// </summary>
        [TestMethod()]
        public void GetPerimeterArrayTest()
        {
            var geoShapes = new GeometricThing[]
            {
                new Triangle(5),
                new Square(3),
                new Rectangle(10, 5)
            };
            var calc = new GeometricCalculator();
            var actual = calc.GetPerimeter(geoShapes);
            actual = MathF.Round((float)actual, 2);
            var expected = 57.00;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Method that calculates the perimeter of several shapes combined using a negative value -
        /// - that generates a return of value 0 for that shape.
        /// Can also be used to calculate the perimeter of one shape as well.
        /// </summary>
        [TestMethod()]
        public void GetPerimeterArrayNegativeTest()
        {
            var geoShapes = new GeometricThing[]
            {
                new Triangle(-5),
                new Square(3),
                new Rectangle(10, 5)
            };
            var calc = new GeometricCalculator();
            var actual = calc.GetPerimeter(geoShapes);
            var expected = 42;
            Assert.AreEqual(expected, actual);
        }
    }
}