using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inlamningsuppgift1TDD.Tests
{
    [TestClass()]
    public class SquareTests
    {
        /// <summary>
        /// Deklarerar en variabel av klassen Square.
        /// </summary>
        private Square square;

        //Anropas innan varje test som instansierar klassen Square
        [TestInitialize]
        public void Setup()
        {
            square = new Square();
        }

        //Anropas efter varje test och tilldelar variabeln square värdet null
        [TestCleanup]
        public void TearDown()
        {
            square = null;
        }

        //Testar GetArea-metoden i Square-klassen med positiva värden (ental och decimaltal)
        [TestMethod()]
        [DataRow(3, 9)]
        [DataRow(2.25f, 5.06f)]
        public void GetAreaOfSquare_PositiveValue_ReturnArea(float side, float expected)
        {
            square.Side = side;
            var actual = square.GetArea();
            Assert.AreEqual(expected, actual);
        }

        //Testar GetArea-metoden i Square-klassen med negativa värden (noll och negativt decimaltal)
        [TestMethod()]
        [DataRow(0, 0)]
        [DataRow(-5.25f, 0)]
        [DataRow(null, 0)]
        public void GetAreaOfSquare_NegativeOrZeroValue_ReturnZero(float side, float expected)
        {
            square.Side = side;
            var actual = square.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }

        //Testar GetPerimeter-metoden i Square-klassen med positiva värden (ental och decimaltal)
        [TestMethod()]
        [DataRow(2, 8)]
        [DataRow(1.23f, 4.92f)]
        public void GetPerimeterOfSquare_PositiveValue_ReturnPerimeter(float side, float expectedPerimeter)
        {
            square.Side = side;
            var actualPerimeter = square.GetPerimeter();
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        //Testar GetPerimeter-metoden i Square-klassen med negativa värden (noll och negativt decimaltal)
        [TestMethod()]
        [DataRow(0, 0)]
        [DataRow(-1.15f, 0)]
        public void GetPerimeterOfSquare_NegativeOrZeroValue_ReturnZero(float side, float expectedPerimeter)
        {
            square.Side = side;
            var actualPerimeter = square.GetPerimeter();
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }
    }
}