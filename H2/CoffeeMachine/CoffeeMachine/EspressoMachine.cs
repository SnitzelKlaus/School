using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class EspressoMachine : Machine, IFilter
    {
        public EspressoMachine()
        {
            Content = new Content("Espresso", 500, 1000);
            Liquid = new Liquid("Milk", 1000, 2000);
        }

        public bool Filter { get; set; }

        public void FilterUsed()
        {
            Filter = false;
        }

        public void ReplaceFilter()
        {
            Filter = true;
        }

        public override string Produce(double cupSize)
        {
            double espressoMix = cupSize / 3;
            double waterMix = espressoMix - cupSize;

            try
            {
                Liquid.DecreaseItem(waterMix);
                Content.DecreaseItem(espressoMix);

                return $"Produced 1 cup of espresso, amount: {cupSize} ml.";
            }
            catch (Exception no)
            {
                return $"ERROR: {no.Message}";
                throw;
            }
        }
    }
}
