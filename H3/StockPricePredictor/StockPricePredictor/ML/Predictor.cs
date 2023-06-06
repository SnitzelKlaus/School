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
            if (!File.Exists(ModelOpen) || !File.Exists(ModelHigh) || !File.Exists(ModelLow) || !File.Exists(ModelClose) || !File.Exists(ModelVolume))
            {
                Console.WriteLine($"Failed to find models at the specified paths");
                return;
            }

            if (!File.Exists(inputDataFile))
            {
                Console.WriteLine($"Failed to find input data at {inputDataFile}");
                return;
            }

            MlContext.ComponentCatalog.RegisterAssembly(typeof(StockExtended).Assembly);

            // Loads the models
            ITransformer openModel;
            ITransformer highModel;
            ITransformer lowModel;
            ITransformer closeModel;
            ITransformer volumeModel;

            using (var stream = new FileStream(ModelOpen, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                openModel = MlContext.Model.Load(stream, out _);
            }
            using (var stream = new FileStream(ModelHigh, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                highModel = MlContext.Model.Load(stream, out _);
            }
            using (var stream = new FileStream(ModelLow, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                lowModel = MlContext.Model.Load(stream, out _);
            }
            using (var stream = new FileStream(ModelClose, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                closeModel = MlContext.Model.Load(stream, out _);
            }
            using (var stream = new FileStream(ModelVolume, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                volumeModel = MlContext.Model.Load(stream, out _);
            }

            // Checks the models
            if (openModel == null || highModel == null || lowModel == null || closeModel == null || volumeModel == null)
            {
                Console.WriteLine("Failed to load model");
                return;
            }

            // Reads data from the file
            var inputDataView = MlContext.Data.LoadFromTextFile<StockExtended>(inputDataFile, ',', hasHeader: true);

            // Creates predictions for each model
            var openPredictions = openModel.Transform(inputDataView);
            var highPredictions = highModel.Transform(inputDataView);
            var lowPredictions = lowModel.Transform(inputDataView);
            var closePredictions = closeModel.Transform(inputDataView);
            var volumePredictions = volumeModel.Transform(inputDataView);

            // Converts IDataView to IEnumerable for each model
            var openPredictedResults = MlContext.Data.CreateEnumerable<OpenPrediction>(openPredictions, reuseRowObject: false);
            var highPredictedResults = MlContext.Data.CreateEnumerable<HighPrediction>(highPredictions, reuseRowObject: false);
            var lowPredictedResults = MlContext.Data.CreateEnumerable<LowPrediction>(lowPredictions, reuseRowObject: false);
            var closePredictedResults = MlContext.Data.CreateEnumerable<ClosePrediction>(closePredictions, reuseRowObject: false);
            var volumePredictedResults = MlContext.Data.CreateEnumerable<VolumePrediction>(volumePredictions, reuseRowObject: false);

            // Displaying the first prediction for demo purposes
            var openPrediction = openPredictedResults.First();
            var highPrediction = highPredictedResults.First();
            var lowPrediction = lowPredictedResults.First();
            var closePrediction = closePredictedResults.First();
            var volumePrediction = volumePredictedResults.First();

            Console.WriteLine($"Predicted Open: {openPrediction.Open}");
            Console.WriteLine($"Predicted High: {highPrediction.High}");
            Console.WriteLine($"Predicted Low: {lowPrediction.Low}");
            Console.WriteLine($"Predicted Close: {closePrediction.Close}");
            Console.WriteLine($"Predicted Volume: {volumePrediction.Volume}");
        }
    }
}   