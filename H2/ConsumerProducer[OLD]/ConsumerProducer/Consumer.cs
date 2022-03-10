using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerProducer
{
    public class Consumer
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Consumer(int id, int productId, string productName)
        {
            this.Id = id;
            this.ProductId = productId;
            this.ProductName = productName;

            Thread co = new Thread(ConsumeProduct);
            co.Name = Id.ToString();
            co.Start();
        }

        public void ConsumeProduct()
        {
            while (true)//Redo
            {
                while (Manager.ProductList[ProductId].Length == 0)
                {
                    Console.WriteLine($"Consumer: {Id}, is waiting for '{ProductName}'...");
                    Monitor.Wait(Manager.ProductList[ProductId]);
                }

                #region Consuming product
                int count = Manager.ProductList[ProductId].Length;
                Product[] tmp = new Product[count];

                //Produces products
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"Consumer: '{Id}', is consuming '{ProductName}'        Total qty: '{count - i}'");
                    Thread.Sleep(100);
                }
                Manager.ProductList[ProductId] = tmp;
                #endregion
            }
        }
    }
}
