using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolidShapes.Shapes;

namespace SolidShapesTests
{
    [TestClass]
    public class RectanglesTests
    {
        [TestMethod]
        public void RectangleAreaTest()
        {
            Rectangle rectangle = new Square();
            rectangle.Width = 3;
            rectangle.Height = 6;

            double expected = 18;
            double actual = rectangle.Area();

            Assert.AreEqual(expected, actual);
        }
    }
}
