using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    class ParseInput
    {
        public static int ParseInt()
        {
            int output;

            while (!int.TryParse(Console.ReadLine(), out output))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ERROR: ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Input NOT valid! (Input only even numbers)");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n[Qty]:");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            return output;
        }
    }
}
