using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPricePredictor.ML.Interfaces
{
    public interface IPredictor
    {
        public void Predict(string dataFile);
    }
}
