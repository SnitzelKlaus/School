using System;
using System.Threading;

namespace CoffeeMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            Console.WriteLine(coffeeMachine.Produce(420));

            TeaMachine teaMachine = new TeaMachine();
            Console.WriteLine(teaMachine.Produce(690.420690));

            EspressoMachine espressoMachine = new EspressoMachine();
            Console.WriteLine(espressoMachine.Produce(690));
            espressoMachine.FilterUsed();
            espressoMachine.ReplaceFilter();
            #region Increase supply
            Console.WriteLine($":::::EspressoMachine supply: {espressoMachine.Liquid.Item} [{espressoMachine.Liquid.Amount}], {espressoMachine.Content.Item} [{espressoMachine.Content.Amount}]");
            espressoMachine.Liquid.IncreaseItem(500);
            espressoMachine.Content.IncreaseItem(500);
            Console.WriteLine($":::::EspressoMachine supply: {espressoMachine.Liquid.Item} [{espressoMachine.Liquid.Amount}], {espressoMachine.Content.Item} [{espressoMachine.Content.Amount}]");
            #endregion

            Console.ReadKey();
        }
    }
}