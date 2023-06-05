using System;
using System.IO;
using StockPricePredictor.ML.Base;
using StockPricePredictor.ML.Objects;
using Microsoft.ML;
using Newtonsoft.Json;

namespace StockPricePredictor.ML
{
    public class Predictor : BaseML
    {
        public void Predict(string inputDataFile)
        {
            if (!File.Exists(ModelPath))
            {
                Console.WriteLine($"Failed to find model at {ModelPath}");
                return;
            }

            if (!File.Exists(inputDataFile))
            {
                Console.WriteLine($"Failed to find input data at {inputDataFile}");
                return;
            }

            ITransformer mlModel;

            using (var stream = new FileStream(ModelPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                mlModel = MlContext.Model.Load(stream, out _);
            }

            if (mlModel == null)
            {
                Console.WriteLine("Failed to load model");
                return;
            }

            // Read data from the file
            var inputDataView = MlContext.Data.LoadFromTextFile<Stock>(inputDataFile, ',', hasHeader: true);

            // Create predictions
            var predictions = mlModel.Transform(inputDataView);

            var predictedResults = MlContext.Data.CreateEnumerable<StockPrediction>(predictions, reuseRowObject: false);

            foreach (var prediction in predictedResults)
            {
                Console.WriteLine($"Predicted Close: {prediction.Close}");
            }
        }
    }
}   