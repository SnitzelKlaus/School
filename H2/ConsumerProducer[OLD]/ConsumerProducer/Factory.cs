using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerProducer
{
    public class Factory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductionLimit { get; set; }

        public Factory(int id, int productId, string productName, int productionLimit)
        {
            this.Id = id;
            this.ProductId = productId;
            this.ProductName = productName;
            this.ProductionLimit = productionLimit;

            Thread pr = new Thread(MakeProduct);
            pr.Name = Id.ToString();
            pr.Start();
            ProductionLimit = productionLimit;

         }

        public void MakeProduct()
        {
            while (true)
            {//Redo

                Monitor.TryEnter(Manager.ProductList[ProductId]);
                {
                    try
                    {
                        if (Monitor.IsEntered(Manager.ProductList[ProductId]))
                        {
                            #region Make product
                            Product[] tmp = Manager.ProductList[ProductId];
                            int count = Manager.ProductList[ProductId].Length;

                            //Produces products
                            for (int i = count; i < ProductionLimit; i++)
                            {
                                tmp[i] = new Product(i, ProductName);
                                Console.WriteLine($"Factory: {Id}, produced a '{ProductName}'       Total qty: {i + 1}");
                                Thread.Sleep(100);
                            }
                            Manager.ProductList[ProductId] = tmp;
                            #endregion

                            Monitor.PulseAll(Manager.ProductList[ProductId]);
                            Monitor.Exit(Manager.ProductList[ProductId]);
                        }
                    }
                    finally
                    {
                        Console.WriteLine($"Factory: '{Id}', stopped producing '{ProductName}'       Total qty: '{Manager.ProductList[ProductId].Length}'");
                        Thread.Sleep(1000);
                    }

                }
            }
        }
    }
}


//Monitor.Pulse(Manager.ProductList[ProductId].Length + Id + 1);