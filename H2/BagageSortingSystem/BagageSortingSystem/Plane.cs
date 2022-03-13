using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSortingSystem
{
    public class Plane
    {
        string Destination = DestinationList.GetRandomDestination();
        int Terminal { get; set; }
        DateTime TakeOff { get; set; }
        public Plane(string destination, int terminal, DateTime takeOff)
        {
            Destination = destination;
            Terminal = terminal;
            TakeOff = takeOff;
        }
    }
}
