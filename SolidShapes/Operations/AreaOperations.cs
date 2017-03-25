using System;
using System.Collections.Generic;
using SolidShapes.Shapes;

namespace SolidShapes.Operations
{
    public class AreaOperations
    {
        public double Sum(IEnumerable<object> shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
                if (shape is Rectangle)
                    area += ((Rectangle) shape).Height * ((Rectangle) shape).Width;
                else if (shape is EquilateralTriangle)
                    area += Math.Sqrt(3) * Math.Pow(((EquilateralTriangle) shape).SideLength, 2) / 4;
            return area;
        }
    }
}