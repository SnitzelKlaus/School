using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
class program
{
    static char _ch = '*';

    static void Main()
    {
        Thread reader = new Thread(Reader);
        Thread writer = new Thread(Writer);

        reader.Start();
        writer.Start();

    }

    static void Reader()
    {
        while (true)
        {
            _ch = Console.ReadKey().KeyChar;
        }
    }

    static void Writer()
    {
        while (true)
        {
            Console.Write(_ch);
            Thread.Sleep(_ch);
        }
    }
}