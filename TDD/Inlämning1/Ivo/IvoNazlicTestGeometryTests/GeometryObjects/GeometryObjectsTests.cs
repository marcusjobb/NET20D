using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IvoNazlicTestGeometry.GeometryObjects.Tests
{
    [TestClass()]
    public class GeometryObjectsTests
    {
        [TestMethod()]
        public void GetCircumferenceSquareTest()
        {
            var square = new Square(1.1111f);
            var actual = square.GetCircumference();
            var expected = 4.4444f;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCircumferenceSquareTest0()
        {
            var square = new Square(0.0f);
            var actual = square.GetCircumference();
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCircumferenceCircleTest()
        {
            var circle = new Circle(2.2f);
            var actual = circle.GetCircumference();
            var expected = 6.9115f;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCircumferenceCircleTest0()
        {
            var circle = new Circle(0.0f);
            var actual = circle.GetCircumference();
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCircumferenceTriangleTest()
        {
            var triangle = new Triangle(1.1f);
            var actual = triangle.GetCircumference();
            var expected = 3.3f;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCircumferenceTriangleTest0()
        {
            var triangle = new Triangle(0.0f);
            var actual = triangle.GetCircumference();
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void GetCircumferenceRectangleTest()
        {
            var rectangle = new Rectangle(2, 4);
            var actual = rectangle.GetCircumference();
            var expected = 12;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCircumferenceRectangleTest0()
        {
            var rectangle = new Rectangle(0, 0.0f);
            var actual = rectangle.GetCircumference();
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaSquareTest()
        {
            var square = new Square(4.4f);
            var actual = square.GetArea();
            var expected = 19.36f;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaSquareTest0()
        {
            var square = new Square(0.0f);
            var actual = square.GetArea();
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaCircleTest()
        {
            var circle = new Circle(4);
            var actual = circle.GetArea();
            var expected = 12.5664f;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaCircleTest0()
        {
            var circle = new Circle(0.0f);
            var actual = circle.GetArea();
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaTriangleTest()
        {
            var triangle = new Triangle(8);
            var actual = triangle.GetArea();
            var expected = 27.712f;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaTriangleTest0()
        {
            var triangle = new Triangle(0.0f);
            var actual = triangle.GetArea();
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaRectangleTest()
        {
            var rectangle = new Rectangle(2, 4);
            var actual = rectangle.GetArea();
            var expected = 8;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAreaRectangleTest0()
        {
            var rectangle = new Rectangle(0, 0.0f);
            var actual = rectangle.GetArea();
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

    }
}