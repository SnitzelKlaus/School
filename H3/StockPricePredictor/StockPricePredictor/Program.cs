using System;
using StockPricePredictor.ML;

namespace StockPricePredictor
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine($"Invalid arguments passed in, exiting.{Environment.NewLine}{Environment.NewLine}" +
                    $"Usage: {Environment.NewLine}" +
                    $"predict <path to input file>{Environment.NewLine}" +
                    $"or {Environment.NewLine}" +
                    $"train <path to training data file>{Environment.NewLine}");

                return;
            }

            switch (args[0])
            {

                // predict ..\..\..\Data\TSLA\TSLA.csv
                // predict ..\..\..\Data\NVDA\NVDA.csv

                case "predict":
                    new Predictor().Predict(args[1]);
                    break;

                // train ..\..\..\Data\TSLA\sampledata.csv ..\..\..\Data\TSLA\testdata.csv
                // train ..\..\..\Data\NVDA\sampledata.csv ..\..\..\Data\NVDA\testdata.csv
                case "train":
                    new Trainer().Train(args[1], args[2]);
                    break;
                default:
                    Console.WriteLine($"{args[0]} is an invalid option");
                    break;
            }
        }
    }
}