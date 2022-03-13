using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSortingSystem
{
    public class DestinationList
    {
        public static List<string> Destinations { get; set; }

        public static string GetRandomDestination()
        {
            Random random = new Random();
            return Destinations[random.Next(0, Destinations.Count)];
        }
    }
}
