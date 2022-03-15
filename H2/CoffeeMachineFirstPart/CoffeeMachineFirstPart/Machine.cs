using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineFirstPart
{
    public abstract class Machine
    {
        private string _name;
        private bool _isAlive;
        private ContentContainer _content;
        private LiquidContainer _liquid;

        public string Name { get => _name; set => _name = value; }
        public bool IsAlive { get => _isAlive; set => _isAlive = value; }
        public ContentContainer Content { get => _content; set => _content = value; }


        public Machine(string name)
        {
            this._name = name;
        }
    }
}
