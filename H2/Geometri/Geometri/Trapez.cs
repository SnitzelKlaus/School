using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    public class Trapez : Shape
    {
        int _a;
        int _b;
        int _c;
        int _d;
        public Trapez(string type, int a, int b, int c, int d) : base(type)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }

        public override double CalArea()
        {
            double s = (_a + _b - _c + _d) / 2;
            double h = (2/(_a - _c)) * Math.Sqrt(s * (s - _a + _c) * (s - _b) * (s - _d));
            return ((_a + _c)/2) * h;
        }

        public override int CalCircuit()
        {
            return _a + _b + _c + _d;
        }
    }
}
