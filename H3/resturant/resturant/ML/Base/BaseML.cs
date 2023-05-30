using Microsoft.ML;
using resturant.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace resturant.ML.Base
{
    public class BaseML
    {
        protected static string _modelPath => Path.Combine(AppContext.BaseDirectory,
        Constants.MODEL_FILENAME);
        protected readonly MLContext _mlContext;
        protected BaseML()
        {
            _mlContext = new MLContext(2020);
        }
    }
}
