using System;
using System.Threading;

namespace ConsumerProducer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Products
            string[] productName = { "Cola" }; //, "Squash", "Twinkie", "Duff"

            //Max qty of a products (5 cola, 3 squash, 8 twinkie ect.)
            int[] productionLimit = { 5 }; //, 6, 8, 6 

            Manager manager = new Manager();
            manager.Start(productName, productionLimit);
        }
    }
}