﻿using System;
using EmailMultiKlassifikation.ML;

namespace EmailMultiKlassifikation
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine($"Invalid arguments passed in, exiting.{ Environment.NewLine}{ Environment.NewLine}" +
                    $"Usage: { Environment.NewLine}" +
                    $"predict <path to input file>{Environment.NewLine}" +
                    $"or {Environment.NewLine}" +
                    $"train <path to training data file>{Environment.NewLine}");
                
                return;
            }

            switch (args[0])
            {
                case "predict":                         // predict ..\..\..\Data\data.json
                    new Predictor().Predict(args[1]);
                    break;
                case "train":                           // train ..\..\..\Data\sampledata.csv ..\..\..\Data\testdata.csv
                    new Trainer().Train(args[1], args[2]);
                    break;
                default:
                    Console.WriteLine($"{args[0]} is an invalid option");
                    break;
            }
        }
    }
}