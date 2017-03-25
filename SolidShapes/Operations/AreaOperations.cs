using System.Collections.Generic;
using SolidShapes.Shapes;

namespace SolidShapes.Operations
{
    public class AreaOperations
    {
        public double Sum(IEnumerable<IGeometricShape> shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
                area += shape.Area();
            return area;
        }
    }
}