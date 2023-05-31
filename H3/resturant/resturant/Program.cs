using resturant.ML;
using System;

namespace resturant
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    if (args.Length < 1)
        //    {
        //        Console.WriteLine("Usage: dotnet run [train|predict] [args]");
        //        return;
        //    }

        //    string operation = args[0].ToLower();
        //    switch (operation)
        //    {
        //        case "train":
        //            if (args.Length < 2)
        //            {
        //                Console.WriteLine("Usage: dotnet run train [training file path]");
        //                return;
        //            }

        //            // Instantiate Trainer
        //            new Trainer().Train(args[1]);
        //            break;

        //        case "predict":
        //            if (args.Length < 2)
        //            {
        //                Console.WriteLine("Usage: dotnet run predict [input data]");
        //                return;
        //            }

        //            // Instantiate Predictor
        //            new Predictor().Predict(args[1]);
        //            break;

        //        default:
        //            Console.WriteLine("Invalid operation. Valid operations are 'train' and 'predict'");
        //            return;
        //    }
        //}

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine($"Invalid arguments passed in, exiting.{Environment.NewLine}{Environment.NewLine}Usage:{Environment.NewLine}" +
                                  $"predict <sentence of text to predict against>{Environment.NewLine}" +
                                  $"or {Environment.NewLine}" +
                                  $"train <path to training data file>{Environment.NewLine}");

                return;
            }

            switch (args[0])
            {
                case "predict":
                    new Predictor().Predict(args[1]);
                    break;
                case "train":
                    new Trainer().Train(args[1]);
                    break;
                default:
                    Console.WriteLine($"{args[0]} is an invalid option");
                    break;
            }
        }
    }
}