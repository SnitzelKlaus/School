using Microsoft.ML;
using resturant.ML.Objects;
using resturant.ML.Base;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace resturant.ML
{
    public class Trainer : BaseML
    {
        private readonly string _trainingFileName;

        public Trainer(string trainingFileName)
        {
            _trainingFileName = trainingFileName;
        }

        public void Train()
        {
            // Check if training data exists
            if (!File.Exists(_trainingFileName))
            {
                Console.WriteLine($"Failed to find training data file {_trainingFileName}");
                return;
            }

            var _mlContext = new MLContext();

            // Load data
            var trainingDataView = _mlContext.Data.LoadFromTextFile<RestaurantFeedback>(_trainingFileName);

            // Split data into training and test set
            var dataSplit = _mlContext.Data.TrainTestSplit(trainingDataView, testFraction: 0.2);

            // Define data preparation estimator
            var dataProcessPipeline = _mlContext.Transforms.Text.FeaturizeText(
                outputColumnName: "Features",
                inputColumnName: nameof(RestaurantFeedback.Text));

            // Define trainer
            var sdcaRegressionTrainer = _mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                labelColumnName: nameof(RestaurantFeedback.Label),
                featureColumnName: "Features");

            // Build training pipeline
            var trainingPipeline = dataProcessPipeline.Append(sdcaRegressionTrainer);

            // Train the model
            ITransformer trainedModel = trainingPipeline.Fit(dataSplit.TrainSet);

            // Save the model
            _mlContext.Model.Save(trainedModel, dataSplit.TrainSet.Schema, _modelPath);

            // Evaluate the model
            var testSetTransform = trainedModel.Transform(dataSplit.TestSet);
            var modelMetrics = _mlContext.BinaryClassification.Evaluate(data: testSetTransform,
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
