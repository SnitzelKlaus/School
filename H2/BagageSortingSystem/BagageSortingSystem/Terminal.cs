using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSortingSystem
{
    public class Terminal
    {
        int Id { get; set; }
        public bool IsAlive { get; set; }
        public static Queue<Luggage> LuggageList = new Queue<Luggage>();

        public Terminal(int id, bool isAlive)
        {
            Id = id;
            IsAlive = isAlive;
            
        }
    }
}
