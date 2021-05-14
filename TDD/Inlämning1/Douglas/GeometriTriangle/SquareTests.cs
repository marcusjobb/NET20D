namespace Geometri.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Geometri;

    [TestClass()]
    public class SquareTests
    {
        /// <summary>
        /// TEST FOR SQUARE SHAPE
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
            var square = new Square();

            square.Height = 30.8;
            square.Width = 30.5;

            var actual = square.Area();
            var expected = 939.4;

            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Skickar in ett nollvärde.
        /// </summary>
        [TestMethod()]
        public void Area_NollTest()
        {
            var square = new Square();

            square.Height = 0;
            square.Width = 0;

            var actual = square.Area();
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OmkretsTest()
        {
            var square = new Square();

            square.Height = 10;
            square.Width = 10;
            square.Height = 10;
            square.Width = 10;

            var actual = square.Omkrets();
            var expected = 40;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Omkrets_NegativTest()
        {
            var square = new Square();

            square.Height = -10;
            square.Width = -10;
            square.Height = -10;
            square.Width = -10;

            var actual = square.Omkrets();
            var expected = -40;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Omkrets_NollTest()
        {
            var square = new Square();

            square.Height = 0;
            square.Width = 0;
            square.Height = 0;
            square.Width = 0;

            var actual = square.Omkrets();
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}