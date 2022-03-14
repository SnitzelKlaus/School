using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    public abstract class Shape
    {
        private string _type;
        public string Type { get => _type; set => _type = value; }

        public Shape(string type)
        {
            _type = type;
        }
        public abstract double CalArea();
        public abstract int CalCircuit();
    }
}
