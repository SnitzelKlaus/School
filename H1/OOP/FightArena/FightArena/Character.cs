using System;
using System.Collections.Generic;
using System.Text;

namespace FightArena
{
    class Character
    {
        public Character(string name, int hitpoints, int minAttack, int maxAttack, int minDefence, int maxDefence)
        {
            Name = name;
            Hitpoints = hitpoints;
            MinAttack = minAttack;
            MaxAttack = maxAttack;
            MinDefence = minDefence;
            MaxDefence = maxDefence;
        }

        public string Name { get; set; }

        public int Hitpoints { get; set; }

        public int MinAttack { get; set; }

        public int MaxAttack { get; set; }

        public int MinDefence { get; set; }

        public int MaxDefence { get; set; }
    }
}
