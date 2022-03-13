using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSortingSystem
{
    public class Log
    {
        int LuggageId { get; set; }
        DateTime DateTime { get; set; }
        public Log (int luggageId, DateTime dateTime)
        {
            LuggageId = luggageId;
            DateTime = dateTime;
        }
    }
}
