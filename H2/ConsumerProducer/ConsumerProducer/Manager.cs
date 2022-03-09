using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerProducer
{
    public class Manager
    {
        public Product[][] products { get; set; }

        
        public void Start(string[] productName, int[] itemCount)
        {
            Product[][] tmp = new Product[productName.Length][];

            for (int i = 0; i < productName.Length; i++)
            {
                for (int j = 0; j < itemCount.Length; j++)
                {
                    tmp[i][j].Name = productName[i];
                    tmp[i][j].Id = j;
                    tmp[i][j].IsAvailable = true;
                }
            }


            foreach(Product[] product in tmp)
            {
                foreach(Product item in product)
                {
                    Console.WriteLine($"Name: {item.Name}, ID: {item.Id}, Available: {item.IsAvailable}");
                }
            }

            Console.ReadKey();
        }
    }
}
