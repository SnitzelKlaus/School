using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst
{
    public class Drink
    {
        public int DrinkId { get; set; }
        public string Name { get; set; }
        public GlassType GlassType { get; set; }
        
        public List<Content> Content { get; set; }
    }
}
