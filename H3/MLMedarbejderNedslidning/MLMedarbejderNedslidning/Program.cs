using System;
using MLMedarbejderNedslidning.ML;

namespace MLMedarbejderNedslidning
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine($"Invalid arguments passed in, exiting.{Environment.NewLine}{Environment.NewLine}Usage:{Environment.NewLine}" +
                                  $"predict <name of file>{Environment.NewLine}" +
                                  $"or {Environment.NewLine}" +
                                  $"train <name of data file>{Environment.NewLine}");

                return;
            }

            switch (args[0])
            {
                case "predict":                         // predict ..\..\..\Data\inputData.json
                    new Predictor().Predict(args[1]);
                    break;
                case "train":                           // train ..\..\..\Data\sampledata.csv
                    new Trainer().Train(args[1]);
                    break;
                default:
                    Console.WriteLine($"{args[0]} is an invalid option");
                    break;
            }
        }
    }
}