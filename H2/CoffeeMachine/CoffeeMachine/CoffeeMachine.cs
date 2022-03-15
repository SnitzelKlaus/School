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
            Content = new Content("Caffee", 500, 1000);
            Liquid = new Liquid("Water", 1000, 2000);
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
            double coffeeMix = cupSize / 5;
            double waterMix = coffeeMix - cupSize;

            try
            {
                Liquid.DecreaseItem(waterMix);
                Content.DecreaseItem(coffeeMix);

                return $"Produced 1 cup of coffee, amount: {cupSize} ml.";
            }
            catch (Exception no)
            {
                return $"ERROR: {no.Message}";
                throw;
            }
        }
    }
}
