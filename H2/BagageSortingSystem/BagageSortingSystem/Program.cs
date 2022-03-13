using System;
using System.Threading;

namespace BagageSortingSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            int terminals = 3;
            int checkIns = 3;
            int planes = 3;

            Airport airport = new Airport();
            airport.Copenhagen(terminals, checkIns, planes);
        }
    }
}