using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class Liquid : Container
    {
        public Liquid(string item, double amount, double maxAmount):base(item, amount, maxAmount)
        {

        }
    }
}
