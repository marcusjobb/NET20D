using Geometri.GeoItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometri.Tests
{
    [TestClass()]
    public class GeometricCalculatorTests
    {
        /// <summary>
        /// Testar arean av en cirkel med null, 0, negativa coh positiva värden
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DataRow(null, 0)] //Rätt
        [DataRow(0, 0)] // Rätt
        [DataRow(1, MathF.PI)] // Rätt
        [DataRow(-2, 0)] // Rätt


        public void GetAreaTest(float radius ,float expected)
        {
            var test = new GeometricCalculator();
            var circle = new Circle(radius);
            var actual = test.GetArea(circle);
            Assert.AreEqual(expected,actual);
        }

        /// <summary>
        /// Testar perimetern av en cirkel med null, 0, negativa coh positiva värden
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DataRow(null, 0)] //Rätt
        [DataRow(0, 0)] // Rätt
        [DataRow(1, 2*MathF.PI)] // Rätt
        [DataRow(-2, 0)] // Rätt

        public void GetPerimeterTest_Circle(float radius, float expected)
        {
            var test = new GeometricCalculator();
            var circle = new Circle(radius);
            var actual = test.GetPerimeter(circle);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testar perimetern av en rektangel med null, 0, negativa coh positiva värden
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DataRow(1, 2, 6)] //Rätt
        [DataRow(0, 2, 0)] //Rätt
        [DataRow(6, -2, 0)] //Rätt
        [DataRow(-3, -2, 0)] //Rätt
        [DataRow(null, 2, 0)] //Rätt

        public void GetPerimeterTest_Rectangle(float a, float b, float expected)
        {
            var test = new GeometricCalculator();
            var rect = new Rectangle(a, b);
            var actual = test.GetPerimeter(rect);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testar arean av en rektangel med null, 0, negativa coh positiva värden
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DataRow(1, 2, 2)] //Rätt
        [DataRow(0, 2, 0)] //Rätt
        [DataRow(6, -2, 0)] //Rätt
        [DataRow(-3, -2, 0)] //Rätt
        [DataRow(null, 2, 0)] //Rätt

        public void GetArea_Rectangle(float a, float b, float expected)
        {
            var test = new GeometricCalculator();
            var rect = new Rectangle(a, b);
            var actual = test.GetArea(rect);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testar perimetern av en liksidig triangel med null, 0, negativa coh positiva värden
        /// </summary>
        /// <param name="bas"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DataRow(2, 6)] //Rätt
        [DataRow(0, 0)] //Rätt
        [DataRow(-2, 0)] //Rätt
        [DataRow(null, 0)] //Rätt

        public void GetPerimeterTest_Triangle(float bas,  float expected)
        {
            var test = new GeometricCalculator();
            var rect = new Triangle(bas, 1);
            var actual = test.GetPerimeter(rect);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testar arean av en liksidig triangel med 0, negativa coh positiva värden
        /// </summary>
        /// <param name="bas"></param>
        /// <param name="höjd"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DataRow(0,0, 0)] //Rätt
        [DataRow(-2,5, 0)] //Rätt
        [DataRow(2, 1, 1)] //Rätt
        
        public void GetAreaTest_Triangle(float bas, float höjd, float expected)
        {
            var test = new GeometricCalculator();
            var rect = new Triangle(bas, höjd);
            var actual = test.GetArea(rect);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testar summan av tre geometriska objekt med positiva och negativa värden
        /// </summary>
        /// <param name="triangleBas"></param>
        /// <param name="radius"></param>
        /// <param name="rectSideA"></param>
        /// <param name="rectSideB"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DataRow(2, 1, 2, 3, 16 + 2 * MathF.PI)] //Rätt 
        [DataRow(-2, -1, -2, 0, 0)] //Rätt 

        public void GetPeimeterTest_SeveralObjects(float triangleBas, float radius, float rectSideA, float rectSideB, float expected)
        {
            var test = new GeometricCalculator();
            var triangle = new Triangle(triangleBas, 1);
            var rect = new Rectangle(rectSideA, rectSideB);
            var circle = new Circle(radius);
            IGeometricThing[] geoThings =new IGeometricThing[] { circle, triangle, rect };
            var actual = test.GetPerimeter(geoThings);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testar summan av tre geometriska objekt varav en är null
        /// </summary>
        /// <param name="triangleBas"></param>
        /// <param name="radius"></param>
        /// <param name="expected"></param>
        [TestMethod()]
        [DataRow(2, 1, 6 + 2 * MathF.PI)] //Rätt 
        
        public void GetPeimeterTest_SeveralObjectsNull(float triangleBas, float radius, float expected)
        {
            var test = new GeometricCalculator();
            var triangle = new Triangle(triangleBas, 1);
            var circle = new Circle(radius);
            IGeometricThing[] geoThings = new IGeometricThing[] { circle, triangle, null };
            var actual = test.GetPerimeter(geoThings);
            Assert.AreEqual(expected, actual);
        }
    }
}