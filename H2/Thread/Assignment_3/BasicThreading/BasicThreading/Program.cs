using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
class program
{
    public static void Main()
    {
        Thread tempReader = new Thread(RandomTemp);

        tempReader.Start();

        Stopwatch sw = Stopwatch.StartNew();
        while (true)
        {
            if(sw.ElapsedMilliseconds > 10000)
            {
                sw.Reset();
                if (!tempReader.IsAlive)
                {
                    Console.WriteLine("Alarm-tråd termineret!");
                    System.Environment.Exit(0);
                }
            }
        }
        Console.Read();
    }

    static void RandomTemp() //Writes a random temperatur between -20 og 120 C.
    {
        Random random = new Random();
        int temperatur;
        int alarm = 0;

        while (true)
        {
            temperatur = random.Next(-20,120);
            Console.WriteLine(temperatur);
            Thread.Sleep(200);

            if(temperatur > 100 || temperatur < 0)
                alarm++;

            if (alarm > 3)
                return;
        }
    }
}