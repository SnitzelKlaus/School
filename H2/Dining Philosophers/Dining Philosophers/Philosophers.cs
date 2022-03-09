using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_Philosophers
{
    public class Philosophers
    {
        public bool _leftFork { get; set; }
        public bool _rightFork { get; set; }
        static object _lock = new object();

        public Philosophers(bool leftFork, bool rightFork)
        {
            _leftFork = leftFork;
            _rightFork = rightFork;
        }

        public static void SelectFork()
        {
            int id = Convert.ToInt16(Thread.CurrentThread.Name);

            int leftFork = id;
            int rightFork = id - 1;

            while (true)
            {
                if (rightFork < Fork._forks.Length)
                    rightFork = Fork._forks.Length;

                lock (_lock)
                {
                    if(Fork._forks[leftFork] == true && Fork._forks[rightFork] == true)
                    {
                        Table.philosophers[id]._leftFork = true;
                        Table.philosophers[id]._rightFork = true;
                        Fork._forks[leftFork] = false;
                        Fork._forks[rightFork] = false;

                        Console.WriteLine($"Ph{id}, is eating with fork {leftFork}, and Fork {rightFork}");
                        Thread.Sleep(1000);

                        Table.philosophers[id]._leftFork = false;
                        Table.philosophers[id]._rightFork = false;
                        Fork._forks[leftFork] = true;
                        Fork._forks[rightFork] = true;

                        Console.WriteLine($"Ph{id} | Done");
                    }
                }
            }
        }

        public void Eat()
        {

        }
    }
}
