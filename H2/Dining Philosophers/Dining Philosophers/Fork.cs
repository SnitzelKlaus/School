using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_Philosophers
{
    public class Fork
    {
        public int Id { get; set; }
        public Fork(int id)
        {
            Id = id;
        }
    }
}
