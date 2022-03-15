using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineFirstPart
{
    public abstract class Container
    {
        public string Item { get => _item; set => _item = value; }
        public double Amount { get => _currentAmount; set => _currentAmount = value; }
        public double MaxAmount { get => _maxAmount; set => _maxAmount = value; }

        private string _item;
        private double _currentAmount;
        private double _maxAmount;

        public Container(string item, double amount, double maxAmount)
        {
            _item = item;
            _currentAmount = amount;
            _maxAmount = maxAmount;
        }

        public virtual void IncreaseItem(double input)
        {
            if(input < MaxAmount && input >= 0)
            {
                Amount = Amount + input;
            }
            else if(input > MaxAmount)
            {
                MaxAmount = Amount;

                Console.WriteLine("You've filled the container to the top!");
            }
            else
            {
                throw new ArgumentException("Something went wrong :(");
            }
        }
        public virtual void DecreaseItem(double input)
        {
            if(input < Amount)
            {
                Amount = Amount - input;
            }
            else
            {
                throw new ArgumentException("The container is running low, please fill it up and try again!");
            }
        }
    }
}
