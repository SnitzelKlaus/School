using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    public class Manager
    {
        public static Queue<Drink> ProductList = new Queue<Drink>();
        public static Queue<Drink> Beer = new Queue<Drink>();
        public static Queue<Drink> Cola = new Queue<Drink>();
        public static Queue<Drink> Squash = new Queue<Drink>();
        public void Start(string[] products)
        {
            Factory factory = new Factory(1, 10, products);
            Splitter splitter = new Splitter(1, products);

            for (int i = 0; i < products.Length; i++)
            {
                _ = new Consumer(i, products[i]);
            }
            
        }
    }
}
