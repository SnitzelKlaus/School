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
        public void Train(string trainingFileName)
        {
            if (!File.Exists(trainingFileName))
            {
                Console.WriteLine($"Failed to find training data file {trainingFileName}");
                return;
            }

            IEstimator<ITransformer> dataProcessPipeline = MlContext.Transforms.Concatenate(
                "Features",
                typeof(CarInventory).ToPropertyList<CarInventory>(nameof(CarInventory.Label)))
                .Append(MlContext.Transforms.NormalizeMeanVariance(inputColumnName: "Features",
                outputColumnName: "FeaturesNormalizedByMeanVar"));

            var trainingDataView = MlContext.Data.LoadFromTextFile<FileInput>(trainingFileName);
            var dataSplit = MlContext.Data.TrainTestSplit(trainingDataView, testFraction: 0.2);

            var dataProcessPipeline = MlContext.Transforms.CopyColumns("Label", nameof(FileInput.Label))
                .Append(MlContext.Transforms.Conversion.ConvertType("Label", outputKind: DataKind.Boolean))
                .Append(MlContext.Transforms.Text.FeaturizeText("NGrams", nameof(FileInput.Strings)))
                .Append(MlContext.Transforms.Concatenate("Features", "NGrams"));

            var trainer = MlContext.BinaryClassification.Trainers.FastTree(labelColumnName:
nameof(CarInventory.Label),
 featureColumnName: "FeaturesNormalizedByMeanVar",
 numberOfLeaves: 2,
 numberOfTrees: 1000,
 minimumExampleCountPerLeaf: 1,
 learningRate: 0.2);

            var trainingPipeline = dataProcessPipeline.Append(trainer);

            ITransformer trainedModel = trainingPipeline.Fit(dataSplit.TrainSet);

            MlContext.Model.Save(trainedModel, dataSplit.TrainSet.Schema, ModelPath);

            //var testSetTransform = trainedModel.Transform(dataSplit.TestSet);
            //var modelMetrics = MlContext.BinaryClassification.EvaluateNonCalibrated(testSetTransform);

            //Console.WriteLine($"Accuracy: {modelMetrics.Accuracy:#.##}{Environment.NewLine}" +
            // $"Positive Precision: {modelMetrics.PositivePrecision:#.##}{Environment.NewLine}" +
            // $"Negative Precision: {modelMetrics.NegativePrecision:#.##}{Environment.NewLine}" +
            // $"Area Under Precision Recall Curve: {modelMetrics.AreaUnderPrecisionRecallCurve:#.##}");
        }
    }
}