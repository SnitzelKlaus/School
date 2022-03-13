using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSortingSystem
{
    public class Luggage
    {
        public string Id { get; set; }
        public string Destination { 
            get
            {
                return Destination;
            }
            set
            {
                Destination = DestinationList.GetRandom();
            }
        }

        public Luggage (string id)
        {
            Id = id;
        }
    }
}
