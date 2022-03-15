using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineFirstPart
{
    public class Liquid : Container
    {
        public Liquid(string item, int amount, int maxAmount):base(item, amount, maxAmount)
        {

        }
    }
}
