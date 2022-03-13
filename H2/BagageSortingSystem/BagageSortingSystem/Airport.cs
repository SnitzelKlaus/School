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
        public static List<CheckIn> CheckIns = new List<CheckIn>();
        public static List<Plane> Planes = new List<Plane>();

        public void Copenhagen(int terminals, int checkIns, int planes)
        {
            #region Destinations
            List<string> destinations = new List<string>();
            destinations.Add("Norway");
            destinations.Add("Sweden");
            destinations.Add("Germany");

            DestinationList.Destinations = destinations;
            #endregion

            #region Start
            for (int i = 0; i < checkIns; i++)
            {
                CheckIns.Add(new CheckIn(i, 10, true)); //Adds check-in to the list
                _ = CheckIns[i]; //Starts check-in, airport counter
            }

            for (int i = 0; i < terminals; i++)
            {
                Terminals.Add(new Terminal(i, true, true)); //Adds terminal to the list
                _ = Terminals[i]; //Starts terminal
            }

            for (int i = 0; i < planes; i++)
            {
                Planes.Add(new Plane(i)); //Adds plane to the list
                _ = Planes[i]; //Starts plane
            }

            _ = new LuggageSorter(0); //Starts sorter
            #endregion
        }
    }
}
