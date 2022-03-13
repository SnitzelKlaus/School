using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSortingSystem
{
    public class Luggage
    {
        public int Id { get; set; }
        public string Destination = DestinationList.GetRandomDestination();
        public Luggage (int id, string destination)
        {
            Id = id;
            Destination = destination;
        }
    }
}
