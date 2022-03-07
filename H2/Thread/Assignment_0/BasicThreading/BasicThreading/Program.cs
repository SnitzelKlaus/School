/*
* C# Program to Create a Simple Thread
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
class program
{
    public void WorkThreadFunction()
    {
        for (int i = 0; i < 5; i++)
            {
            Console.WriteLine($"Simple Thread: {Thread.CurrentThread.Name}");
            }
        }
    }

class threprog
{
    public static void Main()
    {
        program pg = new program();
        Thread thread = new Thread(new ThreadStart(pg.WorkThreadFunction));
        Thread thread1 = new Thread(new ThreadStart(pg.WorkThreadFunction));
        Thread thread2 = new Thread(new ThreadStart(pg.WorkThreadFunction));

        thread1.Name = "first";
        thread2.Name = "second";
        
        thread.Start();
        thread1.Start();
        thread2.Start();

        Console.Read();
    }
}