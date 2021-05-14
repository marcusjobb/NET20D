namespace Geometri.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Geometri;

    [TestClass()]
    public class RectangleTests
    {
        /// <summary>
        /// /// TEST FOR RECTANGLE SHAPE
        /// Testing to set Height value to 40.5 double.
        /// 
        /// Testing to set Width value to 40.5 double.
        /// 
        /// We are using Area() method for calculation.
        /// 
        /// Expected variable is our expected outcome.
        /// </summary>

        [TestMethod()]
        public void AreaTest()
        {
            var rectangle = new Rectangle();

            rectangle.Height = 40.5;
            rectangle.Width = 40.5;

            var actual = rectangle.Area();
            var expected = 1640.25;

            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Skickar in ett nollvärde.
        /// </summary>
        [TestMethod()]
        public void Area_NollTest()
        {
            var rectangle = new Rectangle();

            rectangle.Height = 0;
            rectangle.Width = 0;

            var actual = rectangle.Area();
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OmkretsTest()
        {
            var rectangle = new Rectangle();

            rectangle.Height = 10;
            rectangle.Width = 10;
            rectangle.Height = 10;
            rectangle.Width = 10;

            var actual = rectangle.Omkrets();
            var expected = 40;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Omkrets_NegativtTest()
        {
            var rectangle = new Rectangle();

            rectangle.Height = -10;
            rectangle.Width = -10;
            rectangle.Height = -10;
            rectangle.Width = -10;

            var actual = rectangle.Omkrets();
            var expected = -40;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Omkrets_NollTest()
        {
            var rectangle = new Rectangle();

            rectangle.Height = 0;
            rectangle.Width = 0;
            rectangle.Height = 0;
            rectangle.Width = 0;

            var actual = rectangle.Omkrets();
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}