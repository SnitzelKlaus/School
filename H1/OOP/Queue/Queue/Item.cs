using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    public class Item
    {
        public Item(string name, int qty)
        {
            Name = name;
            Qty = qty;
        }

        public string Name { get; set; }

        public int Qty { get; set; }

    }
}
