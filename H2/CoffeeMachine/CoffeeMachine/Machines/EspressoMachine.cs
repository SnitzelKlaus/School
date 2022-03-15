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
            Content = new Content("Espresso", 0, 1000); //   (name, amount, maxAmount)
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
            double espressoMix = cupSize / 3;
            double waterMix = espressoMix - cupSize;

            if (!IsAlive)
                return $"Please turn the EspressoMachine on";

            if (!Filter)
                return $"Please insert new filter in EspressoMachine";

            try
            {
                Liquid.DecreaseItem(waterMix);
                Content.DecreaseItem(espressoMix);

                return $"Produced 1 cup of Espresso, amount: {cupSize} ml.";
            }
            catch (Exception no)
            {
                return $"ERROR: {no.Message}";
                throw;
            }
        }
    }
}
