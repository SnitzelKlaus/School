using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class ShipPart : Object, IAlive
    {
        private bool _isAlive;

        public bool IsAlive { get => _isAlive; set => _isAlive = value; }

        public ShipPart(int xPos, int yPos, bool isAlive) : base(xPos, yPos)
        {
            IsAlive = isAlive;
        }
    }
}
