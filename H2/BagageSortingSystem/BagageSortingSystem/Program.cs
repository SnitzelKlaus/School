using System;
using System.Threading;

namespace BagageSortingSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            int terminals = 5;
            int checkIns = 5;
            int planes = 5;

            Airport airport = new Airport();
            airport.Copenhagen(terminals, checkIns, planes);
        }
    }
}