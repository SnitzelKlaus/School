﻿using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using MLMedarbejderNedslidning.ML.Base;
using MLMedarbejderNedslidning.ML.Objects;
using Microsoft.ML;
using MLMedarbejderNedslidning.Common;
using Microsoft.ML.Data;

namespace MLMedarbejderNedslidning.ML
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

            var trainingDataView = MlContext.Data.LoadFromTextFile<EmploymentHistory>(trainingFileName, ',');

            var dataSplit = MlContext.Data.TrainTestSplit(trainingDataView, testFraction: 0.2);

            var dataProcessPipeline = MlContext.Transforms.CopyColumns("Label", nameof(EmploymentHistory.DurationInMonths))
                .Append(MlContext.Transforms.Conversion.ConvertType(nameof(EmploymentHistory.IsMarried), outputKind: DataKind.Single))
                .Append(MlContext.Transforms.NormalizeMeanVariance(nameof(EmploymentHistory.IsMarried)))
                .Append(MlContext.Transforms.Conversion.ConvertType(nameof(EmploymentHistory.BSDegree), outputKind: DataKind.Single))
                .Append(MlContext.Transforms.NormalizeMeanVariance(nameof(EmploymentHistory.BSDegree)))
                .Append(MlContext.Transforms.Conversion.ConvertType(nameof(EmploymentHistory.MSDegree), outputKind: DataKind.Single))
                .Append(MlContext.Transforms.NormalizeMeanVariance(nameof(EmploymentHistory.MSDegree)))
                .Append(MlContext.Transforms.NormalizeMeanVariance(nameof(EmploymentHistory.YearsExperience)))
                .Append(MlContext.Transforms.NormalizeMeanVariance(nameof(EmploymentHistory.AgeAtHire)))
                .Append(MlContext.Transforms.NormalizeMeanVariance(nameof(EmploymentHistory.HasKids)))
                .Append(MlContext.Transforms.NormalizeMeanVariance(nameof(EmploymentHistory.WithinMonthOfVesting)))
                .Append(MlContext.Transforms.NormalizeMeanVariance(nameof(EmploymentHistory.DeskDecorations)))
                .Append(MlContext.Transforms.NormalizeMeanVariance(nameof(EmploymentHistory.LongCommute)))
                .Append(MlContext.Transforms.Concatenate("Features", typeof(EmploymentHistory).ToPropertyList<EmploymentHistory>(nameof(EmploymentHistory.DurationInMonths)).ToArray()));

            var trainer = MlContext.Regression.Trainers.Sdca(labelColumnName: "Label", featureColumnName: "Features");

            var trainingPipeline = dataProcessPipeline.Append(trainer);

            ITransformer trainedModel = trainingPipeline.Fit(dataSplit.TrainSet);

            MlContext.Model.Save(trainedModel, dataSplit.TrainSet.Schema, ModelPath);

            var testSetTransform = trainedModel.Transform(dataSplit.TestSet);
            var modelMetrics = MlContext.Regression.Evaluate(testSetTransform);


            Console.WriteLine($"Loss Function: {modelMetrics.LossFunction:0.##}{Environment.NewLine}" +
             $"Mean Absolute Error: {modelMetrics.MeanAbsoluteError:#.##}{Environment.NewLine}" +
             $"Mean Squared Error: {modelMetrics.MeanSquaredError:#.##}{Environment.NewLine}" +
             $"RSquared: {modelMetrics.RSquared:0.##}{Environment.NewLine}" +
             $"Root Mean Squared Error: {modelMetrics.RootMeanSquaredError:#.##}");
        }
    }
}