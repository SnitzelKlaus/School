using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    public class Parallelogram : Shape
    {
        int _a;
        int _b;
        double _angle;
        public Parallelogram(string type, int a, int b, double angle) : base(type)
        {
            _a = a;
            _b = b;
            _angle = angle;
        }
        public override double CalArea()
        {
            return _a * _b * Math.Sin(_angle);
        }

        public override int CalCircuit()
        {
            return 2 * (_a + _b);
        }
    }
}
