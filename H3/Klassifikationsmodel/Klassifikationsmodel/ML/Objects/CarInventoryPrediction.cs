using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBinaryKlassifikation.ML.Objects
{
    public class CarInventoryPrediction
    {
        public bool Label { get; set; }
        public bool PredictedLabel { get; set; }
        public float Score { get; set; }
        public float Probability { get; set; }
    }
}
