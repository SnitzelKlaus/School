using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using EmailMultiKlassifikation.ML.Base;
using EmailMultiKlassifikation.ML.Objects;
using Microsoft.ML;
using EmailMultiKlassifikation.Common;
using Microsoft.ML.Data;

namespace EmailMultiKlassifikation.ML
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

            var trainingDataView = MlContext.Data.LoadFromTextFile<Email>(
                trainingFileName, ',', hasHeader: false);

            var dataProcessPipeline = MlContext.Transforms.Conversion.MapValueToKey(
            inputColumnName: nameof(Email.Category), outputColumnName: "Label")
             .Append(MlContext.Transforms.Text.FeaturizeText(inputColumnName:
            nameof(Email.Subject), outputColumnName: "SubjectFeaturized"))
            .Append(MlContext.Transforms.Text.FeaturizeText(inputColumnName:
            nameof(Email.Body), outputColumnName: "BodyFeaturized"))
            .Append(MlContext.Transforms.Text.FeaturizeText(inputColumnName:
            nameof(Email.Sender), outputColumnName: "SenderFeaturized"))
            .Append(MlContext.Transforms.Concatenate("Features", "SubjectFeaturized",
            "BodyFeaturized", "SenderFeaturized"))
             .AppendCacheCheckpoint(MlContext);

            var trainingPipeline = dataProcessPipeline
                .Append(MlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
                .Append(MlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            ITransformer trainedModel = trainingPipeline.Fit(trainingDataView);
            MlContext.Model.Save(trainedModel, trainingDataView.Schema, ModelPath);

            var testDataView = MlContext.Data.LoadFromTextFile<Email>(testFileName, ',', hasHeader: false);
            var testSetTransform = trainedModel.Transform(testDataView);
            var modelMetrics = MlContext.MulticlassClassification.Evaluate(data: testSetTransform);

            Console.WriteLine($"Macro Accuracy: {modelMetrics.MacroAccuracy:P2}");
            Console.WriteLine($"Log Loss: {modelMetrics.LogLoss:#.##}");
            Console.WriteLine("Per Class Log Loss:");
            for (int i = 0; i < modelMetrics.PerClassLogLoss.Count; i++)
            {
                Console.WriteLine($"Class {i}: {modelMetrics.PerClassLogLoss[i]:#.##}");
            }
        }
    }
}