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
using Microsoft.ML.Transforms;
using StockPricePredictor.ML.Interfaces;

namespace StockPricePredictor.ML
{
    public class Trainer : BaseML, ITrainer
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

            // Loads the training data
            var trainingDataView = MlContext.Data.LoadFromTextFile<Stock>(
                trainingFileName, ',', hasHeader: true);

            // Registers a custom mapping action.This is used to convert the date to a float.
            // The "StockExtendedMapping" string is the contractName.
            MlContext.ComponentCatalog.RegisterAssembly(typeof(StockExtendedMapping).Assembly);
            var pipeline = MlContext.Transforms.CustomMapping(new StockExtendedMapping().GetMapping(), contractName: "StockExtendedMapping");


            // Defining the pipelines
            var openPipeline = pipeline
                .Append(MlContext.Transforms.CopyColumns(inputColumnName: "Open", outputColumnName: "Label"))
                .Append(MlContext.Transforms.Concatenate("Features", "DateFloat", "High", "Low", "Close", "Volume"))
                .Append(MlContext.Regression.Trainers.FastTreeTweedie());

            var highPipeline = pipeline
                .Append(MlContext.Transforms.CopyColumns(inputColumnName: "High", outputColumnName: "Label"))
                .Append(MlContext.Transforms.Concatenate("Features", "DateFloat", "Open", "Low", "Close", "Volume"))
                .Append(MlContext.Regression.Trainers.FastTreeTweedie());

            var lowPipeline = pipeline
                .Append(MlContext.Transforms.CopyColumns(inputColumnName: "Low", outputColumnName: "Label"))
                .Append(MlContext.Transforms.Concatenate("Features", "DateFloat", "Open", "High", "Close", "Volume"))
                .Append(MlContext.Regression.Trainers.FastTreeTweedie());

            var closePipeline = pipeline
                .Append(MlContext.Transforms.CopyColumns(inputColumnName: "Close", outputColumnName: "Label"))
                .Append(MlContext.Transforms.Concatenate("Features", "DateFloat", "Open", "High", "Low", "Volume"))
                .Append(MlContext.Regression.Trainers.FastTreeTweedie());

            var volumePipeline = pipeline
                .Append(MlContext.Transforms.CopyColumns(inputColumnName: "Volume", outputColumnName: "Label"))
                .Append(MlContext.Transforms.Concatenate("Features", "DateFloat", "Open", "High", "Low", "Close"))
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

            // Evaluating the models
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