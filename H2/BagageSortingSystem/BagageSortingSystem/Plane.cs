using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSortingSystem
{
    public class Plane
    {
        public int Id { get; set; }
        public DateTime TakeOff { get; set; }
        public string Destination
        {
            get
            {
                return Destination;
            }
            set
            {
                Destination = DestinationList.GetRandom();
            }
        }

        public int Terminal
        {
            get
            {
                return Terminal;
            }
            set
            {
                bool terminalFound = false;
                while (!terminalFound)
                {
                    for (int i = 0; i < Airport.Terminals.Count; i++)
                    {
                        if (Airport.Terminals[i].IsAvailable)
                        {
                            Terminal = i;
                            terminalFound = true;
                        }
                    }
                }
            }
        }

        public Plane(int id)
        {
            Id = id;
        }
    }
}
