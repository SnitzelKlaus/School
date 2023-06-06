using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPricePredictor.ML.Objects
{
    public class StockExtended
    {
        public float Date { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
        public float Volume { get; set; }

        public static void Mapping(Stock input, StockExtended output)
        {
            output.Date = (float)(input.Date - new DateTime(2000, 1, 1)).TotalDays;
            output.Open = input.Open;
            output.High = input.High;
            output.Low = input.Low;
            output.Close = input.Close;
            output.Volume = input.Volume;
        }
    }
}
