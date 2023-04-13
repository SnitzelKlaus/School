using interfacePresentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfacePresentation.Fishes
{
    public class Shark : IFish, IObject
    {
        public Shark(string name, string description, string habitat, string diet, int x, int y, int width, int height, bool isHitable, bool isFrozen, bool isVisible)
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            Diet = diet;
            X = x;
            Y = y;
            IsHitable = isHitable;
            IsFrozen = isFrozen;
            IsVisible = isVisible;
        }

        // Implement IFish interface
        public string Name { get; set; }
        public string Description { get; set; }
        public string Habitat { get; set; }
        public string Diet { get; set; }


        // Implements IObject
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsHitable { get; set; }
        public bool IsFrozen { get; set; }
        public bool IsVisible { get; set; }


        // Implements IDraw
        public void Draw(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.SetCursorPosition(x, y);
            Console.Write("      .        ");
            Console.SetCursorPosition(x, y+1);
            Console.Write("\\_____)\\_____");
            Console.SetCursorPosition(x, y+2);
            Console.Write("/--v____ __`< ");
            Console.SetCursorPosition(x, y+3);
            Console.Write("        )/     ");
            Console.SetCursorPosition(x, y+4);
            Console.Write("        '");
        }
    }
}
