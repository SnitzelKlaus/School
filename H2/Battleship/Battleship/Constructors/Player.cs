using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class Player : IAlive, IScore
    {
        private string _name;
        private bool _isAlive;
        private List<Ship> _ships;
        private int _shipsLeft;
        private int _score;
        private int _shotsMiss;
        private int _shotsHit;
        
        public string Name { get => _name; set => _name = value; }
        public bool IsAlive { get => _isAlive; set => _isAlive = value; }
        public List<Ship> Ships { get => _ships; set => _ships = value; }
        public int ShipsLeft { get => _shipsLeft; set => _shipsLeft = value; }
        public int ShotsMiss { get => _shotsMiss; set => _shotsMiss = value; }
        public int ShotsHit { get => _shotsHit; set => _shotsHit = value; }

        public int Score { get => _score; set => _score = value; }

        public void AddHit()
        {
            ShotsHit++;
        }

        public void AddMiss()
        {
            ShotsMiss++;
        }

        public void AddScore(int score)
        {
            Score += score;
        }
    }
}
