using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagageSortingSystem
{
    public class LuggageLog
    {
        int LuggageId { get; set; }
        DateTime DateTime { get; set; }
        string LogData { get; set; }
        public LuggageLog (int luggageId, DateTime dateTime, string logData)
        {
            LuggageId = luggageId;
            DateTime = dateTime;
            LogData = logData;
        }
    }
}
