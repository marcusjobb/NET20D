using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inlamningsuppgift1TDD.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        /// <summary>
        /// Deklarerar en variabel av klassen Triangle.
        /// </summary>
        private Triangle triangle;

        //Anropas innan varje test som instansierar klassen Triangle
        [TestInitialize]
        public void Setup()
        {
            triangle = new Triangle();
        }

        //Anropas efter varje test och tilldelar variabeln triangle värdet null
        [TestCleanup]
        public void TearDown()
        {
            triangle = null;
        }

        //Testar GetArea-metoden i Triangel-klassen med positiva värden (ental och decimaltal)
        [TestMethod()]
        [DataRow(1.23f, 4.01f, 2.47f)]
        [DataRow(0.33f, 0.66f, 0.11f)]
        public void GetAreaOfTriangle_PositiveValues_ReturnArea(float height, float tBase, float expected)
        {
            triangle.Height = height;
            triangle.Tbase = tBase;
            var actual = triangle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        //Testar GetArea-metoden i Triangel-klassen med negativa värden (noll och negativa decimaltal)
        [TestMethod()]
        [DataRow(0, 4, 0)]
        [DataRow(-2.55f, -2.55f, 0)]
        public void GetAreaOfTriangle_NegativeOrZeroValues_ReturnZero(float height, float tBase, float expected)
        {
            triangle.Height = height;
            triangle.Tbase = tBase;
            var actual = triangle.GetArea();
            Assert.AreEqual(expected, actual);
        }

        //Testar GetPerimeter-metoden i Triangel-klassen med positiva värden (ental och decimaltal)
        [TestMethod()]
        [DataRow(2.44f, 1.33f, 6.21f)]
        [DataRow(5.23f, 4.55f, 15.01f)]
        public void GetPerimeterOfTriangle_PositiveValues_ReturnPerimeter(float side, float tBase, float expected)
        {
            triangle.Side = side;
            triangle.Tbase = tBase;
            var actual = triangle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }

        //Testar GetPerimeter-metoden i Rectangle-klassen med negativa värden (noll och negativa decimaltal)
        [TestMethod()]
        [DataRow(0, 1.33f, 0)]
        [DataRow(-1.33f, 0, 0)]
        public void GetPerimeterOfTriangle_NegativeOrZeroValues_ReturnZero(float side, float tBase, float expected)
        {
            triangle.Side = side;
            triangle.Tbase = tBase;
            var actual = triangle.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}