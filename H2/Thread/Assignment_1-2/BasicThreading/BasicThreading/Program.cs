using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
class program
{
    public static void Main()
    {
        program pg = new program();
        Thread thread = new Thread(FirstText);
        Thread thread1 = new Thread(SecondText);

        thread.Name = "first";
        thread1.Name = "second";

        thread.Start();
        thread1.Start();

        Console.Read();
    }

    static void FirstText() //Udskriver første del af teksten via nr. 1 tråd
    {
        for (int i = 0; i < 50; i++)
        {
            Console.WriteLine("C#-trådning er nemt!");
            Thread.Sleep(1000);
        }
    }

    static void SecondText() //Udskriver anden del af teksten via nr. 2 tråd
    {
        for (int i = 0; i < 50; i++)
        {
            Console.WriteLine("Også med flere tråde ...");
            Thread.Sleep(1000);
        }
    }
}