using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlStockPredictorAPI.ML.Objects
{
    public class OpenPrediction
    {
        [ColumnName("Score")]
        public float Open;
    }

    public class HighPrediction
    {
        [ColumnName("Score")]
        public float High;
    }

    public class LowPrediction
    {
        [ColumnName("Score")]
        public float Low;
    }

    public class ClosePrediction
    {
        [ColumnName("Score")]
        public float Close;
    }

    public class VolumePrediction
    {
        [ColumnName("Score")]
        public float Volume;
    }
}
