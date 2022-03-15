using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineFirstPart
{
    public class ContentContainer
    {
        private string _name;
        private int _amount;

        public string Name { get => _name; set => _name = value; }
        public int Amount { get => _amount; set => _amount = value; }

        public ContentContainer(string name, int amount)
        {
            this._name = name;
            this._amount = amount;
        }
    }
}
