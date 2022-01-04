using System;

namespace CleanUp
{
    public class UIGraphics
    {
        public void Menu()
        {
            Console.Clear();

            Console.WriteLine("----------------------");
            Console.WriteLine("    Computer Info     ");
            Console.WriteLine("----------------------\n");

            Console.WriteLine("Please choose an option below:\n");

            Console.WriteLine("[1] Get users");
            Console.WriteLine("[2] Get booting device");
            Console.WriteLine("[3] Get memory");
            Console.WriteLine("[4] Get disk metadata");
            Console.WriteLine("[5] Get harddisk seriel number");
            Console.WriteLine("[6] Get processor");
            Console.WriteLine("[7] List all services");

            Console.Write("\n[]: ");
        }
    }
}
