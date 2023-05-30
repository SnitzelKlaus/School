using resturant.ML;
using System;

namespace resturant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please select an operation:");
                Console.WriteLine("1. Train model");
                Console.WriteLine("2. Make prediction");
                Console.WriteLine("3. Exit");
                Console.Write("Enter selection: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Enter file name: ");
                        string trainingFileName = Console.ReadLine();

                        // Instantiate Trainer
                        var trainer = new Trainer(trainingFileName);

                        // Train model
                        trainer.Train();

                        break;

                    case "2":
                        Console.Write("Enter input data for prediction: ");
                        string inputData = Console.ReadLine();

                        // Instantiate Predictor
                        var predictor = new Predictor();

                        // Predict
                        predictor.Predict(inputData);

                        break;

                    case "3":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid selection. Please enter 1, 2, or 3.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}