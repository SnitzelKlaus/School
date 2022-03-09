using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_Philosophers
{
    public class Table
    {
        public static Philosophers[] philosophers = new Philosophers[5];

        public void StartDining()
        {
            Thread[] ph = new Thread[5];

            for (int i = 0; i < ph.Length; i++) //Puts data in thread array and gives each thread a name
            {
                Thread thread = new Thread(new ThreadStart(Philosophers.SelectFork));
                thread.Name = i.ToString();
                ph[i] = thread;
            }

            for (int i = 0; i < ph.Length; i++) //Starts dining philosophers
            {
                ph[i].Start();
            }
        }
    }
}
