using System;
using System.Threading;

namespace ProducerConusmer
{
    internal class Program
    {
        static Queue<int> product = new Queue<int>();

        static void Main(string[] args)
        {
            Thread c = new Thread(Consume);
            c.Start();
            Thread p = new Thread(Produce);
            p.Start();
        }

        static void Produce()
        {
            while (true)
            {
                Monitor.Enter(product);
                for (int i = 0; i <= 10; i++)
                {
                    product.Enqueue(i);
                    Console.WriteLine("Producing");
                    Thread.Sleep(200);
                }
                Monitor.PulseAll(product);
                Monitor.Exit(product);
                Thread.Sleep(1000);
            }
        }

        static void Consume()
        {
            while (true)
            {
                Monitor.Enter(product);

                if (product.Count == 0)
                {
                    Console.WriteLine("Consumer waiting");
                    Monitor.Wait(product);
                }

                product.Dequeue();
                Console.WriteLine("Consumer eating");
                Thread.Sleep(200);
            }
        }
    }
}