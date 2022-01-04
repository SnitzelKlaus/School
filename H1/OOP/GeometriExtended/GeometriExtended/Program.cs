using System;

namespace Geometri
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Side: ");
            Square square = new Square(double.Parse(Console.ReadLine()));
            Console.WriteLine("Perimeter: " + square.Perimeter());
            Console.WriteLine("Area: " + square.Area());

            Console.Write("\nSide: ");
            Square secondSquare = new Square(double.Parse(Console.ReadLine()));
            Console.WriteLine("Perimeter: " + secondSquare.Perimeter());
            Console.WriteLine("Area: " + secondSquare.Area());

            Console.ReadKey();
        }
    }
}
