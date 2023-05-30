using Microsoft.ML;
using resturant.ML.Base;
using resturant.ML.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace resturant.ML
{
    public class Predictor : BaseML
    {
        public void Predict(string inputData)
        {
            if (!File.Exists(_modelPath))
            {
                Console.WriteLine($"Failed to find model at {_modelPath}");
                return;
            }

            ITransformer mlModel;
            using (var stream = new FileStream(_modelPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                mlModel = _mlContext.Model.Load(stream, out _);
            }
            if (mlModel == null)
            {
                Console.WriteLine("Failed to load model");
                return;
            }

            var predEngine = _mlContext.Model.CreatePredictionEngine<RestaurantFeedback, RestaurantPrediction>(mlModel);
            var prediction = predEngine.Predict(new RestaurantFeedback { Text = inputData });
        
            Console.WriteLine($"Based on \"{inputData}\", the feedback is predicted to be:{Environment.NewLine}{(prediction.Prediction? "Negative" : "Positive")} at a {prediction.Probability:P0} confidence");
        }
    }
}
