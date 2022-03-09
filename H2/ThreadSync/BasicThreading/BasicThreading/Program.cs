using System;
using System.Threading;
using System.IO;
using System.Diagnostics;
namespace ThreadPooling
{
    class Program
    {
        static int sum = 0;
        private Object _lock = new Object();

        static void Main(string[] args)
        {
            Thread inc = new Thread(Increase);
            Thread dec = new Thread(Decrease);

            inc.Start();
            dec.Start();

            while(true)
            {
                Console.WriteLine(sum);
                Thread.Sleep(1000);
            }
        }
        static void Increase()
        {
            while (true)
            {
                Monitor.Enter(sum);
                try
                {
                    sum = sum + 2;
                }
                finally
                {
                    Monitor.Exit(sum);
                }
                Thread.Sleep(1000);
            }
        }

        static void Decrease()
        {
            while (true)
            {
                Monitor.Enter(sum);
                try
                {
                    sum--;
                }
                finally
                {
                    Monitor.Exit(sum);
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
