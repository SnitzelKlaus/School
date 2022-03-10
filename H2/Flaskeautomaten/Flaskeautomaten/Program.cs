using System;
using System.Threading;

namespace Flaskeautomaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] products = { "Beer", "Cola", "Squash" };

            Manager manager = new Manager();
            manager.Start(products);
        }
    }
}