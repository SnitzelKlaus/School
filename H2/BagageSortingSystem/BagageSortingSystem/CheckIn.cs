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
        private int LuggageCounter { get; set; }

        public CheckIn(int id, int luggageBuffer)
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

            }
        }
    }
}
