using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public interface IScore
    {
        int Score { get; set; }
        int ShotsHit { get; set; }
        int ShotsMiss { get; set; }


        void AddHit();
        void AddMiss();
        void AddScore(int score);
    }
}
