using System;
using System.IO;
using StockPricePredictor.ML.Base;
using StockPricePredictor.ML.Objects;
using Microsoft.ML;
using Newtonsoft.Json;
using StockPricePredictor.ML.Interfaces;

namespace StockPricePredictor.ML
{
    public class Predictor : BaseML, IPredictor
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

            // Registers a custom mapping action. The "StockExtendedMapping" string is the contractName.
            MlContext.ComponentCatalog.RegisterAssembly(typeof(StockExtendedMapping).Assembly);

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
            var inputDataView = MlContext.Data.LoadFromTextFile<Stock>(inputDataFile, ',', hasHeader: true);

            // Mapping data to the extended model
            var conversionPipeline = MlContext.Transforms.CustomMapping(new StockExtendedMapping().GetMapping(), contractName: "StockExtendedMapping");
            var convertedDataView = conversionPipeline.Fit(inputDataView).Transform(inputDataView);

            // Creates predictions for each model
            var openPredictions = openModel.Transform(convertedDataView);
            var highPredictions = highModel.Transform(convertedDataView);
            var lowPredictions = lowModel.Transform(convertedDataView);
            var closePredictions = closeModel.Transform(convertedDataView);
            var volumePredictions = volumeModel.Transform(convertedDataView);

            // Converts InputDataView to IEnumerable for each model
            var openPredictedResults = MlContext.Data.CreateEnumerable<OpenPrediction>(openPredictions, reuseRowObject: false);
            var highPredictedResults = MlContext.Data.CreateEnumerable<HighPrediction>(highPredictions, reuseRowObject: false);
            var lowPredictedResults = MlContext.Data.CreateEnumerable<LowPrediction>(lowPredictions, reuseRowObject: false);
            var closePredictedResults = MlContext.Data.CreateEnumerable<ClosePrediction>(closePredictions, reuseRowObject: false);
            var volumePredictedResults = MlContext.Data.CreateEnumerable<VolumePrediction>(volumePredictions, reuseRowObject: false);

            var openPrediction = openPredictedResults.First();
            var highPrediction = highPredictedResults.First();
            var lowPrediction = lowPredictedResults.First();
            var closePrediction = closePredictedResults.First();
            var volumePrediction = volumePredictedResults.First();

            // Displaying the first prediction for demo purposes
            Console.WriteLine($"Predicted Open: {openPrediction.Open}");
            Console.WriteLine($"Predicted High: {highPrediction.High}");
            Console.WriteLine($"Predicted Low: {lowPrediction.Low}");
            Console.WriteLine($"Predicted Close: {closePrediction.Close}");
            Console.WriteLine($"Predicted Volume: {volumePrediction.Volume}");


            //string outputPath = "path_to_your_data.csv"; // replace with the actual path to your csv file

            //using (var writer = new StreamWriter(outputPath, append: true))
            //{
            //    if (new FileInfo(outputPath).Length == 0)
            //    {
            //        writer.WriteLine("Date,Open,High,Low,Close,Adj Close,Volume"); // writes headers if the file is empty
            //    }

            //    var nextDate = lastDate.AddDays(1); // next date is one day after the last date in your dataset

            //    string lastLine = File.ReadLines(outputPath).Last();
            //    string lastDateString = lastLine.Split(',')[0];
            //    DateTime lastDate = DateTime.Parse(lastDateString);

            //    writer.WriteLine($"{nextDate},{openPrediction.Open},{highPrediction.High},{lowPrediction.Low},{closePrediction.Close},{closePrediction.Close},{volumePrediction.Volume}");
            //}
        }
    }
}   