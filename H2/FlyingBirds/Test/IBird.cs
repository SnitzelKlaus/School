using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public interface IBird
    {
        void SetLocation(double longtitude, double latitude);
        void Draw();
    }
}
