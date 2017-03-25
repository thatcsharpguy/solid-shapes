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
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 3;
            rectangle.Height = 6;

            double expected = 18;
            double actual = rectangle.Area();

            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class SquareTests
    {
        [TestMethod]
        public void SquareAreaTest()
        {
            Square square = new Square();
            square.SideLength = 6;

            double expected = 36;
            double actual = square.Area();

            Assert.AreEqual(expected, actual);
        }
    }
}
