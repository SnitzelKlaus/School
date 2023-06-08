using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlStockPredictorAPI.ML.Interfaces
{
    public interface ITrainer
    {
        public void Train(string trainingFile, string testFile);
    }
}
