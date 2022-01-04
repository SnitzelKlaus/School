using System;
using System.Collections.Generic;
using System.Text;

namespace Automaten
{
    public class Item
    {
        public Item(string name, double price, int qty)
        {
            Name = name;
            Price = price;
            Qty = qty;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
    }
}
