using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSortingSystem
{
    public class Airport
    {
        public static Queue<Luggage> Conveyor = new Queue<Luggage>();
        public static List<Terminal> Terminals = new List<Terminal>();
        public static List<CheckIn> CheckIn = new List<CheckIn>();
        public static List<Plane> Planes = new List<Plane>();

        public void Copenhagen(int terminals, int checkIns, int planes)
        {
            DestinationList.Destinations.Add("Norway");
            DestinationList.Destinations.Add("Sweden");
            DestinationList.Destinations.Add("Germany");

            for (int i = 0; i < terminals; i++)
            {

            }

            for (int i = 0; i < checkIns; i++)
            {

            }

            for (int i = 0; i < planes; i++)
            {

            }
        }
    }
}
