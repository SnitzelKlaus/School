using Microsoft.ML;
using resturant.ML.Objects;
using resturant.ML.Base;
using Microsoft.ML.Data;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace resturant.ML
{
    public class Trainer : BaseML
    {
        //public void Train(string trainingFileName)
        //{
        //    // Check if training data exists
        //    if (!File.Exists(trainingFileName))
        //    {
        //        Console.WriteLine($"Failed to find training data file {trainingFileName}");
        //        return;
        //    }

        //    // Load data
        //    var trainingDataView = MlContext.Data.LoadFromTextFile<RestaurantFeedback>(trainingFileName);

        //    // Split data into training and test set
        //    var dataSplit = MlContext.Data.TrainTestSplit(trainingDataView, testFraction: 0.2);

        //    // Define data preparation estimator
        //    var dataProcessPipeline = MlContext.Transforms.Text.FeaturizeText(
        //        outputColumnName: "Features",
        //        inputColumnName: nameof(RestaurantFeedback.Text));

        //    // Define trainer
        //    var sdcaRegressionTrainer = MlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
        //        labelColumnName: nameof(RestaurantFeedback.Label),
        //        featureColumnName: "Features");

        //    // Build training pipeline
        //    var trainingPipeline = dataProcessPipeline.Append(sdcaRegressionTrainer);

        //    // Train the model
        //    ITransformer trainedModel = trainingPipeline.Fit(dataSplit.TrainSet);

        //    // Save the model
        //    //MlContext.Model.Save(trainedModel, dataSplit.TrainSet.Schema, ModelPath);

        //    // Evaluate the model
        //    var testSetTransform = trainedModel.Transform(dataSplit.TestSet);
        //    var modelMetrics = MlContext.BinaryClassification.Evaluate(data: testSetTransform,
        //        labelColumnName: nameof(RestaurantFeedback.Label),
        //        scoreColumnName: nameof(RestaurantPrediction.Score));


        //    Console.WriteLine($"Area Under Curve: {modelMetrics.AreaUnderRocCurve:P2}{Environment.NewLine}" +
        //    $"Area Under Precision Recall Curve: {modelMetrics.AreaUnderPrecisionRecallCurve:P2}{Environment.NewLine}" +
        //    $"Accuracy: {modelMetrics.Accuracy:P2}{Environment.NewLine}" +
        //    $"F1Score: {modelMetrics.F1Score:P2}{Environment.NewLine}" +
        //    $"Positive Recall: {modelMetrics.PositiveRecall:#.##}{Environment.NewLine}" +
        //    $"Negative Recall: {modelMetrics.NegativeRecall:#.##}{Environment.NewLine}");
        //}

        public void Train(string trainingFileName)
        {
            if (!File.Exists(trainingFileName))
            {
                Console.WriteLine($"Failed to find training data file ({trainingFileName}");

                return;
            }

            var trainingDataView = MlContext.Data.LoadFromTextFile<RestaurantFeedback>(trainingFileName);

            var dataSplit = MlContext.Data.TrainTestSplit(trainingDataView, testFraction: 0.2);

            var dataProcessPipeline = MlContext.Transforms.Text.FeaturizeText(
                outputColumnName: "Features",
                inputColumnName: nameof(RestaurantFeedback.Text));

            var sdcaRegressionTrainer = MlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                labelColumnName: nameof(RestaurantFeedback.Label),
                featureColumnName: "Features");

            var trainingPipeline = dataProcessPipeline.Append(sdcaRegressionTrainer);

            ITransformer trainedModel = trainingPipeline.Fit(dataSplit.TrainSet);


            var testSetTransform = trainedModel.Transform(dataSplit.TestSet);

            var modelMetrics = MlContext.BinaryClassification.Evaluate(
                data: testSetTransform,
                labelColumnName: nameof(RestaurantFeedback.Label),
                scoreColumnName: nameof(RestaurantPrediction.Score));

            Console.WriteLine($"Area Under Curve: {modelMetrics.AreaUnderRocCurve:P2}{Environment.NewLine}" +
                              $"Area Under Precision Recall Curve: {modelMetrics.AreaUnderPrecisionRecallCurve:P2}{Environment.NewLine}" +
                              $"Accuracy: {modelMetrics.Accuracy:P2}{Environment.NewLine}" +
                              $"F1Score: {modelMetrics.F1Score:P2}{Environment.NewLine}" +
                              $"Positive Recall: {modelMetrics.PositiveRecall:#.##}{Environment.NewLine}" +
                              $"Negative Recall: {modelMetrics.NegativeRecall:#.##}{Environment.NewLine}");

        }
    }
}
