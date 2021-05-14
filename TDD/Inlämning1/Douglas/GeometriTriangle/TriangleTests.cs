namespace Geometri.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Geometri;

    [TestClass()]
    public class TriangleTests
    {
        /// <summary>
        /// /// TEST FOR TRIANGLE SHAPE
        /// Testing to set Height value to 10.5 double.
        /// 
        /// Testing to set Width value to 10.5 double.
        /// 
        /// We are using Area() method for calculation.
        /// 
        /// Expected variable is our expected outcome,
        /// from Height and Width.
        /// </summary>
        [TestMethod()]
        public void AreaTest()
        {
            var triangle = new Triangle();

            triangle.Height = 10.5;
            triangle.Width = 10.5;

            var actual = triangle.Area();
            var expected = 110.25;

            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Skickar in ett nollvärde.
        /// </summary>
        [TestMethod()]
        public void Area_NollTest()
        {
            var triangle = new Triangle();

            triangle.Height = 0;
            triangle.Width = 0;

            var actual = triangle.Area();
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OmkretsTest()
        {
            var triangle = new Triangle();

            triangle.Height = 100;
            triangle.Width = 50;
            triangle.Height = 100;

            var actual = triangle.Omkrets();
            var expected = 250;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Omkrets_NegativTest()
        {
            var triangle = new Triangle();

            triangle.Height = -100;
            triangle.Width = -50;
            triangle.Height = -100;

            var actual = triangle.Omkrets();
            var expected = -250;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Omkrets_NollTest()
        {
            var triangle = new Triangle();

            triangle.Height = 0;
            triangle.Width = 0;
            triangle.Height = 0;

            var actual = triangle.Omkrets();
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}