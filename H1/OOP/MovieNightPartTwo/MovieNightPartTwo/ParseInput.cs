using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNightFirstPart
{
    public class ParseInput
    {
        public int ParseInt()
        {
            int output;

            while (!int.TryParse(Console.ReadLine(), out output))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ERROR: ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Input NOT valid! (Input only even numbers)");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[]: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            return output;
        }
    }
}
