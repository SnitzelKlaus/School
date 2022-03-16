using System;
using System.Threading;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            ISwimmingBird duck = new Duck();

            IBird duck2 = new FlyingBird();

            ISwimmingBird duck3 = new Duck();

            duck.SwimmingDepths(222);
            duck2.Draw();
            duck3.SwimmingDepths(123);
        }
    }
}