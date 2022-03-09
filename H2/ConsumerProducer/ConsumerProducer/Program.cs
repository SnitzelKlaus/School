using System;
using System.Threading;

namespace ConsumerProducer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] productNames = { "Cola", "My", "Dude" };
            int[] itemCount = { 5, 3, 8 };

            Manager manager = new Manager();
            manager.Start(productNames, itemCount);
        }
    }
}