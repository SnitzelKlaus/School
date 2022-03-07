using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

class ThreadPoolDemo
{
    //Execute Task1
    public void task1(object obj)
    {
        for (int i = 0; i <= 2; i++)
        {
            Console.WriteLine("Task 1 is being executed");
        }
    }

    //Execute Task2
    public void task2(object obj)
    {
        for (int i = 0; i <= 2; i++)
        {
            Console.WriteLine("Task 2 is being executed");
        }
    }

    static void Main()
    {
        ThreadPoolDemo tpd = new ThreadPoolDemo();

        //Creates threads for task1 and task2
        for (int i = 0; i < 2; i++)
        {
            ThreadPool.QueueUserWorkItem(tpd.task1);
            ThreadPool.QueueUserWorkItem(tpd.task2);
        }
    Console.Read();
    }
}