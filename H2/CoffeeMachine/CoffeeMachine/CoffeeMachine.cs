using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class CoffeeMachine : Machine, IFilter
    {
        public CoffeeMachine()
        {
            Content = new Content("Caffee", 0, 1000); //   (name, amount, maxAmount)
            Liquid = new Liquid("Water", 0, 2000);
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
            double coffeeMix = cupSize / 5;
            double waterMix = coffeeMix - cupSize;

            if (!IsAlive)
                return $"Please turn the machine on";

            if (!Filter)
                return $"Please insert new filter in CoffeeMachine";

            try
            {
                Liquid.DecreaseItem(waterMix);
                Content.DecreaseItem(coffeeMix);

                return $"Produced 1 cup of Coffee, amount: {cupSize} ml.";
            }
            catch (Exception no)
            {
                return $"ERROR: {no.Message}";
                throw;
            }
        }
    }
}
