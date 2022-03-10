using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConusmer
{
    public class Bakery
    {
        public static Queue<Donut> _donutTray = new Queue<Donut>();

        public Donut GetDonut()
        {
            lock(_donutTray)
            {
                while(_donutTray.Count == 0)
                {
                    Monitor.Wait(_donutTray);
                }

                return _donutTray.Dequeue();
            }
        }

        public void RefillTray(Donut[] freshDonuts)
        {
            lock (_donutTray)
            {
                foreach (Donut d in freshDonuts)
                {
                    _donutTray.Enqueue(d);
                }

                Monitor.PulseAll(_donutTray);
            }
        }
    }
}
