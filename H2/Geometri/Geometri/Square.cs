using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    public class Square : Shape
    {
        private int _a;

        public Square(string type, int a):base(type)
        {
            _a = a;
        }
        public override double CalArea()
        {
            return _a * _a;
        }
        public override int CalCircuit()
        {
            return 2 * (_a + _a);
        }
    }
}
