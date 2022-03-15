using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class TeaMachine : Machine, IFilter
    {
        public TeaMachine()
        {
            Content = new Content("Tea", 0, 1000); //   (name, amount, maxAmount)
            Liquid = new Liquid("Milk", 0, 2000);
        }

        public bool Filter { get; set; }

        public void FilterUsed()
        {
            Filter = false;
        }

        public void FilterRenew()
        {
            Filter = true;
        }

        public override string Produce(double cupSize)
        {
            //Defines values for mixing
            double teaMix = cupSize / 3;
            double waterMix = teaMix - cupSize;

            if (!IsAlive)
                return $"Please turn the machine on";

            if (!Filter)
                return $"Please insert new filter in TeaMachine";

            try
            {
                Liquid.DecreaseItem(waterMix);
                Content.DecreaseItem(teaMix);

                return $"Produced 1 cup of Tea, amount: {cupSize} ml.";
            }
            catch (Exception no)
            {
                return $"ERROR: {no.Message}";
                throw;
            }
        }
    }
}
