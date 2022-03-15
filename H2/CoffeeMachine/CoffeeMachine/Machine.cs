using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public abstract class Machine
    {
        public Content Content { get => _content; set => _content = value; }
        public Liquid Liquid { get => _liquid; set => _liquid = value; }
        public bool IsAlive { get => _isAlive; set => _isAlive = value; }

        private Content _content;
        private Liquid _liquid;
        private bool _isAlive;

        public void TurnOn()
        {
            IsAlive = true;
        }

        public void TurnOff()
        {
            IsAlive = false;
        }

        public abstract string Produce(double cupSize);
    }
}
