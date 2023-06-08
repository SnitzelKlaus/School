using System;
using System.IO;
using MlStockPredictorAPI.Common;
using Microsoft.ML;
using System.Text.RegularExpressions;
using System.Text;

namespace MlStockPredictorAPI.ML.Base
{
    public class BaseML
    {
        protected static string ModelOpen => Path.Combine(AppContext.BaseDirectory, Constants.MODEL_OPEN);
        protected static string ModelHigh => Path.Combine(AppContext.BaseDirectory, Constants.MODEL_HIGH);
        protected static string ModelLow => Path.Combine(AppContext.BaseDirectory, Constants.MODEL_LOW);
        protected static string ModelClose => Path.Combine(AppContext.BaseDirectory, Constants.MODEL_CLOSE);
        protected static string ModelVolume => Path.Combine(AppContext.BaseDirectory, Constants.MODEL_VOLUME);

        protected readonly MLContext MlContext;

        protected BaseML()
        {
            MlContext = new MLContext(2020);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
    }
}