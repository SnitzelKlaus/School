using System;
using System.Collections.Generic;

namespace Geometri
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle("Rectagnle", 2, 4);
            Shape sqaure = new Square("square", 2);
            Shape trapez = new Trapez("Trapez", 10, 9,8,9);
            Shape parallelogram = new Parallelogram("Parallelogram", 3, 5, 20);

            List<Shape> shapes = new List<Shape>();
            shapes.Add(rectangle);
            shapes.Add(trapez);
            shapes.Add(sqaure);
            shapes.Add(parallelogram);

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.Type);
                Console.WriteLine(shape.CalArea());
                Console.WriteLine(shape.CalCircuit());
                Console.WriteLine();
            }
        }
    }
}
