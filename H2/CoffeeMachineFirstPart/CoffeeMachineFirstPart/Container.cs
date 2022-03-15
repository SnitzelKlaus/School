using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineFirstPart
{
    public abstract class Container
    {
        private string _item;
        private int _currentAmount;
        private int _maxAmount;

        public string Item { get => _item; set => _item = value; }
        public int Amount { get => _currentAmount; set => _currentAmount = value; }
        public int MaxAmount { get => _maxAmount; set => _maxAmount = value; }

        public Container(string item, int amount, int maxAmount)
        {
            _item = item;
            _currentAmount = amount;
            _maxAmount = maxAmount;
        }

        public virtual void IncreaseItem(int input)
        {
            if(input < MaxAmount)
            {
                Amount = Amount + input;
            }
            else
            {
                MaxAmount = Amount;
                Console.WriteLine("You've filled the container to the top!");
            }
        }
        public virtual void DecreaseItem(int input)
        {
            if(input > Amount)
            {
                Amount = Amount - input;
            }
            else
            {
                Console.WriteLine("The container is running low, please fill it up and try again!");
            }
        }
    }
}
