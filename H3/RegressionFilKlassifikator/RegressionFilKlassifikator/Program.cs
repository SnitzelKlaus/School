using System;
using RegressionFilKlassifikator.ML;

namespace RegressionFilKlassifikator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine($"Invalid arguments passed in, exiting.{ Environment.NewLine}{ Environment.NewLine}" +
                    $"Usage: { Environment.NewLine}" +
                    $"predict <path to input file>{Environment.NewLine}" +
                    $"or {Environment.NewLine}" +
                    $"train <path to training data file>{Environment.NewLine}" +
                    $"or {Environment.NewLine}" +
                    $"extract <path to folder>{Environment.NewLine}");
                
                return;
            }

            switch (args[0])
            {
                case "extract":                         // extract ..\..\..\Data\SampleData.csv
                    new FeatureExtractor().Extract(args[1]);
                    break;
                case "predict":                         // predict ..\..\..\Data\inputData.json
                    new Predictor().Predict(args[1]);
                    break;
                case "train":                           // train ..\..\..\Data\SampleData.csv
                    new Trainer().Train(args[1]);
                    break;
                default:
                    Console.WriteLine($"{args[0]} is an invalid option");
                    break;
            }
        }
    }
}