using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using StockPricePredictor.ML.Base;
using StockPricePredictor.ML.Objects;
using Microsoft.ML;
using StockPricePredictor.Common;
using Microsoft.ML.Data;

namespace StockPricePredictor.ML
{
    public class Trainer : BaseML
    {
        public void Train(string trainingFileName, string testFileName)
        {
            if (!File.Exists(trainingFileName))
            {
                Console.WriteLine($"Failed to find training data file {trainingFileName}");
                return;
            }

            if (!File.Exists(testFileName))
            {
                Console.WriteLine($"Failed to find test data file {testFileName}");
                return;
            }

            var trainingDataView = MlContext.Data.LoadFromTextFile<Stock>(
                trainingFileName, ',', hasHeader: true);

            // Define the pipeline
            var pipeline = MlContext.Transforms.CopyColumns(inputColumnName: "Close", outputColumnName: "Label")
                .Append(MlContext.Transforms.Concatenate("Features", "Open", "High", "Low", "Close", "AdjClose", "Volume"))
                .Append(MlContext.Regression.Trainers.FastTreeTweedie());

            // Train the model
            var model = pipeline.Fit(trainingDataView);

            // Save the model
            MlContext.Model.Save(model, trainingDataView.Schema, ModelPath);

            var testDataView = MlContext.Data.LoadFromTextFile<Stock>(testFileName, ',', hasHeader: true);

            // Evaluate the model
            var predictions = model.Transform(testDataView);
            var metrics = MlContext.Regression.Evaluate(predictions, "Label", "Score");
            Console.WriteLine($"R-squared: {metrics.RSquared}");
            Console.WriteLine($"Mean Absolute Error: {metrics.MeanAbsoluteError}");
            Console.WriteLine($"Mean Squared Error: {metrics.MeanSquaredError}");
        }
    }
}