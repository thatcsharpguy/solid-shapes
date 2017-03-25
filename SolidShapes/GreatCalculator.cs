using System.Collections.Generic;
using SolidShapes.Operations;
using SolidShapes.Shapes;

namespace SolidShapes
{
    public class GreatCalculator
    {
        public double TotalAreas { get; private set; }
        public double TotalPerimeters { get; private set; }

        public void Calculate(IEnumerable<IGeometricShape> figuras)
        {
            var areaOperations = new AreaOperations();
            var perimeterOperations = new PerimeterOperations();

            TotalAreas = areaOperations.Sum(figuras);
            TotalPerimeters = perimeterOperations.Sum(figuras);
        }
    }
}