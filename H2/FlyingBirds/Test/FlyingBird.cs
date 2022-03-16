using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class FlyingBird : IFlyingBird
    {
        public void Draw()
        {
            Console.WriteLine("--^--");
        }

        public void SetAltitude(double altitude)
        {
            throw new NotImplementedException();
        }

        public void SetLocation(double longtitude, double latitude)
        {
            throw new NotImplementedException();
        }
    }
}
