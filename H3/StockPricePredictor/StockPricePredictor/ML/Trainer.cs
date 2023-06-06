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

            // The mapping function is used to convert the input data to the format expected by the model
            // Here vi transforms date to a float representing the number of days since 1/1/2000
            Action<Stock, StockExtended> mapping = (input, output) =>
            {
                output.Date = (float)(input.Date - new DateTime(2000, 1, 1)).TotalDays;
                output.Open = input.Open;
                output.High = input.High;
                output.Low = input.Low;
                output.Close = input.Close;
                output.Volume = input.Volume;
            };

            // Defining the pipelines
            // We define separate pipelines for each of the columns we want to predict
            // This is a workaround because ml.net does not yet support multi-output regression / Multitask regression models
            // Sequential multi-output regression model

            // Register the custom mapping action. The "CustomMapping" string is the contractName.
            MlContext.ComponentCatalog.RegisterAssembly(typeof(StockExtended).Assembly);

            // Mapping data to the format expected by the model
            var pipeline = MlContext.Transforms.CustomMapping<Stock, StockExtended>(StockExtended.Mapping, contractName: "CustomMapping");

            var openPipeline = pipeline
                .Append(MlContext.Transforms.CopyColumns(inputColumnName: "Open", outputColumnName: "Label"))
                .Append(MlContext.Transforms.Concatenate("Features", "Date", "Open", "High", "Low", "Close", "Volume"))
                .Append(MlContext.Regression.Trainers.FastTreeTweedie());

            var highPipeline = pipeline
                .Append(MlContext.Transforms.CopyColumns(inputColumnName: "High", outputColumnName: "Label"))
                .Append(MlContext.Transforms.Concatenate("Features", "Date", "Open", "High", "Low", "Close", "Volume"))
                .Append(MlContext.Regression.Trainers.FastTreeTweedie());

            var lowPipeline = pipeline
                .Append(MlContext.Transforms.CopyColumns(inputColumnName: "Low", outputColumnName: "Label"))
                .Append(MlContext.Transforms.Concatenate("Features", "Date", "Open", "High", "Low", "Close", "Volume"))
                .Append(MlContext.Regression.Trainers.FastTreeTweedie());

            var closePipeline = pipeline
                .Append(MlContext.Transforms.CopyColumns(inputColumnName: "Close", outputColumnName: "Label"))
                .Append(MlContext.Transforms.Concatenate("Features", "Date", "Open", "High", "Low", "Close", "Volume"))
                .Append(MlContext.Regression.Trainers.FastTreeTweedie());

            var volumePipeline = pipeline
                .Append(MlContext.Transforms.CopyColumns(inputColumnName: "Volume", outputColumnName: "Label"))
                .Append(MlContext.Transforms.Concatenate("Features", "Date", "Open", "High", "Low", "Close", "Volume"))
                .Append(MlContext.Regression.Trainers.FastTreeTweedie());

            // Training the models
            var openModel = openPipeline.Fit(trainingDataView);
            var highModel = highPipeline.Fit(trainingDataView);
            var lowModel = lowPipeline.Fit(trainingDataView);
            var closeModel = closePipeline.Fit(trainingDataView);
            var volumeModel = volumePipeline.Fit(trainingDataView);

            // Saving the models
            MlContext.Model.Save(openModel, trainingDataView.Schema, ModelOpen);
            MlContext.Model.Save(highModel, trainingDataView.Schema, ModelHigh);
            MlContext.Model.Save(lowModel, trainingDataView.Schema, ModelLow);
            MlContext.Model.Save(closeModel, trainingDataView.Schema, ModelClose);
            MlContext.Model.Save(volumeModel, trainingDataView.Schema, ModelVolume);

            var testDataView = MlContext.Data.LoadFromTextFile<Stock>(testFileName, ',', hasHeader: true);

            EvaluateModel(openModel, testDataView, "Open");
            EvaluateModel(highModel, testDataView, "High");
            EvaluateModel(lowModel, testDataView, "Low");
            EvaluateModel(closeModel, testDataView, "Close");
            EvaluateModel(volumeModel, testDataView, "Volume");
        }

        public void EvaluateModel(ITransformer model, IDataView testDataView, string modelName)
        {
            var predictions = model.Transform(testDataView);
            var metrics = MlContext.Regression.Evaluate(predictions, "Label", "Score");
            Console.WriteLine($"----------{{{modelName} Model Metrics:}}----------");
            Console.WriteLine($"R-squared: {metrics.RSquared}");
            Console.WriteLine($"Mean Absolute Error: {metrics.MeanAbsoluteError}");
            Console.WriteLine($"Mean Squared Error: {metrics.MeanSquaredError}\n");
        }
    }
}