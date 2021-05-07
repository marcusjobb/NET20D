using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inlamningsuppgift1TDD.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        /// <summary>
        /// Deklarerar en variabel av klassen Rectangle.
        /// </summary>
        private Rectangle rectangle;

        //Anropas innan varje test som instansierar klassen Rectangle
        [TestInitialize]
        public void Setup()
        {
            rectangle = new Rectangle();
        }

        //Anropas efter varje test och tilldelar variabeln rectangle värdet null
        [TestCleanup]
        public void TearDown()
        {
            rectangle = null;
        }

        //Testar GetArea-metoden i Rectangle-klassen med positiva värden (ental och decimaltal)
        [TestMethod()]
        [DataRow(5, 5, 25)]
        [DataRow(4.12f, 2.12f, 8.73f)]
        public void GetAreaOfRectangle_PositiveValues_ReturnArea(float height, float width, float expected)
        {
            rectangle.Height = height;
            rectangle.Width = width;
            var actual = rectangle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        //Testar GetArea-metoden i Rectangle-klassen med negativa värden (noll och negativa decimaltal)
        [TestMethod()]
        [DataRow(0, 3, 0)]
        [DataRow(-4.12f, -2.12f, 0)]
        public void GetAreaOfRectangle_NegativeOrZeroValues_ReturnZero(float height, float width, float expected)
        {
            rectangle.Height = height;
            rectangle.Width = width;
            var actual = rectangle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        //Testar GetPerimeter-metoden i Rectangle-klassen med positiva värden (ental och decimaltal)
        [TestMethod()]
        [DataRow(3, 5, 16)]
        [DataRow(1.23f, 3.45f, 9.36f)]
        public void GetPerimeterOfRectangle_PositiveValues_ReturnPerimeter(float height, float width, float expected)
        {
            rectangle.Height = height;
            rectangle.Width = width;
            var actual = rectangle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }

        //Testar GetPerimeter-metoden i Rectangle-klassen med negativa värden (noll och negativa decimaltal)
        [TestMethod()]
        [DataRow(-1.15f, 0, 0)]
        [DataRow(2.22f, -2.33f, 0)]
        public void GetPerimeterOfRectangle_NegativeOrZeroValues_ReturnZero(float height, float width, float expected)
        {
            rectangle.Height = height;
            rectangle.Width = width;
            var actual = rectangle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}