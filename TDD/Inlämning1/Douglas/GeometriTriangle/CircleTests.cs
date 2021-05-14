namespace Geometri.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Geometri;

    /// <summary>
    /// /// TEST FOR SQUARE SHAPE
    /// Testing to set Radius value to 50 double.
    /// (50 * 50 * pi)
    /// 
    /// We are using Area() method for calculation.
    /// (Abstract class)
    /// 
    /// Expected variable is our expected outcome,
    /// from Radius calc.
    /// </summary>
    [TestClass()]
    public class CircleTests
    {
        [TestMethod()]
        public void AreaTest()
        {
            var circle = new Circle();

            circle.Radius = 50;

            var actual = circle.Area();
            var expected = 7853.981633974483;

            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Skickar in ett nollvärde.
        /// </summary>
        [TestMethod()]
        public void Area_NollTest()
        {
            var circle = new Circle();

            circle.Radius = 0;

            var actual = circle.Area();
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OmkretsTest()
        {
            var circle = new Circle();

            circle.Radius = 5;
            circle.Diameter = 5;

            var actual = circle.Omkrets();
            var expected = 157.07963267948966;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Omkrets_NegativtTest()
        {
            var circle = new Circle();

            circle.Radius = 0;
            circle.Diameter = 0;

            var actual = circle.Omkrets();
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}