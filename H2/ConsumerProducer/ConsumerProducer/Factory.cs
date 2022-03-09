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

        public Factory(int id, int productId)
        {
            this.Id = id;
            this.ProductId = productId;

            Thread pr = new Thread(MakeProduct);
            pr.Start();
        }

        public static void MakeProduct()
        {
            while (true)
            {

            }
        }
    }
}
