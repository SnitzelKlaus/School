using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    public class Splitter
    {


        public int Id { get; set; }
        public string[] ProductSplit { get; set; }
        
        public Splitter(int id, string[] productSplit)
        {
            Id = id;
            ProductSplit = productSplit;

            Thread splitter = new Thread(SplitProduct);
            splitter.Start();
        }

        private void SplitProduct()
        {
            while (true)
            {

                Monitor.Enter(Manager.ProductList);

                if (Manager.ProductList.Count == 0)
                {
                    Console.WriteLine("Splitter waiting for products");
                    Monitor.Wait(Manager.ProductList);
                }

                for (int i = 0; i < ProductSplit.Length; i++) //Loops through
                {
                    for (int j = 0; j < Manager.ProductList.Count; j++)
                    {
                        switch (Manager.ProductList.Peek().Name)
                        {
                            case "Beer":
                                Monitor.Enter(Manager.Beer);

                                Manager.Beer.Enqueue(Manager.ProductList.Peek());
                                Manager.ProductList.Dequeue();
                                Console.WriteLine("Split to Beer");

                                Monitor.PulseAll(Manager.Beer);
                                Monitor.Exit(Manager.Beer);
                                Thread.Sleep(100);

                                break;
                            case "Cola":
                                Monitor.Enter(Manager.Cola);

                                Manager.Cola.Enqueue(Manager.ProductList.Peek());
                                Manager.ProductList.Dequeue();
                                Console.WriteLine("Split to Cola");

                                Monitor.PulseAll(Manager.Cola);
                                Monitor.Exit(Manager.Cola);
                                Thread.Sleep(100);
                                break;
                            case "Squash":
                                Monitor.Enter(Manager.Squash);

                                Manager.Squash.Enqueue(Manager.ProductList.Peek());
                                Manager.ProductList.Dequeue();
                                Console.WriteLine("Split to Squash");

                                Monitor.PulseAll(Manager.Squash);
                                Monitor.Exit(Manager.Squash);
                                Thread.Sleep(100);
                                break;

                            default:
                                Console.WriteLine("ERROR: Couldn't find a split for product");
                                break;
                        }
                    }
                }
                Thread.Sleep(200);
            }
        }
    }
}
