using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    public class Factory
    {
        public int Id { get; set; }
        public int ProductionBuffer { get; set; } //Sets a buffer for the production
        public string[] ProductName { get; set; } //Takes a string[] of products it's going to produce

        public Factory(int id, int productionBuffer, string[] productName)
        {
            Id = id;
            ProductionBuffer = productionBuffer;
            ProductName = productName;

            Thread factory = new Thread(MakeProduct);
            factory.Start();
        }

        private void MakeProduct()
        {
            while (true)
            {
                Monitor.Enter(Manager.ProductList); //Enters productlist and starts producing

                for (int i = 0; i < ProductName.Length; i++)
                {
                    for (int j = 0; j <= ProductionBuffer; j++)
                    {
                        Manager.ProductList.Enqueue(new Drink(ProductName[i]));
                        Console.WriteLine($"Factory: produced {ProductName[i]}");
                        Thread.Sleep(200);
                    }
                }

                Monitor.PulseAll(Manager.ProductList); //Sends a pulse to splitter
                Monitor.Exit(Manager.ProductList);
                Thread.Sleep(1000);
            }
        }
    }
}
