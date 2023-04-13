using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using interfacePresentation.Fishes;
using interfacePresentation.Interfaces;


namespace interfacePresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Object Creation
            Sunfish sunfish = new Sunfish(
                "Sunfish",                                  // Name
                "A fish that swims in the sun",             // Description
                "Ocean",                                    // Habitat
                "Plankton",                                 // Diet
                40,                                         // X
                10,                                         // Y
                5,                                          // Width
                15,                                         // Height
                true,                                       // IsHitable
                false,                                      // IsFrozen
                true                                        // IsVisible
                );

            Shark shark = new Shark(
                "Shark",                                    // Name
                "A fish that swims in the ocean",           // Description
                "Ocean",                                    // Habitat
                "Fish",                                     // Diet
                10,                                         // X
                14,                                         // Y
                4,                                          // Width
                2,                                          // Height
                true,                                       // IsHitable
                false,                                      // IsFrozen
                true                                        // IsVisible
                );
            #endregion


            List<IObject> objects = new List<IObject>()
            {
                sunfish,
                shark
            };

            foreach (IFish obj in objects)
            {
                Console.WriteLine(obj.Description);
                Console.WriteLine(obj.Diet);
            }

            foreach (IObject obj in objects)
            {
                Console.WriteLine(obj.X);
                Console.WriteLine(obj.Y);
            }


            #region Stuff
            ConsoleKey direction = ConsoleKey.DownArrow;

            // Disables console cursor
            Console.CursorVisible = false;
            while (true)
            {
                foreach (IObject obj in objects)
                {
                    if (obj.IsVisible)
                    {
                        foreach (IObject obj2 in objects)
                        {
                            // Collision detection
                            if (obj.X >= obj2.X && obj.X <= (obj2.X + obj2.Width) && obj.Y > obj2.Y && obj.Y < (obj2.Y + obj2.Height))
                                break;

                            obj.Draw(obj.X, obj.Y);
                        }
                    }
                }

                // Gets input if key pressed
                if (Console.KeyAvailable)
                {
                    // Stores pressed key
                    ConsoleKey keyPressed = Console.ReadKey().Key;

                    switch (direction)
                    {
                        case ConsoleKey.LeftArrow when keyPressed != ConsoleKey.RightArrow:
                        case ConsoleKey.RightArrow when keyPressed != ConsoleKey.LeftArrow:
                        case ConsoleKey.UpArrow when keyPressed != ConsoleKey.DownArrow:
                        case ConsoleKey.DownArrow when keyPressed != ConsoleKey.UpArrow:
                            direction = keyPressed;
                            break;
                    }

                    // Moves object
                    switch (direction)
                    {
                        case ConsoleKey.LeftArrow:
                            sunfish.X -= 2;
                            break;
                        case ConsoleKey.RightArrow:
                            sunfish.X += 2;
                            break;
                        case ConsoleKey.DownArrow:
                            sunfish.Y += 1;
                            break;
                        case ConsoleKey.UpArrow:
                            sunfish.Y -= 1;
                            break;
                    }
                }
            }
            #endregion
        }
    }
}