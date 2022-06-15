using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Content
    {
        public int ContentId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        
        public UnitType Unit { get; set; }
    }
}
