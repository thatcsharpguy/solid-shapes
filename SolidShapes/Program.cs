using System;

namespace SolidShapes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var calculator = new GreatCalculator();
            calculator.Calculate();
            Console.WriteLine($"Área total: {calculator.TotalAreas}\nPerímetro total:{calculator.TotalPerimeters}");
            Console.ReadKey();
        }
    }
}