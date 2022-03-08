using System;
using System.Threading;
using System.IO;
using System.Diagnostics;
namespace ThreadPooling
{
    class Program
    {
        static int sum = 0;

        static void Main(string[] args)
        {
            Thread inc = new Thread(Increase);
            Thread dec = new Thread(Decrease);

            inc.Start();
            dec.Start();

            Console.WriteLine(sum);
        }
        static void Increase()
        {
            Interlocked.Increment(ref sum);
            Thread.Sleep(1000);
        }

        static void Decrease()
        {
            Interlocked.Increment(ref sum);
            Thread.Sleep(1000);
        }
    }
}