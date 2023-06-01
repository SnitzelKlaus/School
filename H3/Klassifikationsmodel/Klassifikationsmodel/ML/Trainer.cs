using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using CarBinaryKlassifikation.ML.Base;
using CarBinaryKlassifikation.ML.Objects;
using Microsoft.ML;
using CarBinaryKlassifikation.Common;
using Microsoft.ML.Data;

namespace CarBinaryKlassifikation.ML
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

            var trainingDataView = MlContext.Data.LoadFromTextFile<CarInventory>(trainingFileName);
            var dataSplit = MlContext.Data.TrainTestSplit(trainingDataView, testFraction: 0.2);

            var dataProcessPipeline = MlContext.Transforms.CopyColumns("Label", nameof(CarInventory.Label))
                .Append(MlContext.Transforms.Concatenate("Features",    nameof(CarInventory.HasSunroof),
                                                                        nameof(CarInventory.HasAC),
                                                                        nameof(CarInventory.HasAutomaticTransmission),
                                                                        nameof(CarInventory.Amount)))
                .Append(MlContext.Transforms.NormalizeMeanVariance(inputColumnName: "Features", outputColumnName: "FeaturesNormalizedByMeanVar"));

            var trainer = MlContext.BinaryClassification.Trainers.FastTree(labelColumnName: nameof(CarInventory.Label),
                featureColumnName: "FeaturesNormalizedByMeanVar",
                numberOfLeaves: 2,
                numberOfTrees: 1000,
                minimumExampleCountPerLeaf: 1,
                learningRate: 0.2);

            var trainingPipeline = dataProcessPipeline.Append(trainer);

            ITransformer trainedModel = trainingPipeline.Fit(trainingDataView);
            MlContext.Model.Save(trainedModel, trainingDataView.Schema, ModelPath);

            var testDataView = MlContext.Data.LoadFromTextFile<CarInventory>(testFileName, ',', hasHeader: false);
            var testSetTransform = trainedModel.Transform(testDataView);
            var modelMetrics = MlContext.BinaryClassification.Evaluate(data: testSetTransform,
             labelColumnName: nameof(CarInventory.Label),
             scoreColumnName: "Score");

            Console.WriteLine($"Accuracy: {modelMetrics.Accuracy:P2}");
            Console.WriteLine($"Area Under Curve: {modelMetrics.AreaUnderRocCurve:P2}");
            Console.WriteLine($"Area under Precision recall Curve: {modelMetrics.AreaUnderPrecisionRecallCurve:P2}");
            Console.WriteLine($"F1Score: {modelMetrics.F1Score:P2}");
            Console.WriteLine($"LogLoss: {modelMetrics.LogLoss:#.##}");
            Console.WriteLine($"LogLossReduction: {modelMetrics.LogLossReduction:#.##}");
            Console.WriteLine($"PositivePrecision: {modelMetrics.PositivePrecision:#.##}");
            Console.WriteLine($"PositiveRecall: {modelMetrics.PositiveRecall:#.##}");
            Console.WriteLine($"NegativePrecision: {modelMetrics.NegativePrecision:#.##}");
            Console.WriteLine($"NegativeRecall: {modelMetrics.NegativeRecall:P2}");
        }
    }
}