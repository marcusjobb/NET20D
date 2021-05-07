using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Inlamning1_Geometri.Geometry;


namespace GeometryLibrary
{
   [TestMethod()]
    public class Class1
    {
      
        public void TriangleTest()
        {
            var triangle = new Triangle(60,60);
            var input = triangle.GetPerimeter();
            var expexted = 180;
            Assert.AreEqual(input, expexted);

        }

    }
}
