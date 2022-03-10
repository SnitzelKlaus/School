using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    public class Consumer
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public Consumer(int id, string productName)
        {
            Id = id;
            ProductName = productName;

            Thread consumer = new Thread(ConsumeProduct);
            consumer.Start();
        }

        private void ConsumeProduct()
        {
            while (true)
            {
                while (true)
                {
                    switch (ProductName)
                    {
                        case "Beer":
                            Monitor.Enter(Manager.Beer);

                            if (Manager.Beer.Count == 0)
                            {
                                Console.WriteLine("Consumer waiting for Beer");
                                Monitor.Wait(Manager.Beer);
                            }

                            Manager.Beer.Dequeue();
                            Console.WriteLine("Consumer drinking Beer");
                            Thread.Sleep(200);
                            break;

                        case "Cola":
                            Monitor.Enter(Manager.Cola);

                            if (Manager.Cola.Count == 0)
                            {
                                Console.WriteLine("Consumer waiting for Cola");
                                Monitor.Wait(Manager.Cola);
                            }

                            Manager.Cola.Dequeue();
                            Console.WriteLine("Consumer drinking Cola");
                            Thread.Sleep(200);
                            break;

                        case "Squash":
                            Monitor.Enter(Manager.Squash);

                            if (Manager.Squash.Count == 0)
                            {
                                Console.WriteLine("Consumer waiting for Squash");
                                Monitor.Wait(Manager.Squash);
                            }

                            Manager.Squash.Dequeue();
                            Console.WriteLine("Consumer drinking Squash");
                            Thread.Sleep(200);
                            break;
                        default:
                            Console.WriteLine("Consumer couldn't find a product");
                            break;
                    }
                }
            }
        }
    }
}
