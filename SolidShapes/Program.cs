using System;
using SolidShapes.Operations;
using SolidShapes.Shapes;

namespace SolidShapes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var rectangulos = new IGeometricShape[]
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

            var sumaDeAreas = areaOperations.Sum(rectangulos);
            var sumaDePerimetros = perimeterOperations.Sum(rectangulos);

            Console.WriteLine($"Área total: {sumaDeAreas}\nPerímetro total:{sumaDePerimetros}");
            Console.ReadKey();
        }
    }
}