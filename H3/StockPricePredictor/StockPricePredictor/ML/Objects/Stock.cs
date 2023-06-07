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
        [LoadColumn(0)]
        public string Date;

        [LoadColumn(1)]
        public float Open;

        [LoadColumn(2)]
        public float High;

        [LoadColumn(3)]
        public float Low;

        [LoadColumn(4)]
        public float Close;

        [LoadColumn(5)]
        public float AdjClose;

        [LoadColumn(6)]
        public float Volume;
    }
}
