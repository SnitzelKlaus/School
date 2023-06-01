using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using RegressionFilKlassifikator.ML.Base;
using RegressionFilKlassifikator.ML.Objects;
using Microsoft.ML;
using RegressionFilKlassifikator.Common;
using Microsoft.ML.Data;

namespace RegressionFilKlassifikator.ML
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

            var trainingDataView = MlContext.Data.LoadFromTextFile<FileInput>(trainingFileName);
            var dataSplit = MlContext.Data.TrainTestSplit(trainingDataView, testFraction: 0.2);

            //var dataProcessPipeline = MlContext.Transforms.CopyColumns("Label", nameof(FileInput.Label))
            //    .Append(MlContext.Transforms.Conversion.ConvertType("Label", outputKind: DataKind.Single))
            //    .Append(MlContext.Transforms.Text.FeaturizeText("NGrams", nameof(FileInput.Strings)))
            //    .Append(MlContext.Transforms.Concatenate("Features", "NGrams"));

            var dataProcessPipeline = MlContext.Transforms.CopyColumns("Label", nameof(FileInput.Label))
                .Append(MlContext.Transforms.Conversion.ConvertType("Label", outputKind: DataKind.Boolean))
                .Append(MlContext.Transforms.Text.FeaturizeText("NGrams", nameof(FileInput.Strings)))
                .Append(MlContext.Transforms.Concatenate("Features", "NGrams"));

            var trainer = MlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features");

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