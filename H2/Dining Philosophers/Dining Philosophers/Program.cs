using System.Threading;
using System.IO;

namespace Dining_Philosophers
{
    class program
    {
        static void Main(string[] args)
        {
            Table table = new Table();
            table.StartDining();
        }
    }
}