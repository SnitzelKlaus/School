using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerProducer
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }

        public Product(int id, string name, bool isAvailable)
        {
            this.Id = id;
            this.Name = name;
            this.IsAvailable = isAvailable;
        }
    }
}
