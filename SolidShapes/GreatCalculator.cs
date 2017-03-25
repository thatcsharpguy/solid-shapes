using SolidShapes.Operations;
using SolidShapes.Shapes;

namespace SolidShapes
{
    public class GreatCalculator
    {
        public double TotalAreas { get; private set; }
        public double TotalPerimeters { get; private set; }

        public void Calculate()
        {
            var figuras = new IGeometricShape[]
            {
                new Rectangle {Width = 10, Height = 5},
                new EquilateralTriangle {SideLength = 5},
                new Rectangle {Width = 4, Height = 6},
                new Square {SideLength = 10},
                new Rectangle {Width = 8, Height = 9},
                new Square {SideLength = 8},
                new EquilateralTriangle {SideLength = 5}
            };

            var areaOperations = new AreaOperations();
            var perimeterOperations = new PerimeterOperations();

            TotalAreas = areaOperations.Sum(figuras);
            TotalPerimeters = perimeterOperations.Sum(figuras);
        }
    }
}