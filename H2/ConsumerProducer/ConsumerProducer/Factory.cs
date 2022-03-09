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
        public int ProductionLimit { get; set; }

        public Factory(int id, int productId, int productionLimit)
        {
            this.Id = id;
            this.ProductId = productId;
            this.ProductionLimit = productionLimit;

            Thread pr = new Thread(MakeProduct);
            pr.Start();
            ProductionLimit = productionLimit;

         }

        public void MakeProduct()
        {
            while (true)
            {
                Console.WriteLine($"Factory: {Id}, is producing {Manager.ProductList[ProductId][0].Name}");
            }
        }
    }
}
