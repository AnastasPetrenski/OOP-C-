using System;

namespace ClassBoxData
{
    public class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            Box rectangle = new Box(a, b, h);
            Console.WriteLine(rectangle.CalculateSurfaceArea());
            Console.WriteLine(rectangle.CalculateLateralArea());
            Console.WriteLine(rectangle.CalculateVolume());
        }
    }
}
