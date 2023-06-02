using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailMultiKlassifikation.ML.Objects
{
    public class EmailPrediction
    {
        [ColumnName("PredictedLabel")]
        public string Category { get; set; }
        public string Prediction { get; set; }
        public float[] Score { get; set; }
    }
}
