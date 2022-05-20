using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class Ship
    {
        private string _name;
        private bool _isHorizontal;
        private int _amountOfParts;
        private int _amountOfHits;
        private List<ShipPart> _shipParts;
        private double _xPos;
        private double _yPos;

        public string Name { get => _name; set => _name = value; }
        public bool IsHorizontal { get => _isHorizontal; set => _isHorizontal = value; }
        public int AmountOfParts { get => _amountOfParts; set => _amountOfParts = value; }
        public int AmountOfHits { get => _amountOfHits; set => _amountOfHits = value; }
        public List<ShipPart> ShipParts { get => _shipParts; set => _shipParts = value; }
        public double XPos { get => _xPos; set => _xPos = value; }
        public double YPos { get => _yPos; set => _yPos = value; }

        public void RotateShip()
        {
            if (IsHorizontal)
            {
                IsHorizontal = false;
            }
            else
            {
                IsHorizontal = true;
            }
        }

        public void PlaceShip()
        {
            
        }
    }
}
