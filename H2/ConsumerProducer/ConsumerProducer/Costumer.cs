using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerProducer
{
    public class Costumer
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Costumer(int id, int productId)
        {
            this.Id = id;
            this.ProductId = productId;

            Thread co = new Thread(ConsumeProduct);
            co.Start();
        }

        public static void ConsumeProduct()
        {
            while (true)
            {
            }
        }
    }
}
