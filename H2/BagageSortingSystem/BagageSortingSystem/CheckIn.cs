using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSortingSystem
{
    public class CheckIn
    {
        public int Id { get; set; }
        public int LuggageBuffer { get; set; }
        public bool IsAlive { get; set; }
        private int LuggageCounter { get; set; }

        public CheckIn(int id, int luggageBuffer, bool isAlive)
        {
            Id = id;
            LuggageBuffer = luggageBuffer;

            Thread counter = new Thread(CheckInLuggage);
            counter.Start();
        }

        private void CheckInLuggage()
        {
            while (true)
            {
                if (IsAlive)
                {
                    Monitor.Enter(Airport.Conveyor);
                    
                }
            }
        }
    }
}
