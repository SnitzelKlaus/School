using System;
using System.Threading;

namespace CoffeeMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region CoffeeMachine
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            coffeeMachine.FilterRenew();
            coffeeMachine.Liquid.IncreaseItem(500);
            coffeeMachine.Content.IncreaseItem(500);
            coffeeMachine.TurnOn();
            Console.WriteLine(coffeeMachine.Produce(420));
            coffeeMachine.TurnOff();
            #endregion

            #region TeaMachine
            TeaMachine teaMachine = new TeaMachine();
            //teaMachine.FilterRenew();
            teaMachine.Liquid.IncreaseItem(500);
            teaMachine.Content.IncreaseItem(500);
            teaMachine.TurnOn();
            Console.WriteLine(teaMachine.Produce(690.420690));
            teaMachine.TurnOff();
            #endregion

            #region EspressoMachine
            EspressoMachine espressoMachine = new EspressoMachine();
            espressoMachine.FilterRenew();
            espressoMachine.Liquid.IncreaseItem(500);
            espressoMachine.Content.IncreaseItem(500);
            espressoMachine.TurnOn();
            Console.WriteLine(espressoMachine.Produce(690));
            espressoMachine.TurnOff();
            #endregion

            //Shows liquid and content has increased in espresso machine aswell as change in liquid
            #region Increase supply
            Console.WriteLine($"\n:::::EspressoMachine supply: {espressoMachine.Liquid.Item} [{espressoMachine.Liquid.Amount}], {espressoMachine.Content.Item} [{espressoMachine.Content.Amount}]:::::");
            
            espressoMachine.Liquid.IncreaseItem(500);
            espressoMachine.Content.IncreaseItem(500);

            espressoMachine.Liquid.Item = "Water"; //Changes liquid to water

            Console.WriteLine($":::::EspressoMachine supply: {espressoMachine.Liquid.Item} [{espressoMachine.Liquid.Amount}], {espressoMachine.Content.Item} [{espressoMachine.Content.Amount}]:::::");
            #endregion

            Console.ReadKey();
        }
    }
}