using System;
using System.Threading;

namespace CoffeeMachineFirstPart
{
    public class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            coffeeMachine.Liquid.IncreaseItem(500);
            coffeeMachine.Content.IncreaseItem(500);
            Console.WriteLine(coffeeMachine.Produce(420));

            EspressoMachine espressoMachine = new EspressoMachine();
            espressoMachine.Liquid.IncreaseItem(500);
            espressoMachine.Content.IncreaseItem(500);
            Console.WriteLine(espressoMachine.Produce(690));

            Console.ReadKey();
        }
    }
}