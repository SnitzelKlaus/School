using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    public class Rectangle : Shape
    {
        int _a;
        int _b;

        public Rectangle(string type, int a, int b) : base(type)
        {
            _a = a;
            _b = b;
        }
        public override double CalArea()
        {
            return _a * _b;
        }

        public override int CalCircuit()
        {
            return 2 *(_a + _b);
        }
    }
}
