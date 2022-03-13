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
            IsAlive = isAlive;

            Thread checkIn = new Thread(CheckInLuggage);
            checkIn.Start();
        }

        private void CheckInLuggage()
        {
            Random random = new Random();
            LuggageCounter = 0;

            while (true)
            {
                if (IsAlive)
                {
                    for (int i = 0; i < LuggageBuffer; i++)
                    {
                        Monitor.Enter(Airport.Conveyor);

                        Airport.Conveyor.Enqueue(new Luggage($"{Id}-{LuggageCounter}"));
                        Console.WriteLine($"Luggage ID:[{Id}-{LuggageCounter}] added to the conveyor belt.");
                        LuggageCounter++;
                        Monitor.PulseAll(Airport.Conveyor);
                        Monitor.Exit(Airport.Conveyor);

                        Thread.Sleep(random.Next(200, 500));
                    }
                }
            }
        }
    }
}
