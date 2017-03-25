using System.Collections.Generic;
using SolidShapes.Shapes;

namespace SolidShapes.Operations
{
    public class AreaOperations
    {
        public double Sum(IEnumerable<Rectangle> rectangles)
        {
            double area = 0;
            foreach (var rectangle in rectangles)
                area += rectangle.Height * rectangle.Width;
            return area;
        }
    }
}