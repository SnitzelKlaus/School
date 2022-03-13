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
        public bool IsAvailable { get; set; }
        public bool IsAlive { get; set; }
        public Queue<Luggage> LuggageList = new Queue<Luggage>();

        public Terminal(int id, bool isAlive, bool isAvailable)
        {
            Id = id;
            IsAlive = isAlive;
            IsAvailable = isAvailable;
            

        }
    }
}
