using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_Philosophers
{
    public class Philosophers
    {
        public int Id { get; set; }
        public Fork LeftFork { get; set; }
        public Fork RightFork { get; set; }

        public Philosophers(int id, Fork leftFork, Fork rightFork) //Constructs philosopher from inserted data
        {
            this.LeftFork = leftFork;
            this.RightFork = rightFork;
            this.Id = id;

            Thread ph = new Thread(GrabFork); //Starts philosopher thread
            ph.Start();
        }

        public void GrabFork()
        {
            while (true)
            {
                Random random = new Random();
                Thread.Sleep(1000);

                if (Monitor.TryEnter(LeftFork)) //Attempts to grabs left or right fork
                {
                    try
                    {
                        if (Monitor.IsEntered(LeftFork)) //Grabbed left fork
                        {
                            Console.WriteLine($"Ph: {Id} grabbed left fork |(*).");
                            try
                            {
                                int attempt = random.Next(5);
                                int count = 0;

                                Thread.Sleep(1000);
                                Console.WriteLine($"Ph: {Id} is trying to grab right fork |(*).");

                                while (count < attempt) //Finite number of attempts
                                {
                                    if (Monitor.TryEnter(RightFork)) //Attempts to grab right fork
                                    {
                                        Console.WriteLine($"Ph: {Id} grabbed right fork |(*)|"); //Grabbed right fork
                                        try
                                        {
                                            Eat(); //Eats!
                                            Thread.Sleep(random.Next(500));
                                            break;
                                        }
                                        finally
                                        {
                                            Console.WriteLine($"Ph: {Id} let go of right fork |(*)."); //Lets go of right fork
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Ph: {Id} couldn't grab right fork |(*). but will try ({attempt - count}) times");
                                    }
                                    count++;
                                    Thread.Sleep(1000);
                                }
                            }
                            finally //Lets go of left fork
                            {
                                Console.WriteLine($"Ph: {Id} let go of left fork .(*).");
                            }
                        }

                    }
                    finally //Lets go of left fork
                    {
                        Console.WriteLine($"Ph: {Id} lets go of left fork .(*).");
                    }

                }
            }
        }

        public void Eat() //Eats!
        {
            Console.WriteLine($"Ph: {Id} is eating with left fork {LeftFork.Id} and right fork {RightFork.Id}");
        }
    }
}
