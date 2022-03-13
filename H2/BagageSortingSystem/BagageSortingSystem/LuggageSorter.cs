using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSortingSystem
{
    public class LuggageSorter
    {
        public int Id { get; set; }
        
        public LuggageSorter(int id)
        {
            Id = id;

            Thread sorter = new Thread(Sort);
            sorter.Start();
        }

        public void Sort()
        {
            while (true)
            {
                Monitor.Enter(Airport.Conveyor);

                if(Airport.Conveyor.Count == 0)
                {
                    Console.WriteLine("Conveyor waiting for luggage...");
                    Monitor.Wait(Airport.Conveyor);
                }

                for (int i = 0; i < Airport.Planes.Count; i++)
                {
                    if(Airport.Conveyor.Peek().Destination == Airport.Planes[i].Destination)
                    {
                        int terminal = Airport.Planes[i].Terminal;

                        Airport.Terminals[terminal].LuggageList.Enqueue(Airport.Conveyor.Peek());
                        Console.WriteLine($"Luggage ID:[{Airport.Conveyor.Peek().Id}] transfered to terminal:[{Airport.Terminals[terminal]}]");
                        Airport.Conveyor.Dequeue();
                    }
                }
            }
        }
    }
}
