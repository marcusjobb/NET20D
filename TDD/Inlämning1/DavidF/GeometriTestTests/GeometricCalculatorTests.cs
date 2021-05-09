using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometriTest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Net.Http.Headers;

namespace GeometriTest.Tests
{
    [TestClass()]
    public class GeometricCalculatorTests
    {
        GeometricCalculator calc = new GeometricCalculator();

        // rektanglar 
        [TestMethod()]
        public void GetPerimeterTest_Rectangle_P14()
        {

            GeometriTest.Rectangle rec = new Rectangle();
            rec.Height = 5;
            rec.Base = 2;
            var actual = calc.GetPerimeter(rec);
            var expected = 14f;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetPerimeterTest_Rectangle_NullObject()
        {

            GeometriTest.Rectangle rec = new Rectangle();
            var actual = calc.GetPerimeter(rec);
            var expected = 0f;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetPerimeterTest_Rectangle_MinusData()
        {

            GeometriTest.Rectangle rec = new Rectangle();
            rec.Height = -5;
            rec.Base = -2;
            var actual = calc.GetPerimeter(rec);
            var expected = -14f;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetAreaTest_Rectangle_A10()
        {

            GeometriTest.Rectangle rec = new Rectangle();
            rec.Height = 5;
            rec.Base = 2;
            var actual = calc.GetArea(rec);
            var expected = 10f;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetAreaTest_Rectangle_MinusData()
        {

            GeometriTest.Rectangle rec = new Rectangle();
            rec.Height = -5;
            rec.Base = -2;
            var actual = calc.GetArea(rec);
            var expected = 10f;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetAreaTest_Rectangle_NullObject()
        {

            GeometriTest.Rectangle rec = new Rectangle();
            var actual = calc.GetArea(rec);
            var expected = 0f;

            Assert.AreEqual(expected, actual);
        }

        // trianglar 
        [TestMethod()]
        public void GetPerimeterTest_Triangle_P12_39()
        {

            GeometriTest.Triangle triangle = new Triangle();
            triangle.Height = 5;
            triangle.Base = 2;
            var actual = calc.GetPerimeter(triangle).GoodRound();
            var expected = 12.39f;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetPerimeterTest_Triangle_NullObject()
        {

            GeometriTest.Triangle triangle = new Triangle();
            var actual = calc.GetPerimeter(triangle).GoodRound();
            var expected = 0f;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetPerimeterTest_Triangle_MinusData()
        {

            GeometriTest.Triangle triangle = new Triangle();
            triangle.Height = -5;
            triangle.Base = -2;
            var actual = calc.GetPerimeter(triangle).GoodRound();
            var expected = 12.39f;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetAreaTest_Triangle_A10()
        {

            GeometriTest.Triangle triangle = new Triangle();
            triangle.Height = 5;
            triangle.Base = 2;
            var actual = calc.GetArea(triangle);
            var expected = 5f;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetAreaTest_Triangle_MinusData()
        {
            GeometriTest.Triangle triangle = new Triangle();
            triangle.Height = -5;
            triangle.Base = -2;
            var actual = calc.GetArea(triangle);
            var expected = 5f;

            Assert.AreEqual(expected, actual);

        }
        [TestMethod()]
        public void GetAreaTest_Triangle_NullObject()
        {

            GeometriTest.Triangle triangle = new Triangle();
            var actual = calc.GetArea(triangle);
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]

        // cirklar 
        public void GetPerimeterTest_Circle_P31()
        {

            GeometriTest.Circle circ = new Circle();
            circ.Radius = 5;
            var actual = calc.GetPerimeter(circ).GoodRound();
            var expected = 31.42f;


            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetPerimeterTest_Circle_NullObject()
        {

            GeometriTest.Circle circ = new Circle();
            var actual = calc.GetPerimeter(circ);
            var expected = 0f;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetPerimeterTest_Circle_MinusData()
        {

            GeometriTest.Circle circ = new Circle();
            circ.Radius = -5;
            var actual = calc.GetPerimeter(circ).GoodRound();
            var expected = -31.42f;


            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetAreaTest_Circle_A15_71()
        {


            GeometriTest.Circle circ = new Circle();
            circ.Radius = 5;
            var actual = calc.GetArea(circ).GoodRound();
            var expected = 15.71f;


            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetAreaTest_Circle_MinusData()
        {

            GeometriTest.Circle circ = new Circle();
            circ.Radius = -5;
            var actual = calc.GetArea(circ).GoodRound();
            var expected = -15.71f;


            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetAreaTest_Circle_NullObject()
        {

            GeometriTest.Circle circ = new Circle();
            var actual = calc.GetArea(circ).GoodRound();
            var expected = 0f;


            Assert.AreEqual(expected, actual);
        }

        // flera objekt 
        [TestMethod()]
        public void GetPerimeterTest_SeveralObjects_RealData()
        {
            List<GeometricThing> list = new List<GeometricThing>();
            list.Add(new Rectangle { Base = 2, Height = 2 });
            list.Add(new Triangle { Base = 2, Height = 3 });
            list.Add(new Circle { Radius = 2 });


            var actual = calc.GetPerimeter(list).GoodRound();
            var expected = 13.28f;


            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPerimeterTest_SeveralObjects_NullData()
        {
            List<GeometricThing> list = new List<GeometricThing>();
            list.Add(new Rectangle { Base = 0, Height = 0 });
            list.Add(new Triangle { Base = 0, Height = 0 });
            list.Add(new Circle { Radius = 0 });


            var actual = calc.GetPerimeter(list).GoodRound();
            var expected = 0f;


            Assert.AreEqual(expected, actual);
        }

    }
}