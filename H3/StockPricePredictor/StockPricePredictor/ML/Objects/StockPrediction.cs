using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPricePredictor.ML.Objects
{
    public class StockPrediction
    {
        [ColumnName("Score")]
        public float Close { get; set; }
    }
}
