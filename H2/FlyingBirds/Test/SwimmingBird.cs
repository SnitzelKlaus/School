using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public abstract class SwimmingBird : IFlyingBird, ISwimmingBird
    {
        public virtual void Draw()
        {
            Console.WriteLine("--^--");
        }

        public virtual void SetAltitude(double altitude)
        {
            Console.WriteLine($"Altitude is {altitude}");
        }

        public virtual void SetLocation(double longtitude, double latitude)
        {
            Console.WriteLine($"Location: {longtitude}, {latitude}");
        }

        public virtual void SwimmingDepths(double depth)
        {
            Console.WriteLine($"Swimming depth: {depth}");
        }
    }
}
