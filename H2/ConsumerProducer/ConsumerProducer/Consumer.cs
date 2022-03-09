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
        public Consumer(int id, int productId)
        {
            this.Id = id;
            this.ProductId = productId;

            Thread co = new Thread(ConsumeProduct);
            co.Start();
        }

        public void ConsumeProduct()
        {
            while (true)
            {
                Console.WriteLine($"Consumer: {Id}, is consuming {Manager.ProductList[ProductId][0].Name}");
            }
        }
    }
}
