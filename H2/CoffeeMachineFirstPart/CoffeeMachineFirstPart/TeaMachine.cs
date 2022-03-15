using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineFirstPart
{
    public class TeaMachine : Machine, IFilter
    {
        public TeaMachine()
        {
            Content = new Content("Tea", 500, 1000);
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
            double teaMix = cupSize / 3;
            double waterMix = teaMix - cupSize;

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
