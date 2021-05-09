using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uppgift1TDD.Math;
using System;
using System.Collections.Generic;
using System.Text;
using Uppgift1TDD.GeometricItems;
using System.Runtime.CompilerServices;
using Uppgift1TDD.Interfaces;

namespace Uppgift1TDD.Math.Tests
{
    [TestClass()]
    public class GeometricCalculatorTests
    {
        [TestMethod()]
        public void GetAreaTestShapes()
        {
            var calc = new GeometricCalculator();
            var Shape = new Triangle(7, 5);

            float expected = 17.5f;
            float actual = calc.GetArea(Shape);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTestShapes()
        {
            var calc = new GeometricCalculator();
            var Shape = new Square(7);

            float expected = 28;
            float actual = calc.GetPerimeter(Shape);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTestArrayWithShapes()
        {
            var calc = new GeometricCalculator();

            Shape[] arrayShape = new Shape[3];
            arrayShape[0] = new Triangle(3, 5);
            arrayShape[1] = new Square(4);
            arrayShape[2] = new Rectangle(5, 6);

            float expected = 51;
            float actual = calc.GetPerimeter(arrayShape);
            Assert.AreEqual(expected, actual);
        }
    }
}