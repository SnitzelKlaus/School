using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_Philosophers
{
    class Philosophers
    {
        public bool _leftFork { get; set; }
        public bool _rightFork { get; set; }
        object _lock = new object();

        public Philosophers(bool leftFork, bool rightFork)
        {
            _leftFork = leftFork;
            _rightFork = rightFork;
        }

        public static void StartDining()
        {
            Philosophers[] philosophers = new Philosophers[5];
        }

        public static void SelectFork(object obj)
        {
            
        }

        public void Eat()
        {

        }
    }
}
