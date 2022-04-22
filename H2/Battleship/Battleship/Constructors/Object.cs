using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class Object : IPosition
    {
        private double _xPos;
        private double _yPos;

        public double XPos { get => _xPos; set => _xPos = value; }
        public double YPos { get => _yPos; set => _yPos = value; }

        public Object(int xPos, int yPos)
        {
            _xPos = xPos;
            _yPos = yPos;
        }
    }
}
