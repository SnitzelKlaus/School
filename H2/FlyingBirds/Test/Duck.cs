using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Duck : SwimmingBird
    {
        public override void SetAltitude(double altitude)
        {
            base.SetAltitude(altitude);
        }

        public override void SetLocation(double longtitude, double latitude)
        {
            base.SetLocation(longtitude, latitude);
        }

        public override void SwimmingDepths(double depth)
        {
            base.SwimmingDepths(depth);
        }
    }
}
