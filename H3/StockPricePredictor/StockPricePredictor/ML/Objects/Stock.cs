using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPricePredictor.ML.Objects
{
    public class Stock
    {
        // Date,    Open,   High,   Low,    Close,  Adj Close,  Volume

        [LoadColumn(0)]
        public DateTime Date { get; set; }
        [LoadColumn(1)]
        public float Open { get; set; }
        [LoadColumn(2)]
        public float High { get; set; }
        [LoadColumn(3)]
        public float Low { get; set; }
        [LoadColumn(4)]
        public float Close { get; set; }
        [LoadColumn(5)]
        public float AdjClose { get; set; }
        [LoadColumn(6)]
        public float Volume { get; set; }
    }
}
